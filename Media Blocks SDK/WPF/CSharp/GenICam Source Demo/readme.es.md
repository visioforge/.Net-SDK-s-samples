# Demo de Fuente GenICam Mejorado

## Descripción General

Esta aplicación de demostración ha sido significativamente mejorada para proporcionar información completa sobre cámaras e capacidades para cámaras compatibles con GenICam. La aplicación ahora muestra propiedades detalladas de la cámara, especificaciones técnicas y configuraciones en tiempo real.

## Características

### Interfaz de Usuario Mejorada

La aplicación ahora cuenta con una interfaz moderna con pestañas que incluye tres secciones principales:

1. **Panel de Selección de Cámara**
   - Menú desplegable de cámaras con detección automática
   - Controles de Iniciar/Detener/Actualizar
   - Temporizador de grabación en tiempo real

2. **Pestañas de Información de Cámara**
   - **Información Básica**: Fabricante, modelo, número de serie, ID del dispositivo, protocolo, dirección, tamaño del sensor, estado
   - **Especificaciones Técnicas**: Formatos de píxel compatibles, capacidades de resolución, disponibilidad de características
   - **Configuración Actual**: Configuración y estado de la cámara en tiempo real

3. **Visualización de Video**
   - Área de visualización de video más grande y dedicada
   - Soporte de video en pantalla completa

### Información Completa de la Cámara

#### Información Básica
- **Nombre del Fabricante**: Fabricante de la cámara
- **Nombre del Modelo**: Modelo de la cámara
- **Número de Serie**: Identificador único del dispositivo
- **ID del Dispositivo**: Identificador del dispositivo GenICam
- **Protocolo**: Protocolo de comunicación (GigE, USB3, etc.)
- **Dirección de Red**: Dirección IP para cámaras de red
- **Tamaño del Sensor**: Resolución máxima del sensor
- **Estado de Conexión**: Estado de conexión en tiempo real

#### Especificaciones Técnicas
- **Formatos de Píxel Compatibles**: Lista completa de formatos de imagen disponibles
- **Capacidades de Resolución**: 
  - Rangos de ancho y alto con incrementos
  - Dimensiones máximas del sensor
- **Soporte de Velocidad de Fotogramas**: Rangos de velocidad de fotogramas disponibles
- **Soporte de Binning**: Capacidades de binning horizontal y vertical
- **Disponibilidad de Características**: Detección en tiempo real de características de la cámara
  - Control de exposición
  - Control de ganancia
  - Control de velocidad de fotogramas
  - Soporte de binning

#### Visualización de Configuración Actual
- **Región Actual**: ROI activo (X, Y, Ancho, Alto)
- **Formato de Píxel Activo**: Formato de imagen actualmente seleccionado
- **Tiempo de Exposición**: Configuración de exposición actual en microsegundos
- **Ganancia**: Valor de ganancia actual en dB
- **Velocidad de Fotogramas**: Velocidad de fotogramas de adquisición actual
- **Binning**: Configuración de binning actual
- **Estado de Adquisición**: Estado Ejecutándose/Detenido
- **Estado de Conexión**: Monitoreo de conexión en tiempo real

### Características Avanzadas de la Cámara

La aplicación incluye detección y pruebas sofisticadas de características de la cámara:

#### Descubrimiento Automático de Características
- Detección de características GenICam comunes
- Soporte para características de tipo string, integer, float y boolean
- Manejo elegante de errores para características no compatibles

#### Pruebas de Características
- Monitoreo de temperatura del dispositivo (si está disponible)
- Detección de versión de firmware
- Detección avanzada de modo de activación
- Estado de modo automático de exposición/ganancia

#### Información de Depuración
La aplicación proporciona salida de depuración detallada que incluye:
- Límites de capacidad de la cámara (exposición, ganancia, velocidad de fotogramas)
- Características GenICam disponibles
- Pruebas de accesibilidad de características
- Diagnósticos de errores

## Implementación Técnica

### Arquitectura Mejorada
- **Integración AravisCamera**: Creación directa de instancia de cámara para información detallada
- **Manejo Completo de Errores**: Degradación elegante cuando las características no están disponibles
- **Actualizaciones en Tiempo Real**: Actualización automática de configuraciones y estado de la cámara
- **Gestión de Memoria**: Disposición adecuada de recursos de la cámara

### Componentes Clave

1. **Gestión de Información de Cámara**
   ```csharp
   private GenICamSourceInfo _currentCameraInfo;
   private AravisCamera _currentCamera;
   ```

