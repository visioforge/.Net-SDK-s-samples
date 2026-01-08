# Media Player SDK X .Net - SkinnedPlayer (C#/MAUI)

Esta aplicación de muestra demuestra cómo crear un reproductor multimedia altamente personalizable utilizando **Media Player SDK X** en una aplicación **.NET MAUI**. Muestra la flexibilidad del motor de skins del SDK y sus capacidades multiplataforma.

## Características Principales

- **Reproducción Multimedia Avanzada**: Utiliza `MediaPlayerCoreX` para una reproducción robusta y de alto rendimiento de video y audio en diferentes plataformas.
- **Interfaz de Usuario Personalizable**: Integra `SkinPlayerControls` para proporcionar una interfaz de usuario lista para usar y personalizable (play, pause, buscar, volumen, etc.).
- **Motor de Skins Dinámico**: Demuestra la carga de skins desde recursos incrustados y el cambio entre ellos en tiempo de ejecución.
  - Incluye skins **Default** y **Violet** como ejemplos.
  - Utiliza `SkinManager` para gestionar y aplicar archivos de tema `vfskin`.
- **Multiplataforma**: Construido sobre .NET MAUI, soportando Windows, Android, iOS y macOS desde una única base de código.
- **Gestión de Dispositivos**: Muestra cómo inicializar dispositivos de salida de audio (donde sea aplicable).

## Comenzando

1. Abra `SkinnedPlayer.csproj` en Visual Studio.
2. Asegúrese de tener instaladas las cargas de trabajo (workloads) de MAUI necesarias.
3. Compile y ejecute el proyecto en su plataforma o emulador deseado (Windows, Android, iOS o macOS).
4. Utilice el botón **Skin** en la interfaz para alternar instantáneamente entre los temas *Default* y *Violet*.

## Frameworks Soportados

* .NET 6
* .NET 7
* .NET 8
* .NET 9
* .NET 10

## Plataformas Soportadas

* **Windows**: (Vía Windows App SDK)
* **Android**: API 23+
* **iOS**: 15.0+
* **macOS**: Catalyst 15.0+

---

[Visite la página del producto.](https://www.visioforge.com/media-player-sdk-net)
