# Video Capture SDK .Net - audio-capture-short-console (C#/Console)

El código del vídeo corto «Grabar un micrófono en MP3 con unas pocas líneas de C#»: una aplicación de consola que graba el micrófono predeterminado en `mic.mp3` hasta que se pulsa Intro. Para grabar otra entrada, pase como primer argumento una parte de su nombre que no tenga ningún otro dispositivo, exactamente como la muestra la configuración de sonido de Windows (cuentan las mayúsculas y los acentos). Cada dispositivo de salida aparece también como entrada loopback con su propio nombre, de modo que pasar el nombre de una salida, como `Altavoces`, graba lo que reproduce esa salida. Un dispositivo puede aparecer en más de una API de audio, y se usa la primera entrada cuyo nombre contiene el texto, sea cual sea su API. Si no hay entrada predeterminada, o ningún nombre coincide, la aplicación se detiene con una excepción. La grabación no se reproduce por los altavoces (`Audio_Play = false`). Detenga la grabación con Intro: cerrar la ventana o pulsar Ctrl+C termina la aplicación sin `StopAsync`, y el archivo MP3 queda sin terminar. Más escenarios de captura de audio, entre ellos el sonido del sistema, están en la [guía de captura de audio](https://www.visioforge.com/help/es/docs/dotnet/videocapture/audio-capture/).

## Marcos compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/video-capture-sdk-net)
