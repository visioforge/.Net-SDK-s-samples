# Media Blocks SDK .Net - Face Recognition Demo (C#/WPF)

Recognizes people by face from a webcam, video file, or RTSP/IP-camera stream using the
`FaceRecognitionBlock`. The block runs a two-stage pipeline: a YuNet face detector locates faces and
their five landmarks, each face is aligned to a canonical 112x112 crop and turned into an embedding
(SFace / ArcFace), and the embedding is matched 1:N against an enrolled gallery by cosine similarity.
Recognition runs on a background thread, so live video never stalls.

## Run

1. On the **Models** tab, press **Download** to fetch the ONNX models (cached under
   `%USERPROFILE%/VisioForge/models`); the Download button is hidden once a model is cached. Or point
   the boxes at your own models:
   - `face_detection_yunet_2023mar.onnx` — YuNet face detector (MIT).
   - Embedding (pick the **Embedding model family**): **SFace** (128-D, Apache-2.0) or **AuraFace**
     (512-D, ArcFace family, Apache-2.0). Both are downloadable; the family selector switches which one
     the Download button fetches.
2. On the **Enrollment** tab, type a person name, press **Pick photo and enroll...**, and select a
   clear, front-facing photo of that person. Repeat for each identity (you can enroll several photos
   per name). Save the gallery to a `.vfg` file and load it back on the next run. Switching the
   embedding model family re-embeds the enrolled photos automatically, so the gallery always matches
   the running model (embeddings from different models are not comparable).
3. On the **Settings** tab, tune the detection confidence, the recognition threshold (cosine
   similarity), and the frame-skip rate.
4. Pick a source on the **Source** tab, press **Start**, and watch recognized names drawn over the
   video and listed on the **Faces** tab. Unrecognized faces are labeled `Unknown`.

## Models

Both default models come from the [OpenCV Zoo](https://github.com/opencv/opencv_zoo) and are designed
to work together (SFace aligns with YuNet's five landmarks). The **Download** buttons fetch them from
the VisioForge samples release; you can also download them directly from the sources below and point
the **Models** tab at the files.

| Stage | File | License | Source |
|-------|------|---------|--------|
| Detector | `face_detection_yunet_2023mar.onnx` | MIT | [OpenCV Zoo — face_detection_yunet](https://github.com/opencv/opencv_zoo/tree/main/models/face_detection_yunet) · [Hugging Face mirror](https://huggingface.co/opencv/face_detection_yunet) |
| Embedding (SFace) | `face_recognition_sface_2021dec.onnx` | Apache-2.0 (128-D) | [OpenCV Zoo — face_recognition_sface](https://github.com/opencv/opencv_zoo/tree/main/models/face_recognition_sface) · [Hugging Face mirror](https://huggingface.co/opencv/face_recognition_sface) |
| Embedding (AuraFace) | `face_recognition_auraface_v1.onnx` | Apache-2.0 (512-D) | [fal/AuraFace-v1](https://huggingface.co/fal/AuraFace-v1) (ResNet100, ArcFace family) |

Both embedders are commercially licensed (Apache-2.0) and selectable via the **Embedding model family**
combo. AuraFace (512-D) is higher-accuracy than SFace (128-D) at a larger size (~261 MB vs ~37 MB). The
embedding length is read from the model, so any compatible ArcFace-family recognizer also works via
**Browse**. Keep one gallery per embedding model — embeddings from different models are not comparable.

> A model's license is set by its origin (training code + published weights), not by the ONNX format.
> The original InsightFace ArcFace weights are **non-commercial** — this demo ships the commercially
> licensed **AuraFace** (Apache-2.0, by fal) as the 512-D option instead.

Model weights are **not** shipped with the SDK NuGet packages — they are downloaded on first use.

## Privacy

Face recognition processes biometric data. Make sure your use complies with the applicable privacy
and data-protection laws (GDPR, BIPA, CCPA, and similar) in your jurisdiction.
