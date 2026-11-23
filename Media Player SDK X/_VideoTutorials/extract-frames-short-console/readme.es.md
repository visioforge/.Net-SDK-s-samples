# Media Player SDK .Net - extract-frames-short-console (C#/Console)

El código del vídeo corto «Extraer fotogramas de un vídeo con unas pocas líneas de C#»: una aplicación de consola que guarda un fotograma por minuto de `movie.mp4` como archivos PNG, de `frame-30.png` a `frame-510.png`, con `MediaInfoReaderX.GetFileSnapshotSKBitmap`. Coloque un vídeo llamado `movie.mp4` en la carpeta desde la que inicia la aplicación: ambos nombres de archivo son relativos al directorio de trabajo (con `dotnet run`, la carpeta en la que lo ejecuta; en Visual Studio, la carpeta de salida). Una posición posterior al final del archivo, o un archivo que no se puede decodificar, no devuelve ningún fotograma, y ese PNG se omite. La guía escrita, con salida a `System.Drawing.Bitmap` y a RGB sin procesar, es [extraer fotogramas de vídeo en .NET](https://www.visioforge.com/help/es/docs/dotnet/mediaplayer/code-samples/get-frame-from-video-file/).

## Marcos compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/media-player-sdk-net)
