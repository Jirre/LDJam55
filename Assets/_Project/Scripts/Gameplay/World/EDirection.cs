using System;

namespace Project.Gameplay.World
{
    [Flags]
    public enum EDirection
    {
        North = (1 << 0),
        East = (1 << 1),
        South = (1 << 2),
        West = (1 << 3)
    }
}
