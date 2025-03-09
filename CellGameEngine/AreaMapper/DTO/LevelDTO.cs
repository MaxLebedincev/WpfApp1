using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.CellGameEngine.AreaMapper.Cells;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell;

namespace WpfApp1.CellGameEngine.AreaMapper.DTO
{
    internal class LevelDTO
    {
        public required List<List<CellTypeEnum>> Map { get; set; }
        public required List<PlayerCellDTO> Players { get; set; }
        public List<DynamicCellDTO>? DynamicObjects { get; set; }
    }
}
