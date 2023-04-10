namespace MagicMaze.Extensions
{
    using System.Drawing;

    using MagicMaze.Core.Entities;
    using MagicMaze.Core.Enums;
    using MagicMaze.Interfaces;

    public static class CellExtensions
    {
        private const int SIGN_OF_NEAREST = 1;

        public static void Merge(this Cell[,] cells, ICellFactory cellFactory, Point first, Point second)
        {
            if (first.X != second.X && first.Y != second.Y)
            {
                return;
            }

            int deltaX = first.X - second.X;
            int deltaY = first.Y - second.Y;

            if (-deltaX == SIGN_OF_NEAREST)
            {
                cells[first.X, first.Y] = cellFactory.Create(cells[first.X, first.Y].Walls & ~Walls.Top);
                cells[second.X, second.Y] = cellFactory.Create(cells[second.X, second.Y].Walls & ~Walls.Bottom);
            }
            else if (deltaX == SIGN_OF_NEAREST)
            {
                cells[first.X, first.Y] = cellFactory.Create(cells[first.X, first.Y].Walls & ~Walls.Bottom);
                cells[second.X, second.Y] = cellFactory.Create(cells[second.X, second.Y].Walls & ~Walls.Top);
            }

            if (-deltaY == SIGN_OF_NEAREST)
            {
                cells[first.X, first.Y] = cellFactory.Create(cells[first.X, first.Y].Walls & ~Walls.Right);
                cells[second.X, second.Y] = cellFactory.Create(cells[second.X, second.Y].Walls & ~Walls.Left);
            }
            else if (deltaY == SIGN_OF_NEAREST)
            {
                cells[first.X, first.Y] = cellFactory.Create(cells[first.X, first.Y].Walls & ~Walls.Left);
                cells[second.X, second.Y] = cellFactory.Create(cells[second.X, second.Y].Walls & ~Walls.Right);
            }
        }

        public static bool HasMoveTo(this Cell cell, Point current, Point next)
        {
            if (current.X != next.X && current.Y != next.Y)
            {
                return false;
            }

            int deltaX = current.X - next.X;
            int deltaY = current.Y - next.Y;

            if (-deltaX == SIGN_OF_NEAREST)
            {
                if (cell.Walls.HasFlag(Walls.Right))
                {
                    return false;
                }
            }
            else if (deltaX == SIGN_OF_NEAREST)
            {
                if (cell.Walls.HasFlag(Walls.Left))
                {
                    return false;
                }
            }

            if (-deltaY == SIGN_OF_NEAREST)
            {
                if (cell.Walls.HasFlag(Walls.Top))
                {
                    return false;
                }
            }
            else if (deltaY == SIGN_OF_NEAREST)
            {
                if (cell.Walls.HasFlag(Walls.Bottom))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
