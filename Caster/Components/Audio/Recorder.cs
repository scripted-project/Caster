using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace CasterAPP.Components
{
    internal class AudioRecorder
    {
        internal int Microphone;
        internal string OutputPath;

        internal delegate void StopHandler();
        internal event StopHandler Stop = delegate { };
    
        internal AudioRecorder(int microphone, string outputPath)
        {
            Microphone = microphone;
            OutputPath = outputPath;
        }

        internal void Start()
        {
            WaveInEvent src = new();
            src.DeviceNumber = Microphone;
            src.WaveFormat = new();

            WaveFileWriter fw = new(OutputPath, src.WaveFormat);

            src.DataAvailable += (sender, e) => fw.Write(e.Buffer, 0, e.BytesRecorded);

            src.RecordingStopped += (sender, e) =>
            {
                fw.Dispose();
                src.Dispose();
            };

            src.StartRecording();
            Stop += src.StopRecording;
        }
    }
}
