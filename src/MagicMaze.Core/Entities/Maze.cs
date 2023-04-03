namespace MagicMaze.Core.Entities
{
    public class Maze
    {
        public static Maze Empty => new Maze(MazeParameters.Empty);

        public Cell[,] Cells { get; protected set; }

        public MazeParameters Parameters { get; protected set; }

        public Maze(MazeParameters parameters)
        {
            Parameters = parameters;
            Cells = new Cell[parameters.RowCount, parameters.ColumnCount];
        }
    }
}
