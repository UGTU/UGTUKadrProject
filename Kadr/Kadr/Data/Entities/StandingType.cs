using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class StandingType : INull
    {
        public override string ToString()
        {
            return StandingTypeName;
        }

        #region Члены INull

        bool INull.IsNull()
        {
            return false;
        }

        #endregion
    }

    public class NullStandingType : StandingType, INull
    {

        private NullStandingType()
        {
            this.id = 0;
            StandingTypeName = "(Не задан)";
        }

        public static readonly NullStandingType Instance = new NullStandingType();

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
