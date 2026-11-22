# Media Blocks SDK .Net - rtsp-server-short-console (C#/Console)

El ejemplo del vídeo corto "Stream an MP4 File as an RTSP Server in a Few Lines of C#": una aplicación de consola que sirve un archivo de vídeo como flujo RTSP en `rtsp://127.0.0.1:8554/live` hasta que se pulsa Enter. El servidor codifica el vídeo en H.264, y el audio en AAC si el archivo tiene pista de audio. Pase la ruta del archivo como primer argumento y abra la URL en VLC o `ffplay`. El archivo se reproduce una vez, en tiempo real, desde que se inicia la aplicación: un cliente que se conecta más tarde lo recibe a partir de ese punto. El servidor acepta clientes en todas las interfaces de red, así que otros equipos lo alcanzan en la dirección IP de este equipo. La [guía del bloque RTSP Server](https://www.visioforge.com/help/es/docs/dotnet/mediablocks/RTSPServer/) explica los ajustes, la autenticación y una cámara como fuente.

## Marcos compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/es/media-blocks-sdk-net)
