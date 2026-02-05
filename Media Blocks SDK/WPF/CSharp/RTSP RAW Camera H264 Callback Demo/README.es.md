# Ejemplo de Camara RTSP RAW con Callback H264

## Descripcion general

Este ejemplo demuestra una **arquitectura de dos pipelines** para recibir un flujo H.264 de una camara RTSP, interceptar los datos codificados sin procesar y luego decodificarlos/mostrarlos. La innovacion clave es el `H264PushSourceBlock` -- un MediaBlock personalizado que acepta datos H.264 sin procesar a traves del metodo `PushData()` y los introduce en un pipeline de decodificacion GStreamer separado.

Este patron le da acceso completo a los bytes H.264 codificados sin procesar entre la captura y la decodificacion, permitiendo casos de uso como:

- Grabar el flujo original en disco mientras se previsualiza simultaneamente
- Analizar o modificar unidades NAL antes de la decodificacion
- Reenviar el flujo sin procesar a traves de un transporte personalizado
- Aplicar filtrado o estadisticas a nivel de fotograma en el flujo de bits codificado

## Arquitectura

```
Pipeline 1 (Captura)                          Pipeline 2 (Reproductor)
========================                      =====================================

  RTSPRAWSourceBlock                            H264PushSourceBlock (AppSrc)
        |                                              |
        v                                              v
  BufferSinkBlock ──── OnDataFrame ────>          H264ParseBlock
                       el callback copia               |
                       los bytes H264                  v
                       sin procesar y            H264DecoderBlock (FFmpeg)
                       llama a PushData()              |
                                                       v
                                              VideoSampleGrabberBlock (depuracion)
                                                       |
                                                       v
                                              VideoRendererBlock (visualizacion WPF)
```

### Pipeline 1: Captura

Se conecta a la camara RTSP y captura datos H.264 codificados sin procesar:

- **RTSPRAWSourceBlock** -- se conecta a la URL de la camara RTSP a traves de TCP, negocia el flujo y genera unidades de acceso H.264 codificadas sin procesar (unidades NAL en formato AVC/prefijo de longitud).
- **BufferSinkBlock** -- recibe cada fotograma codificado y dispara el evento `OnDataFrameBuffer`, proporcionando el arreglo de bytes sin procesar, el tamano de los datos y la marca de tiempo de presentacion (PTS).

### Pipeline 2: Reproductor

Recibe los datos H.264 sin procesar a traves de `PushData()`, los analiza, decodifica y renderiza:

- **H264PushSourceBlock** -- envuelve un elemento `appsrc` de GStreamer. Acepta datos H.264 sin procesar desde el codigo de la aplicacion, los convierte del formato AVC al formato byte-stream Annex B y los introduce en el pipeline.
- **H264ParseBlock** -- elemento `h264parse` de GStreamer. Analiza el byte-stream, extrae los conjuntos de parametros SPS/PPS, detecta los limites de las unidades de acceso y genera H.264 analizado correctamente formateado.
- **H264DecoderBlock** -- decodificador `avdec_h264` basado en FFmpeg. Decodifica las unidades de acceso H.264 en fotogramas de video sin procesar (I420/NV12).
- **VideoSampleGrabberBlock** -- bloque de depuracion opcional que dispara un callback por cada fotograma de video decodificado, utilizado para verificar que la decodificacion funciona.
- **VideoRendererBlock** -- renderiza los fotogramas de video decodificados en el control `VideoView` de WPF.

## H264PushSourceBlock -- Como funciona

El `H264PushSourceBlock` es el puente entre los dos pipelines. Esta implementado en [H264PushSourceBlock.cs](../../../../../VisioForge.Core/MediaBlocks/Sources/H264PushSourceBlock.cs).

### Configuracion de GStreamer AppSrc

Durante `Build()`, el bloque crea y configura un elemento `appsrc` de GStreamer:

```csharp
_appsrc = new AppSrc("h264src");
_appsrc.Caps = Caps.FromString("video/x-h264, stream-format=byte-stream, alignment=nal");
_appsrc.Format = Format.Time;
_appsrc.StreamType = AppStreamType.Stream;
_appsrc["is-live"] = true;
_appsrc["do-timestamp"] = false;  // Las marcas de tiempo se establecen manualmente por buffer
_appsrc.Block = false;
```

