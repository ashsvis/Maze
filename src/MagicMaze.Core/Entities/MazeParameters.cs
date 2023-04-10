namespace MagicMaze.Core.Entities
{
    using System.Drawing;

    public class MazeParameters
    {
        private const int ROWS_COUNT = 15;
        private const int COLUMNS_COUNT = 15;
        private const int CELL_SIZE = 5;

        private static Point START_POINT => new Point(0, 0);
        private static Point FINISH_POINT => new Point(ROWS_COUNT - 1, COLUMNS_COUNT - 1);

        public static MazeParameters Empty => new MazeParameters(0, 0, 0, Point.Empty, Point.Empty);
        public static MazeParameters Default => new MazeParameters(ROWS_COUNT, COLUMNS_COUNT, CELL_SIZE, START_POINT, FINISH_POINT);

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
