///**
// * Copyright 2017 Google Inc. All Rights Reserved.
// *
// * Licensed under the Apache License, Version 2.0 (the "License");
// * you may not use this file except in compliance with the License.
// * You may obtain a copy of the License at
// *
// *      http://www.apache.org/licenses/LICENSE-2.0
// *
// * Unless required by applicable law or agreed to in writing, software
// * distributed under the License is distributed on an "AS IS" BASIS,
// * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// * See the License for the specific language governing permissions and
// * limitations under the License.
// */

//using System;
//using System.IO;
//using Foundation;
//using AVFoundation;

//using AudioToolbox;
//using System.Diagnostics;

//namespace SimpleVideoCapture
//{
//    /// <summary>
//    /// Object for recording PCM sound
//    /// </summary>
//    public class SoundRecorder
//    {
//        private readonly string TAG = typeof(SoundRecorder).Name;

//        private const int CountAudioBuffers = 3;
//        private const int AudioBufferLength = 3200;
//        private const int BitsPerChannel = 16;
//        private int Channels = 1;

//       // private readonly VoiceActivityDetector vad;

//        private AudioStreamBasicDescription audioStreamDescription;
//        private InputAudioQueue inputQueue;
                
//        private AudioStream outputAudioStream;

//        public event EventHandler<byte[]> OnAudioDataReceived;

//        public bool Active
//        {
//            get
//            {
//                return inputQueue.IsRunning;
//            }
//        }

//        public SoundRecorder(int sampleRate, int channels)
//        {
//            Channels = channels;

//            // this.vad = vad;

//            var res = AVAudioSession.SharedInstance().SetCategory(AVAudioSessionCategory.PlayAndRecord);

//            if (AVAudioSession.SharedInstance().Category != AVAudioSession.CategoryRecord
//                && AVAudioSession.SharedInstance().Category != AVAudioSession.CategoryPlayAndRecord)
//            {
//                throw new Exception("AVAudioCategory not set to RECORD or PLAY_AND_RECORD. Please set it using AVAudioSession class.");
//            }

//            audioStreamDescription = new AudioStreamBasicDescription
//            {
//                Format = AudioFormatType.LinearPCM,
//                FormatFlags =
//                        AudioFormatFlags.LinearPCMIsSignedInteger |
//                        AudioFormatFlags.LinearPCMIsPacked,

//                SampleRate = sampleRate,
//                BitsPerChannel = BitsPerChannel,
//                ChannelsPerFrame = Channels,
//                BytesPerFrame = (BitsPerChannel / 8) * Channels,
//                FramesPerPacket = 1,
//                Reserved = 0,
//            };

//            audioStreamDescription.BytesPerPacket = audioStreamDescription.BytesPerFrame * audioStreamDescription.FramesPerPacket;

//            inputQueue = CreateInputQueue(audioStreamDescription);
//        }

//        private InputAudioQueue CreateInputQueue(AudioStreamBasicDescription streamDescription)
//        {
//            var queue = new InputAudioQueue(streamDescription);

//            for (int count = 0; count < CountAudioBuffers; count++)
//            {
//                IntPtr bufferPointer;
//                queue.AllocateBuffer(AudioBufferLength, out bufferPointer);
//                queue.EnqueueBuffer(bufferPointer, AudioBufferLength, null);
//            }
//            queue.InputCompleted += HandleInputCompleted;
//            return queue;
//        }

//        public AudioStream CreateAudioStream()
//        {
//            outputAudioStream = new AudioStream();
//            return outputAudioStream;
//        }

//        public void StartRecording()
//        {
//            Debug.WriteLine(TAG, "StartRecording");

//            var status = inputQueue.Start();
//            Debug.WriteLine(TAG, "Start status: " + status);

//            if (status == AudioQueueStatus.Ok)
//            {
//                outputAudioStream?.StartRecording();
//                Debug.WriteLine(TAG, "Started");
//            }
//            else
//            {
//                throw new Exception("Sound recording initialization failure: " + status);
//            }
//        }

//        public void StopRecording()
//        {
//            Debug.WriteLine(TAG, "StopRecording");

//            if (inputQueue.IsRunning)
//            {
//                var stopStatus = inputQueue.Pause();
//                //var stopStatus = inputQueue.Stop();

//                Debug.WriteLine(TAG, "Stop status " + stopStatus);

//                outputAudioStream?.EndRecording();
//            }
//        }

//        private void HandleInputCompleted(object sender, InputCompletedEventArgs e)
//        {
//            Debug.WriteLine(TAG, "HandleInputCompleted");

//            if (!Active)
//            {
//                return;
//            }

//            var buffer = (AudioQueueBuffer)System.Runtime.InteropServices.Marshal.PtrToStructure(e.IntPtrBuffer, typeof(AudioQueueBuffer));

//            ProcessBuffer(buffer);

//            var status = inputQueue.EnqueueBuffer(e.IntPtrBuffer, AudioBufferLength, e.PacketDescriptions);
//        }

//        private void ProcessBuffer(AudioQueueBuffer buffer)
//        {
//            Debug.WriteLine(TAG, "AudioQueueBuffer size:" + buffer.AudioDataByteSize);

//            if (buffer.AudioDataByteSize > 0)
//            {
//                var soundData = new byte[buffer.AudioDataByteSize];
//                System.Runtime.InteropServices.Marshal.Copy(buffer.AudioData, soundData, 0, (int)buffer.AudioDataByteSize);

//                OnAudioDataReceived?.Invoke(this, soundData);

