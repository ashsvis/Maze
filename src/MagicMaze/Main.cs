namespace MagicMaze
{
    using System.Windows.Forms;

    using MagicMaze.Controllers;
    using MagicMaze.Core.Entities;
    using MagicMaze.Interfaces;
    using MagicMaze.View;

    public partial class Main : Form
    {
        private const int ROWS_COUNT = 15;
        private const int COLUMNS_COUNT = 20;
        private const int CELL_SIZE = 10;

        private readonly IMazeViewer _viewer;
        private readonly MazeController _controller;

        public Main()
        {
            InitializeComponent();
            _viewer = new MazeViewer(sceneWindow);
            _controller = new MazeController(_viewer);
        }

        private void sceneWindow_Load(object sender, System.EventArgs e)
        {
            _controller.CreateCommand(new MazeParameters(ROWS_COUNT, COLUMNS_COUNT, CELL_SIZE));
        }
    }
}
