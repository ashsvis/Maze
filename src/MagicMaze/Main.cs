namespace MagicMaze
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using MagicMaze.Controllers;
    using MagicMaze.Core.Entities;
    using MagicMaze.View;
    using Maze.Model;

    public partial class Main : Form
    {
        private const int ROWS_COUNT = 15;
        private const int COLUMNS_COUNT = 15;

        private Point START_POINT => new Point(0, 0);
        private Point FINISH_POINT => new Point(ROWS_COUNT - 1, COLUMNS_COUNT - 1);

        private readonly MazeViewer _viewer;
        private readonly MazeModel _model;
        private readonly MazeController _controller;

        public Main()
        {
            InitializeComponent();

            _viewer = new MazeViewer(sceneWindow);
            _model = new MazeModel(_viewer);
            _controller = new MazeController(_model);
        }

        private void SceneWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    _controller.MoveUpCommand();
                    break;

                case Keys.S:
                    _controller.MoveDownCommand();
                    break;

                case Keys.A:
                    _controller.MoveLeftCommand();
                    break;

                case Keys.D:
                    _controller.MoveRightCommand();
                    break;

                default:
                    break;
            }
        }

        private void SceneWindow_Load(object sender, EventArgs e)
        {
            _controller.CreateCommand(new MazeParameters(ROWS_COUNT, COLUMNS_COUNT, START_POINT, FINISH_POINT), MazeColorSettings.Default);
        }

        private void RebuildMenuItem_Click(object sender, EventArgs e)
        {
            _controller.CreateCommand(new MazeParameters(ROWS_COUNT, COLUMNS_COUNT, START_POINT, FINISH_POINT), MazeColorSettings.Default);
        }
    }
}
