using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class OkEducDecorator
    {
        private OK_Educ Education;

        public OkEducDecorator(OK_Educ educ)
        {
            this.Education = educ;
        }

        public override string ToString()
        {
            return Education.EducationType.EduTypeName + ", " + Education.EducWhen;
        }
    }
}
