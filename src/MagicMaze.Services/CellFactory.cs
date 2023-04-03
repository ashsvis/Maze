namespace MagicMaze.Services
{
    using System.Collections.Generic;

    using MagicMaze.Core.Entities;
    using MagicMaze.Core.Enums;
    using MagicMaze.Interfaces;

    public class CellFactory : ICellFactory
    {
        private readonly Dictionary<Walls, Cell> _cells;

        public CellFactory()
        {
            _cells = new Dictionary<Walls, Cell>();
        }

        public Cell Create(Walls walls)
        {
            if (_cells.ContainsKey(walls))
            {
                return _cells[walls];
            }

            var cell = new Cell(walls);
            _cells[walls] = cell;

            return cell;
        }
    }
}
