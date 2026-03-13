# Media Blocks SDK .Net - HLS Streamer (C#/Console)

Esta aplicación genera video y audio sintético y lo transmite utilizando el protocolo HLS (HTTP Live Streaming). La demostración incluye un servidor HTTP integrado para facilitar las pruebas.

## Características

* Genera video sintético (1280x720 @ 25fps)
* Genera audio sintético (estéreo, 44.1kHz)
* Codifica usando H.264 y AAC
* Crea segmentos HLS con lista de reproducción .m3u8
* Incluye servidor HTTP integrado en el puerto 8088
* Gestiona automáticamente los archivos de segmentos

## Bloques de medios utilizados

* `VirtualVideoSourceBlock` - Generación de video sintético
* `VirtualAudioSourceBlock` - Generación de audio sintético
* `H264EncoderBlock` - Codificación de video H.264/AVC
* `AACEncoderBlock` - Codificación de audio AAC
* `HLSSinkBlock` - Salida de streaming HLS

## Cómo usar

1. Ejecute la aplicación
2. Espere unos segundos para que se cree el primer segmento HLS
3. Abra http://localhost:8088/index.htm en su navegador web
4. El video debería comenzar a reproducirse automáticamente
5. Presione Enter en la consola para detener la transmisión

## Configuración

Puede modificar la configuración de HLS en `Program.cs`:

* `TargetDuration` - Duración de cada segmento (predeterminado: 5 segundos)
* `MaxFiles` - Número máximo de archivos de segmento a mantener (predeterminado: 10)
* `PlaylistLength` - Número de segmentos en la lista de reproducción (predeterminado: 5)
* `Custom_HTTP_Server_Port` - Puerto del servidor HTTP (predeterminado: 8088)

## Frameworks soportados

* .Net 4.7.2
* .Net Core 3.1
* .Net 5
* .Net 6
* .Net 7
* .Net 8
* .Net 9
* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/media-blocks-sdk)
