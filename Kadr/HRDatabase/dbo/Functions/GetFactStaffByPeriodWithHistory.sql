--select * from [dbo].[GetFactStaffByPeriodWithHistory]('20.01.2014','20.12.2014')where idPlanStaff=1066
CREATE FUNCTION [dbo].[GetFactStaffByPeriodWithHistory] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS  TABLE

AS
RETURN	(SELECT FactStaff.id idFactStaff, idPlanStaff, idEmployee, idTypeWork, FactStaff.StaffCount, CalcStaffCount, IsReplacement, idDepartment, HourCount, HourSalary, FactStaff.id
	FROM  dbo.FactStaffWithHistory as FactStaff, PlanStaff 
	WHERE
		((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
								OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
		AND FactStaff.idPlanStaff=PlanStaff.id)