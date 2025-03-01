using System.Numerics;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Entity.Area;
using WpfApp1.Entity.Area.Cells;
using WpfApp1.Entity.Area.Cells.Player.Interface;

namespace WpfApp1.Handlers
{
    /// <summary>
    /// Обработчик событий.
    /// </summary>
    internal static class EventHandler
    {
        /// <summary>
        /// Перемещение.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="key"></param>
        public static void Move(Map map, Key key)
        {
            foreach (var player in map.Players)
            {
                var nextCell = GetNextPlayerLocation(player, key);

                var isNextCell = true;

                isNextCell &= map.Cells[nextCell.x, nextCell.y].Type != CellType.Wall;

                isNextCell &= 
                    map.Players
                    .Where(p => player.UUID != p.UUID)
                    .Any(p => p.Location.x != nextCell.x || p.Location.y != nextCell.y);

                player.Location = isNextCell ? nextCell : player.Location;
            }
        }

        /// <summary>
        /// Пост условия.
        /// </summary>
        /// <param name="map">Карта.</param>
        /// <returns>Требуется ли ререндер.</returns>
        public static bool CellConditions(Map map)
        {
            var result = false;

            foreach (var player in map.Players)
            {
                if (map.Cells[player.Location.x, player.Location.y].Type == CellType.Win)
                {
                    result = map.NextLevel();

                    if (!result)
                    {
                        MessageBox.Show("Вы победили!");
                        result = true;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получение следующей позиции игрока. 
        /// </summary>
        /// <param name="player">Игрок.</param>
        /// <param name="key">Клавиша нажатия.</param>
        /// <returns>Новая позиция.</returns>
        private static (int x, int y) GetNextPlayerLocation(PlayerCell player, Key key)
        {
            var location = player.Location;

            if (player.MoveKeys.Right == key)
            {
                location = (player.Location.x + 1, player.Location.y);
            }
            else if (player.MoveKeys.Left == key)
            {
                location = (player.Location.x - 1, player.Location.y);
            }
            else if (player.MoveKeys.Up == key)
            {
                location = (player.Location.x, player.Location.y - 1);
            }
            else if (player.MoveKeys.Down == key)
            {
                location = (player.Location.x, player.Location.y + 1);
            }

            return location;
        }
    }
}
