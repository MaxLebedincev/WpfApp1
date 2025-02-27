using System.Windows.Media;

namespace WpfApp1.Entity.Area.Cells
{
    /// <summary>
    /// Базовая ячейка.
    /// </summary>
    internal abstract class BaseCell
    {
        /// <summary>
        /// Тип ячейки.
        /// </summary>
        public CellType Type { get; set; }

        /// <summary>
        /// Получение цвета ячейки.
        /// </summary>
        public abstract SolidColorBrush GetColor();
    }
}
