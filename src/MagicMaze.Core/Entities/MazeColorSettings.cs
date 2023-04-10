using System.Drawing;

namespace MagicMaze.Core.Entities
{
    public class MazeColorSettings
    {
        private static Color DARK_GRAY => Color.FromArgb(1, 20, 20, 20);
        private static Color BLACK_GRAY => Color.FromArgb(1, 70, 70, 70);
        private static Color LIGHT_BLUE => Color.FromArgb(1, 61, 109, 153);
        private static Color LIGHT_WHITE => Color.FromArgb(1, 255, 255, 255);
        private static Color LIGHT_GRAY => Color.FromArgb(1, 125, 125, 125);

        public static MazeColorSettings Default => new MazeColorSettings(BLACK_GRAY, LIGHT_BLUE, DARK_GRAY, LIGHT_WHITE, LIGHT_GRAY);

        public Color Background { get; }

        public Color Cursor { get; }

        public Color Wall { get; }

        public Color Finish { get; }

        public Color Route { get; }

        public MazeColorSettings(Color background, Color cursor, Color wall, Color finish, Color route)
        {
            Background = background;
            Cursor = cursor;
            Wall = wall;
            Finish = finish;
            Route = route;
        }
    }
}
