using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1.CellGameEngine
{
    internal interface IRenderGraphicBase
    {
        /// <summary>
        /// Что-то отрисовывается
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="color">Цвет</param>
        /// <returns>Получи зону и закрась.</returns>
        public abstract Polyline RenderArea(int x, int y, SolidColorBrush color);

        public abstract Polyline RenderCell(int x, int y, SolidColorBrush color);
    }
}
