using System;
using UnityEngine;

namespace Project.Gameplay.World
{
    [Serializable]
    public class PlayerSpawnData
    {
        [SerializeField] private EDirection _EntryDirection;
        public EDirection EntryDirection => _EntryDirection;

        [SerializeField] private Vector2Int _Position;
        public Vector2Int Position => _Position;
    }
}
