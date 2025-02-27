using System.Windows.Media;

namespace WpfApp1.Entity.Area.Cells
{
    internal class PlayerCell : BaseCell
    {
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

            var bytes = new byte[3];
            new Random().NextBytes(bytes);
            Color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(bytes[0], bytes[1], bytes[2]));
        }

        public PlayerCell(int x, int y, SolidColorBrush color) : this(x, y)
        {
            Color = color;
        }
    }
}
