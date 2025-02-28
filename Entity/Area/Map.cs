using System.Collections.ObjectModel;
using System.IO;
using WpfApp1.Entity.Area.Cells;

namespace WpfApp1.Entity.Area
{
    internal class Map
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
        public int currentLevel = 0;

        /// <summary>
        /// Ячейки поля.
        /// </summary>
        public BaseCell[,] Cells { get; set; } = new DefaultCell[0,0];

        /// <summary>
        /// Размеры поля
        /// </summary>
        public (int x, int y) Size { get; private set; }

        /// <summary>
        /// Список игроков
        /// </summary>
        public readonly List<PlayerCell> Players = [];

        /// <summary>
        /// Создает карту из загруженных файлов.
        /// </summary>
        public Map(string levelsFolder)
        {
            _levelsFolder = levelsFolder;

            if (Directory.Exists(_levelsFolder))
            {
                _levelFiles = Directory.GetFiles(_levelsFolder);
            }

            LoadLevel();
        }

        /// <summary>
        /// Загрузка уровня.
        /// </summary>
        /// <returns>Есть ли следующий уровень для загрузки.</returns>
        public bool NextLevel()
        {
            var result = currentLevel + 1 < _levelFiles.Length;

            if (result)
            {
                ++currentLevel;
                LoadLevel();
            }
            else
            {
                currentLevel = 0;
                LoadLevel();
            }

            return result;
        }

        private static (int x, int y) GetMaxPositions(string[] pos) => (pos.Select(s => s.Split().Length).ToArray().Max(), pos.Length);

        /// <summary>
        /// Загрузка уровня.
        /// </summary>
        private void LoadLevel()
        {
            var allLines = File.ReadAllLines(_levelFiles[currentLevel]);

            var startPlayerPosition = allLines.First().Split().Select(int.Parse).ToArray();

            LoadPlayers(startPlayerPosition);

            var mapPosition = allLines.Skip(1).ToArray();

            Size = GetMaxPositions(mapPosition);
            Cells = new DefaultCell[Size.x, Size.y];

            LoadCells(mapPosition); ;
        }

        /// <summary>
        /// Загрузка играков.
        /// </summary>
        /// <param name="startPlayerPosition">Позиции играков.</param>
        private void LoadPlayers(int[] startPlayerPosition)
        {
            if (Players.Count() > 0)
            {
                for (var playerCounter = 0; playerCounter < startPlayerPosition.Length / 2; playerCounter++)
                {
                    Players[playerCounter].Location = (startPlayerPosition[0], startPlayerPosition[1]);
                }
            }
            else
            {
                for (var playerCounter = 0; playerCounter < startPlayerPosition.Length / 2; playerCounter++)
                {
                    var Player = new PlayerCell(startPlayerPosition[0], startPlayerPosition[1]);
                    Players.Add(Player);
                }
            }
        }

        /// <summary>
        /// Загрузка ячеек.
        /// </summary>
        /// <param name="mapPosition">Позиции.</param>
        private void LoadCells(string[] mapPosition)
        {
            for (var heightPointCounter = 0; heightPointCounter < Size.y; heightPointCounter++)
            {
                var WidthPoints = mapPosition[heightPointCounter].Split().Select(int.Parse).ToArray();

                for (var widthPointsCounter = 0; widthPointsCounter < WidthPoints.Length; widthPointsCounter++)
                {
                    Cells[widthPointsCounter, heightPointCounter] = new DefaultCell()
                    {
                        Type = (CellType)WidthPoints[widthPointsCounter]
                    };
                }
            }
        }
    }
}
