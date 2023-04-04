namespace MagicMaze
{
    using System.Windows.Forms;

    using MagicMaze.Controllers;
    using MagicMaze.Core.Entities;
    using MagicMaze.View;
    using Maze.Model;

    public partial class Main : Form
    {
        private const int ROWS_COUNT = 25;
        private const int COLUMNS_COUNT = 25;
        private const int CELL_SIZE = 1;

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

        private void sceneWindow_Load(object sender, System.EventArgs e)
        {
            _controller.CreateCommand(new MazeParameters(ROWS_COUNT, COLUMNS_COUNT, CELL_SIZE), MazeColorSettings.Default);
        }

        private void sceneWindow_KeyDown(object sender, KeyEventArgs e)
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
    }
}
