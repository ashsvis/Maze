namespace MagicMaze.Controllers
{
    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;
    using MagicMaze.Services;

    public class MazeController
    {
        private readonly IMazeBuilder _builder;
        private readonly IMazeViewer _viewer;

        private Maze _current;

        public MazeController(IMazeViewer mazeViewer)
        {
            _viewer = mazeViewer;
            _builder = new MazeBuilder(new CellFactory());
        }

        public void CreateCommand(MazeParameters parameters) 
        {
            _current = _builder.Build(parameters);
            _viewer.Draw(_current);
        }
    }
}
