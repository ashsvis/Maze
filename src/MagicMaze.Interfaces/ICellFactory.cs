namespace MagicMaze.Interfaces
{
    using MagicMaze.Core.Enums;
    using MagicMaze.Core.Entities;

    public interface ICellFactory
    {
        Cell Create(Walls walls);
    }
}
