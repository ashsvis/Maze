namespace MagicMaze.Interfaces
{
    using System.Drawing;

    using MagicMaze.Core.Entities;

    public interface IMazeViewer
    {
        void Draw(Maze maze, Route route, Point position);
    }
}