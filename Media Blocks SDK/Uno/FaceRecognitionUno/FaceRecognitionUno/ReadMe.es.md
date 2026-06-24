# Face Recognition Uno - Media Blocks SDK

Este ejemplo demuestra el reconocimiento facial en tiempo real desde una cámara en vivo usando VisioForge Media Blocks SDK con Uno Platform. La tubería es `cámara -> FaceRecognitionBlock -> renderizador de video`; los rostros detectados se enmarcan y etiquetan con la identidad coincidente en la vista previa.

## Características

- Vista previa de cámara en vivo con superposición de detección y reconocimiento facial
- Registro de personas a partir de una foto de la galería (nombre + imagen), persistente entre ejecuciones
- Guardar / cargar la galería de rostros (`.vfg`) con un archivo lateral de familia de embeddings
- Modelo de embedding conmutable: SFace (128-D) o AuraFace (512-D, ArcFace)
- Modelos (detector YuNet + embedder) descargados bajo demanda
- Enfocado en Android; también compila para Windows

## Cómo usar

1. Toque **DOWNLOAD MODELS** (solo la primera vez).
2. Escriba un nombre, toque **ENROLL PHOTO** y elija una foto frontal y nítida.
3. Toque **START**: apunte la cámara a la persona registrada; la superposición muestra el nombre y la puntuación de coincidencia.
4. Opcionalmente, **SAVE GALLERY** para reutilizar las identidades registradas la próxima vez.

## Página del Producto

[VisioForge Media Blocks SDK .NET](https://www.visioforge.com/media-blocks-sdk-net)

## Requisitos

- .NET 10.0
- Uno Platform 6.4+
- Android API 24+ (requerido por ONNX Runtime)
- Licencia VisioForge SDK para uso en producción
