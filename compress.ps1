# Compress files and folders into a Zip, excluding specified folders and files
# Usage: ./compress.ps1 [-Path <directory>] [-OutputName <n>] [-WhatIf]

param(
    [string]$Path = ".",
    [string]$OutputName = "",
    [switch]$WhatIf
)

# Folders to ignore (add or remove as needed)
$ignoreFolders = @(
    "venv",
    ".venv",
    "node_modules",
    "bin",
    "obj",
    "__pycache__",
    ".pytest_cache",
    ".git",
    ".vs",
    ".idea"
)

# Files to ignore (add or remove as needed)
$ignoreFiles = @(
    ".coverage",
    ".DS_Store",
    "Thumbs.db",
    "*.pyc",
    "*.pyo",
    "*.log",
    "*.tmp",
    "*.bak"
)

$resolvedPath = Resolve-Path -Path $Path
$folderName = Split-Path -Path $resolvedPath -Leaf

if ($OutputName -eq "") {
    $OutputName = $folderName
}

$zipPath = Join-Path -Path (Split-Path -Path $resolvedPath -Parent) -ChildPath "$OutputName.zip"

# Get all items, excluding ignored folders and files
$items = Get-ChildItem -Path $resolvedPath -Recurse -Force | Where-Object {
    $item = $_
    $isIgnored = $false
    
    # Check if item is in an ignored folder
    foreach ($folder in $ignoreFolders) {
        if ($item.FullName -match "(\\|/)$([regex]::Escape($folder))(\\|/|$)") {
            $isIgnored = $true
            break
        }
    }
    
    # Check if item matches an ignored file pattern
    if (-not $isIgnored -and -not $item.PSIsContainer) {
        foreach ($pattern in $ignoreFiles) {
            if ($item.Name -like $pattern) {
                $isIgnored = $true
                break
            }
        }
    }
    
    -not $isIgnored
}

if ($items.Count -eq 0) {
    Write-Host "No files to compress." -ForegroundColor Yellow
    return
}

if ($WhatIf) {
    Write-Host "Would create: $zipPath" -ForegroundColor Cyan
    Write-Host "`nWould include $($items.Count) item(s):" -ForegroundColor Cyan
    Write-Host "`nIgnored folders: $($ignoreFolders -join ', ')" -ForegroundColor Yellow
    Write-Host "Ignored files: $($ignoreFiles -join ', ')" -ForegroundColor Yellow
    return
}

# Remove existing zip if present
if (Test-Path $zipPath) {
    Remove-Item -Path $zipPath -Force
    Write-Host "Removed existing: $zipPath" -ForegroundColor Yellow
}

# Create a temporary directory for staging
$tempDir = Join-Path -Path $env:TEMP -ChildPath ([System.Guid]::NewGuid().ToString())
$tempStaging = Join-Path -Path $tempDir -ChildPath $folderName
New-Item -ItemType Directory -Path $tempStaging -Force | Out-Null

try {
    # Copy files to staging, preserving structure
    foreach ($item in $items) {
        $relativePath = $item.FullName.Substring($resolvedPath.Path.Length + 1)
        $destination = Join-Path -Path $tempStaging -ChildPath $relativePath
        
        if ($item.PSIsContainer) {
            New-Item -ItemType Directory -Path $destination -Force | Out-Null
        } else {
            $destFolder = Split-Path -Path $destination -Parent
            if (-not (Test-Path $destFolder)) {
                New-Item -ItemType Directory -Path $destFolder -Force | Out-Null
            }
            Copy-Item -Path $item.FullName -Destination $destination -Force
        }
    }
    
    # Create the zip
    Compress-Archive -Path $tempStaging -DestinationPath $zipPath -Force
    
    $zipSize = (Get-Item $zipPath).Length / 1MB
    Write-Host "Created: $zipPath ($("{0:N2}" -f $zipSize) MB)" -ForegroundColor Green
    Write-Host "Included $($items.Count) item(s)" -ForegroundColor Green
    Write-Host "Ignored folders: $($ignoreFolders -join ', ')" -ForegroundColor Yellow
    Write-Host "Ignored files: $($ignoreFiles -join ', ')" -ForegroundColor Yellow
}
finally {
    # Clean up temp directory
    if (Test-Path $tempDir) {
        Remove-Item -Path $tempDir -Recurse -Force
    }
}
