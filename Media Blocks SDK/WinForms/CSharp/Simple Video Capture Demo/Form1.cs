using Gst;
using System;

using System.IO;
using System.Linq;
using System.Windows.Forms;

using VisioForge.Core.MediaBlocks;
using VisioForge.Core.MediaBlocks.AudioRendering;
using VisioForge.Core.MediaBlocks.Sinks;
using VisioForge.Core.MediaBlocks.Sources;
using VisioForge.Core.MediaBlocks.Special;
using VisioForge.Core.MediaBlocks.VideoEncoders;
using VisioForge.Core.MediaBlocks.VideoRendering;
using VisioForge.Core.Types;
using VisioForge.Core.Types.Events;
using VisioForge.Core.Types.X.Output;
using VisioForge.Core.Types.X.Sinks;
using VisioForge.Core.Types.X.Sources;
using VisioForge.Core.Types.X.VideoEncoders;

namespace MediaBlocks_Simple_Video_Capture_Demo
{
    public partial class Form1 : Form
    {
        private MediaBlocksPipeline _pipeline;

        private VideoRendererBlock _videoRenderer;

        //private VideoRendererBlock _videoRenderer2;

        //   private AudioRendererBlock _audioRenderer;

        private SystemVideoSourceBlock _videoSource;

        // private SystemAudioSourceBlock _audioSource;

        private MP4SinkBlock _mp4Muxer;

        private H264EncoderBlock _h264Encoder;

        private TeeBlock _videoTee;

        // private TeeBlock _audioTee;

        // private AACEncoderBlock _aacEncoder;


        private Element _fakeSink;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            _pipeline = new MediaBlocksPipeline(true);
            _pipeline.OnError += Pipeline_OnError;

            Text += $" (SDK v{MediaBlocksPipeline.SDK_Version})";

            cbOutputFormat.SelectedIndex = 0;

            var videoCaptureDevices = await SystemVideoSourceBlock.GetDevicesAsync();
            if (videoCaptureDevices.Length > 0)
            {
                foreach (var item in videoCaptureDevices)
                {
                    cbVideoInput.Items.Add(item.Name);
                }

                cbVideoInput.SelectedIndex = 0;
            }

            var audioCaptureDevices = await SystemAudioSourceBlock.GetDevicesAsync(AudioCaptureDeviceAPI.DirectSound);
            if (audioCaptureDevices.Length > 0)
            {
                foreach (var item in audioCaptureDevices)
                {
                    cbAudioInput.Items.Add(item.Name);
                }

                cbAudioInput.SelectedIndex = 0;
            }

            var audioOutputDevices = await AudioRendererBlock.GetDevicesAsync(AudioOutputDeviceAPI.DirectSound);
            if (audioOutputDevices.Length > 0)
            {
                foreach (var item in audioOutputDevices)
                {
                    cbAudioOutput.Items.Add(item);
                }

                cbAudioOutput.SelectedIndex = 0;
            }

