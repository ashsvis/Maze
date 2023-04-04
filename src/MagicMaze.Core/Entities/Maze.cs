namespace MagicMaze.Core.Entities
{
    public class Maze
    {
        public static Maze Empty => new Maze(MazeParameters.Empty, MazeColorSettings.Default);

        public Cell[,] Cells { get; protected set; }

        public MazeParameters Parameters { get; protected set; }

        public MazeColorSettings Colors { get; protected set; }

        public Maze(MazeParameters parameters, MazeColorSettings colors)
        {
            Parameters = parameters;
            Colors = colors;

            Cells = new Cell[parameters.RowCount, parameters.ColumnCount];
        }
    }
}
