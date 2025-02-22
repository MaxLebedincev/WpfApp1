using System.IO;
using System.Numerics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int SizeCell = 50;

        private const string Pathlevel = "Levels\\";

        private (int x, int y) Player { get; set; }
        private (double x, double y) Border { get; set; }

        private int[][] Map { get; set; } 

        public MainWindow()
        {
            InitializeComponent();

            InitMap();
            TickMap();
        }

        private void InitMap()
        {
            var str = File.ReadAllLines($"{Pathlevel}level_1.txt");

            var startPointPlayer = str.First().Split().Select(int.Parse).ToArray();
            Player = (startPointPlayer[0], startPointPlayer[1]);

            Map = new int[str.Length - 1][];
            var temp = 0;
            foreach (var line in str.Skip(1))
            {
                Map[temp] = line.Split().Select(int.Parse).ToArray();
                temp++;
            }

            Border = (Map.Length * SizeCell, Map.Length * SizeCell);
        }

        private void TickMap()
        {
            canvas.Children.Clear();

            for (int i = 1; i < Map.Length + 1; i++)
            {
                for (int j = 1; j < Map.Length + 1; j++)
                {
                    canvas.Children.Add(CustomRectangle(i * SizeCell, j * SizeCell, SizeCell, SizeCell, Brushes.Black, Map[i - 1][j - 1]));
                }
            }

            canvas.Children.Add(CustomRectangle(Player.x * SizeCell, Player.y * SizeCell, SizeCell, SizeCell, Brushes.Red, 2));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Player = (Player.x - 1, Player.y - 1);

            Player = e.Key switch
            {
                Key.Right => (Map[Player.x + 1][Player.y] == 1 ? Player.x : Player.x + 1 , Player.y),
                Key.Left => (Map[Player.x - 1][Player.y] == 1 ? Player.x : Player.x - 1, Player.y),
                Key.Up => (Player.x, Map[Player.x][Player.y - 1] == 1 ? Player.y : Player.y - 1),
                Key.Down => (Player.x, Map[Player.x][Player.y + 1] == 1 ? Player.y : Player.y + 1),
                _ => (Player.x, Player.y),
            };

            if (Map[Player.x][Player.y] == 3)
            {
                MessageBox.Show("Вы победили!");
            }

            Player = (Player.x + 1, Player.y + 1);

            TickMap();
        }

        private Polyline CustomRectangle(double x, double y, double height, double width, Brush solidColor, int color = 0)
        {
            Polyline rectangle = new Polyline();

            rectangle.Stroke = solidColor;
            rectangle.Fill = color switch
            {
                0 => Brushes.White,
                1 => Brushes.Black,
                2 => Brushes.Red,
                3 => Brushes.Green,
                _ => throw new NotImplementedException()
            };

            rectangle.Points = new PointCollection(new List<Point>
            {
                new Point(x, y),
                new Point(x + width, y),
                new Point(x + width, y + height),
                new Point(x, y + height),
                new Point(x, y)
            });

            return rectangle;
        }
    }
}