using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Entity.Area.Cells.Player.Interface
{
    internal interface IMove
    {
        public Key Up { get; }
        public Key Down { get; }
        public Key Left { get; }
        public Key Right { get; }
    }
}
