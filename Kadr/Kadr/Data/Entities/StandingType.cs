using System;
using System.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public static class RStandingTypeExtensions
    {
        /// <summary>
        /// Получает вид работы
        /// </summary>
        /// <param name="standingType">Вид работы по трудовой книжке</param>
        /// <returns>Вид работы</returns>
        public static KindOfExperience GetKindOfExperience(this StandingType standingType)
        {
            var values = Enum.GetValues(typeof(KindOfExperience)).Cast<int>();
            if (values.Contains(standingType.id))
                return (KindOfExperience)standingType.id;
            return KindOfExperience.Other;
        }
    }

    public partial class StandingType : CompareObject, INull
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
