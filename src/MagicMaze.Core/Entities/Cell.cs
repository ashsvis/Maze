namespace MagicMaze.Core.Entities
{
    using MagicMaze.Core.Enums;

    public class Cell
    {
        public Walls Walls { get; protected set; }

        public Cell(Walls walls)
        {
            Walls = walls;
        }
    }
}
