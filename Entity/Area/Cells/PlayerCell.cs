using System.Windows.Media;
using WpfApp1.Entity.Area.Cells.Player.Interface;
using WpfApp1.Entity.Area.Cells.Player.MoveKeys;

namespace WpfApp1.Entity.Area.Cells
{
    internal class PlayerCell : BaseCell
    {
        public IMove MoveKeys { get; private set; }

        /// <summary>
        /// УИД игрока.
        /// </summary>
        public readonly Guid UUID = Guid.NewGuid();

        /// <summary>
        /// Расположение ячейки игрока.
        /// </summary>
        public (int x, int y) Location { get; set; }

        /// <summary>
        /// Цвет игрока.
        /// </summary>
        public SolidColorBrush Color { get; set; }
        public override SolidColorBrush GetColor() => Color;
        public PlayerCell(int x, int y)
        {
            Location = (x, y);
            MoveKeys = new ArrowKeys();

            var bytes = new byte[3];
            new Random().NextBytes(bytes);
            Color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(bytes[0], bytes[1], bytes[2]));
        }

        public PlayerCell(int x, int y, SolidColorBrush color) : this(x, y)
        {
            Color = color;
        }

        public PlayerCell(int x, int y, IMove Keys) : this(x, y)
        {
            MoveKeys = Keys;
        }
    }
}
