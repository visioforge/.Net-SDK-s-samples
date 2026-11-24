# Media Blocks SDK .Net - udp-mpegts-short-console (C#/Console)

El ejemplo del vídeo corto "UDP Video Streaming in a Few Lines of C#": una aplicación de consola que envía un archivo de vídeo como flujo MPEG-TS por UDP a `udp://127.0.0.1:5004` hasta que se pulsa Enter. El vídeo se codifica en H.264, y el audio en AAC si el archivo tiene pista de audio. Pase como primer argumento la ruta de un archivo con pista de vídeo y abra el flujo con `ffplay udp://127.0.0.1:5004` o `vlc udp://@:5004`. El archivo se envía una vez, en tiempo real, desde que se inicia la aplicación: un receptor que se inicia más tarde lo recibe a partir de ese punto. Para enviar el flujo a otro equipo, ponga en `Host` la dirección IP de ese equipo o una dirección multicast. La [guía de streaming UDP](https://www.visioforge.com/help/es/docs/dotnet/general/network-streaming/udp/) explica el multicast, varios receptores y los ajustes del sink.

## Marcos compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/es/media-blocks-sdk-net)
