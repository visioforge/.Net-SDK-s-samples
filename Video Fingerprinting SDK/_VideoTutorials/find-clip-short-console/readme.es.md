# Video Fingerprinting SDK - find-clip-short-console (C#/Console)

El código del vídeo corto «Encontrar un clip dentro de horas de grabación con unas pocas líneas de C#»: una aplicación de consola que encuentra cada lugar en el que `clip.mp4` aparece en `movie.mp4` e imprime sus tiempos de inicio. `VFPAnalyzer.GetSearchFingerprintForVideoFileAsync` crea una huella de cada archivo y `VFPAnalyzer.SearchAsync` devuelve el inicio de cada coincidencia, por lo que un clip recodificado o escalado también se encuentra. La aplicación no imprime nada mientras lee los archivos: en el vídeo, un clip de 10 segundos en 480p se encuentra en los cinco lugares de 2 horas y 18 minutos de vídeo 720p, y la ejecución tarda unos nueve minutos. Coloque ambos archivos en la carpeta desde la que inicia la aplicación: los nombres de archivo son relativos al directorio de trabajo (con `dotnet run`, la carpeta en la que lo ejecuta; en Visual Studio, la carpeta de salida). Sin clave de licencia, el SDK funciona en modo de prueba y muestra una vez el mensaje «Unregistered version»; haga clic en OK y la búsqueda continúa. La guía escrita es [buscar fragmentos de vídeo dentro de vídeos más largos](https://www.visioforge.com/help/es/docs/vfp/dotnet/samples/how-to-search-one-video-fragment-in-another/).

## Marcos compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/video-fingerprinting-sdk)