//                if (outputAudioStream != null)
//                {
//                    outputAudioStream.Write(soundData, 0, soundData.Length);
//                    //vad.ProcessBufferEx(soundData, soundData.Length);
//                }
//            }
//        }
//    }

//    public class AudioStream : Stream
//    {
//        private readonly string TAG = typeof(AudioStream).Name;

//        private readonly MemoryStream innerStream;
//        private readonly object innerStreamLock = new object();

//        private long readPosition;
//        private long writePosition;

//        private AutoResetEvent dataAvailable = new AutoResetEvent(false);

//        public AudioStream()
//        {
//            innerStream = new MemoryStream();
//        }


//        public override bool CanRead { get { return true; } }

//        public override bool CanSeek { get { return false; } }

//        public override bool CanWrite { get { return true; } }

//        public override void Flush()
//        {
//            lock (innerStreamLock)
//            {
//                innerStream.Flush();
//            }
//        }

//        public override long Length
//        {
//            get
//            {
//                lock (innerStreamLock)
//                {
//                    return innerStream.Length;
//                }
//            }
//        }

//        public override long Position
//        {
//            get
//            {
//                lock (innerStreamLock)
//                {
//                    return innerStream.Position;
//                }
//            }

//            set { throw new NotSupportedException(); }
//        }

//        private bool ProduceInProcess { get; set; }

//        public override int Read(byte[] buffer, int offset, int count)
//        {
//            //Log.Debug(TAG, "ProduceInProcess {0}, readPosition {1}, innerStream.Length {2}", ProduceInProcess, readPosition, innerStream.Length);
//            if (ProduceInProcess && readPosition >= innerStream.Length)
//            {
//                dataAvailable.Reset();

//                Debug.WriteLine(TAG, "Waiting for Write...");
//                dataAvailable.WaitOne();
//                Debug.WriteLine(TAG, "Wait complete");
//            }

//            lock (innerStreamLock)
//            {
//                innerStream.Position = readPosition;
//                var red = innerStream.Read(buffer, offset, count);
//                readPosition = innerStream.Position;

//                //Log.Debug(TAG, "Read " + count + " - " + red);

//                return red;
//            }
//        }

//        public override long Seek(long offset, SeekOrigin origin)
//        {
//            throw new NotSupportedException();
//        }

//        public override void SetLength(long value)
//        {
//            throw new NotImplementedException();
//        }

//        public override void Write(byte[] buffer, int offset, int count)
//        {
//            //Log.Debug(TAG, "Write " + count);
//            lock (innerStreamLock)
//            {
//                innerStream.Position = writePosition;
//                innerStream.Write(buffer, offset, count);
//                writePosition = innerStream.Position;

//                dataAvailable.Set();
//            }
//        }

//        public void EndRecording()
//        {
//            Debug.WriteLine(TAG, "EndRecording");
//            ProduceInProcess = false;
//            dataAvailable.Set();
//        }

//        public void StartRecording()
//        {
//            ProduceInProcess = true;
//        }
//    }
//}


////using System;
////using System.Diagnostics;
////using System.Runtime.InteropServices;
////using AudioToolbox;
////using AVFoundation;

////namespace HeyHeyHey
////{
////    public class AudioQueueRecorder : IDisposable
////    {
////        private InputAudioQueue audioQueue;
////        private IntPtr[] audioQueueBufferPtrs;
////        private readonly int bufferSize;
////        private readonly int numBuffers = 3;
////        public event Action<byte[]> AudioDataReceived;

////        public AudioQueueRecorder()
////        {
////            bufferSize = 4096; // Adjust as needed

////            var audioFormat = new AudioStreamBasicDescription
////            {
////                SampleRate = 44100,
////                Format = AudioFormatType.LinearPCM,
////                ChannelsPerFrame = 1,
////                BitsPerChannel = 16,
////                BytesPerPacket = 2,
////                BytesPerFrame = 2,
////                FramesPerPacket = 1,
////                FormatFlags = AudioFormatFlags.LinearPCMIsSignedInteger | AudioFormatFlags.LinearPCMIsPacked
////            };

////            audioQueue = new InputAudioQueue(audioFormat);
////            audioQueueBufferPtrs = new IntPtr[numBuffers];

////            for (int i = 0; i < numBuffers; i++)
////            {
////                audioQueue.AllocateBuffer(bufferSize, out IntPtr bufferPtr);
////                audioQueueBufferPtrs[i] = bufferPtr;
////                audioQueue.InputCompleted += AudioQueue_InputCompleted;
////                audioQueue.EnqueueBuffer(bufferPtr, null);
////            }
////        }

////        public void Start()
////        {
////            audioQueue.Start();
////        }

////        public void Stop()
////        {
////            audioQueue.Stop(true);
////        }

////        private unsafe void AudioQueue_InputCompleted(object sender, InputCompletedEventArgs e)
////        {
////            var buffer = (AudioQueueBuffer*)e.IntPtrBuffer;
////            var data = new byte[bufferSize];
////            Marshal.Copy((IntPtr)buffer->AudioData, data, 0, bufferSize);

////            Debug.WriteLine($"AudioQueue_InputCompleted: {data.Length}");

////            AudioDataReceived?.Invoke(data);

////            if (audioQueue.IsRunning)
////            {
////                audioQueue.EnqueueBuffer(e.IntPtrBuffer, null);
////            }
////        }

////        public void Dispose()
////        {
////            foreach (var bufferPtr in audioQueueBufferPtrs)
////            {
////                audioQueue.FreeBuffer(bufferPtr);
////            }
////            audioQueue.Dispose();
////        }
////    }
////}
