namespace MagicMaze.Interfaces
{
    using MagicMaze.Core.Entities;

    public interface IMazeModel
    {
        void MovePositionUp();
        void MovePositionDown();
        void MovePositionLeft();
        void MovePositionRight();
        void Push(Maze maze);
    }
}
