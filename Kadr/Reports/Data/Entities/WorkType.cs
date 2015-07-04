using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reports
{
    public partial class WorkType
    {
        public override string ToString()
        {
            return TypeWorkName;
        }

        public static WorkType[] Vacancy
        {
            get
            {
                WorkType Vac = new WorkType();
                Vac.id = 0;
                Vac.TypeWorkName = "Вакансия";
                Vac.idWorkSuperType = 1;
                Vac.IsMain = false;
                Vac.IsReplacement = false;
                Vac.TypeWorkShortName = "Вакансия";
                WorkType[] workTypes = { Vac };
                return workTypes;
            }
        }
    }


}
