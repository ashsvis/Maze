namespace Maze.Model
{
    using System.Drawing;

    using MagicMaze.Core.Entities;
    using MagicMaze.Core.Enums;
    using MagicMaze.Interfaces;

    public class MazeModel : IMazeModel
    {
        private const int SIGN_OF_NEAREST = 1;

        private readonly IMazeViewer _viewer;

        private Maze _maze;
        private Point _position;

        public MazeModel(IMazeViewer mazeViewer) 
        {
            _viewer = mazeViewer;
            _position = Point.Empty;
        }

        public void Push(Maze maze)
        {
            _maze = maze;
            _position = maze.Parameters.StartPoint;
            _viewer.Draw(_maze, _position);
        }

        public void MovePositionUp()
        {
            MoveTo(new Point(_position.X, _position.Y + 1));
        }

        public void MovePositionDown()
        {
            MoveTo(new Point(_position.X, _position.Y - 1));
        }

        public void MovePositionLeft()
        {
            MoveTo(new Point(_position.X - 1, _position.Y));
        }

        public void MovePositionRight()
        {
            MoveTo(new Point(_position.X + 1, _position.Y));
        }

        private void MoveTo(Point position)
        {
            if (_position.X != position.X && _position.Y != position.Y)
            {
                return;
            }

            int deltaX = _position.X - position.X;
            int deltaY = _position.Y - position.Y;

            if (-deltaX == SIGN_OF_NEAREST)
            {
                if (_maze.Cells[_position.Y, _position.X].Walls.HasFlag(Walls.Right))
                {
                    return;
                }
            }
            else if (deltaX == SIGN_OF_NEAREST)
            {
                if (_maze.Cells[_position.Y, _position.X].Walls.HasFlag(Walls.Left))
                {
                    return;
                }
            }

            if (-deltaY == SIGN_OF_NEAREST)
            {
                if (_maze.Cells[_position.Y, _position.X].Walls.HasFlag(Walls.Top))
                {
                    return;
                }
            }
            else if (deltaY == SIGN_OF_NEAREST)
            {
                if (_maze.Cells[_position.Y, _position.X].Walls.HasFlag(Walls.Bottom))
                {
                    return;
                }
            }

            _position = position;
            _viewer.Draw(_maze, _position);
        }
    }
}
