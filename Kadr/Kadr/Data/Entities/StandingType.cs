﻿using System;
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
            if (standingType == null) throw new ArgumentNullException(nameof(standingType));
            var values = Enum.GetValues(typeof(KindOfExperience)).Cast<int>();
            if (values.Contains(standingType.id))
                return (KindOfExperience)standingType.id;
            return KindOfExperience.Other;
        }
    }

    public partial class StandingType : CompareObject, INullable
    {
        public override string ToString()
        {
            return StandingTypeName;
        }

        public static StandingType DefaultStadingType
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.StandingTypes.Where(StT => StT.id == 1).FirstOrDefault();
            }
        }

    }

    public class NullStandingType : StandingType, INull
    {

        private NullStandingType()
        {
            this.id = 0;
            StandingTypeName = "(Не задан)";
        }

        public static readonly NullStandingType Instance = new NullStandingType();

        public override string ToString()
        {
            return "(Не задан)";
        }

    }
}
