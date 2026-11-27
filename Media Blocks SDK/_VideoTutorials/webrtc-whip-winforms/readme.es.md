# Media Blocks SDK .Net - webrtc-whip-winforms (C#/WinForms)

El ejemplo del tutorial en vídeo "Stream a Camera to a Browser over WebRTC in C#": una aplicación WinForms que envía una cámara a navegadores web sin servidor de medios y, de forma opcional, la publica en un servidor de medios con WHIP. Elija la cámara y haga clic en Start. `WebRTCSinkBlock` sirve la página del espectador desde `wwwroot` y ejecuta la señalización por sí mismo; abra `http://localhost:8090/?signalling=8443` en un navegador y la cámara se reproduce allí, codificada a VP8 para cada espectador. La ventana cuenta los espectadores. Con una URL WHIP en el segundo campo (MediaMTX acepta `http://<servidor>:8889/<nombre del flujo>/whip`), `TeeBlock` envía además la cámara a través de `H264EncoderBlock` a `WHIPSinkBlock`, y el servidor de medios la sirve a cualquier número de espectadores. La [guía](https://www.visioforge.com/help/es/docs/dotnet/mediablocks/Guides/webrtc-whip/) explica cada paso.

## Frameworks compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/media-blocks-sdk-net)
