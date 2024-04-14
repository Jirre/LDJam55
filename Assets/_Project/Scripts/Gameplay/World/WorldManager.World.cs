using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Project.Gameplay.World
{
    public partial class WorldManager // World
    {
        [SerializeField] private int _MinRoomCount, _MaxRoomCount;

        [SerializeField] private float _ConnectionChance = 0.75f;
        
        public void GenerateWorld()
        {
            DisposeRooms();
            
            Vector2Int source = Vector2Int.zero;

            int roomCount = Random.Range(_MinRoomCount, _MaxRoomCount);
            
            List<Vector2Int> openList = new List<Vector2Int>
            {
                source
            };

            _rooms.Add(source, new Room(source));

            while (_rooms.Count < roomCount &&
                   openList.Count > 0)
            {
                CreateRoom(ref source, ref openList);
            }
            
            foreach (KeyValuePair<Vector2Int,Room> kvp in _rooms)
            {
                kvp.Value.Build(_Theme, ERoomType.Default);
            }
            
            GenerateRoom(_rooms[Vector2Int.zero]);
        }

        private void CreateRoom(ref Vector2Int source, ref List<Vector2Int> openList)
        {
            Vector2Int[] targets = CheckConnections(_rooms[source].Passages, source);
            int t = Random.Range(0, targets.Length);
            for (int i = 0; i < targets.Length; i++)
            {
                Vector2Int target = targets[(t + i) % targets.Length];
                if (_rooms.ContainsKey(target) && Random.value < _ConnectionChance)
                    continue;
                    
                if (!_rooms.ContainsKey(target))
                    _rooms.Add(target, new Room(target));
                    
                _rooms[source].AddPassage(target);
                _rooms[target].AddPassage(source);
                if (CheckConnections(_rooms[target].Passages, source).Length <= 0)
                    openList.Remove(target);
                openList.Add(target);
                    
                source = target;
                return;
            }
            
            source = openList.Random();
        }

        private void DisposeRooms()
        {
            _rooms ??= new Dictionary<Vector2Int, Room>();
            _rooms.Clear();
        }

        private Vector2Int[] CheckConnections(EDirection directions, Vector2Int pPosition)
        {
            List<Vector2Int> targets = new List<Vector2Int>();
            if (!directions.HasFlag(EDirection.North)) 
                targets.Add(pPosition + Vector2Int.up);
            if (!directions.HasFlag(EDirection.East)) 
                targets.Add(pPosition + Vector2Int.right);
            if (!directions.HasFlag(EDirection.South)) 
                targets.Add(pPosition + Vector2Int.down);
            if (!directions.HasFlag(EDirection.West)) 
                targets.Add(pPosition + Vector2Int.left);

            return targets.ToArray();
        }
    }
}
