namespace MagicMaze.Services
{
    using System.Drawing;

    using MagicMaze.Core.Entities;
    using MagicMaze.Core.Enums;
    using MagicMaze.Extensions;
    using MagicMaze.Interfaces;

    public class MazeBuilder : IMazeBuilder
    {
        private readonly ICellFactory _cellFactory;

        public MazeBuilder(ICellFactory cellFactory)
        {
            _cellFactory = cellFactory;
        }

        public Maze Build(MazeParameters parameters, MazeColorSettings colorSettings)
        {
            if (parameters == null)
            {
                return Maze.Empty;
            }

            var maze = new Maze(parameters, colorSettings);

            for (int rowIndex = 0; rowIndex < maze.Parameters.RowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < maze.Parameters.ColumnCount; columnIndex++)
                {
                    maze.Cells[rowIndex, columnIndex] = _cellFactory.Create(Walls.All);
                }
            }

            var routeGenerator = new RouteGenerator(
                maze.Parameters.StartPoint, 
                maze.Parameters.RowCount,
                maze.Parameters.ColumnCount);

            while (routeGenerator.TryGenerate(out Point[] points))
            {
                Point currentPoint = points[0];
                for (int i = 1; i < points.Length; i++)
                {
                    maze.Cells.Merge(_cellFactory, currentPoint, points[i]);
                    currentPoint = points[i];
                }
            }

            return maze;
        }
    }
}
