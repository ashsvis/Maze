namespace MagicMaze.Services
{
    using System.Drawing;
    using System.Collections.Generic;

    using MagicMaze.Core.Entities;

    public class RouteGenerator
    {
        public Point[] GenerateReal(Maze maze, Point startPoint)
        {
            List<Point> points = new List<Point>
            {
                startPoint
            };

            // TODO: Generate real route.
            points.Add(new Point(0, 1));
            points.Add(new Point(1, 1));
            points.Add(new Point(2, 1));
            points.Add(new Point(2, 2));
            points.Add(new Point(2, 3));
            points.Add(new Point(1, 2));

            return points.ToArray();
        }

        public bool TryGenerateFake(Maze maze, out Point[] points)
        {
            // TODO: Generate fake route.
            points = null;
            return false;
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
    }
}