| Propiedad | Valor | Proposito |
|-----------|-------|-----------|
| `Caps` | `video/x-h264, stream-format=byte-stream, alignment=nal` | Indica a los elementos posteriores el formato de datos |
| `Format` | `Time` | Las marcas de tiempo estan en nanosegundos (tiempo de GStreamer) |
| `StreamType` | `Stream` | Flujo de datos continuo (no buscable) |
| `is-live` | `true` | Los datos llegan en tiempo real desde una fuente en vivo |
| `do-timestamp` | `false` | La aplicacion proporciona PTS en cada buffer |
| `Block` | `false` | `PushBuffer()` retorna inmediatamente, nunca bloquea |

### Conversion de AVC a Byte-Stream

**Esta fue la correccion critica que hizo que todo funcionara.**

Las fuentes RTSP (a traves de `RTSPRAWSourceBlock` / `BufferSinkBlock`) entregan datos H.264 en **formato AVC** -- cada unidad NAL esta prefijada con una longitud big-endian de 4 bytes:

```
Formato AVC:    [00 00 00 17][23 bytes de datos NAL][00 00 1C CC][7372 bytes de datos NAL]...
                 ^^^^^^^^^^^                         ^^^^^^^^^^^
                 longitud = 23                       longitud = 7372
```

Pero las caps de GStreamer declaran `stream-format=byte-stream`, que espera **formato Annex B** -- cada unidad NAL esta prefijada con un codigo de inicio de 4 bytes:

```
Byte-stream:    [00 00 00 01][23 bytes de datos NAL][00 00 00 01][7372 bytes de datos NAL]...
                 ^^^^^^^^^^^                         ^^^^^^^^^^^
                 codigo de inicio                    codigo de inicio
```

Dado que tanto el prefijo de longitud AVC como el codigo de inicio Annex B son exactamente de 4 bytes, `PushData()` convierte in situ reemplazando cada prefijo de longitud con `00 00 00 01`:

```csharp
private static void ConvertAvcToByteStream(byte[] data, int length)
{
    int offset = 0;
    while (offset + 4 <= length)
    {
        int nalLength = (data[offset] << 24) | (data[offset + 1] << 16) |
                        (data[offset + 2] << 8) | data[offset + 3];

        // Omitir si ya es un codigo de inicio
        if (data[offset] == 0 && data[offset + 1] == 0 &&
            data[offset + 2] == 0 && data[offset + 3] == 1) { /* omitir */ }

        // Reemplazar prefijo de longitud con codigo de inicio
        data[offset]     = 0x00;
        data[offset + 1] = 0x00;
        data[offset + 2] = 0x00;
        data[offset + 3] = 0x01;

        offset += 4 + nalLength;
    }
}
```

Sin esta conversion, `h264parse` recibe datos que no coinciden con las caps declaradas y silenciosamente no produce salida -- los buffers entran al analizador pero nada sale.

### Flujo de PushData

```
Callback de BufferSink_OnDataFrame
    |
    |  1. Copiar bytes sin procesar desde memoria no administrada
    v
byte[] data  (formato AVC desde RTSP)
    |
    |  2. ConvertAvcToByteStream() -- reemplazo in situ
    v
byte[] data  (byte-stream Annex B)
    |
    |  3. Crear Gst.Buffer, establecer PTS, mapear y copiar datos
    v
Gst.Buffer con PTS
    |
    |  4. _appsrc.PushBuffer(buffer)
    v
Pipeline de GStreamer: appsrc -> h264parse -> avdec_h264 -> renderer
```

### Marcas de tiempo

Cada buffer recibe una marca de tiempo de presentacion (PTS) de la fuente RTSP:

```csharp
buffer.Pts = (ulong)(timestamp.TotalMilliseconds * Constants.MSECOND);
```

`Constants.MSECOND` convierte milisegundos a la base de tiempo en nanosegundos de GStreamer. La configuracion `do-timestamp=false` en `appsrc` asegura que se utilicen estas marcas de tiempo establecidas manualmente en lugar de las generadas automaticamente.

## Secuencia de inicio del pipeline

El orden de inicio es critico para la transmision en vivo:

