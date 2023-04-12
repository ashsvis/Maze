namespace MagicMaze.Services.Tests
{
    using NUnit.Framework;

    using MagicMaze.Core.Enums;
    using MagicMaze.Core.Entities;

    public class MazeBuilderTests
    {
        [Test]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        [TestCase(10, 10)]
        [TestCase(10, 100)]
        [TestCase(100, 10)]
        [TestCase(100, 100)]
        [TestCase(100, 1000)]
        [TestCase(1000, 10)]
        [TestCase(1000, 100)]
        [TestCase(1000, 1000)]
        public void Build_WhenMazeDifferentDimensions_NotContainsClosedCells(int rowCount, int columnCount)
        {
            // Arrange
            var cellFactory = new CellFactory();
            var closedCell = cellFactory.Create(Walls.All);
            var mazeBuilder = new MazeBuilder(cellFactory);
            var mazeParameters = new MazeParameters(
                rowCount, 
                columnCount, 
                MazeParameters.Default.CellSize, 
                MazeParameters.Default.StartPoint, 
                MazeParameters.Default.FinishPoint);

            // Act
            var maze = mazeBuilder.Build(mazeParameters, MazeColorSettings.Default);

            // Assert
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    Assert.AreNotSame(closedCell, maze.Cells[rowIndex, columnIndex]);
                }
            }
        }
    }
}