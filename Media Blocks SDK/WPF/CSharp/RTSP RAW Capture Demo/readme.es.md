# Demo de Captura RTSP RAW

Esta aplicación de demostración WPF muestra cómo:

1. **Previsualizar transmisiones RTSP** con decodificación H264/HEVC para visualización
2. **Grabar transmisiones RTSP a archivos MP4 o MPEG-TS** sin recodificar el video (guardando H264/HEVC tal cual)
3. **Recodificación de audio opcional** a AAC para compatibilidad

## Características

### Modo de Previsualización
- Conectar a transmisiones RTSP (H264/HEVC)
- Decodificar video para previsualización en tiempo real
- Soporte de reproducción de audio
- Visualización de video en vivo en control VideoView de WPF

### Modo de Grabación
- **Guardar video sin recodificar** - Las transmisiones H264/HEVC se guardan tal cual en archivos MP4 o MPEG-TS
- **Recodificación de audio opcional** - Elija si guardar el audio tal cual o recodificarlo a AAC
- Soporta formatos de salida MP4 y MPEG-TS
- Soporte de autenticación (usuario/contraseña)

## Uso

1. **Ingrese la URL RTSP** - Introduzca su URL de transmisión RTSP (ej: `rtsp://192.168.1.100:554/stream`)
2. **Autenticación (opcional)** - Ingrese usuario y contraseña si es necesario
3. **Habilitar Audio** - Marque la casilla para capturar la transmisión de audio

### Previsualización
1. Haga clic en **"Start Preview"** para ver la transmisión
2. Haga clic en **"Stop Preview"** para detener la visualización

### Grabación
1. Elija la ruta del archivo de salida y el formato (MP4 o MPEG-TS)
2. Seleccione la casilla **"Re-encode Audio"** si es necesario:
   - **Marcado**: El audio se decodificará y recodificará a AAC
   - **Desmarcado**: La transmisión de audio se guarda tal cual sin recodificar
3. Haga clic en **"Start Record"** para comenzar la grabación
4. Haga clic en **"Stop Record"** para detener y finalizar el archivo

## Detalles Técnicos

### Pipeline de Previsualización
Utiliza `RTSPSourceBlock` con decodificación completa:
- Transmisión RTSP → Decodificador → Renderizador de Video (para visualización)
- Transmisión RTSP → Decodificador → Renderizador de Audio (para reproducción)

### Pipeline de Grabación
Utiliza `RTSPRAWSourceBlock` para grabación eficiente sin recodificar video:
- **Video**: Transmisión RTSP → Multiplexor (sin decodificar/codificar) - guarda H264/HEVC tal cual
- **Audio** (si "Re-encode Audio" está marcado): Transmisión RTSP → Decodificador → Codificador AAC → Multiplexor
- **Audio** (si "Re-encode Audio" está desmarcado): Transmisión RTSP → Multiplexor (sin decodificar/codificar)

Este enfoque proporciona:
- **Máximo rendimiento** - Sin recodificación de video intensiva en CPU
- **Calidad de video sin pérdidas** - Transmisión H264/HEVC original preservada
- **Flexibilidad** - Elija si recodificar audio según necesidades de compatibilidad

## Requisitos

- Windows 10/11
- .NET 10.0
- VisioForge Media Blocks SDK
- Fuente de transmisión RTSP (cámara IP, servidor de video, etc.)

## Demos Relacionados

- **RTSP Preview Demo** - Funcionalidad básica de previsualización RTSP
- **RTSP MultiView Demo (WinForms)** - Múltiples transmisiones RTSP con grabación
- **RTSP Restreamer** - Retransmitir RTSP a otros protocolos

## Soporte

Para más información y tutoriales en video, visite:
- https://www.visioforge.com/video-tutorials
- https://www.visioforge.com/

## Licencia

Copyright (c) 2025 VisioForge
