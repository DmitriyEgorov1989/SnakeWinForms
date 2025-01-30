namespace SnakeWinFormsApp
{
    public class Food
    {
        private Point _position;
        private Random _random = new Random();
        private int _mapSize;
        public Food(int mapsize)
        {
            _mapSize = mapsize;
            SetBallCoordinate();
        }
        private void SetBallCoordinate()
        {
            _position = new Point(_random.Next(0, _mapSize), _random.Next(0, _mapSize));
        }
        public int GetPointX()
        {
            return _position.X;
        }
        public int GetPointY()
        {
            return _position.Y;
        }
        public void DrawFood(Label[,] gameMap)
        {
            gameMap[_position.X, _position.Y].BackColor = Color.Red;

        }
    }
}