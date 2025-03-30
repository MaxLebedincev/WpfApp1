using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.CellGameEngine.AreaMapper;

namespace WpfApp1.CellGameEngine
{
    /// <summary>
    /// 
    /// </summary>
    internal interface IRenderMap
    {
        public abstract void RenderMap(Mapper map);
    }
}
