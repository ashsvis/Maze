namespace MagicMaze.Services.Tests
{
    using NUnit.Framework;

    using MagicMaze.Core.Enums;

    public class CellFactoryTests
    {
        [Test]
        [TestCase(Walls.None)]
        [TestCase(Walls.All)]
        [TestCase(Walls.Top)]
        [TestCase(Walls.Top | Walls.Left)]
        [TestCase(Walls.Top | Walls.Right)]
        [TestCase(Walls.Top | Walls.Left | Walls.Right)]
        [TestCase(Walls.Top | Walls.Bottom)]
        [TestCase(Walls.Top | Walls.Bottom | Walls.Left)]
        [TestCase(Walls.Top | Walls.Bottom | Walls.Right)]
        [TestCase(Walls.Top | Walls.Bottom | Walls.Left | Walls.Right)]
        [TestCase(Walls.Bottom)]
        [TestCase(Walls.Bottom | Walls.Left)]
        [TestCase(Walls.Bottom | Walls.Right)]
        [TestCase(Walls.Bottom | Walls.Left | Walls.Right)]
        [TestCase(Walls.Left)]
        [TestCase(Walls.Left | Walls.Right)]
        [TestCase(Walls.Right)]
        public void Create_WhenTwoNoIdenticalCellsAreCreated_ReturnNotSameCell(Walls walls)
        {
            // Arrange
            var cellFactory = new CellFactory();

            // Act
            var cellOne = cellFactory.Create(walls);
            var cellTwo = cellFactory.Create(Walls.All & ~walls);

            // Assert
            Assert.AreNotSame(cellOne, cellTwo);
        }

        [Test]
        [TestCase(Walls.None)]
        [TestCase(Walls.All)]
        [TestCase(Walls.Top)]
        [TestCase(Walls.Top | Walls.Left)]
        [TestCase(Walls.Top | Walls.Right)]
        [TestCase(Walls.Top | Walls.Left | Walls.Right)]
        [TestCase(Walls.Top | Walls.Bottom)]
        [TestCase(Walls.Top | Walls.Bottom | Walls.Left)]
        [TestCase(Walls.Top | Walls.Bottom | Walls.Right)]
        [TestCase(Walls.Top | Walls.Bottom | Walls.Left | Walls.Right)]
        [TestCase(Walls.Bottom)]
        [TestCase(Walls.Bottom | Walls.Left)]
        [TestCase(Walls.Bottom | Walls.Right)]
        [TestCase(Walls.Bottom | Walls.Left | Walls.Right)]
        [TestCase(Walls.Left)]
        [TestCase(Walls.Left | Walls.Right)]
        [TestCase(Walls.Right)]
        public void Create_WhenTwoIdenticalCellsAreCreated_ReturnSameCell(Walls walls)
        {
            // Arrange
            var cellFactory = new CellFactory();

            // Act
            var cellFirst = cellFactory.Create(walls);
            var cellSecond = cellFactory.Create(walls);

            // Assert
            Assert.AreSame(cellFirst, cellSecond);
        }
    }
}