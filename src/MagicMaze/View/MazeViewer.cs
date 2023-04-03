namespace MagicMaze.View
{
    using Tao.OpenGl;
    using Tao.Platform.Windows;

    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;

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
            Gl.glClearColor(0f, 0f, 1f, 1);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            _sceneWindow.Invalidate();
        }
    }
}
