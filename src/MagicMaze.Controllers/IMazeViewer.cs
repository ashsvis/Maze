using MagicMaze.Core.Entities;

namespace MagicMaze.Controllers
{
    public interface IMazeViewer
    {
        void Draw(Maze maze);
    }
}