using WpfApp1.Entity.Area.Cells.Player.Interface;
using WpfApp1.Entity.Area.Cells.Player.MoveKeys;

namespace WpfApp1.Entity.Area.Cells.Player
{
    internal static class PlayerTools
    {
        public static readonly IMove[] MoveKeys = [new ArrowKeys(), new WASDKeys()];
    }
}
