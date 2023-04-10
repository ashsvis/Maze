namespace MagicMaze.View
{
    using System.Drawing;

    using Tao.OpenGl;
    using Tao.Platform.Windows;

    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;
    using MagicMaze.Core.Enums;

    public class MazeViewer : IMazeViewer
    {
        private const int BORDER_SIZE = 1;

        private readonly SimpleOpenGlControl _sceneWindow;

        public MazeViewer(SimpleOpenGlControl sceneWindow)
        {
            _sceneWindow = sceneWindow;
            _sceneWindow.InitializeContexts();
        }

        public void Draw(Maze maze, Route route, Point cursorPosition)
        {
            Gl.glViewport(0, 0, _sceneWindow.Width, _sceneWindow.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            int rowSize = maze.Parameters.CellSize * maze.Parameters.RowCount;
            int columnSize = maze.Parameters.CellSize * maze.Parameters.ColumnCount;

            Gl.glOrtho(-BORDER_SIZE, columnSize + BORDER_SIZE, -BORDER_SIZE, rowSize + BORDER_SIZE, -1f, 1f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            Gl.glClearColor(
                maze.Colors.Background.R / 255.0f,
                maze.Colors.Background.G / 255.0f,
                maze.Colors.Background.B / 255.0f,
                maze.Colors.Background.A / 255.0f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            foreach (Point coordinate in route.Coordinates)
            {
                DrawPolygon(coordinate, maze.Colors.Route, maze.Parameters.CellSize);
            }

            DrawPolygon(maze.Parameters.FinishPoint, maze.Colors.Finish, maze.Parameters.CellSize);
            DrawPolygon(cursorPosition, maze.Colors.Cursor, maze.Parameters.CellSize);

            for (int rowIndex = 0; rowIndex < maze.Parameters.RowCount; rowIndex++)
            {
                int y = rowIndex * maze.Parameters.CellSize;

                for (int columnIndex = 0; columnIndex < maze.Parameters.ColumnCount; columnIndex++)
                {
                    int x = columnIndex * maze.Parameters.CellSize;

                    DrawCell(maze.Cells[rowIndex, columnIndex], x, y, maze.Parameters.CellSize, maze.Colors.Wall);
                }
            }

            _sceneWindow.Invalidate();
        }

        private void DrawCell(Cell cell, int x, int y, int size, Color color)
        {
            Gl.glLineWidth(3f);
            Gl.glColor3f(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);

            if (cell.Walls.HasFlag(Walls.Bottom))
            {
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex2f(x, y);
                Gl.glVertex2f(x + size, y);
                Gl.glEnd();
            }

            if (cell.Walls.HasFlag(Walls.Right))
            {
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex2f(x + size, y);
                Gl.glVertex2f(x + size, y + size);
                Gl.glEnd();
            }

            if (cell.Walls.HasFlag(Walls.Top))
            {
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex2f(x + size, y + size);
                Gl.glVertex2f(x, y + size);
                Gl.glEnd();
            }

            if (cell.Walls.HasFlag(Walls.Left))
            {
                Gl.glBegin(Gl.GL_LINES);
                Gl.glVertex2f(x, y + size);
                Gl.glVertex2f(x, y);
                Gl.glEnd();
            }
        }

        private void DrawPolygon(Point point, Color color, int size)
        {
            Gl.glColor3f(color.R / 255.0f, color.G / 255.0f, color.B / 255.0f);

            int x = point.X * size;
            int y = point.Y * size;

            Gl.glBegin(Gl.GL_POLYGON);
            Gl.glVertex2f(x, y);
            Gl.glVertex2f(x + size, y);
            Gl.glVertex2f(x + size, y + size);
            Gl.glVertex2f(x, y + size);
            Gl.glEnd();
        }
    }
}
