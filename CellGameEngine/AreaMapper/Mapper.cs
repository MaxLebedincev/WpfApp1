using System.Diagnostics.Metrics;
using System.Dynamic;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Text.Json;
using WpfApp1.CellGameEngine.AreaMapper.Cells;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Base;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Static;
using WpfApp1.CellGameEngine.AreaMapper.DTO;

namespace WpfApp1.CellGameEngine.AreaMapper
{
    internal class Mapper
    {
        /// <summary>
        /// Путь до файлов с уровнями.
        /// </summary>
        private readonly string _levelsFolder;

        /// <summary>
        /// Список уровней.
        /// </summary>
        private readonly string[] _levelFiles = [];

        /// <summary>
        /// Текущий уровень.
        /// </summary>
        private int _currentLevel = 0;

        /// <summary>
        /// Ячейки поля.
        /// </summary>
        public BaseCell[,] Cells { get; private set; } = new StaticCell[0, 0];

        /// <summary>
        /// Размеры поля
        /// </summary>
        public (int x, int y) Size => (Cells.GetLength(0), Cells.GetLength(1));

        /// <summary>
        /// Список игроков.
        /// </summary>
        public PlayerCell[]? Players { get; private set; }

        /// <summary>
        /// Список динамических объектов.
        /// </summary>
        public DynamicCell[]? DynamicCells { get; private set; }

        /// <summary>
        /// Создает карту из загруженных файлов.
        /// </summary>
        public Mapper(string levelsFolder)
        {
            _levelsFolder = levelsFolder;

            if (Directory.Exists(_levelsFolder))
            {
                _levelFiles = Directory.GetFiles(_levelsFolder);
            }

            LoadLevel();
        }

        public Mapper()
        {
        }

        /// <summary>
        /// Загрузка уровня.
        /// </summary>
        /// <returns>Есть ли следующий уровень для загрузки.</returns>
        public bool NextLevel()
        {
            var result = _currentLevel + 1 < _levelFiles.Length;

            if (result)
            {
                ++_currentLevel;
                LoadLevel();
            }
            else
            {
                _currentLevel = 0;
                LoadLevel();
            }

            return result;
        }

        /// <summary>
        /// Загрузка уровня.
        /// </summary>
        private void LoadLevel()
        {
            var loader = new MapLoader(_levelFiles[_currentLevel]);

            Cells = loader.GetCells();

            Players = loader.GetPlayers(Players);

            DynamicCells = loader.GetDynamicCells();
        }
    }
}
