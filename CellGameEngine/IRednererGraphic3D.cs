using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1.CellGameEngine
{
    internal interface IRednererGraphic3D
    {
        public abstract Polyline RenderField(int x, int y, SolidColorBrush color);

        public abstract Polyline RenderCube(int x, int y, SolidColorBrush color);
    }
}
