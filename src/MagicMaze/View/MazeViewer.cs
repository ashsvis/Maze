namespace MagicMaze.View
{
    using Tao.OpenGl;
    using Tao.Platform.Windows;

    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;
    using MagicMaze.Core.Enums;

    public class MazeViewer : IMazeViewer
    {
        private readonly SimpleOpenGlControl _sceneWindow;

        public MazeViewer(SimpleOpenGlControl sceneWindow)
        {
            _sceneWindow = sceneWindow;
            _sceneWindow.InitializeContexts();
        }

        public void Draw(Maze maze)
        {
            Gl.glViewport(0, 0, _sceneWindow.Width, _sceneWindow.Height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            int rowSize = maze.Parameters.CellSize * maze.Parameters.RowCount;
            int columnSize = maze.Parameters.CellSize * maze.Parameters.ColumnCount;

            Gl.glOrtho(0f, columnSize, 0f, rowSize, -1f, 1f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            Gl.glClearColor(0.3f, 0.3f, 0.3f, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            int size = maze.Parameters.CellSize;

            for (int rowIndex = 0; rowIndex < maze.Parameters.RowCount; rowIndex++)
            {
                int y = rowIndex * size;

                for (int columnIndex = 0; columnIndex < maze.Parameters.ColumnCount; columnIndex++)
                {
                    int x = columnIndex * size;

                    Draw(maze.Cells[rowIndex, columnIndex], x, y, size);
                }
            }

            _sceneWindow.Invalidate();
        }


        private void Draw(Cell cell, int x, int y, int size)
        {
            Gl.glLineWidth(3f);
            Gl.glColor3f(0.1f, 0.1f, 0.1f);

            if (cell.Walls.HasFlag(Walls.Top))
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

            if (cell.Walls.HasFlag(Walls.Botton))
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
    }
}
