using System.Windows.Input;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.Interface;

namespace WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.MoveKeys
{
    internal class WASDKeys : IMovement
    {
        public Key Up => Key.W;
        public Key Down => Key.S;
        public Key Left => Key.A;
        public Key Right => Key.D;
    }
}
