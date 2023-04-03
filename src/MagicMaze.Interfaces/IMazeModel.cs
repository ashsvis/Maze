namespace MagicMaze.Interfaces
{
    using System.Drawing;

    using MagicMaze.Core.Entities;

    public interface IMazeModel
    {
        Point Position { get; }

        void Push(Maze maze);
        void Push(Point position);
    }
}
