# Video Capture SDK .Net - Snapshot Sample (VB.NET/WinForms)

Esta aplicación demuestra cómo capturar instantáneas de una cámara usando el Video Capture SDK .Net.

## Características

- Selección y configuración de cámara
- Vista previa de video con resolución configurable (predeterminado: 1280x720 a 25 fps)
- Captura de instantáneas del video en vivo
- Visualización de instantáneas capturadas en un PictureBox

## Implementación clave

El ejemplo usa `VideoCaptureCore` con las siguientes configuraciones principales:

- `Video_Still_Frames_Grabber_Enabled = True` - Habilita la captura de fotogramas
- `Frame_GetCurrent()` - Captura el fotograma actual como Bitmap
- El audio está deshabilitado para este ejemplo de solo vista previa

## Frameworks soportados

* .Net 4.7.2
* .Net Core 3.1
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9

---

[Visit the product page.](https://www.visioforge.com/video-capture-sdk-net)
