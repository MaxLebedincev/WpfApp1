using System.Text.Json.Serialization;
using System.Windows.Input;
using System.Windows.Media;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Base;

namespace WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic
{
    internal class DynamicCell : BaseCell
    {
        /// <summary>
        /// УИД игрока.
        /// </summary>
        public readonly Guid UUID = Guid.NewGuid();

        /// <summary>
        /// Расположение ячейки игрока.
        /// </summary>
        public Position Location { get; set; }

        /// <summary>
        /// Цвет игрока.
        /// </summary>
        public SolidColorBrush Color { get; set; }
        public override SolidColorBrush GetColor() => Color;

        public DynamicCell(int x, int y)
        {
            Location = new() { X = x, Y = y };

            var bytes = new byte[3];
            new Random().NextBytes(bytes);
            Color = new SolidColorBrush(System.Windows.Media.Color.FromRgb(bytes[0], bytes[1], bytes[2]));
        }

        public DynamicCell(int x, int y, SolidColorBrush color) : this(x, y)
        {
            Color = color;
        }
    }
}
