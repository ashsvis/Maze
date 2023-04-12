namespace MagicMaze.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using NUnit.Framework;

    public class RouteGeneratorTests
    {
        [Test]
        public void TryGenerate_WhenMazeIsEqualToZeroCell_ReturnRouteEmpty()
        {
            // Arrange
            var startPoint = new Point(0, 0);
            var routeGenerator = new RouteGenerator(startPoint, 0, 0);

            // Act
            bool firstResult = routeGenerator.TryGenerate(out Point[] firstPoints);
            bool secondResult = routeGenerator.TryGenerate(out Point[] secondPoints);

            // Assert
            Assert.IsFalse(firstResult);
            Assert.AreEqual(0, firstPoints.Length);
            Assert.IsFalse(secondResult);
            Assert.AreEqual(0, secondPoints.Length);
        }

        [Test]
        public void TryGenerate_WhenMazeIsEqualToOneCell_ReturnRouteInOneCell()
        {
            // Arrange
            var startPoint = new Point(0, 0);
            var routeGenerator = new RouteGenerator(startPoint, 1, 1);

            // Act
            bool firstResult = routeGenerator.TryGenerate(out Point[] firstPoints);
            bool secondResult = routeGenerator.TryGenerate(out Point[] secondPoints);

            // Assert
            Assert.IsTrue(firstResult);
            Assert.AreEqual(1, firstPoints.Length);
            Assert.AreEqual(startPoint, firstPoints[0]);
            Assert.IsFalse(secondResult);
            Assert.AreEqual(0, secondPoints.Length);
        }

        [Test]
        [TestCase(10, 10)]
        [TestCase(10, 100)]
        [TestCase(100, 10)]
        [TestCase(100, 100)]
        [TestCase(100, 1000)]
        [TestCase(1000, 10)]
        [TestCase(1000, 100)]
        [TestCase(1000, 1000)]
        public void TryGenerate_WhenMazeDifferentDimensions_BypassedAllCells(int rowCount, int columnCount)
        {
            // Arrange
            var startPoint = new Point(0, 0);
            var totalPoints = new List<Point>();
            var routeGenerator = new RouteGenerator(startPoint, rowCount, columnCount);

            // Act
            bool firstResult = routeGenerator.TryGenerate(out Point[] points);

            bool secondResult;
            do
            {
                totalPoints.AddRange(new ArraySegment<Point>(points, 1, points.Length - 1));
                secondResult = routeGenerator.TryGenerate(out points);
            }
            while (secondResult);

            // Assert
            Assert.IsTrue(firstResult);
            Assert.AreEqual(rowCount * columnCount, totalPoints.Count);
        }
    }
}