# Demo de Reproductor con Fuente Personalizada

Esta aplicación de demostración WPF muestra cómo usar Media Player SDK .NET con un filtro de fuente DirectShow personalizado usando `MediaPlayerSourceMode.CustomSource`.

## Características

- Integración de filtro de fuente DirectShow personalizado mediante CLSID
- Reproducción de video con filtros de fuente personalizados
- Renderizado de audio con selección de dispositivo
- Control de volumen
- Búsqueda en línea de tiempo
- Controles de Reproducir, Pausar, Reanudar, Detener

## Uso

1. Ingrese la ruta al archivo de medios que desea reproducir
2. Ingrese el CLSID de su filtro de fuente DirectShow personalizado en el formato `{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}`
3. Seleccione el dispositivo de salida de audio
4. Haga clic en "Start" para comenzar la reproducción

## Requisitos del Filtro de Fuente Personalizado

El filtro de fuente DirectShow personalizado debe:

- Estar registrado en el sistema
- Implementar la interfaz `IFileSourceFilter`
- Soportar el formato de medios del archivo que intenta reproducir

## CLSID de Ejemplo

Para propósitos de prueba, puede usar el CLSID del filtro de muestra: `{B98D13E7-55DB-4385-A33D-09FD1BA26338}`

## Puntos Clave del Código

La configuración principal para el modo de fuente personalizada:

```csharp
// Configurar modo de fuente personalizada
_player.Source_Mode = MediaPlayerSourceMode.CustomSource;
_player.Source_Custom_CLSID = "{B98D13E7-55DB-4385-A33D-09FD1BA26338}";

// Agregar archivo a la lista de reproducción
_player.Playlist_Add(filename);

// Iniciar reproducción
await _player.PlayAsync();
```

## Frameworks Soportados

- .NET Framework 4.7.2
- .NET 5.0
- .NET 6.0
- .NET 7.0
- .NET 8.0
- .NET 9.0
- .NET 10.0

## Requisitos

- Windows 10 o posterior
- Filtro de fuente DirectShow personalizado registrado en el sistema

---

[Visite la página del producto.](https://www.visioforge.com/media-player-sdk-net)
