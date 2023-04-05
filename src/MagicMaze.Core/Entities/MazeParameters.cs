namespace MagicMaze.Core.Entities
{
    using System.Drawing;

    public class MazeParameters
    {
        public static MazeParameters Empty => new MazeParameters(0, 0, Point.Empty, Point.Empty);

        public int RowCount { get; protected set; }

        public int ColumnCount { get; protected set; }

        public Point StartPoint { get; protected set; }

        public Point FinishPoint { get; protected set; }

        public MazeParameters(int rowCount, int columnCount, Point startPoint, Point finishPoint)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            StartPoint = startPoint;
            FinishPoint = finishPoint;
        }
    }
}
