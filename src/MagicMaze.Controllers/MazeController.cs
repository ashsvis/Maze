namespace MagicMaze.Controllers
{
    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;
    using MagicMaze.Services;

    public class MazeController
    {
        private readonly IMazeBuilder _builder;
        private readonly IRouteFinder _finder;
        private readonly IMazeModel _model;

        private Maze _current;

        public MazeController(IMazeModel mazeModel)
        {
            _model = mazeModel;
            _builder = new MazeBuilder(new CellFactory());
            _finder = new RouteFinder();
        }

        public void CreateCommand(MazeParameters parameters, MazeColorSettings colorSettings) 
        {
            _current = _builder.Build(parameters, colorSettings);
            _model.Push(_current);
        }

        public void FindExitCommand()
        {
            if (_current == null)
            {
                return;
            }

            Route route = _finder.Find(
                _current.Cells, 
                _current.Parameters.StartPoint,
                _current.Parameters.FinishPoint,
                _current.Parameters.RowCount,
                _current.Parameters.ColumnCount);

            _model.Push(route);
        }

        public void MoveUpCommand()
        {
            _model.MovePositionUp();
        }

        public void MoveDownCommand()
        {
            _model.MovePositionDown();
        }

        public void MoveLeftCommand()
        {
            _model.MovePositionLeft();
        }

        public void MoveRightCommand()
        {
            _model.MovePositionRight();
        }
    }
}
