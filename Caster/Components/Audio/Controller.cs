using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using NAudio.Wave;
using CasterAPP.Components;

namespace CasterAPP
{
    public partial class MainWindow
    {
        internal AudioRecorder? arec;
        private void InitializeAudio()
        {
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var cap = WaveIn.GetCapabilities(i);
                audioSelection.Items.Add(cap.ProductName);
            }
            arec = new(audioSelection.SelectedIndex, outputDestination.Text);
        }
    }
}
