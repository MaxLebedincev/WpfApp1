using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.CellGameEngine.AreaMapper.Cells;

namespace WpfApp1.CellGameEngine.AreaMapper.DTO
{
    internal class DynamicCellDTO
    {
        public Position Location { get; set; }
        public string? Color { get; set; }
    }
}
