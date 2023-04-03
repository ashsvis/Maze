namespace MagicMaze.Interfaces
{
    using System.Drawing;

    using MagicMaze.Core.Entities;

    public interface IMazeViewer
    {
        void Draw(Maze maze, Point position);
    }
}