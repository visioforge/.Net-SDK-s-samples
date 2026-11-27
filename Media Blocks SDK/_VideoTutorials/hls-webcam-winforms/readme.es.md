# Media Blocks SDK .Net - hls-webcam-winforms (C#/WinForms)

El ejemplo del tutorial en vídeo "Stream a Webcam over HLS in C#": una aplicación WinForms que transmite una cámara y un micrófono por HLS y sirve el flujo por sí misma, sin instalar un servidor web. Elija la cámara y el micrófono y haga clic en Start. `TeeBlock` divide la cámara entre la vista previa de la ventana y `H264EncoderBlock`; el micrófono pasa por `AACEncoderBlock`; `HLSSinkBlock` escribe segmentos MPEG-TS de unos 2 segundos y la lista de reproducción en la carpeta `hls`, y su servidor HTTP integrado sirve esa carpeta con la página del espectador `hls/index.htm` (hls.js). Abra `http://localhost:8088/` en un navegador y la cámara se reproduce allí. La [guía](https://www.visioforge.com/help/es/docs/dotnet/general/network-streaming/hls-streaming/) explica cada ajuste.

## Frameworks compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/media-blocks-sdk-net)