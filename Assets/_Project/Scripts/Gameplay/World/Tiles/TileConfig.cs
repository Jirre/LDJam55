using System;
using System.Linq;
using JvLib.Data;
using JvLib.Inspector;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Project.Gameplay.World.Tiles
{
    public partial class TileConfig : DataEntry
    {
        [SerializeField] private ETileType _Type;
        public ETileType Type => _Type;

        [SerializeField, PrefabOnly] private SerializableDictionary<EWorldTheme, TileContainer> _Tiles;
        public EWorldTheme[] Themes => _Tiles.Keys.ToArray();
        
        public TileContainer GetTile(EWorldTheme pTheme)
        {
            if (_Tiles?.TryGetValue(pTheme, out TileContainer result) ?? false)
                return result;

            throw new ArgumentOutOfRangeException(nameof(pTheme),
                $"No Tile registered for theme {pTheme} in Tile {Name}");
        }
    }

    [Serializable]
    public struct TileContainer
    {
        public TileBase Ground;
        public TileBase Decor;
    }
}