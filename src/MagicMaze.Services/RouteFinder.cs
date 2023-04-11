namespace MagicMaze.Services
{
    using System.Drawing;
    using System.Collections.Generic;

    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;
    using MagicMaze.Extensions;

    public class RouteFinder : IRouteFinder
    {
        internal class RouteNode
        {
            public RouteNode Parent { get; }

            public Point Position { get; }

            public RouteNode(RouteNode parent, Point position)
            {
                Parent = parent;
                Position = position;
            }
        }

        public RouteFinder()
        {
        }

        public Route Find(Cell[,] cells, Point startPoint, Point finishPoint, int rowCount, int columnCount)
        {
            var visitedPoints = new bool[rowCount, columnCount];
            var stackPoints = new Queue<RouteNode>();
            stackPoints.Enqueue(new RouteNode(null, startPoint));

            RouteNode finish = null;

            while (stackPoints.Count > 0)
            {
                RouteNode current = stackPoints.Dequeue();
                visitedPoints[current.Position.X, current.Position.Y] = true;

                if (current.Position == finishPoint)
                {
                    finish = current;
                    break;
                }

                var neighbours = current.Position.GenerateNeighbours(rowCount, columnCount, visitedPoints);

                foreach (var neighbour in neighbours)
                {
                    if (visitedPoints[neighbour.X, neighbour.Y])
                    {
                        continue;
                    }

                    if (!cells[current.Position.Y, current.Position.X].HasMoveTo(current.Position, neighbour))
                    {
                        continue;
                    }

                    stackPoints.Enqueue(new RouteNode(current, neighbour));
                }
            }

            var routePoints = new List<Point>();

            while (finish != null)
            {
                routePoints.Add(finish.Position);
                finish = finish.Parent;
            }

            return new Route(routePoints.ToArray());
        }
    }
}
