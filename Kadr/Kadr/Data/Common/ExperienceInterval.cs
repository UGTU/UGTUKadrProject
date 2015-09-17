using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APG.Base;

namespace Kadr.Data.Common
{
    public class ExperienceInterval : IEmployeeExperienceRecord
    {
        private readonly IEmployeeExperienceRecord _sourceRecord;
        private readonly DateTime _begin;
        private readonly DateTime _end;

        public ExperienceInterval(IEmployeeExperienceRecord sourceRecord, DateTime begin, DateTime end)
        {
            if (sourceRecord == null) throw new ArgumentNullException("sourceRecord");
            _sourceRecord = sourceRecord;
            _begin = begin;
            _end = end;
        }

        /// <summary>
        /// Признак того, что этот стаж имеет дату завершения
        /// </summary>
        public bool IsEnded { get { return _sourceRecord.IsEnded; } }

        /// <summary>
        /// Получает территориальные условия работы
        /// </summary>
        public TerritoryConditions Territory { get { return _sourceRecord.Territory; } }

        /// <summary>
        /// Получает вид стажа
        /// </summary>
        public KindOfExperience Experience { get { return _sourceRecord.Experience; } }

        /// <summary>
        /// Получает принадлежность стажа организации
        /// </summary>
        public Affilations Affilation { get { return _sourceRecord.Affilation; } }

        /// <summary>
        /// Получает тип стажа в организации
        /// </summary>
        public WorkOrganizationWorkType WorkWorkType { get { return _sourceRecord.WorkWorkType; } }

        public DateTime Start { get { return _sourceRecord.Start; }
            set { }
        }

        public DateTime Stop { get { return _sourceRecord.Stop; }
            set { }
        }
    }
}
