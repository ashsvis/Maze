namespace MagicMaze.Services
{
    using MagicMaze.Core.Entities;
    using MagicMaze.Core.Enums;
    using MagicMaze.Interfaces;

    public class MazeBuilder : IMazeBuilder
    {
        private readonly ICellFactory _cellFactory;

        public MazeBuilder(ICellFactory cellFactory)
        {
            _cellFactory = cellFactory;
        }

        public Maze Build(MazeParameters parameters)
        {
            if (parameters == null)
            {
                return Maze.Empty;
            }

            var maze = new Maze(parameters);

            for (int rowIndex = 0; rowIndex < maze.Parameters.RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < maze.Parameters.ColumnCount; columnIndex++)
                {
                    maze.Cells[rowIndex, columnIndex] = _cellFactory.Create(Walls.All);
                }
            }

            // TODO: Generate try path.
            // TODO: Generate dead ends.

            return maze;
        }
    }
}
