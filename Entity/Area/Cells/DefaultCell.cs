using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1.Entity.Area.Cells
{
    /// <summary>
    /// Стандартная ячейка поддерживающая логику стен, пространства и победы.
    /// </summary>
    internal class DefaultCell : BaseCell
    {
        public override SolidColorBrush GetColor()
        {
            return this.Type switch
            {
                CellType.None => Brushes.White,
                CellType.Wall => Brushes.Black,
                CellType.Win => Brushes.Green,
                _ => throw new NotImplementedException()
            };
        }
    }
}
