using AudioToolbox;
using AVFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioForge.Core;

namespace SimpleVideoCapture
{
    public class StreamAudioPlayer
    {
        private AVAudioEngine audioEngine;
        private AVAudioPlayerNode playerNode;
        private AVAudioFormat audioFormat;

        public StreamAudioPlayer()
        {
            // Initialize the audio engine and player node
            audioEngine = new AVAudioEngine();
            playerNode = new AVAudioPlayerNode();
            audioEngine.AttachNode(playerNode);

            // Define the audio format
            audioFormat = new AVAudioFormat(AVAudioCommonFormat.PCMInt16, 44100, 2, true);

            // Connect the player node to the engine's output
            audioEngine.Connect(playerNode, audioEngine.MainMixerNode, audioFormat);
        }

        public void Start()
        {
            NSError error;
            audioEngine.StartAndReturnError(out error);

            if (error != null)
            {
                Console.WriteLine("Error starting audio engine: " + error.LocalizedDescription);
                return;
            }

            playerNode.Play();
        }

        public void PushData(byte[] data)
        {
            // Convert byte array to NSData
            using (NSData nsData = NSData.FromArray(data))
            {
                // Create an AVAudioPCMBuffer from the NSData
                AVAudioPcmBuffer pcmBuffer = new AVAudioPcmBuffer(audioFormat, (uint)(nsData.Length.ToUInt64() / (ulong)audioFormat.StreamDescription.BytesPerFrame));
                pcmBuffer.FrameLength = pcmBuffer.FrameCapacity;

                // Copy the NSData to the AVAudioPCMBuffer
                NativeAPI.CopyMemory(pcmBuffer.Int16ChannelData, nsData.Bytes, (int)pcmBuffer.FrameCapacity);

               // System.Runtime.InteropServices.Marshal.Copy(nsData.Bytes, pcmBuffer.Int16ChannelData[0], 0, (int)pcmBuffer.FrameCapacity);

                // Schedule the buffer for playback
                playerNode.ScheduleBuffer(pcmBuffer, AVAudioPlayerNodeCompletionCallbackType.PlayedBack, null);
            }
        }

        public void Stop()
        {
            playerNode.Stop();
            audioEngine.Stop();
        }
    }


}
