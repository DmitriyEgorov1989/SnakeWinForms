using System.Media;
using static SnakeWinFormsApp.Snake;

namespace SnakeWinFormsApp
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer _timer;
        private Label[,] _gameMap;
        private Snake _snake;
        private Food _food;
        private SoundPlayer _soundEffect;
        private Point _lastHeadPosition;
        private const int _cellSize = 35;
        private const int _mapSize = 24;
        private bool _checkDirectionUp = true;
        private bool _checkDirectionRight = false;
        private bool _checkDirectionLeft = false;
        private bool _checkDirectionDown = false;
        private string _soundEffectFilePath = @"tresk-pri-otkusyivanii-yabloka.wav";

        public MainForm()
        {
            InitializeComponent();
            InstalSizeForm();
            AddTimer();
            _snake = new Snake();
            _food = new Food(_mapSize);
            _soundEffect = new SoundPlayer(_soundEffectFilePath);
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            InitMap();
            AddFood();
            _snake.Draw(_gameMap);
            _timer.Start();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            _snake.Move();
            Clear();

            if (_snake.IsOutOfBounds(_mapSize))
            {
                _timer.Stop();
                MessageBox.Show($"Game over!!!");
            }
            else if (HasEatenFood())
            {
                _soundEffect.Play();
                scoreCountLabel.Text = (Convert.ToInt32(scoreCountLabel.Text) + 1).ToString();
                _snake.Draw(_gameMap);
                AddFood();
            }
            else
            {
                _snake.Entity.RemoveAt(_snake.Entity.Count - 1);
                _snake.Draw(_gameMap);
            }
            if (_snake.IsHeadInSnakeBody())
            {
                _timer.Stop();
                MessageBox.Show($"Game over!!!");
            }
        }
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && !_checkDirectionDown && _snake.CheckStep(_lastHeadPosition))
            {
                _snake.DirectionMove = Direction.Up;
                _checkDirectionUp = true;
                _checkDirectionRight = false;
                _checkDirectionLeft = false;
                _checkDirectionDown = false;
                _lastHeadPosition = _snake.GetPositionHead();
            }
            if (e.KeyCode == Keys.Down && !_checkDirectionUp && _snake.CheckStep(_lastHeadPosition))
            {
                _snake.DirectionMove = Direction.Down;
                _checkDirectionDown = true;
                _checkDirectionRight = false;
                _checkDirectionLeft = false;
                _checkDirectionUp = false;
                _lastHeadPosition = _snake.GetPositionHead();
            }
            if (e.KeyCode == Keys.Left && !_checkDirectionRight && _snake.CheckStep(_lastHeadPosition))
            {
                _snake.DirectionMove = Direction.Left;
                _checkDirectionLeft = true;
                _checkDirectionRight = false;
                _checkDirectionUp = false;
                _checkDirectionDown = false;
                _lastHeadPosition = _snake.GetPositionHead();
            }
            if (e.KeyCode == Keys.Right && !_checkDirectionLeft && _snake.CheckStep(_lastHeadPosition))
            {
                _snake.DirectionMove = Direction.Right;
                _checkDirectionRight = true;
                _checkDirectionUp = false;
                _checkDirectionLeft = false;
                _checkDirectionDown = false;
                _lastHeadPosition = _snake.GetPositionHead();
            }
        }
        private void AddTimer()
        {
            _timer = new System.Windows.Forms.Timer
            {
                Interval = 350,
            };
            _timer.Tick += Timer_Tick;
        }
        private void AddFood()
        {
            do
            {
                _food = new Food(_mapSize);
            } while (IsFoodOnSnake());

            _food.DrawFood(_gameMap);
        }
        private Label CreateMap(int indexRow, int indexColumn)
        {
            var label = new Label
            {
                BackColor = Color.DarkSlateGray,
                Size = new Size(35, 35),
            };
            var startX = 3;
            var cellSpacing = 0;
            var x = startX + (indexColumn * (_cellSize + cellSpacing));
            var y = _cellSize + (indexRow * (_cellSize + cellSpacing));
            label.Location = new Point(x, y);
            return label;
        }
        private void InitMap()
        {
            _gameMap = new Label[_mapSize, _mapSize];
            {
                for (int i = 0; i < _mapSize; i++)
                {
                    for (int j = 0; j < _mapSize; j++)
                    {
                        var newLabel = CreateMap(i, j);
                        _gameMap[i, j] = newLabel;
                        Controls.Add(newLabel);
                    }
                }
            }
        }
        private void InstalSizeForm()
        {
            var horizontalSpacing = 1;
            var verticalSpacing = 4;
            Width = _mapSize * (_cellSize + horizontalSpacing);
            Height = _mapSize * (_cellSize + verticalSpacing);
        }
        private bool IsFoodOnSnake()
        {
            for (int i = 0; i < _snake.Entity.Count; i++)
            {
                if (_snake.GetPointX(i) == _food.GetPointX() && _snake.GetPointY(i) == _food.GetPointY())
                {
                    return true;
                }
            }
            return false;
        }
        private bool HasEatenFood()
        {
            return _snake.GetPointX(0) == _food.GetPointX() && _snake.GetPointY(0) == _food.GetPointY();
        }
        private void Clear()
        {
            var deleteSegment = _snake.Entity[_snake.Entity.Count - 1];
            {
                _gameMap[deleteSegment.X, deleteSegment.Y].BackColor = Color.DarkSlateGray;
            }
        }
    }
}