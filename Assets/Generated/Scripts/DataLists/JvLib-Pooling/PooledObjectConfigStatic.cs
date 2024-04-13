using JvLib.Data;

namespace JvLib.Pooling.Data.Objects
{
    public partial class PooledObjectConfig
    {
        private static JvLib.Pooling.Data.Objects.PooledObjectConfigs values;

        public static JvLib.Pooling.Data.Objects.PooledObjectConfigs Values
        {
            get
            {
                if (values == null)
                    values = (JvLib.Pooling.Data.Objects.PooledObjectConfigs)DataRegistry.GetList("59e5ce10c9334a84999ee081725105f3");
                return values;
            }
        }


    }
}

