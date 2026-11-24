# Media Blocks SDK .Net - hls-webcam-short-console (C#/Console)

El ejemplo del vídeo corto "Live HLS Streaming From a Webcam in a Few Lines of C#": una aplicación de consola que transmite en directo por HLS la primera cámara web hasta que se pulsa Enter. `SystemVideoSourceBlock` captura la cámara, `H264EncoderBlock` codifica el vídeo en H.264 y `HLSSinkBlock` lo divide en segmentos MPEG-TS y escribe la lista de reproducción `playlist.m3u8` en la subcarpeta `hls` de la carpeta de la aplicación, después de borrar lo que dejó allí una ejecución anterior. El servidor HTTP integrado del sink sirve solo esa subcarpeta, en el puerto 8088: abra `http://localhost:8088/` en un navegador, y `index.htm`, copiado en `hls` al compilar, reproduce la lista con hls.js. El primer segmento está listo unos cinco segundos después del inicio; recargue la página si la abrió antes. El flujo solo lleva vídeo. La [guía de streaming HLS](https://www.visioforge.com/help/es/docs/dotnet/general/network-streaming/hls-streaming/) añade el audio y los ajustes del sink.

## Marcos compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/es/media-blocks-sdk-net)
