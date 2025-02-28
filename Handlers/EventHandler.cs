using System.Numerics;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Entity.Area;

namespace WpfApp1.Handlers
{
    /// <summary>
    /// Обработчик событий.
    /// </summary>
    internal static class EventHandler
    {
        public static void Move(Map map, Key key)
        {
            foreach (var player in map.Players)
            {
                player.Location = key switch
                {
                    Key.Right => (map.Cells[player.Location.x + 1, player.Location.y].Type == CellType.Wall ? player.Location.x : player.Location.x + 1, player.Location.y),
                    Key.Left => (map.Cells[player.Location.x - 1, player.Location.y].Type == CellType.Wall ? player.Location.x : player.Location.x - 1, player.Location.y),
                    Key.Up => (player.Location.x, map.Cells[player.Location.x, player.Location.y - 1].Type == CellType.Wall ? player.Location.y : player.Location.y - 1),
                    Key.Down => (player.Location.x, map.Cells[player.Location.x, player.Location.y + 1].Type == CellType.Wall ? player.Location.y : player.Location.y + 1),
                    _ => (player.Location.x, player.Location.y),
                };
            }
        }

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
    }
}
