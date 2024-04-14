using JvLib.Data;

namespace Project.Gameplay.World.Tiles
{
    public partial class TileConfig
    {
        private static Project.Gameplay.World.Tiles.TileConfigs values;
        private static Project.Gameplay.World.Tiles.TileConfig walls;
        private static Project.Gameplay.World.Tiles.TileConfig floor;
        private static Project.Gameplay.World.Tiles.TileConfig safezone;
        private static Project.Gameplay.World.Tiles.TileConfig liquid;
        private static Project.Gameplay.World.Tiles.TileConfig decor;
        private static Project.Gameplay.World.Tiles.TileConfig altDecor;
        private static Project.Gameplay.World.Tiles.TileConfig door;

        public static Project.Gameplay.World.Tiles.TileConfigs Values
        {
            get
            {
                if (values == null)
                    values = (Project.Gameplay.World.Tiles.TileConfigs)DataRegistry.GetList("f92cc076e9f82834e9f8e6145f528ce6");
                return values;
            }
        }

        public static Project.Gameplay.World.Tiles.TileConfig Walls
        {
            get
            {
                if (walls == null && Values != null)
                    walls = (Project.Gameplay.World.Tiles.TileConfig)Values.GetEntry("637e756cdc2e73c4ab9a1fa97536b759");
                return walls;
            }
        }

        public static Project.Gameplay.World.Tiles.TileConfig Floor
        {
            get
            {
                if (floor == null && Values != null)
                    floor = (Project.Gameplay.World.Tiles.TileConfig)Values.GetEntry("1a9173a860e38b641bd6f72ea5f281c9");
                return floor;
            }
        }

        public static Project.Gameplay.World.Tiles.TileConfig Safezone
        {
            get
            {
                if (safezone == null && Values != null)
                    safezone = (Project.Gameplay.World.Tiles.TileConfig)Values.GetEntry("7b6b65f3827461a43b3bb822550cb238");
                return safezone;
            }
        }

        public static Project.Gameplay.World.Tiles.TileConfig Liquid
        {
            get
            {
                if (liquid == null && Values != null)
                    liquid = (Project.Gameplay.World.Tiles.TileConfig)Values.GetEntry("c2260d3a551a31f4cb5d47a740efe95f");
                return liquid;
            }
        }

        public static Project.Gameplay.World.Tiles.TileConfig Decor
        {
            get
            {
                if (decor == null && Values != null)
                    decor = (Project.Gameplay.World.Tiles.TileConfig)Values.GetEntry("ad12cab7f43638a4ba83c70dd69b4637");
                return decor;
            }
        }

        public static Project.Gameplay.World.Tiles.TileConfig AltDecor
        {
            get
            {
                if (altDecor == null && Values != null)
                    altDecor = (Project.Gameplay.World.Tiles.TileConfig)Values.GetEntry("b82dae1b54ebe6646938f4a151fa5052");
                return altDecor;
            }
        }

        public static Project.Gameplay.World.Tiles.TileConfig Door
        {
            get
            {
                if (door == null && Values != null)
                    door = (Project.Gameplay.World.Tiles.TileConfig)Values.GetEntry("484292c85bec8664f84716157063221d");
                return door;
            }
        }

    }
}

