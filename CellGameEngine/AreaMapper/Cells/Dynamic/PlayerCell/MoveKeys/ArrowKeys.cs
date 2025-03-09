using System.Windows.Input;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.Interface;

namespace WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.MoveKeys
{
    internal class ArrowKeys : IMovement
    {
        public Key Up => Key.Up;
        public Key Down => Key.Down;
        public Key Left => Key.Left;
        public Key Right => Key.Right;
    }
}
