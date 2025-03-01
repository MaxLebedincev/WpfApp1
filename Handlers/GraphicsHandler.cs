
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.Entity.Area;

namespace WpfApp1.Handlers
{
    /// <summary>
    /// Графический обработчик. 
    /// </summary>
    internal static class GraphicsHandler
    {
        /// <summary>
        /// Размер ячейки.
        /// </summary>
        private const int SizeCell = 50;

        /// <summary>
        /// Отрисовать карту.
        /// </summary>
        /// <param name="map">Объект карты.</param>
        /// <param name="canvas">Объект для записи элементов.</param>
        public static void RenderMap(Map map, Canvas canvas)
        {
            canvas.Children.Clear();

            for (int i = 0; i < map.Size.x; i++)
            {
                for (int j = 0; j < map.Size.y; j++)
                {
                    var color = map.Cells[i, j]?.GetColor();

                    if (color != null) canvas.Children.Add(RenderCell(i * SizeCell, j * SizeCell, color));
                }
            }

            foreach (var player in map.Players)
            {
                canvas.Children.Add(RenderCell(player.Location.x * SizeCell, player.Location.y * SizeCell, player.Color));
            }
        }

        /// <summary>
        /// Отрисовка ячейки.
        /// </summary>
        /// <param name="x">Ширина от 0.</param>
        /// <param name="y">Высота от 0.</param>
        /// <param name="color">Цвет ячейки.</param>
        /// <returns>Ячейка для рендера.</returns>
        private static Polyline RenderCell(int x, int y, SolidColorBrush color)
        {
            return new Polyline()
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
        }
    }
}
