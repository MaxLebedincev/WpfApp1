using System.Windows;
using System.Windows.Input;
using WpfApp1.Entity.Area;
using WpfApp1.Handlers;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Map Map { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            
            Map = new Map("Levels\\");

            Map.RenderMap(canvas);

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Map.Down(e.Key);

            Map.RenderMap(canvas);


            //if (Map[Player.x, Player.y] == 3)
            //{
            //    MessageBox.Show("Вы победили!");
            //}
        }
    }
}