namespace MagicMaze.Controllers
{
    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;
    using MagicMaze.Services;

    public class MazeController
    {
        private readonly IMazeBuilder _builder;
        private readonly IMazeModel _model;

        private Maze _current;

        public MazeController(IMazeModel mazeModel)
        {
            _model = mazeModel;
            _builder = new MazeBuilder(new CellFactory());
        }

        public void CreateCommand(MazeParameters parameters) 
        {
            _current = _builder.Build(parameters);
            _model.Push(_current);
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
