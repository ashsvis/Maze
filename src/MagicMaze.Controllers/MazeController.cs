namespace MagicMaze.Controllers
{
    using System.Drawing;

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
            var position = _model.Position;
            _model.Push(new Point(position.X, position.Y + 1));
        }

        public void MoveDownCommand()
        {
            var position = _model.Position;
            _model.Push(new Point(position.X, position.Y - 1));
        }

        public void MoveLeftCommand()
        {
            var position = _model.Position;
            _model.Push(new Point(position.X - 1, position.Y));
        }

        public void MoveRightCommand()
        {
            var position = _model.Position;
            _model.Push(new Point(position.X + 1, position.Y));
        }
    }
}
