using UnityEngine;

namespace Project.Gameplay.World.Tiles
{
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class ATileBehaviour : MonoBehaviour
    {
        protected SpriteRenderer Renderer;
        
        private void Awake()
        {
            Renderer = GetComponent<SpriteRenderer>();
        }

        internal abstract void SetTile(Tile pContext);
    }
}
