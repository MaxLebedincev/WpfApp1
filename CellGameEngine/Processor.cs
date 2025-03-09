using System.Windows;
using System.Windows.Input;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Dynamic.PlayerCell;
using WpfApp1.CellGameEngine.AreaMapper.Cells.Static;
using WpfApp1.CellGameEngine.AreaMapper.Cells;
using WpfApp1.CellGameEngine.AreaMapper;

namespace WpfApp1.CellGameEngine
{
    /// <summary>
    /// Обработчик событий.
    /// </summary>
    internal class Processor
    {
        private readonly Mapper _mapper;

        private readonly Renderer _renderer;

        private bool _isPause = false;

        public Processor(Mapper mapper, Renderer renderer)
        {
            _mapper = mapper;
            _renderer = renderer;
        }

        public void Load() => _renderer.RenderMap(_mapper);

        public void Execute(Key key)
        {
            if (key == Key.Escape)
            {
                _isPause = !_isPause;
                _renderer.RenderPause(_mapper);
            }

            if (!_isPause)
            {
                TimeStep(key);
            }
        }

        /// <summary>
        /// Один шаг полного цикла игры.
        /// </summary>
        /// <param name="key"></param>
        private void TimeStep(Key key)
        {
            PreHandleKeyDown(key);

            _renderer.RenderMap(_mapper);

            if (PostHandleKeyDown())
            {
                _renderer.RenderMap(_mapper);
            }
        }

        /// <summary>
        /// Пред обработка нажатия.
        /// </summary>
        /// <param name="key"></param>
        private void PreHandleKeyDown(Key key)
        {
            foreach (var player in _mapper.Players)
            {
                var nextCell = player.GetNextPlayerLocation(key);

                var isNextCell = true;

                isNextCell &= _mapper.Cells[nextCell.X, nextCell.Y].Type != CellTypeEnum.Wall;

                isNextCell &=
                    _mapper.Players
                    .Where(p => player.UUID != p.UUID)
                    .Any(p => p.Location.X != nextCell.X || p.Location.Y != nextCell.Y);

                player.Location = isNextCell ? nextCell : player.Location;
            }
        }

        /// <summary>
        /// Пост обработка нажатия.
        /// </summary>
        /// <returns>Требуется ли ререндер.</returns>
        private bool PostHandleKeyDown()
        {
            var result = false;

            foreach (var player in _mapper.Players)
            {
                if (_mapper.Cells[player.Location.X, player.Location.Y].Type == CellTypeEnum.Win)
                {
                    result = _mapper.NextLevel();

                    if (!result)
                    {
                        MessageBox.Show("Вы победили!");
                        result = true;
                    }
                }
            }

            return result;
        }
    }
}
