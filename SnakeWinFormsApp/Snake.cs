namespace SnakeWinFormsApp
{
    public class Snake
    {
        public List<Point> Entity;
        public Direction DirectionMove;
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
        }
        public Snake()
        {
            SetBallCoordinate();
            DirectionMove = Direction.Up;
        }
        private void SetBallCoordinate()
        {
            Entity = new List<Point>
                {
                    new Point(7,6),
                    new Point(6,6)
                };
        }
        public int GetPointX(int index)
        {
            return Entity[index].X;
        }
        public int GetPointY(int index)
        {
            return Entity[index].Y;
        }
        public Point GetPositionHead()
        {
            return Entity[0];
        }
        public bool CheckStep(Point _lastHeadPosition)
        {
            return _lastHeadPosition != Entity[0];
        }
        public bool IsHeadInSnakeBody()
        {
            for (int i = 1; i < Entity.Count; i++)
            {
                if (Entity[0].X == Entity[i].X && Entity[0].Y == Entity[i].Y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsOutOfBounds(int mapSize)
        {
            return Entity.Count > 0 && Entity[0].X < 0 || Entity[0].X >= mapSize || Entity[0].Y < 0 || Entity[0].Y >= mapSize;
        }
        public void Draw(Label[,] gameMap)
        {
            foreach (var partSnake in Entity)
            {
                gameMap[partSnake.X, partSnake.Y].BackColor = Color.GreenYellow;
            }
        }
        public void Move()
        {
            var head = Entity[0];
            Point newHead = head;

            switch (DirectionMove)
            {
                case Direction.Up:
                    newHead = new Point(head.X - 1, head.Y);
                    break;
                case Direction.Down:
                    newHead = new Point(head.X + 1, head.Y);
                    break;
                case Direction.Left:
                    newHead = new Point(head.X, head.Y - 1);
                    break;
                case Direction.Right:
                    newHead = new Point(head.X, head.Y + 1);
                    break;
            }
            Entity.Insert(0, newHead);
        }
    }
}