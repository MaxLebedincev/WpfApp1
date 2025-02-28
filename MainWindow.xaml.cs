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

            GraphicsHandler.RenderMap(Map, canvas);

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Handlers.EventHandler.Move(Map, e.Key);

            GraphicsHandler.RenderMap(Map, canvas);

            if (Handlers.EventHandler.CellConditions(Map))
            {
                GraphicsHandler.RenderMap(Map, canvas);
            }
        }
    }
}