namespace MagicMaze.Interfaces
{
    using System.Drawing;

    using MagicMaze.Core.Entities;

    public interface IRouteFinder
    {
        Route Find(Cell[,] cells, Point startPoint, Point finishPoint, int rowCount, int columnCount);
    }
}
