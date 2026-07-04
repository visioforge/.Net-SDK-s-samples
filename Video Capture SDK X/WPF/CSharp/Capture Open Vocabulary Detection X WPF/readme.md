# Capture Open Vocabulary Detection X (WPF)

Live open-vocabulary object detection on a camera with **VideoCaptureCoreX**.

An `OpenVocabularyDetectorBlock` (OWLv2 or Grounding DINO) is inserted into the capture
engine with `Video_Processing_AddBlock`. Type free-text prompts (for example `a person`,
`a red car`) and the model finds and boxes matching objects in the live preview in real
time. Prompts can be edited and applied while capture is running.

## Usage

1. Pick a camera on the **Camera** tab.
2. On the **Model** tab choose OWLv2 or Grounding DINO and press **Download model files**
   (weights are not shipped with the SDK; they are cached under
   `%USERPROFILE%\VisioForge\models\openvocab`). You can also browse for your own `.onnx`.
3. Add detection prompts on the **Prompts** tab.
4. Press **Start**.

## Key API

```csharp
var settings = new OpenVocabularyDetectorSettings(modelFile, vocabFile, mergesFile, prompts)
{
    Model = OpenVocabularyModel.OWLv2,
    DrawDetections = true,
};

_detector = new OpenVocabularyDetectorBlock(settings);
_detector.OnObjectsDetected += Detector_OnObjectsDetected;
_core.Video_Processing_AddBlock(_detector);   // insert into VideoCaptureCoreX
```

Requires a Media Blocks SDK .Net or Video Capture SDK .Net (X-engine) license.
