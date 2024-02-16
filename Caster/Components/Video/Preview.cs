using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using PixelFormat = System.Drawing.Imaging.PixelFormat;


namespace CasterAPP
{
    public partial class MainWindow
    {
        internal void Preview(VideoCapture capture)
        {
            if (capture != null && capture.IsOpened)
            {
                Mat frame = new();
                capture.Read(frame);
                if (!frame.IsEmpty)
                {
                    Image<Bgr, byte> image = frame.ToImage<Bgr, byte>();
                    BitmapSource source = ToBitmapSource(image);
                    cameraPreview.Source = source;
                }
            }
        }
        internal BitmapSource ToBitmapSource(Image<Bgr, byte> image)
        {
            Mat mat = image.Mat;
            Bitmap bitmap = new(mat.Width, mat.Height, PixelFormat.Format24bppRgb);

            BitmapSource bitmapSource;
            using (MemoryStream memory = new())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                bitmapSource = BitmapFrame.Create(memory, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            }
            return bitmapSource;
        }
    }
}
