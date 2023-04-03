namespace MagicMaze.Interfaces
{
    using MagicMaze.Core.Enums;
    using MagicMaze.Core.Entities;

    interface ICellFactory
    {
        Cell Create(Walls walls);
    }
}
