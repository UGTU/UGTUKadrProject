using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    public static class EmployeeExtensions
    {
        public static int? GetAge(this Employee employee)
        {
            if (!employee.BirthDate.HasValue) return default(int?);
            var today = DateTime.Today;
            var birthDate = employee.BirthDate.Value;
            var yearsDiff = today.Year - birthDate.Year;
            if (today.Month < birthDate.Month) yearsDiff -= 1;
            return yearsDiff;
        }
    }
}
