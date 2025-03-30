using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.CellGameEngine
{
    internal class Renderer2v2 : Renderer2
    {
        public Renderer2v2(Panel canvas) : base(canvas)
        {

            this.RenderPause(new AreaMapper.Mapper() { });
        }
    }
}
