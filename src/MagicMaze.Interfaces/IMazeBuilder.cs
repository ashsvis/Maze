namespace MagicMaze.Interfaces
{
    using MagicMaze.Core.Entities;

    public interface IMazeBuilder
    {
        Maze Build(MazeParameters parameters, MazeColorSettings colorSettings);
    }
}
