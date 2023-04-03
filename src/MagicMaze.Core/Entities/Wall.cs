namespace MagicMaze.Core.Entities
{
    public class Wall
    {
        public static Wall Empty => new Wall();

        public bool Enabled { get; }
    }
}
