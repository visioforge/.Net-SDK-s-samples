# Capture VLM Captioning X (WPF)

Live vision-language captioning on a camera with **VideoCaptureCoreX**.

A Florence-2 `VLMBlock` is inserted into the capture engine with `Video_Processing_AddBlock`.
For each sampled frame the model runs the selected task — caption, detailed caption, object
detection, dense region caption, OCR, or phrase grounding — draws the result over the live
preview, and raises `OnResultGenerated`. The task and text input can be changed while capture
is running.

## Usage

1. Pick a camera on the **Camera** tab.
2. On the **Model** tab press **Download model files** to fetch the Florence-2 ONNX model set
   (weights are not shipped with the SDK; they are cached under
   `%USERPROFILE%\VisioForge\models\vlm`). You can also browse for your own model folder.
3. On the **Task** tab choose a task, tune the processing interval / max tokens, and (for
   **PhraseGrounding**) type the phrase to ground.
4. Press **Start**. Results appear in the table and, when enabled, are drawn over the video.

## Key API

```csharp
var settings = new VLMSettings(modelFolder)
{
    Task = VLMTask.Caption,
    TextInput = "",
    DrawResults = true,
};

_vlm = new VLMBlock(settings);
_vlm.OnResultGenerated += Vlm_OnResultGenerated;
_core.Video_Processing_AddBlock(_vlm);   // insert into VideoCaptureCoreX (before StartAsync)
```

Requires a Media Blocks SDK .Net or Video Capture SDK .Net (X-engine) license.
