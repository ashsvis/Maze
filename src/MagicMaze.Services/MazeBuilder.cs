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

            var cells = new Cell[parameters.RowCount, parameters.ColumnCount];
            for (int i = 0; i < cells.Rank; i++)
            {
                for (int j = 0; j < cells.GetLength(i); j++)
                {
                    cells[i, j] = _cellFactory.Create(Walls.All);
                }
            }

            return new Maze(cells);
        }
    }
}
