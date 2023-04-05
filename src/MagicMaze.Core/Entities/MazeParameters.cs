namespace MagicMaze.Core.Entities
{
    using System.Drawing;

    public class MazeParameters
    {
        public static MazeParameters Empty => new MazeParameters(0, 0, 0, Point.Empty, Point.Empty);

        public int RowCount { get; protected set; }

        public int ColumnCount { get; protected set; }

        public int CellSize { get; protected set; }

        public Point StartPoint { get; protected set; }

        public Point FinishPoint { get; protected set; }

        public MazeParameters(int rowCount, int columnCount, int cellSize, Point startPoint, Point finishPoint)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            CellSize = cellSize;
            StartPoint = startPoint;
            FinishPoint = finishPoint;
        }
    }
}
