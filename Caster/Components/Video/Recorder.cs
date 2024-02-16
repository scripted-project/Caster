using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasterAPP.Components
{
    internal class VideoRecorder
    {
        internal int Camera;
        internal string OutputPath;

        internal VideoRecorder(int camera, string outputPath)
        {
            Camera = camera;
            OutputPath = outputPath;
        }
    }
}
