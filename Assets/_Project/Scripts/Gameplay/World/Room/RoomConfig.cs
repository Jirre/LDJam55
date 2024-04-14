using JvLib.Data;
using UnityEngine;

namespace Project.Gameplay.World
{
    public partial class RoomConfig : DataEntry
    {
        [SerializeField] private ERoomType _Type;
        public ERoomType Type => _Type;
        
        [SerializeField] private EDirection _Passages;
        public EDirection Passages => _Passages;

        [SerializeField] private Texture2D _Layout;
        public Texture2D Layout => _Layout;
        
        [SerializeField] private SerializableDictionary<EDirection, Vector2Int> _PlayerSpawnAreas;
    }
}