# Media Blocks SDK .Net - Motion Detection Demo (WPF)

Este ejemplo del SDK muestra cómo crear una aplicación de detección de movimiento utilizando el SDK VisioForge Media Blocks .Net con OpenCV en un entorno WPF. La aplicación captura vídeo desde una cámara web y aplica detección de movimiento en tiempo real usando CVMotionCellsBlock, que divide el cuadro de vídeo en una cuadrícula de celdas y detecta el movimiento dentro de cada celda.

## Características

- Captura de vídeo en tiempo real desde cámara web
- Detección de movimiento usando OpenCV CVMotionCellsBlock
- Parámetros de detección de movimiento configurables:
  - Tamaño de cuadrícula (columnas y filas)
  - Umbral de sensibilidad
  - Umbral de celdas de movimiento
- Superposición visual que muestra las celdas con movimiento detectado
- Registro de eventos de movimiento con marcas de tiempo
- Visualización de estadísticas de movimiento en vivo
- Sin funcionalidad de audio o grabación (solo vista previa)

## Bloques utilizados

- [SystemVideoSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/SystemVideoSourceBlock/) - captura vídeo desde la cámara web
- [CVMotionCellsBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/OpenCV/CVMotionCellsBlock/) - detecta movimiento usando análisis basado en celdas de OpenCV
- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renderiza vídeo con superposición de detección de movimiento

## Paquetes NuGet requeridos

- VisioForge.CrossPlatform.Core.Windows.x64
- VisioForge.CrossPlatform.Libav.Windows.x64.UPX
- VisioForge.CrossPlatform.OpenCV.Windows.x64

## Versiones de .Net compatibles

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9

---

[Media Blocks SDK .Net product page](https://www.visioforge.com/media-blocks-sdk)
