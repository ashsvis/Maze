namespace MagicMaze.Core.Entities
{
    public class Maze
    {
        public static Maze Empty => new Maze(new Cell[0, 0]);

        public Cell[,] Cells { get; protected set; }

        public Maze(Cell[,] cells)
        {
            Cells = cells;
        }
    }
}
