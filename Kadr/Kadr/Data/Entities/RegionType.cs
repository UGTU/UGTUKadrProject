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
    public  partial class RegionType: INullable
    {
        public static RegionType UsualConditionRegionType
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.RegionTypes.Where(RT => RT.id == 1).FirstOrDefault();
            }
        }
        
        public override string ToString()
        {
            return RegionTypeSmallName;
        }

    }

    public class NullRegionType : RegionType, INull
    {

        private NullRegionType()
        {
            this.id = 0;
            RegionTypeSmallName = "(Не задан)";
        }

        public static readonly NullRegionType Instance = new NullRegionType();



        public override string ToString()
        {
            return "(Не задан)";
        }

    }
}
