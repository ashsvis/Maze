namespace Maze.Model
{
    using System.Drawing;

    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;

    public class MazeModel : IMazeModel
    {
        private readonly IMazeViewer _viewer;

        private Maze _maze;
        private Point _position;

        public Point Position => _position;

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
            _position = position;
            _viewer.Draw(_maze, _position);
        }
    }
}
