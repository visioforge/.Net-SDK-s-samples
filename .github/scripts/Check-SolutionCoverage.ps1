<#
.SYNOPSIS
    Checks that every sample project is built by a CI workflow.

.DESCRIPTION
    A sample that no workflow builds can rot unnoticed until a customer opens it.
    Three checks, all static:

      1. missing-target    - a .sln or project named in .github/workflows/build-*.yml
                             does not exist.
      2. not-built         - a project is listed in a built .sln but has no
                             Release|*.Build.0 entry there (unchecked in Configuration
                             Manager), and nothing else builds it. Every workflow
                             builds with --configuration Release.
      3. orphan            - a project on disk is in no built .sln, is not built by
                             name, and is not a ProjectReference of a built project.

    Run standalone (prints a table, exit code = violation count), or with -Quiet
    to only emit violation objects (for tools/build-github-samples/Run-All.ps1).

.PARAMETER RepoRoot
    Samples repository root. Defaults to two levels above this script, or
    $env:VF_SAMPLES_ROOT when set.

.PARAMETER Quiet
    Suppress the console table and the exit code; only emit violation objects.
#>
[CmdletBinding()]
param(
    [string]$RepoRoot,
    [switch]$Quiet
)

if (-not $RepoRoot) {
    $RepoRoot = if ($env:VF_SAMPLES_ROOT) { $env:VF_SAMPLES_ROOT } else { Join-Path $PSScriptRoot '../..' }
}
$repoFull = [System.IO.Path]::GetFullPath($RepoRoot).TrimEnd('\', '/')
$sep = [System.IO.Path]::DirectorySeparatorChar
$ic = [System.StringComparer]::OrdinalIgnoreCase

$violations = [System.Collections.Generic.List[PSCustomObject]]::new()

function Get-RelPath([string]$Path) {
    if ($Path.StartsWith($repoFull, [System.StringComparison]::OrdinalIgnoreCase)) {
        return $Path.Substring($repoFull.Length).TrimStart('\', '/')
    }
    return $Path
}

function Add-Violation([string]$Check, [string]$File, [string]$Message) {
    $violations.Add([PSCustomObject]@{ Check = $Check; RelPath = (Get-RelPath $File); Message = $Message; File = $File })
}

# Paths in .sln and .csproj files use '\'; resolve them on any OS.
function Resolve-RepoPath([string]$BaseDir, [string]$Relative) {
    $rel = $Relative.Trim().Replace('\', $sep).Replace('/', $sep)
    return [System.IO.Path]::GetFullPath([System.IO.Path]::Combine($BaseDir, $rel))
}

# Every project on disk. The set is case-insensitive so a .sln written on Windows
# still matches the file on a case-sensitive file system.
$projectFiles = Get-ChildItem -LiteralPath $repoFull -Recurse -File -Include *.csproj, *.vbproj, *.fsproj -ErrorAction SilentlyContinue |
    Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' }
$onDisk = [System.Collections.Generic.HashSet[string]]::new($ic)
foreach ($p in $projectFiles) { [void]$onDisk.Add($p.FullName) }

# 1. Solutions and projects the workflows build.
$targets = [System.Collections.Generic.HashSet[string]]::new($ic)
$workflowDir = Join-Path $repoFull '.github/workflows'
foreach ($wf in Get-ChildItem -LiteralPath $workflowDir -Filter 'build-*.yml' -File) {
    foreach ($m in [regex]::Matches([System.IO.File]::ReadAllText($wf.FullName), '"([^"]+\.(?:sln|csproj|vbproj|fsproj))"')) {
        [void]$targets.Add($m.Groups[1].Value)
    }
}

$projRe = '(?m)^Project\("\{[^}]+\}"\)\s*=\s*"[^"]*"\s*,\s*"([^"]+\.(?:cs|vb|fs)proj)"\s*,\s*"(\{[^}]+\})"'

# 2. Projects those solutions build. A project a solution lists but skips is fine
#    as long as another built solution builds it (a Mac-only head in a Windows .sln).
$built = [System.Collections.Generic.HashSet[string]]::new($ic)
$unbuilt = [System.Collections.Generic.Dictionary[string, string]]::new($ic)
$slnCount = 0
foreach ($name in $targets) {
    $target = Resolve-RepoPath $repoFull $name
    if (-not (Test-Path -LiteralPath $target)) {
        Add-Violation 'missing-target' $target 'named in a workflow but not on disk'
        continue
    }
    if (-not $name.EndsWith('.sln', [System.StringComparison]::OrdinalIgnoreCase)) {
        [void]$built.Add($target)
        continue
    }
    $slnCount++
    $sln = $target
    $text = [System.IO.File]::ReadAllText($sln)
    $slnDir = Split-Path -Parent $sln
    foreach ($m in [regex]::Matches($text, $projRe)) {
        $proj = Resolve-RepoPath $slnDir $m.Groups[1].Value
        $guid = [regex]::Escape($m.Groups[2].Value)
        if ($text -match "(?mi)^\s*$guid\.Release\|[^=]*\.Build\.0\s*=") {
            [void]$built.Add($proj)
        } else {
            $unbuilt[$proj] = $name
        }
    }
}

# 3. Built projects plus everything they reference, transitively.
$covered = [System.Collections.Generic.HashSet[string]]::new($ic)
$queue = [System.Collections.Generic.Queue[string]]::new()
foreach ($p in $built) { if ($covered.Add($p)) { $queue.Enqueue($p) } }
while ($queue.Count -gt 0) {
    $proj = $queue.Dequeue()
    if (-not $onDisk.Contains($proj)) { continue }
    $dir = Split-Path -Parent $proj
    foreach ($m in [regex]::Matches([System.IO.File]::ReadAllText($proj), '(?i)<ProjectReference\b[^>]*\bInclude\s*=\s*"([^"]+)"')) {
        $ref = Resolve-RepoPath $dir $m.Groups[1].Value
        if ($covered.Add($ref)) { $queue.Enqueue($ref) }
    }
}

foreach ($p in $projectFiles) {
    if ($covered.Contains($p.FullName)) { continue }
    if ($unbuilt.ContainsKey($p.FullName)) {
        Add-Violation 'not-built' $p.FullName "listed in '$($unbuilt[$p.FullName])' without a Release Build.0 entry, and no other built solution builds it"
    } else {
        Add-Violation 'orphan' $p.FullName 'in no solution a workflow builds'
    }
}

$violations | Write-Output

if ($Quiet) { return }

Write-Host ""
Write-Host "===== Solution coverage check =====" -ForegroundColor Magenta
Write-Host "root: $repoFull" -ForegroundColor DarkGray
Write-Host "workflow solutions: $slnCount  projects on disk: $($onDisk.Count)  built or referenced: $($covered.Count)" -ForegroundColor DarkGray

if ($violations.Count -eq 0) {
    Write-Host "[OK] every project is built by a workflow" -ForegroundColor Green
} else {
    $violations | Sort-Object Check, RelPath | Format-Table Check, RelPath, Message -AutoSize -Wrap | Out-Host
    $summary = ($violations | Group-Object Check | ForEach-Object { "$($_.Name)=$($_.Count)" }) -join '  '
    Write-Host "[FAIL] $($violations.Count) violation(s): $summary" -ForegroundColor Red
}

exit $violations.Count
