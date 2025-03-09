using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.Interface
{
    internal interface IMovement
    {
        public Key Up { get; }
        public Key Down { get; }
        public Key Left { get; }
        public Key Right { get; }
    }
}
