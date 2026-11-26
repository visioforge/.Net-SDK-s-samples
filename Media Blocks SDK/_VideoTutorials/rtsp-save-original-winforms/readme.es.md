# Media Blocks SDK .Net - rtsp-save-original-winforms (C#/WinForms)

El ejemplo del tutorial en vídeo "Save an RTSP Camera to MP4 Without Re-encoding in C#": una aplicación WinForms que graba una cámara IP en un archivo MP4 en la carpeta Vídeos, conservando el vídeo codificado propio de la cámara. Escriba la URL RTSP de la cámara, el usuario y la contraseña (ambos campos están enmascarados) y haga clic en Start. `RTSPRAWSourceBlock` entrega los flujos codificados de la cámara y `MP4SinkBlock` los escribe: el vídeo entra tal como lo envió la cámara, sin decodificador ni codificador. El sonido AAC entra tal cual; G.711 o cualquier otro códec se decodifica y se codifica a AAC, la única parte que se recodifica. El transporte TCP conserva la temporización original de los fotogramas. Mientras graba, la ventana muestra el tiempo, el tamaño del archivo y la carga de CPU de la aplicación. Stop escribe el índice MP4 y el archivo se reproduce en cualquier reproductor. La [guía](https://www.visioforge.com/help/es/docs/dotnet/mediablocks/Guides/rtsp-save-original-stream/) explica cada paso.

## Frameworks compatibles

* .Net 10

---

[Visite la página del producto.](https://www.visioforge.com/media-blocks-sdk-net)
