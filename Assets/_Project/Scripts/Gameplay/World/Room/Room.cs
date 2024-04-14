using System;
using System.Linq;
using Project.Gameplay.World.Tiles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Project.Gameplay.World
{
    public class Room
    {
        public RoomConfig Config { get; private set; }
        public ERoomType Type { get; private set; }
        public Tile[,] Tiles { get; private set; }
        
        public readonly Vector2Int Position;
        private EDirection _passages;
        public EDirection Passages => _passages;
        
        public static readonly Vector2Int SIZE = new Vector2Int(27, 15);
        
        public Room(Vector2Int pPosition)
        {
            Position = pPosition;
        }

        internal void Build(EWorldTheme pTheme, ERoomType pType)
        {
            Type = pType;
            RoomConfig[] configs = RoomConfigs.Entries.Where(e => e.Type == pType && e.Passages == Passages).ToArray();
            if (!(configs.Length > 0))
                throw new ArgumentOutOfRangeException($"No Room found of type {pType} and passages {Passages}");
            
            Config = configs.Random();
            Texture2D layout = Config.Layout;
            ETileType[,] types = TileHelper.TextureToArray(layout);
            Tiles = new Tile[layout.width, layout.height];
            
            for (int y = 0; y < layout.height; y++)
            {
                for (int x = 0; x < layout.width; x++)
                {
                    TileConfig config = WorldManager.GetTile(pTheme, types[x, y]);
                    Tiles[x, y] = new Tile(new Vector2Int(x, y), config, pTheme);
                }
            }
        }

        internal void AddPassage(Vector2Int pNeighbor)
        {
            if (Position.x < pNeighbor.x) _passages |= EDirection.East;
            if (Position.x > pNeighbor.x) _passages |= EDirection.West;
            if (Position.y < pNeighbor.y) _passages |= EDirection.North;
            if (Position.y > pNeighbor.y) _passages |= EDirection.South;
        }
        internal void RemovePassage(EDirection direction) => _passages ^= ~direction;
    }
}
