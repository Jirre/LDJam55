using JvLib.Data;
using UnityEngine;

namespace Project.Gameplay.World.Tiles
{
    [CreateAssetMenu(
        menuName = "Project/World/Tiles",
        fileName = nameof(TileConfigs),
        order = 172)]
    public class TileConfigs : DataList<TileConfig>
    {
    }
}
