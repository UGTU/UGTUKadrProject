using System;
using System.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public static class RegionTypeExtensions
    {
        /// <summary>
        /// Получает территориальные условия региона
        /// </summary>
        /// <param name="regionType">Тип региона</param>
        /// <returns>Территориальные условия</returns>
        public static TerritoryConditions GetTerritoryCondition(this RegionType regionType)
        {
            var values = Enum.GetValues(typeof (TerritoryConditions)).Cast<int>();
            if (values.Contains(regionType.id))
                return (TerritoryConditions) regionType.id;
            return TerritoryConditions.Default;
        }
    }
    public  partial class RegionType: INull
    {
        public override string ToString()
        {
            return RegionTypeSmallName;
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
            RegionTypeSmallName = "(Не задан)";
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
