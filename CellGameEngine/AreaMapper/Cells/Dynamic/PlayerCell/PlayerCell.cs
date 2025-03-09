using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.MoveKeys;
using WpfApp1.CellGameEngine.AreaMapper.Cells;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.Interface;
using System.Text.Json.Serialization;

namespace WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell
{
    internal class PlayerCell(int x, int y) : DynamicCell(x, y)
    {
        public new CellTypeEnum Type => CellTypeEnum.Player;

        public IMovement MovementKeys { get; private set; } = new ArrowKeys();

        public PlayerCell(int x, int y, IMovement Keys) : this(x, y)
        {
            MovementKeys = Keys;
        }

        public void UpdateMoveKeys(IMovement newKeys)
        {
            MovementKeys = newKeys;
        }
    }
}
