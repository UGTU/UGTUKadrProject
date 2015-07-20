using Kadr.Data.Common;

namespace Kadr.Data
{
    public  partial class RegionType: INull
    {
        public override string ToString()
        {
            return RegionTypeName;
        }

        #region Члены INull

        bool INull.IsNull()
        {
            return false;
        }

        #endregion
    }

    public class NullRegionType : RegionType, INull
    {

        private NullRegionType()
        {
            this.id = 0;
            RegionTypeName = "(Не задан)";
        }

        public static readonly NullRegionType Instance = new NullRegionType();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }
}
