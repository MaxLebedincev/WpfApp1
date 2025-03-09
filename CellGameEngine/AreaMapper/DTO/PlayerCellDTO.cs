using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.Interface;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.MoveKeys;

namespace WpfApp1.CellGameEngine.AreaMapper.DTO
{
    internal class PlayerCellDTO : DynamicCellDTO
    {
        public MovementKeysEnum MovementKeys { get; set; } = MovementKeysEnum.ArrowKeys;
    }
}