            edFilename.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "VisioForge", "output.mp4");
        }

        private void Pipeline_OnError(object sender, ErrorsEventArgs e)
        {
            Invoke((Action)(() =>
            {
                mmLog.Text = mmLog.Text + e.Message + Environment.NewLine;
            }));
        }

        private async void btStart_Click(object sender, EventArgs e)
        {
            bool capture = cbOutputFormat.SelectedIndex > 0;

            mmLog.Clear();

            if (cbVideoInput.SelectedIndex < 0)
            {
                MessageBox.Show(this, "Select video input device");
                return;
            }

            // video source
            VideoCaptureDeviceSourceSettings videoSourceSettings = null;

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await SystemVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        videoSourceSettings = new VideoCaptureDeviceSourceSettings(device)
                        {
                            Format = formatItem.ToFormat()
                        };

                        videoSourceSettings.Format.FrameRate = new VideoFrameRate(Convert.ToDouble(cbVideoFrameRate.Text));
                    }
                }
            }

            _videoSource = new SystemVideoSourceBlock(videoSourceSettings);

            // audio source
            DSAudioCaptureDeviceSourceSettings audioSourceSettings = null;

            deviceName = cbAudioInput.Text;
            format = cbAudioFormat.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                var device = (await SystemAudioSourceBlock.GetDevicesAsync(AudioCaptureDeviceAPI.DirectSound)).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    var formatItem = device.Formats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        audioSourceSettings = new DSAudioCaptureDeviceSourceSettings(device, formatItem.ToFormat());
                    }
                }
            }

            //_audioSource = new SystemAudioSourceBlock(audioSourceSettings);

            // video renderer
            _videoRenderer = new VideoRendererBlock(_pipeline, VideoView1);
            //_videoRenderer2 = new VideoRendererBlock(_pipeline, VideoView2);

            // audio renderer
            // _audioRenderer = new AudioRendererBlock(cbAudioOutput.Text);

            // capture
            capture = true;
            if (capture)
            {
                _videoTee = new TeeBlock(2);
                //_audioTee = new TeeBlock(2);
                _h264Encoder = new H264EncoderBlock(new MFH264EncoderSettings());
                // _aacEncoder = new AACEncoderBlock(new MFAACEncoderSettings());
                _mp4Muxer = new MP4SinkBlock(new MP4SinkSettings(edFilename.Text));

                //_fakeSink = ElementFactory.Make("fakesink");
                //_pipeline.AddBlock(_fakeSink);
            }

            // connect all
            if (capture)
            {
                _pipeline.Connect(_videoSource.Output, _videoTee.Input);
                _pipeline.Connect(_videoTee.Outputs[0], _videoRenderer.Input);
                //_pipeline.Connect(_videoTee.Outputs[1], _videoRenderer2.Input);

                _pipeline.Connect(_videoTee.Outputs[1], _h264Encoder.Input);
                _pipeline.Connect(_h264Encoder.Output, _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Video));

                //_pipeline.Connect(_audioSource.Output, _audioTee.Input);
                //_pipeline.Connect(_audioTee.Outputs[0], _audioRenderer.Input);
                //_pipeline.Connect(_audioTee.Outputs[1], _aacEncoder.Input);
                //_pipeline.Connect(_aacEncoder.Output, _mp4Muxer.CreateNewInput(MediaBlockPadMediaType.Audio));

                //_pipeline.Connect(_audioSource.Output, _audioRenderer.Input);

                //_previewBin = Parse.BinFromDescription("videoconvert ! autovideosink", true);
            }
            else
            {
                // _pipeline.Connect(_audioSource.Output, _audioRenderer.Input);
                _pipeline.Connect(_videoSource.Output, _videoRenderer.Input);
            }

            // start
            await _pipeline.StartAsync();

            timer1.Start();
        }

        private async void btStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            await _pipeline?.StopAsync();

            _pipeline?.ClearBlocks();

            VideoView1.Invalidate();
        }

        private async void btPause_Click(object sender, EventArgs e)
        {
            await _pipeline.PauseAsync();
        }

        private async void btResume_Click(object sender, EventArgs e)
        {
            await _pipeline.ResumeAsync();
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Tag = 1;

            var position = await _pipeline.Position_GetAsync();

            lbTime.Text = position.ToString("hh\\:mm\\:ss");

            timer1.Tag = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btStop_Click(null, null);

            if (_pipeline != null)
            {
                _pipeline.OnError -= Pipeline_OnError;

                _pipeline.Dispose();
                _pipeline = null;
            }
        }

        private async void cbVideoInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceName = cbVideoInput.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                cbVideoFormat.Items.Clear();

                var device = (await SystemVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    foreach (var item in device.VideoFormats)
                    {
                        cbVideoFormat.Items.Add(item.Name);
                    }

                    if (cbVideoFormat.Items.Count > 0)
                    {
                        cbVideoFormat.SelectedIndex = 0;
                    }
                }
            }
        }

        private async void cbVideoFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVideoFrameRate.Items.Clear();

            var deviceName = cbVideoInput.Text;
            var format = cbVideoFormat.Text;
            if (!string.IsNullOrEmpty(deviceName) && !string.IsNullOrEmpty(format))
            {
                var device = (await SystemVideoSourceBlock.GetDevicesAsync()).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    var formatItem = device.VideoFormats.FirstOrDefault(x => x.Name == format);
                    if (formatItem != null)
                    {
                        // build int range from tuple (min, max)    
                        var frameRateList = formatItem.GetFrameRateRangeAsStringList();
                        foreach (var item in frameRateList)
                        {
                            cbVideoFrameRate.Items.Add(item);
                        }

                        if (cbVideoFrameRate.Items.Count > 0)
                        {
                            cbVideoFrameRate.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private async void cbAudioInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            var deviceName = cbAudioInput.Text;
            if (!string.IsNullOrEmpty(deviceName))
            {
                cbAudioFormat.Items.Clear();

                var device = (await SystemAudioSourceBlock.GetDevicesAsync(AudioCaptureDeviceAPI.DirectSound)).FirstOrDefault(x => x.Name == deviceName);
                if (device != null)
                {
                    foreach (var format in device.Formats)
                    {
                        cbAudioFormat.Items.Add(format.Name);
                    }

                    if (cbAudioFormat.Items.Count > 0)
                    {
                        cbAudioFormat.SelectedIndex = 0;
                    }
                }
            }
        }

        private void tbVolume1_Scroll(object sender, EventArgs e)
        {
            //if (_audioRenderer != null)
            //{
            //    _audioRenderer.Volume = tbVolume.Value / 100.0;
            //}
        }

        private void btSelectOutput_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "MP4 files (*.mp4)|*.mp4|WebM files (*.webm)|*.mp4|All files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                edFilename.Text = dialog.FileName;
            }
        }

        private Pad _videoTeePad;

        private Element _videoQueueRecord;

        //private Element _videoEncoder;

        private Element _videoConverter;

        //private Element _muxer;

        //private Element _filesink;

        private Element _videoPreviewX;

        private Bin _previewBin;

        private int _counter;

        //private void btStartRecord_Click(object sender, EventArgs e)
        //{
        //    var blockpad = _videoTee.Outputs[1].GetInternalPad();

        //    blockpad.AddProbe(PadProbeType.BlockDownstream, pad_probe_cb);
        //}

        //private PadProbeReturn pad_probe_cb(Pad pad, PadProbeInfo info)
        //{
        //    Pad srcpad, sinkpad;

        //    //GST_DEBUG_OBJECT(pad, "pad is blocked now");

        //    /* remove the probe first */
        //    pad.RemoveProbe(info.Id);

        //    /* install new probe for EOS */
        //    var cur_effect = _videoRenderer2.GetElement();
        //    srcpad = cur_effect.GetStaticPad("src");
        //    srcpad.AddProbe(PadProbeType.Block | PadProbeType.EventDownstream, event_probe_cb);
        //    srcpad.Dispose();

        //    /* push EOS into the element, the probe will be fired when the
        //     * EOS leaves the effect and it has thus drained all of its data */
        //    sinkpad =  cur_effect.GetStaticPad("sink");
        //    sinkpad.SendEvent(Event.NewEos());
        //    sinkpad.Dispose();

        //    return PadProbeReturn.Ok;
        //}

        //private PadProbeReturn event_probe_cb(Pad pad, PadProbeInfo info)
        //{
        //    Gst.Pipeline pipeline = _pipeline.GetPipelineContext().Pipeline;
        //    var cur_effect = _videoRenderer2.GetElement();
        //    var next = _fakeSink;

        //    var infoData = info.GetData();
        //    var eosPtr = Gst.Event.NewEosPtr();

        //    if (infoData != eosPtr)//  GST_EVENT_TYPE(GST_PAD_PROBE_INFO_DATA(info)) != GST_EVENT_EOS)
        //        return PadProbeReturn.Ok;

        //    pad.RemoveProbe(info.Id);

        //    ///* take next effect from the queue */
        //    //next = g_queue_pop_head(&effects);
        //    //if (next == NULL)
        //    //{
        //    //    GST_DEBUG_OBJECT(pad, "no more effects");
        //    //    g_main_loop_quit(loop);
        //    //    return GST_PAD_PROBE_DROP;
        //    //}

        //   // g_print("Switching from '%s' to '%s'..\n", GST_OBJECT_NAME(cur_effect),
        //   //     GST_OBJECT_NAME(next));

        //    cur_effect.SetState(State.Null);

        //    /* remove unlinks automatically */
        //    //GST_DEBUG_OBJECT(pipeline, "removing %" GST_PTR_FORMAT, cur_effect);
        //    pipeline.Remove(cur_effect);

        //    /* push current effect back into the queue */
        //    //g_queue_push_tail(&effects, g_steal_pointer(&cur_effect));

        //    /* add, link and start the new effect */
        //    //GST_DEBUG_OBJECT(pipeline, "adding   %" GST_PTR_FORMAT, next);
        //    pipeline.Add(next);

        //    //GST_DEBUG_OBJECT(pipeline, "linking..");
        //    var outPad = _videoTee.Outputs[1].GetInternalPad();
        //    var inPad = next.GetStaticPad("sink");
        //    if (outPad.Link(inPad) != PadLinkReturn.Ok)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Unable to connect");
        //    }

        //    next.SetState(State.Playing);

        //    //cur_effect = next;
        //    //GST_DEBUG_OBJECT(pipeline, "done");

        //    return PadProbeReturn.Drop;
        //}

        //private void btStartRecord_Click(object sender, EventArgs e)
        //{
        //    System.Diagnostics.Debug.WriteLine("startRecording\n");
        //    Pad sinkpad;
        //    PadTemplate templ;

        //    templ = _videoTee.GetElement().GetPadTemplate("src_%u");
        //    _videoTeePad = _videoTee.GetElement().RequestPad(templ, null, null);

        //    _videoQueueRecord = ElementFactory.Make("queue", "queue_record");
        //    //_videoEncoder = ElementFactory.Make("openh264enc", null);
        //    _videoConverter = ElementFactory.Make("videoconvert", null);
        //    _videoPreviewX = ElementFactory.Make("autovideosink", null);
        //    // _muxer = ElementFactory.Make("mp4mux", null);
        //    //  _filesink = ElementFactory.Make("filesink", null);
        //    //     string filename = @$"c:\vf\output_{_counter++}.mp4";
        //    //    System.Diagnostics.Debug.WriteLine($"file created {filename}");
        //    // _filesink.SetProperty("location", new GLib.Value(filename));

        //    //_videoEncoder["tune"] = new GLib.Value(4);

        //    _pipeline.GetPipelineContext().Pipeline.Add(_videoQueueRecord);
        //    //  _pipeline.GetPipelineContext().Pipeline.Add(_videoEncoder);
        //    _pipeline.GetPipelineContext().Pipeline.Add(_videoConverter);
        //    _pipeline.GetPipelineContext().Pipeline.Add(_videoPreviewX);
        //    //   _pipeline.GetPipelineContext().Pipeline.Add(_muxer);
        //    //   _pipeline.GetPipelineContext().Pipeline.Add(_filesink);

        //    // link
        //    if (!Element.Link(_videoQueueRecord, _videoConverter))
        //    {
        //        System.Diagnostics.Debug.WriteLine("link queue_record -> videoconvert failed");
        //    }

        //    if (!Element.Link(_videoConverter, _videoPreviewX))
        //    {
        //        System.Diagnostics.Debug.WriteLine("link _videoConverter -> _videoPreviewX failed");
        //    }

        //    //var format = "I420";
        //    //var caps = new Caps("video/x-raw");
        //    //caps.SetValue("format", new GLib.Value(format));
        //    //if (!_videoConverter.LinkFiltered(_videoEncoder, caps))
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine("H264Encoder: Elements could not be linked.");
        //    //}

        //    //var templMP4 = _muxer.GetPadTemplate("video_%u");
        //    //var muxerPad = _muxer.RequestPad(templMP4, null, null);
        //    //var encoderPad = _videoEncoder.GetStaticPad("src");

        //    //if (encoderPad == null)
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine("MP4Sink: encoderPad is null.");
        //    //}

        //    //if (encoderPad.Link(muxerPad) != PadLinkReturn.Ok)
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine("MP4Sink: Pads could not be linked.");
        //    //}

        //    //if (!Element.Link(_videoEncoder, _muxer))
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine("H264Encoder: Elements could not be linked.");
        //    //}

        //    //if (!Element.Link(_muxer, _filesink))
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine("H264Encoder: Elements could not be linked.");
        //    //}

        //    _videoQueueRecord.SyncStateWithParent();
        //    // _videoEncoder.SyncStateWithParent();
        //    // _muxer.SyncStateWithParent();
        //    //  _filesink.SyncStateWithParent();
        //    _videoPreviewX.SyncStateWithParent();
        //    _videoConverter.SyncStateWithParent();

        //    sinkpad = _videoQueueRecord.GetStaticPad("sink");
        //    _videoTeePad.Link(sinkpad);
        //    sinkpad.Dispose();
        //}

        //private PadProbeReturn unlink_cb(Pad pad, PadProbeInfo info)
        //{
        //    System.Diagnostics.Debug.WriteLine("Unlinking...");
        //    Pad sinkpad = _videoQueueRecord.GetStaticPad("sink");
        //    _videoTeePad.Unlink(sinkpad);
        //    sinkpad.Dispose();

        //    //_videoEncoder.SendEvent(Event.NewEos());

        //    return PadProbeReturn.Remove;
        //}

        private void btStartRecord_Click(object sender, EventArgs e)
        {
            //_videoTee.Outputs[1].ConnectLive(_videoRenderer2.Input);
            //_videoRenderer2.GetElement().SetState(State.Playing);

            _mp4Muxer.SetFilenameOrURL(edFilename.Text + $"{System.DateTime.Now.Millisecond}.mp4");
            _videoTee.Outputs[1].ConnectLive(_h264Encoder.Input);
            _h264Encoder.GetElement().SetState(State.Playing);
        }

        private void btStopRecord_Click(object sender, EventArgs e)
        {
            //_videoTee.Outputs[1].DisconnectLive(_videoRenderer2.Input);
            _videoTee.Outputs[1].DisconnectLive(_h264Encoder.Input);

            if (!_h264Encoder.GetElement().SendEvent(Event.NewEos()))
            {
                System.Diagnostics.Debug.WriteLine("EOS event failed");
            }

            _h264Encoder.GetElement().SetState(State.Null);
            _h264Encoder.GetCore().SyncStateWithParent();

            _mp4Muxer.GetElement().SetState(State.Null);
            _mp4Muxer.GetCore().SyncStateWithParent();
        }
    }
}
