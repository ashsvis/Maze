namespace MagicMaze.Core.Entities
{
    public class MazeParameters
    {
        public int RowCount { get; protected set; }

        public int ColumnCount { get; protected set; }

        public int CellSize { get; protected set; }

        public MazeParameters(int rowCount, int columnCount, int cellSize)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            CellSize = cellSize;
        }
    }
}
