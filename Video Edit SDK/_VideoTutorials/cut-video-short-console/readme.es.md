# Video Edit SDK .Net - cut-video-short-console (C#/Console)

El código del vídeo corto «Cortar un vídeo sin recodificar con unas pocas líneas de C#»: una aplicación de consola que copia de 1:00 a 1:30 de `movie.mp4` en `cut.mp4` con `VideoEditCore.FastEdit_CutFileAsync`. Las pistas se copian sin recodificar, así que el corte conserva la calidad del original: 30 segundos de una película H.264 720p tardaron 0,6 s, incluido el inicio de la aplicación. Si el corte falla, el motivo se muestra antes de «Failed». El corte empieza en el fotograma clave en la posición inicial o antes de ella. Coloque un vídeo llamado `movie.mp4` en la carpeta desde la que inicia la aplicación: ambos nombres de archivo son relativos al directorio de trabajo (con `dotnet run`, la carpeta en la que lo ejecuta; en Visual Studio, la carpeta de salida). El paquete `VisioForge.DotNet.Core.Redist.FFMPEG.x64` aporta el ejecutable de FFmpeg que realiza el corte. La guía escrita es [cortar un vídeo sin recodificar](https://www.visioforge.com/help/es/docs/dotnet/videoedit/code-samples/cut-video-without-reencoding/).

## Marcos compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/video-edit-sdk-net)
