#!/bin/bash
# Usage: embed-extension.sh <path-to-extension.appex> <output-path-of-main-app> <codesign-identity> <entitlements-plist>
# Copies the broadcast extension into the main app's PlugIns directory, then codesigns both
# the extension and the main .app so iOS installd accepts the bundle.
set -e

APPEX="$1"
OUTDIR="$2"
IDENTITY="$3"
EXT_ENTITLEMENTS="$4"

if [ ! -d "$APPEX" ]; then
    echo "[embed-extension] extension not built: $APPEX"
    exit 0
fi

APP=$(find "$OUTDIR" -name "ScreenCapture.app" -type d | head -1)
if [ -z "$APP" ]; then
    echo "[embed-extension] main .app not found under $OUTDIR"
    exit 0
fi

rm -rf "$APP/PlugIns/ScreenCaptureExtension.appex"
mkdir -p "$APP/PlugIns"
cp -R "$APPEX" "$APP/PlugIns/"

EMBEDDED="$APP/PlugIns/ScreenCaptureExtension.appex"
echo "[embed-extension] copied into $APP/PlugIns/"

# Codesign the embedded extension with its entitlements + the same identity used for main app.
# .NET iOS skipped this during the extension's own build (no app container to embed into at
# that point), so we do it here.
# "iPhone Developer" is a .NET iOS build-tool magic string; the raw codesign CLI doesn't
# understand it. If we get that, look up the first "Apple Development" SHA1 from the keychain.
if [ "$IDENTITY" = "iPhone Developer" ] || [ -z "$IDENTITY" ]; then
    RESOLVED=$(security find-identity -v -p codesigning | awk '/"Apple Development:/{print $2; exit}')
    if [ -n "$RESOLVED" ]; then
        echo "[embed-extension] resolved 'iPhone Developer' -> $RESOLVED"
        IDENTITY="$RESOLVED"
    fi
fi

if [ -n "$IDENTITY" ] && [ -f "$EXT_ENTITLEMENTS" ]; then
    echo "[embed-extension] signing $EMBEDDED with identity '$IDENTITY' and entitlements $EXT_ENTITLEMENTS"
    # Sign nested frameworks/dylibs first (deep) then the bundle.
    codesign --force --sign "$IDENTITY" --preserve-metadata=identifier,entitlements --timestamp=none --deep "$EMBEDDED" 2>/dev/null || true
    codesign --force --sign "$IDENTITY" --entitlements "$EXT_ENTITLEMENTS" --timestamp=none --generate-entitlement-der "$EMBEDDED"

    # Re-sign the main .app so its code directory hashes cover the new PlugIns entry.
    # Preserve main app's original entitlements by not passing --entitlements.
    codesign --force --sign "$IDENTITY" --preserve-metadata=entitlements,identifier --timestamp=none --generate-entitlement-der "$APP"

    codesign -dv "$EMBEDDED" 2>&1 | head -3 || true
    codesign -dv "$APP" 2>&1 | head -3 || true
else
    echo "[embed-extension] skipping codesign (identity or entitlements not provided)"
fi
