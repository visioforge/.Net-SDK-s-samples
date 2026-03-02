# Demo de Grabacion Pre-Evento - VideoCaptureCoreX - WPF

Esta demo muestra la funcionalidad de grabacion pre-evento (buffer circular) utilizando VideoCaptureCoreX, permitiendo capturar video/audio que ocurrio ANTES de un evento desencadenante.

## Caracteristicas

- Almacenamiento continuo en buffer de video/audio codificado en memoria
- Duracion pre-evento configurable (5-60 segundos)
- Duracion post-evento configurable (5-30 segundos)
- Activacion de grabacion bajo demanda
- Capacidad de extension del temporizador post-evento
- API simple de alto nivel (VideoCaptureCoreX)

## Como Funciona

VideoCaptureCoreX almacena continuamente en buffer los fotogramas codificados de video H.264 y audio AAC utilizando `PreEventRecordingOutput`. Cuando se activa una grabacion:

1. El buffer se vacia comenzando desde el fotograma clave mas cercano
2. Los fotogramas almacenados (pre-evento) se escriben en un archivo MP4
3. Los fotogramas en vivo continuan grabandose durante la duracion post-evento
4. La grabacion se detiene automaticamente despues del periodo post-evento
5. El sistema vuelve al modo de almacenamiento en buffer

## Uso

1. **Seleccionar Dispositivos:** Elija el dispositivo de video y el formato de los menus desplegables
2. **Audio Opcional:** Marque "Record audio" y seleccione un dispositivo de audio
3. **Configurar Duraciones:**
   - **Pre-evento**: Cuantos segundos capturar ANTES del activador (5-60s)
   - **Post-evento**: Cuantos segundos capturar DESPUES del activador (5-30s)
4. **Establecer Carpeta de Salida:** Especifique donde se deben guardar los archivos grabados
5. **Iniciar:** Haga clic en "Start" para comenzar el almacenamiento en buffer
6. **Activar Grabacion:** Cuando ocurra un evento, haga clic en "Trigger Recording"
   - Archivo de salida: `event_YYYYMMDD_HHmmss.mp4`
7. **Extender (Opcional):** Haga clic en "Extend" para reiniciar el temporizador post-evento
8. **Detener Grabacion (Opcional):** Detenga manualmente antes de que termine la duracion post-evento

## Casos de Uso

- **Camaras de seguridad**: Capturar metraje antes de la deteccion de movimiento/sonido
- **Aplicaciones de dashcam**: Guardar video antes y despues de un incidente
- **Repeticion deportiva**: Repeticion instantanea con pre-buffer
- **Experimentos cientificos**: Capturar eventos impredecibles
- **Control de calidad**: Grabar defectos de fabricacion con contexto

## Detalles Tecnicos

- **API**: API de alto nivel basada en salidas de VideoCaptureCoreX
- **Framework de UI**: WPF (Windows Presentation Foundation)
- **Tipo de Buffer:** Fotogramas codificados (H.264 + AAC) en memoria
- **Formato de Contenedor:** MP4 (via mp4mux)
- **Indice de Salida Pre-Evento:** 0 (primera salida)
- **Seguimiento de Estado:** `GetPreEventRecordingState(0)` devuelve el estado actual
- **Eventos:** `OnPreEventRecordingStarted`, `OnPreEventRecordingStopped`

## Notas de Implementacion

Esta demo utiliza **VideoCaptureCoreX** para una integracion simplificada:

```csharp
VideoCapture1 = new VideoCaptureCoreX(VideoView1 as IVideoView);
VideoCapture1.Video_Source = videoSourceSettings;
VideoCapture1.Audio_Source = audioSourceSettings;
VideoCapture1.Audio_Record = true;

var preEventOutput = new PreEventRecordingOutput(
    settings: new PreEventRecordingSettings
    {
        PreEventDuration = TimeSpan.FromSeconds(30),
        PostEventDuration = TimeSpan.FromSeconds(10)
    },
    videoEnc: new OpenH264EncoderSettings(),
    audioEnc: new VOAACEncoderSettings()
);

VideoCapture1.Outputs_Add(preEventOutput);

// Despues: activar grabacion
VideoCapture1.TriggerPreEventRecording(0, filename);
```

El `PreEventRecordingOutput` se conecta automaticamente al pipeline de VideoCaptureCoreX y maneja todo el almacenamiento en buffer, codificacion y escritura de archivos internamente.

Para control manual del pipeline, consulte las demos del **Media Blocks SDK** que utilizan `PreEventRecordingBlock` directamente.

## Requisitos

- Windows 10/11 x64
- .NET 10.0+
- SDK VisioForge VideoCaptureCoreX
- Dispositivo de captura de video (webcam, tarjeta de captura, etc.)
- Dispositivo de captura de audio (opcional)

## Demos Relacionadas

- **Media Blocks SDK WPF** - Control manual del pipeline con `PreEventRecordingBlock`
- **VideoCaptureCoreX Avalonia** - Version multiplataforma (Windows, macOS, Linux)
