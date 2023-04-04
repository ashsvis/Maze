using System.Drawing;

namespace MagicMaze.Core.Entities
{
    public class MazeColorSettings
    {
        private static Color DARK_GRAY => Color.FromArgb(1, 20, 20, 20);
        private static Color BLACK_GRAY => Color.FromArgb(1, 33, 33, 33);
        private static Color LIGHT_BLUE => Color.FromArgb(1, 61, 109, 153);

        public static MazeColorSettings Default => new MazeColorSettings(BLACK_GRAY, LIGHT_BLUE, DARK_GRAY);

        public Color Background { get; }

        public Color Cursor { get; }

        public Color Wall { get; }

        public MazeColorSettings(Color background, Color cursor, Color wall)
        {
            Background = background;
            Cursor = cursor;
            Wall = wall;
        }
    }
}