```
1. Crear el pipeline del reproductor y conectar todos los bloques
2. Precargar el pipeline del reproductor (StartAsync con onlyPreload: true)
   - Transiciona el pipeline al estado PAUSED
   - Se llama a Build() en todos los bloques (appsrc se crea aqui)
   - Los pads se enlazan: appsrc.src -> h264parse.sink -> decoder.sink -> renderer.sink

3. Crear el pipeline de captura (fuente RTSP + buffer sink)
4. Iniciar el pipeline de captura (StartAsync)
   - Se establece la conexion RTSP
   - Los fotogramas H264 comienzan a llegar a traves del callback OnDataFrame
   - PushData() introduce los datos convertidos en el pipeline del reproductor en pausa
   - h264parse comienza a acumular y analizar unidades NAL

5. Esperar ~1 segundo para que los datos fluyan (h264parse necesita SPS/PPS + primer fotograma IDR)

6. Reanudar el pipeline del reproductor (ResumeAsync)
   - Transiciona de PAUSED a PLAYING
   - h264parse genera unidades de acceso analizadas
   - El decodificador comienza a producir fotogramas decodificados
   - El renderer muestra el video
```

### Por que precargar primero?

El pipeline del reproductor se precarga (PAUSED) antes de que comience la captura, para que:
- Todos los elementos de GStreamer esten creados y enlazados
- El `appsrc` este listo para aceptar datos a traves de `PushBuffer()`
- `h264parse` pueda comenzar a acumular unidades NAL SPS/PPS/IDR mientras esta en pausa
- Cuando se reanuda a PLAYING, ya hay datos en cola para decodificar

## Diagnosticos

### Sonda de pad

El bloque incluye una sonda de pad opcional para depurar el flujo de buffers:

```csharp
_h264Source.EnablePadProbe();  // Llamar DESPUES de precargar (appsrc debe existir)
```

La sonda registra el tamano del buffer y el PTS para los primeros 10 buffers y cada 100 buffers posteriores. Si `probeCount` permanece en 0, los buffers no estan saliendo de `appsrc` (indicando una incompatibilidad de caps/formato).

### GetDiagnostics()

Retorna una instantanea del estado del bloque:

```
appsrc state=Playing, peer=sink, pushCount=250, probeCount=250, caps=[video/x-h264, ...]
```

- `state` -- estado del elemento GStreamer (Paused/Playing)
- `peer` -- nombre del pad sink del elemento posterior (confirma el enlace)
- `pushCount` -- total de llamadas a `PushData()`
- `probeCount` -- buffers que realmente fluyeron a traves del pad de salida
- `caps` -- caps negociadas en el pad de salida

### Analisis de unidades NAL

El ejemplo incluye `AnalyzeH264StartCodes()` que inspecciona los primeros bytes de cada fotograma para identificar:
- Formato de datos: AVC (prefijo de longitud) vs byte-stream (codigos de inicio)
- Tipos de unidades NAL: SPS (7), PPS (8), fotograma clave IDR (5), slice no IDR (1), SEI (6), AUD (9)
- Numero de unidades NAL por buffer

## Lecciones clave de depuracion

1. **Incompatibilidad AVC vs Byte-Stream**: El problema mas comun al introducir datos H.264 en GStreamer. Las fuentes RTSP tipicamente generan formato AVC (unidades NAL con prefijo de longitud), pero `h264parse` con caps `stream-format=byte-stream` espera codigos de inicio Annex B. El sintoma es: `PushBuffer()` retorna `Ok`, el appsrc esta en estado Playing, los pads estan enlazados -- pero `h264parse` no produce salida y el decodificador nunca recibe datos.

2. **Temporizacion de la sonda de pad**: `EnablePadProbe()` debe llamarse despues de `StartAsync(onlyPreload: true)` porque el elemento appsrc se crea durante `Build()`, que se activa con la precarga. Llamarlo antes resulta en que `_appsrc` sea null y la sonda no se instale silenciosamente.

3. **Orden del estado del pipeline**: El pipeline del reproductor debe precargarse antes de que comience la captura, y reanudarse solo despues de que se hayan introducido los datos iniciales. Esto asegura que `h264parse` haya acumulado los conjuntos de parametros SPS/PPS necesarios para comenzar el analisis.

## Archivos

| Archivo | Descripcion |
|---------|-------------|
| `MainWindow.xaml` | Interfaz WPF con vista de video, entrada de URL, visualizacion de estadisticas y panel de registro |
| `MainWindow.xaml.cs` | Orquestacion de dos pipelines, callback de datos y diagnosticos |
| `H264PushSourceBlock.cs` | MediaBlock personalizado que envuelve `appsrc` de GStreamer con conversion AVC a byte-stream |
| `MediaBlockType.cs` | Entrada de enumeracion `H264PushSource` para el nuevo tipo de bloque |
