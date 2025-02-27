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
        /// Ячейки поля.
        /// </summary>
        public BaseCell[,] Cells {  get; set; }

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

            var str = File.ReadAllLines($"{_levelsFolder}level_1.txt");

            var startPlayerPosition = str.First().Split().Select(int.Parse).ToArray();
            var Player = new PlayerCell(startPlayerPosition[0], startPlayerPosition[1]);
            Players.Add(Player);

            var mapPosition = str.Skip(1).ToArray();

            var maxWidth = mapPosition.Select(s => s.Split().Length).ToArray().Max();
            var maxHeight = mapPosition.Length;

            Cells = new DefaultCell[maxWidth, maxHeight];
            Size = (maxWidth, maxHeight);

            for (var heightPointCounter = 0; heightPointCounter < maxHeight; heightPointCounter++)
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
