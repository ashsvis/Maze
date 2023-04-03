namespace Maze.Model
{
    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;

    public class MazeModel : IMazeModel
    {
        private readonly IMazeViewer _viewer;

        private Maze _current;

        public MazeModel(IMazeViewer mazeViewer) 
        {
            _viewer = mazeViewer;
        }

        public void Push(Maze maze)
        {
            _current = maze;
            _viewer.Draw(_current);
        }
    }
}
