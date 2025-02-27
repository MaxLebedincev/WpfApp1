using System.Windows.Input;
using WpfApp1.Entity.Area;

namespace WpfApp1.Handlers
{
    /// <summary>
    /// Обработчик событий.
    /// </summary>
    internal static class EventHandler
    {
        public static void Down(this Map _map, Key key)
        {
            foreach (var player in _map.Players)
            {
                player.Location = key switch
                {
                    Key.Right => (_map.Cells[player.Location.x + 1, player.Location.y].Type == CellType.Wall ? player.Location.x : player.Location.x + 1, player.Location.y),
                    Key.Left => (_map.Cells[player.Location.x - 1, player.Location.y].Type == CellType.Wall ? player.Location.x : player.Location.x - 1, player.Location.y),
                    Key.Up => (player.Location.x, _map.Cells[player.Location.x, player.Location.y - 1].Type == CellType.Wall ? player.Location.y : player.Location.y - 1),
                    Key.Down => (player.Location.x, _map.Cells[player.Location.x, player.Location.y + 1].Type == CellType.Wall ? player.Location.y : player.Location.y + 1),
                    _ => (player.Location.x, player.Location.y),
                };
            }
        }
    }
}
