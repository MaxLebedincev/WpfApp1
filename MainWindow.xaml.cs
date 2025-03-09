using System.Windows;
using System.Windows.Input;
using WpfApp1.CellGameEngine;
using WpfApp1.CellGameEngine.AreaMapper;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Processor _processor { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            _processor = new Processor(
                new Mapper("Levels\\"), 
                new Renderer(canvas)
            );

            _processor.Load();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            _processor.Execute(e.Key);
        }
    }
}