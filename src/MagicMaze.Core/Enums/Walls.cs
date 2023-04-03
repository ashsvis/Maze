namespace MagicMaze.Core.Enums
{
    using System;

    [Flags]
    public enum Walls
    {
        None = 0,
        Top = 1 << 1, 
        Botton = 1 << 2, 
        Left = 1 << 3, 
        Right = 1 << 4,
        All = Top | Botton | Left | Right,
    }
}
