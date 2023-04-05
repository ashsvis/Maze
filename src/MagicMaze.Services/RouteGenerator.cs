namespace MagicMaze.Services
{
    using System;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Security.Cryptography;

    using MagicMaze.Core.Entities;

    public class RouteGenerator
    {
        private static Point[] Empty => new Point[0];

        private const int MAXIMUM_NUMBER_OF_WALLS = 4;

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
                Point[] nearestPoints = GetNearestPoints(currentPoint);
                if (nearestPoints.Length == 0)
                {
                    break;
                }

                int randomIndex = GetRandomInt32(0, MAXIMUM_NUMBER_OF_WALLS) % nearestPoints.Length;
                currentPoint = nearestPoints[randomIndex];
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

        private Point[] GetNearestPoints(Point point)
        {
            var nearestPoints = new List<Point>(MAXIMUM_NUMBER_OF_WALLS);

            if (point.X > 0 && _visitedPoints[point.X - 1, point.Y] == false)
            {
                nearestPoints.Add(new Point(point.X - 1, point.Y));
            }

            if (point.Y > 0 && _visitedPoints[point.X, point.Y - 1] == false)
            {
                nearestPoints.Add(new Point(point.X, point.Y - 1));
            }

            if (point.Y < _columnCount - 1 && _visitedPoints[point.X, point.Y + 1] == false)
            {
                nearestPoints.Add(new Point(point.X, point.Y + 1));
            }

            if (point.X < _rowCount - 1 && _visitedPoints[point.X + 1, point.Y] == false)
            {
                nearestPoints.Add(new Point(point.X + 1, point.Y));
            }

            return nearestPoints.ToArray();
        }
    }
}
