# VisioForge Media Blocks SDK .Net

## RTSP Preview Demo (C#/WinForms, motor multiplataforma)

El código proporcionado es un ejemplo completo de una aplicación de Windows desarrollada utilizando VisioForge Media Blocks SDK .Net, diseñada para previsualizar transmisiones de cámaras IP usando el protocolo RTSP.

Además, la aplicación demuestra cómo enumerar cámaras IP en la red local utilizando el protocolo ONVIF.

## Bloques utilizados

- [RTSPSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources#rtsp-source-block) - captura video de una fuente RTSP
- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering) - renderiza video
- [AudioRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/AudioRendering) - renderiza audio

## Modo de Baja Latencia

La fuente RTSP ahora admite el modo de baja latencia para aplicaciones de transmisión en tiempo real. **Importante:** Para una latencia verdaderamente baja, debe configurar TANTO la fuente RTSP como el renderizador de video.

La demostración incluye una casilla de verificación "Modo de baja latencia" que configura todo automáticamente de manera correcta.

### Configuración Manual

```csharp
var rtsp = await RTSPSourceSettings.CreateAsync(
    new Uri(cbIPURL.Text), 
    edIPLogin.Text, 
    edIPPassword.Text, 
    audioEnabled);

// 1. Habilitar el modo de baja latencia en la fuente RTSP (latencia=80ms, sin búfer)
rtsp.LowLatencyMode = true;

_rtspSource = new RTSPSourceBlock(rtsp);
_videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);

// 2. Deshabilitar la sincronización en el renderizador de video (¡crítico para baja latencia!)
_videoRenderer.IsSync = false;

_pipeline.Connect(_rtspSource.VideoOutput, _videoRenderer.Input);
```

### Resultados Esperados

| Configuración | Latencia | Caso de Uso |
|---------------|---------|----------|
| Predeterminado (sync=true, LowLatencyMode=false) | 1-2 segundos | Grabación, reproducción |
| Solo LowLatencyMode=true | 500-800ms | Mejorado pero aún con búfer |
| **Ambos habilitados** | **60-120ms** | **Vigilancia en tiempo real ✓** |

### Por Qué Se Necesitan Ambas Configuraciones

1. **LowLatencyMode=true** - Reduce el búfer de la fuente RTSP (latencia=80ms en lugar de 1000ms)
2. **IsSync=false** - Deshabilita la sincronización del reloj del renderizador de video (muestra fotogramas inmediatamente)

Sin ambas configuraciones, el renderizador de video aún esperará la sincronización del reloj incluso si la fuente RTSP tiene baja latencia.

## Frameworks compatibles

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9

---

[Visitar la página del producto.](https://www.visioforge.com/media-blocks-sdk-net)
