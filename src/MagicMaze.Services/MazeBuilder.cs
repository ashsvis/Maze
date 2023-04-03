namespace MagicMaze.Services
{
    using System.Drawing;
    using System.Collections.Generic;

    using MagicMaze.Core.Entities;
    using MagicMaze.Core.Enums;
    using MagicMaze.Interfaces;


    public class MazeBuilder : IMazeBuilder
    {
        private const int SIGN_OF_NEAREST = 1;

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
            Merge(maze.Cells, new Point(1, 1), new Point(0, 1));
            Merge(maze.Cells, new Point(1, 0), new Point(1, 1));
            Merge(maze.Cells, new Point(1, 1), new Point(1, 2));
            Merge(maze.Cells, new Point(2, 1), new Point(1, 1));

            IEnumerable<Cell> nearests = null;

            nearests = GetNearests(maze.Cells, new Point(0, 0), maze.Parameters.RowCount, maze.Parameters.ColumnCount);
            nearests = GetNearests(maze.Cells, new Point(0, 1), maze.Parameters.RowCount, maze.Parameters.ColumnCount);
            nearests = GetNearests(maze.Cells, new Point(1, 1), maze.Parameters.RowCount, maze.Parameters.ColumnCount);

            // TODO: Generate dead ends.

            return maze;
        }

        private IEnumerable<Cell> GetNearests(Cell[,] cells, Point point, int rowCount, int columnCount)
        {
            var nearests = new List<Cell>(4);

            if (point.X > 0)
            {
                nearests.Add(cells[point.X - 1, point.Y]);
            }

            if (point.Y > 0)
            {
                nearests.Add(cells[point.X, point.Y - 1]);
            }

            if (point.Y < columnCount - 1)
            {
                nearests.Add(cells[point.X, point.Y + 1]);
            }

            if (point.X < rowCount - 1)
            {
                nearests.Add(cells[point.X + 1, point.Y]);
            }

            return nearests;
        }

        private void Merge(Cell[,] cells, Point first, Point second)
        {
            if (first.X != second.X && first.Y != second.Y)
            {
                return;
            }

            int deltaX = first.X - second.X;
            int deltaY = first.Y - second.Y;

            if (-deltaX == SIGN_OF_NEAREST)
            {
                cells[first.X, first.Y] = _cellFactory.Create(cells[first.X, first.Y].Walls & ~Walls.Botton);
                cells[second.X, second.Y] = _cellFactory.Create(cells[second.X, second.Y].Walls & ~Walls.Top);
            }
            else if (deltaX == SIGN_OF_NEAREST)
            {
                cells[first.X, first.Y] = _cellFactory.Create(cells[first.X, first.Y].Walls & ~Walls.Top);
                cells[second.X, second.Y] = _cellFactory.Create(cells[second.X, second.Y].Walls & ~Walls.Botton);
            }

            if (-deltaY == SIGN_OF_NEAREST)
            {
                cells[first.X, first.Y] = _cellFactory.Create(cells[first.X, first.Y].Walls & ~Walls.Right);
                cells[second.X, second.Y] = _cellFactory.Create(cells[second.X, second.Y].Walls & ~Walls.Left);
            }
            else if (deltaY == SIGN_OF_NEAREST)
            {
                cells[first.X, first.Y] = _cellFactory.Create(cells[first.X, first.Y].Walls & ~Walls.Left);
                cells[second.X, second.Y] = _cellFactory.Create(cells[second.X, second.Y].Walls & ~Walls.Right);
            }
        }
    }
}
