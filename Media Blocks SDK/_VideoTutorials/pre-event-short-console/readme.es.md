# Media Blocks SDK .Net - pre-event-short-console (C#/Console)

El ejemplo del vídeo corto "Record the 10 Seconds Before an Event in C#": una aplicación de consola que guarda en memoria los últimos diez segundos de una cámara IP y, al pulsar Enter, los guarda en `event.mp4` junto con cinco segundos más de vídeo en directo. Pase la URL RTSP de la cámara como primer argumento y ponga su usuario y contraseña en `RTSPSourceSettings.CreateAsync`. `RTSPSourceBlock` recibe el flujo, `H264EncoderBlock` codifica el vídeo en H.264 y `PreEventRecordingBlock` mantiene los fotogramas codificados en un búfer circular. `TriggerRecording` escribe el búfer en el archivo desde su primer fotograma clave y sigue grabando; el archivo se cierra cinco segundos después de escribir el vídeo del búfer, y la aplicación muestra su ruta y termina. Pulse Enter otra vez si la primera pulsación llegó antes del primer fotograma; si no llega ningún fotograma, cada Enter muestra el error, y Ctrl+C cierra la aplicación. El archivo solo lleva vídeo. La [guía de grabación previa al evento](https://www.visioforge.com/help/es/docs/dotnet/mediablocks/Guides/pre-event-recording/) añade el audio, la detección de movimiento como disparador y la salida MPEG-TS.

## Marcos compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/es/media-blocks-sdk-net)
