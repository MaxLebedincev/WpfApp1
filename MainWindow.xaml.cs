using System.Windows;
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
        private (double x, double y) Player { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Player = (50, 50);

            TickMap();
        }

        private Polyline CustomRectangle(double x, double y, double height, double width, Brush solidColor, bool isUser = false)
        {
            Polyline rectangle = new Polyline();

            rectangle.Stroke = solidColor;
            rectangle.Fill = isUser ? Brushes.Red : null;
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

        private void TickMap()
        {
            canvas.Children.Clear();

            for (int i = 1; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    canvas.Children.Add(CustomRectangle(i * 50, j * 50, 50, 50, Brushes.Black));
                }
            }

            canvas.Children.Add(CustomRectangle(Player.x, Player.y, 50, 50, Brushes.Red, true));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Player = e.Key switch
            {
                Key.Right => (Player.x + 50, Player.y),
                Key.Left => (Player.x - 50, Player.y),
                Key.Up => (Player.x, Player.y - 50),
                Key.Down => (Player.x, Player.y + 50),
                _ => (Player.x, Player.y),
            };

            TickMap();
        }
    }
}