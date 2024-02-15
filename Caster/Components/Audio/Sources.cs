using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caster;
using NAudio.Wave;

namespace Caster
{
    public partial class MainWindow
    {
        private void InitializeAudioSources()
        {
            for (int i = 0; i < WaveIn.DeviceCount; i++)
            {
                var cap = WaveIn.GetCapabilities(i);
                audioSelection.Items.Add(cap.ProductName);
            }
        }
    }
}
