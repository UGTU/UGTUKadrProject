using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    public static class VacationPlanExstensions
    {
        public static IEnumerable<ViewVacationPlan> AsVacationPlanView(this IEnumerable<FetchVacationPlansByDepartmentIdResult> resultSet)
        {
            return resultSet.Select(x => new ViewVacationPlan() { CountDay = x.CountDay.GetValueOrDefault(), DateBegin = x.DateBegin.GetValueOrDefault(), DateEnd = x.DateEnd.GetValueOrDefault(), FirstName = x.FirstName, LastName = x.LastName, Otch = x.Otch, OtpuskYear = x.OtpuskYear.GetValueOrDefault(), PostName = x.PostName, DepartmentName = x.DepartmentName});
        }
    }
}
