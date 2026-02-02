# Fragmento de código de texto desplazable

Este fragmento de código demuestra cómo agregar una superposición de texto desplazable a la reproducción de video usando el VisioForge Media Blocks SDK.

## Características

- Reproducción de video con `UniversalSourceBlock`
- Superposición de texto desplazable usando `OverlayManagerScrollingText`
- Texto, velocidad y apariencia configurables
- Efecto de sombra para mejor visibilidad

## Componentes clave

- `MediaBlocksPipeline` - Pipeline principal para procesamiento de medios
- `UniversalSourceBlock` - Fuente de video desde archivo
- `OverlayManagerBlock` - Gestiona superposiciones en el video
- `OverlayManagerScrollingText` - Elemento de superposición de texto desplazable
- `VideoRendererBlock` - Renderiza el video en pantalla

## Uso

1. Seleccione un archivo de video
2. Ingrese el texto a desplazar
3. Configure la velocidad de desplazamiento
4. Haga clic en Start para reproducir

## Ejemplo de código

```csharp
// Create scrolling text overlay
var scrollingText = new OverlayManagerScrollingText(
    "Breaking News: Welcome to VisioForge!",
    x: 0, y: 50,
    speed: 5,
    direction: ScrollDirection.RightToLeft)
{
    DefaultWidth = 1920,
    Infinite = true,
    Color = SKColors.Yellow
};

// Add to overlay manager
overlayManager.Video_Overlay_Add(scrollingText);

// Connect pipeline
pipeline.Connect(fileSource.VideoOutput, overlayManager.Input);
pipeline.Connect(overlayManager.Output, videoRenderer.Input);
```

## Requisitos

- .NET v4.7.2 o posterior
- Windows con soporte WPF
- VisioForge Media Blocks SDK
