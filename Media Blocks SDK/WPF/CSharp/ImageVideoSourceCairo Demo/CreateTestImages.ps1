# PowerShell script to create test images for the ImageVideoSourceCairo Demo
# This creates simple colored rectangles with text labels

Add-Type -AssemblyName System.Drawing

# Function to create a test image
function Create-TestImage {
    param(
        [string]$filename,
        [int]$width,
        [int]$height,
        [System.Drawing.Color]$color,
        [string]$text
    )
    
    $bitmap = New-Object System.Drawing.Bitmap $width, $height
    $graphics = [System.Drawing.Graphics]::FromImage($bitmap)
    
    # Fill background
    $brush = New-Object System.Drawing.SolidBrush $color
    $graphics.FillRectangle($brush, 0, 0, $width, $height)
    
    # Add text
    $font = New-Object System.Drawing.Font "Arial", 48, [System.Drawing.FontStyle]::Bold
    $textBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::White)
    $format = New-Object System.Drawing.StringFormat
    $format.Alignment = [System.Drawing.StringAlignment]::Center
    $format.LineAlignment = [System.Drawing.StringAlignment]::Center
    $rect = New-Object System.Drawing.RectangleF 0, 0, $width, $height
    $graphics.DrawString($text, $font, $textBrush, $rect, $format)
    
    # Save
    $outputPath = Join-Path $PSScriptRoot $filename
    $bitmap.Save($outputPath)
    
    # Cleanup
    $graphics.Dispose()
    $bitmap.Dispose()
    $brush.Dispose()
    $font.Dispose()
    $textBrush.Dispose()
    
    Write-Host "Created: $outputPath"
}

# Create test images with different resolutions
Create-TestImage "image1.png" 800 600 ([System.Drawing.Color]::DarkBlue) "PNG Image`n800x600"
Create-TestImage "image2.jpg" 1920 1080 ([System.Drawing.Color]::DarkGreen) "JPEG Image`n1920x1080"
Create-TestImage "image3.gif" 640 480 ([System.Drawing.Color]::DarkRed) "GIF Image`n640x480"
Create-TestImage "image4.bmp" 1280 720 ([System.Drawing.Color]::DarkOrange) "BMP Image`n1280x720"

Write-Host "`nTest images created successfully!"
Write-Host "You can now run the ImageVideoSourceCairo Demo."