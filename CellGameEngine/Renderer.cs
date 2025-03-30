using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.CellGameEngine.AreaMapper;

namespace WpfApp1.CellGameEngine
{
    /// <summary>
    /// Графический обработчик. 
    /// </summary>
    internal class Renderer : RendererBase, IRenderGraphicBase
    {
        public Renderer(Canvas canvas) : base(canvas) { }

        /// <summary>
        /// Размер ячейки.
        /// </summary>
        private const int SizeCell = 50;

        /// <summary>
        /// Отрисовать карту.
        /// </summary>
        /// <param name="map">Объект карты.</param>
        /// <param name="canvas">Объект для записи элементов.</param>
        public override void RenderMap(Mapper map)
        {
            _canvas.Children.Clear();

            for (int i = 0; i < map.Size.x; i++)
            {
                for (int j = 0; j < map.Size.y; j++)
                {
                    var color = map.Cells[i, j]?.GetColor();

                    if (color != null) _canvas.Children.Add(RenderCell(i * SizeCell, j * SizeCell, color));
                }
            }

            foreach (var player in map.Players)
            {
                _canvas.Children.Add(RenderCell(player.Location.X * SizeCell, player.Location.Y * SizeCell, player.Color));
            }
        }

        public override void RenderPause(Mapper map)
        {
            var color = new SolidColorBrush(Color.FromArgb(125, 0, 0, 0));
            
            _canvas.Children.Add(RenderArea(map.Size.x * SizeCell, map.Size.y * SizeCell, color));
        }

        /// <summary>
        /// Отрисовка ячейки.
        /// </summary>
        /// <param name="x">Ширина от 0.</param>
        /// <param name="y">Высота от 0.</param>
        /// <param name="color">Цвет ячейки.</param>
        /// <returns>Ячейка для рендера.</returns>
        public Polyline RenderCell(int x, int y, SolidColorBrush color) => new()
        {

            Stroke = Brushes.Black,
            Fill = color,
            Points =
            [
                new Point(x, y),
                new Point(x + SizeCell, y),
                new Point(x + SizeCell, y + SizeCell),
                new Point(x, y + SizeCell),
                new Point(x, y)
            ]
        };

        /// <summary>
        /// Отрисовка области.
        /// </summary>
        /// <param name="x">Ширина.</param>
        /// <param name="y">Высота.</param>
        /// <param name="color">Цвет.</param>
        /// <returns>Область для рендера.</returns>
        public Polyline RenderArea(int x, int y, SolidColorBrush color) => new()
        {

            Stroke = Brushes.Black,
            Fill = color,
            Points =
            [
                new Point(0, 0),
                new Point(x, 0),
                new Point(x, y),
                new Point(0, y),
                new Point(0, 0)
            ]
        };
    }
}
