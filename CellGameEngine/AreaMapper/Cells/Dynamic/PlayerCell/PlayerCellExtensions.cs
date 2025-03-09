using System.Windows.Input;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.MoveKeys;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell.Interface;

namespace WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell
{
    internal static class PlayerCellExtensions
    {
        public static readonly Dictionary<MovementKeysEnum, IMovement> MovementKeysGroups = new()
        {
            { MovementKeysEnum.ArrowKeys, new ArrowKeys() },
            { MovementKeysEnum.WASDKeys, new WASDKeys() }
        };

        /// <summary>
        /// Получение следующей позиции игрока. 
        /// </summary>
        /// <param name="player">Игрок.</param>
        /// <param name="key">Клавиша нажатия.</param>
        /// <returns>Новая позиция.</returns>
        public static Position GetNextPlayerLocation(this PlayerCell player, Key key)
        {
            var location = player.Location;

            if (player.MovementKeys.Right == key)
            {
                location.X += 1;
            }
            else if (player.MovementKeys.Left == key)
            {
                location.X -= 1;
            }
            else if (player.MovementKeys.Up == key)
            {
                location.Y -= 1;
            }
            else if (player.MovementKeys.Down == key)
            {
                location.Y += 1;
            }

            return location;
        }
    }
}
