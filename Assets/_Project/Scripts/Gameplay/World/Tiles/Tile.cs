using UnityEngine;

namespace Project.Gameplay.World.Tiles
{
    public readonly struct Tile
    {
        public readonly Vector2Int Position;
        public readonly EWorldTheme Theme;
        public readonly TileConfig Config;

        public Tile(Vector2Int pPosition, TileConfig pConfig, EWorldTheme pTheme)
        {
            Position = pPosition;
            Config = pConfig;
            Theme = pTheme;
        }
    }
}
