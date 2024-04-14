using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Project.Gameplay.World
{
    public partial class WorldManager : MonoBehaviour
    {
        [SerializeField] private EWorldTheme _Theme;
        private Dictionary<Vector2Int, Room> _rooms;

        [SerializeField] private Tilemap _GroundMap;
        [SerializeField] private Tilemap _DecorMap;

        private void Start()
        {
            BuildTileTable();
            GenerateWorld();
        }

        private void SpawnEnemies()
        {
            
        }
    }
}