2. **Detección Avanzada de Características**
   ```csharp
   ShowAdvancedCameraFeatures();
   TestCameraFeatures();
   ```

3. **Actualizaciones de Estado en Tiempo Real**
   ```csharp
   UpdateCurrentCameraSettings();
   UpdateConnectionStatus();
   ```

### Características de Cámara Compatibles

La aplicación puede detectar y mostrar información para cámaras que soportan:
- **Estándar GenICam**: Compatibilidad completa con GenICam 3.0+
- **GigE Vision**: Cámaras basadas en red
- **USB3 Vision**: Cámaras USB 3.0
- **Camera Link**: Cámaras industriales (mediante capas de transporte apropiadas)

## Instrucciones de Uso

### Operación Básica
1. **Iniciar Aplicación**: Iniciar la demostración mejorada
2. **Detección de Cámara**: Las cámaras se detectan automáticamente y se listan
3. **Seleccionar Cámara**: Elegir cámara del menú desplegable
4. **Ver Información**: Explorar las tres pestañas de información
5. **Iniciar Transmisión**: Hacer clic en "Iniciar" para comenzar la captura de video
6. **Monitorear Estado**: Ver configuraciones y estado en tiempo real

### Características Avanzadas
- **Actualizar Cámaras**: Usar el botón "Actualizar" para volver a escanear cámaras
- **Actualizar Configuraciones**: Hacer clic en "Actualizar Configuración Actual" para refrescar valores en tiempo real
- **Salida de Depuración**: Monitorear la ventana de Salida de Visual Studio para información detallada

## Requisitos

### Dependencias de Software
- VisioForge Media Blocks SDK .Net
- Biblioteca Aravis (Windows: VisioForge.CrossPlatform.GenICam.Windows.x64)
- .NET 8.0 o posterior
- WPF Framework

### Soporte de Hardware
- Cámaras compatibles con GenICam
- Cámaras GigE Vision
- Cámaras USB3 Vision
- Adaptadores de red compatibles (para cámaras GigE)

## Notas de Desarrollo

### Estructura del Código
- **MainWindow.xaml**: Interfaz de usuario mejorada con interfaz de pestañas
- **MainWindow.xaml.cs**: Lógica completa de información de cámara
- **Métodos de Información de Cámara**: Región dedicada para el manejo de datos de cámara
- **Métodos de Información Avanzada de Cámara**: Pruebas de características y diagnósticos

### Manejo de Errores
La aplicación incluye manejo robusto de errores:
- Degradación elegante cuando las cámaras no están disponibles
- Mensajes de error detallados para solución de problemas
- Disposición segura de recursos de cámara
- Manejo de tiempo de espera de red para cámaras GigE

### Consideraciones de Rendimiento
- Enumeración eficiente de cámaras
- Carga perezosa de información detallada de cámara
- Actualizaciones optimizadas de interfaz de usuario
- Gestión de recursos consciente de la memoria

## Solución de Problemas

### Problemas Comunes
1. **No se Encontraron Cámaras**: Asegúrese de que los controladores de cámara estén instalados y las cámaras estén conectadas
2. **Cámaras de Red**: Verificar configuración de red y configuraciones de firewall
3. **Problemas de Permisos**: Ejecutar como administrador si es necesario para acceso a cámara
4. **Característica No Disponible**: Algunas cámaras pueden no soportar todas las características GenICam

### Información de Depuración
Habilitar salida de depuración para ver:
- Proceso de detección de cámara
- Pruebas de disponibilidad de características
- Detalles de errores y trazas de pila
- Métricas de rendimiento

## Mejoras Futuras

Posibles mejoras futuras:
- Interfaz de usuario de configuración de cámara
- Captura y guardado de imágenes
- Soporte para múltiples cámaras
- Visualización de histograma en tiempo real
- Configuración avanzada de activación
- Herramientas de calibración de cámara

## Licencia

Esta demostración mejorada mantiene la misma licencia que las aplicaciones de demostración originales del VisioForge Media Blocks SDK.

## Bloques utilizados

- [VideoRendererBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/VideoRendering/) - renderiza video
- [GenICamSourceBlock](https://www.visioforge.com/help/docs/dotnet/mediablocks/Sources/GenICamSourceBlock/) - captura video desde fuente GenICam

## Frameworks compatibles

- .Net 4.7.2
- .Net Core 3.1
- .Net 5
- .Net 6
- .Net 7
- .Net 8
- .Net 9

---

[Página del producto Media Blocks SDK .Net](https://www.visioforge.com/media-blocks-sdk)