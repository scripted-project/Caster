using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasterAPP
{
    public partial class MainWindow
    {
        internal void InitializeControllers()
        {
            outputDestination.TextChanged += OnOutDESTChanged;
        }
    }
}
