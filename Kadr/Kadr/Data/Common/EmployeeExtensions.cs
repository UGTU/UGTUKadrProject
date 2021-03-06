﻿using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using APG.Base;

namespace Kadr.Data.Common
{
    public static class EmployeeExtensions
    {
        /// <summary>
        /// Получает возраст сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Возраст</returns>
        public static DateSpan GetAge(this Employee employee)
        {
            if (!employee.BirthDate.HasValue) return null;
            var today = DateTime.Today;
            var birthDate = employee.BirthDate.Value;
            return new DateSpanDifference(birthDate, today);
        }
    }
}
