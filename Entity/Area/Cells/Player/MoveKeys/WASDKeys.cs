using System.Windows.Input;
using WpfApp1.Entity.Area.Cells.Player.Interface;

namespace WpfApp1.Entity.Area.Cells.Player.MoveKeys
{
    internal class WASDKeys : IMove
    {
        public Key Up => Key.W;
        public Key Down => Key.S;
        public Key Left => Key.A;
        public Key Right => Key.D;
    }
}
