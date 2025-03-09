using System.Windows.Media;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic;
using WpfApp1.CellGameEngine.AreaMapper.Cells;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Base;

namespace WpfApp1.CellGameEngine.AreaMapper.Cells.Static
{
    internal class StaticCell : BaseCell
    {
        public override SolidColorBrush GetColor()
        {
            return Type switch
            {
                CellTypeEnum.None => Brushes.White,
                CellTypeEnum.Wall => Brushes.Black,
                CellTypeEnum.Win => Brushes.Green,
                _ => throw new NotImplementedException()
            };
        }
    }
}
