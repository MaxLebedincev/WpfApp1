using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfApp1.CellGameEngine.AreaMapper;

namespace WpfApp1.CellGameEngine
{
    internal class Renderer2 : RendererBase, IRednererGraphic3D
    {
        public Renderer2(Panel canvas) : base(canvas)
        {
        }

        public Polyline RenderCube(int x, int y, SolidColorBrush color)
        {
            // Реализация Кубов
            throw new NotImplementedException();
        }

        public Polyline RenderField(int x, int y, SolidColorBrush color)
        {
            throw new NotImplementedException();
        }

        public override void RenderMap(Mapper map)
        {
            _canvas.Children.Clear();

            for (int i = 0; i < map.Size.x; i++)
            {
                for (int j = 0; j < map.Size.y; j++)
                {
                    var color = map.Cells[i, j]?.GetColor();

                    if (color != null) _canvas.Children.Add(RenderCube(i * SizeCell, j * SizeCell, color));
                }
            }

            foreach (var player in map.Players)
            {
                _canvas.Children.Add(RenderCube(player.Location.X * SizeCell, player.Location.Y * SizeCell, player.Color));
            }
        }

        public override void RenderPause(Mapper map)
        {
            throw new NotImplementedException();
        }
    }
}
