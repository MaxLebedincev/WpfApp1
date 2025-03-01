using System.Windows.Input;
using WpfApp1.Entity.Area.Cells.Player.Interface;

namespace WpfApp1.Entity.Area.Cells.Player.MoveKeys
{
    internal class ArrowKeys : IMove
    {
        public Key Up => Key.Up;
        public Key Down => Key.Down;
        public Key Left => Key.Left;
        public Key Right => Key.Right;
    }
}
