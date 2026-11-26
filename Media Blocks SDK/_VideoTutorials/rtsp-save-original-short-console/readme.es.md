# Media Blocks SDK .Net - rtsp-save-original-short-console (C#/Console)

El ejemplo del vídeo corto "Save an RTSP Camera to MP4 Without Re-encoding in C#": una aplicación de consola que escribe en `camera.mp4` el vídeo H.264 o H.265 y el sonido AAC propios de una cámara IP, sin decodificador ni codificador. Pase la URL RTSP de la cámara como primer argumento y ponga su usuario y contraseña en `RTSPRAWSourceSettings.CreateAsync`. `RTSPRAWSourceBlock` entrega los flujos codificados de la cámara, el transporte TCP conserva la temporización original de los fotogramas y `MP4SinkBlock` recibe el vídeo y el sonido en dos entradas. Pulse Enter para detener: `StopAsync` escribe el índice MP4 y el archivo se reproduce en cualquier reproductor. El sonido entra solo cuando es AAC: una cámara sin micrófono, o una que envía G.711 u otro códec, da un archivo solo de vídeo. El [ejemplo WinForms](../rtsp-save-original-winforms) codifica ese sonido a AAC, y la [guía](https://www.visioforge.com/help/es/docs/dotnet/mediablocks/Guides/rtsp-save-original-stream/) explica ambos casos.

## Frameworks compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/media-blocks-sdk-net)
