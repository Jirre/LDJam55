using UnityEngine;

namespace Project.Gameplay.World.Tiles
{
    public class AnimatedTileBehaviour : ATileBehaviour
    {
        [SerializeField] private Sprite[] _Sprites;
        [SerializeField] private float _TotalDuration;
        private int _frame = -1;
        
        internal override void SetTile(Tile pContext)
        {
            throw new System.NotImplementedException();
        }

        private void Update()
        {
            if (Mathf.FloorToInt(Time.time / _TotalDuration) % _Sprites.Length == _frame) return;
            
            _frame = Mathf.FloorToInt(Time.time / _TotalDuration) % _Sprites.Length;
            Renderer.sprite = _Sprites[_frame];
        }
    }
}
