namespace MagicMaze.Services
{
    using System;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    using MagicMaze.Extensions;

    public class RouteGenerator
    {
        private static Point[] Empty => new Point[0];

        private readonly Queue<Point> _stackPoints;
        private readonly bool[,] _visitedPoints;
        private readonly RandomNumberGenerator _randomGenerator;
        private readonly int _rowCount;
        private readonly int _columnCount;

        public RouteGenerator(Point startPoint, int rowCount, int columnCount)
        {
            _randomGenerator = RandomNumberGenerator.Create();            
            _visitedPoints = new bool[rowCount, columnCount];
            _stackPoints = new Queue<Point>();
            _stackPoints.Enqueue(startPoint);

            _rowCount = rowCount;
            _columnCount = columnCount;
        }

        public bool TryGenerate(out Point[] points)
        {
            points = Empty;

            if (_stackPoints.Count == 0)
            {
                return false;
            }

            Point currentPoint = _stackPoints.Dequeue();
            var routePoints = new List<Point> { currentPoint };

            while (true)
            {
                Point[] neighbours = currentPoint.GenerateNeighbours(_rowCount, _columnCount, _visitedPoints);
                if (neighbours.Length == 0)
                {
                    break;
                }

                int randomIndex = GetRandomInt32(0, PointExtensions.MAXIMUM_NUMBER_OF_WALLS) % neighbours.Length;
                currentPoint = neighbours[randomIndex];
                _visitedPoints[currentPoint.X, currentPoint.Y] = true;
                _stackPoints.Enqueue(currentPoint);

                routePoints.Add(currentPoint);
            }

            points = routePoints.ToArray();
            return true;
        }

        private int GetRandomInt32(int minValue, int maxValue)
        {
            if (maxValue <= minValue)
            {
                return 0;
            }

            return (int)(GetRandomFraction() * ((long)maxValue - minValue) + minValue);
        }

        private float GetRandomFraction()
        {
            byte[] data = new byte[4];
            _randomGenerator.GetBytes(data);

            return (float)BitConverter.ToUInt32(data, 0) / uint.MaxValue;
        }
    }
}
