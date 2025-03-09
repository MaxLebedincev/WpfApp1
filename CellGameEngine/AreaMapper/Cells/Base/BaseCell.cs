using System.Text.Json.Serialization;
using System.Windows.Media;
using WpfApp1.CellGameEngine.AreaMapper.Cells;

namespace WpfApp1.CellGameEngine.AreaMapper.Cells.Base
{
    /// <summary>
    /// Базовая ячейка.
    /// </summary>
    internal abstract class BaseCell
    {
        /// <summary>
        /// Тип ячейки.
        /// </summary>
        [JsonIgnore]
        public CellTypeEnum Type { get; set; }

        /// <summary>
        /// Получение цвета ячейки.
        /// </summary>
        public abstract SolidColorBrush GetColor();
    }
}
