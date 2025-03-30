using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.CellGameEngine.AreaMapper;

namespace WpfApp1.CellGameEngine
{
    internal abstract class RendererBase : IRenderMap
    {
        internal readonly Panel _canvas;

        internal const int SizeCell = 50;

        public RendererBase(Panel canvas)
        {
            _canvas = canvas;
            
        }
        public abstract void RenderMap(Mapper map);

        public abstract void RenderPause(Mapper map);

        public virtual void FA()
        {
            Console.WriteLine("FA");
        }
    }
}
