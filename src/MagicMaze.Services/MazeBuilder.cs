namespace MagicMaze.Services
{
    using System.Drawing;

    using MagicMaze.Core.Entities;
    using MagicMaze.Core.Enums;
    using MagicMaze.Interfaces;


    public class MazeBuilder : IMazeBuilder
    {
        private const int SIGN_OF_NEAREST = 1;

        private readonly ICellFactory _cellFactory;
        private readonly RouteGenerator _routeGenerator;

        public MazeBuilder(ICellFactory cellFactory)
        {
            _cellFactory = cellFactory;
            _routeGenerator = new RouteGenerator();
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

            Point currentPoint = new Point(0, 0);
            Point[] points = _routeGenerator.GenerateReal(maze, currentPoint);

            for (int i = 1; i < points.Length; i++)
            {
                MergeCells(maze.Cells, currentPoint, points[i]);
                currentPoint = points[i];
            }

            while (_routeGenerator.TryGenerateFake(maze, out points))
            {
                currentPoint = points[0];
                for (int i = 1; i < points.Length; i++)
                {
                    MergeCells(maze.Cells, currentPoint, points[i]);
                    currentPoint = points[i];
                }
            }

            return maze;
        }

        private void MergeCells(Cell[,] cells, Point first, Point second)
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
