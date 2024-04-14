using System;
using System.Collections.Generic;
using Project.Gameplay.World.Tiles;
using UnityEngine;

namespace Project.Gameplay.World
{
    public partial class WorldManager // Generator Room
    {
        private static Dictionary<EWorldTheme, Dictionary<ETileType, TileConfig>> TILE_TABLE;

        public void BuildTileTable()
        {
            TILE_TABLE = new Dictionary<EWorldTheme, Dictionary<ETileType, TileConfig>>();
            foreach (TileConfig tile in TileConfigs.Entries)
            {
                EWorldTheme[] themes = tile.Themes;
                foreach (EWorldTheme theme in themes)
                {
                    if (!TILE_TABLE.ContainsKey(theme))
                        TILE_TABLE.Add(theme, new Dictionary<ETileType, TileConfig>());

                    if (!TILE_TABLE[theme].ContainsKey(tile.Type))
                    {
                        TILE_TABLE[theme].Add(tile.Type, tile);
                        continue;
                    }
                
                    Debug.LogError($"Multiple Tiles of the same Theme {theme} and Type {tile.Type} exist");
                }
            }
        }

        public static TileConfig GetTile(EWorldTheme pTheme, ETileType pType)
        {
            if (TILE_TABLE.ContainsKey(pTheme) && TILE_TABLE[pTheme].ContainsKey(pType))
                return TILE_TABLE[pTheme][pType];
            throw new ArgumentOutOfRangeException($"No Tile of the same type {pTheme} and Type {pType} exist");
        }
        
        public void GenerateRoom(Room pRoom)
        {
            int width = pRoom.Tiles.GetLength(0);
            int height = pRoom.Tiles.GetLength(1);

            _GroundMap.transform.localPosition = new Vector3(-width * .5f, -height * .5f, 10f);
            _DecorMap.transform.localPosition = new Vector3(-width * .5f, -height * .5f, 9f);
            
            for (int y = -1; y <= height; y++)
            {
                for (int x = -1; x <= width; x++)
                {
                    Tile tile;
                    if (x < 0 || x >= width ||
                        y < 0 || y >= height)
                        tile = new Tile(new Vector2Int(x, y), TileConfig.Walls, _Theme);
                    else tile = pRoom.Tiles[x, y];
                    
                    TileContainer container = tile.Config.GetTile(tile.Theme);
                    if (container.Ground != null)
                    {
                        _GroundMap.SetTile(new Vector3Int(tile.Position.x, tile.Position.y, 0), container.Ground);
                    }
                    if (container.Decor != null)
                    {
                        _DecorMap.SetTile(new Vector3Int(tile.Position.x, tile.Position.y, 0), container.Decor);
                    }
                }
            }
        }
    }
}
