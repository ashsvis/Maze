namespace MagicMaze.Core.Entities
{
    public class MazeParameters
    {
        public static MazeParameters Empty => new MazeParameters(0, 0, 0);

        public int RowCount { get; protected set; }

        public int ColumnCount { get; protected set; }

        public int CellSize { get; protected set; }

        public int BorderSize { get; protected set; }

        public MazeParameters(int rowCount, int columnCount, int cellSize)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            CellSize = cellSize;
        }
    }
}
