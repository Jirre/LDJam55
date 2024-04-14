using JvLib.Data;
using UnityEngine;

namespace Project.Gameplay.World
{
    [CreateAssetMenu(
        menuName = "Project/World/Rooms",
        fileName = nameof(RoomConfigs),
        order = 172)]
    public class RoomConfigs : DataList<RoomConfig>
    {
    }
}
