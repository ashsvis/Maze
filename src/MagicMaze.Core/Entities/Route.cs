namespace MagicMaze.Core.Entities
{
    using System.Drawing;

    public class Route
    {
        public static Route Empty => new Route(new Point[0]);

        public Point[] Coordinates { get; protected set; }

        public Route(Point[] coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
