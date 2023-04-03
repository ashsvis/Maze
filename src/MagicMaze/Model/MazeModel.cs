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
            _position = new Point(0, 0);
        }

        public void Push(Maze maze)
        {
            _maze = maze;
            _viewer.Draw(_maze, _position);
        }

        public void Push(Point position)
        {
            _position = position;
            _viewer.Draw(_maze, _position);
        }
    }
}
