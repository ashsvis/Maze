namespace MagicMaze.Extensions
{
    using System.Drawing;
    using System.Collections.Generic;

    public static class PointExtensions
    {
        public const int MAXIMUM_NUMBER_OF_WALLS = 4;

        public static Point[] GenerateNeighbours(this Point point, int rowCount, int columnCount, bool[,] visited)
        {
            var nearestPoints = new List<Point>(MAXIMUM_NUMBER_OF_WALLS);

            if (point.X > 0 && visited[point.X - 1, point.Y] == false)
            {
                nearestPoints.Add(new Point(point.X - 1, point.Y));
            }

            if (point.Y > 0 && visited[point.X, point.Y - 1] == false)
            {
                nearestPoints.Add(new Point(point.X, point.Y - 1));
            }

            if (point.Y < columnCount - 1 && visited[point.X, point.Y + 1] == false)
            {
                nearestPoints.Add(new Point(point.X, point.Y + 1));
            }

            if (point.X < rowCount - 1 && visited[point.X + 1, point.Y] == false)
            {
                nearestPoints.Add(new Point(point.X + 1, point.Y));
            }

            return nearestPoints.ToArray();
        }
    }
}
