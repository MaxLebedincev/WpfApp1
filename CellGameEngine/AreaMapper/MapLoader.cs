using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Static;
using WpfApp1.CellGameEngine.AreaMapper.DTO;

namespace WpfApp1.CellGameEngine.AreaMapper
{
    internal class MapLoader
    {
        private readonly string _filePath;

        private readonly LevelDTO _level;

        private JsonSerializerOptions Options => new()
        {
            IncludeFields = true,
            WriteIndented = true,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };

        public MapLoader(string filePath) 
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();

            _filePath = filePath;

            var json = File.ReadAllText(_filePath);

            var level = JsonSerializer.Deserialize<LevelDTO>(json, Options) ?? throw new JsonException();

            _level = level;
        }

        public StaticCell[,] GetCells()
        {
            (int x, int y) = (_level.Map.Max(y => y.Count), _level.Map.Count);
            var Cells = new StaticCell[x, y];

            foreach (var str in _level.Map.Select((value, counter) => new { counter, value }))
            {
                foreach (var cellType in str.value.Select((value, counter) => new { counter, value }))
                {
                    Cells[cellType.counter, str.counter] = new StaticCell()
                    {
                        Type = cellType.value
                    };
                }
            }

            return Cells;
        } 

        public PlayerCell[] GetPlayers(PlayerCell[]? players = null)
        {
            players ??= new PlayerCell[_level.Players.Count];

            foreach (var player in _level.Players.Select((value, counter) => new { counter, value }))
            {
                if (players[player.counter] == null)
                {
                    players[player.counter] = new PlayerCell(player.value.Location.X, player.value.Location.Y, PlayerCellExtensions.MovementKeysGroups[player.value.MovementKeys]);
                }
                else
                {
                    players[player.counter].Location = player.value.Location;
                }
                
                if (!string.IsNullOrEmpty(player.value.Color))
                {
                    players[player.counter].Color = new SolidColorBrush((Color)ColorConverter.ConvertFromString(player.value.Color));
                }
            }

            return players;
        }

        public DynamicCell[]? GetDynamicCells()
        {
            if (_level.DynamicObjects == null) return null;

            var dynamicCells = new DynamicCell[_level.DynamicObjects.Count];

            foreach (var dynamicObject in _level.DynamicObjects.Select((value, counter) => new { counter, value }))
            {
                dynamicCells[dynamicObject.counter] = new PlayerCell(dynamicObject.value.Location.X, dynamicObject.value.Location.Y);
            }

            return dynamicCells;
        }
    }
}
