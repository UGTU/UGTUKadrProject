--select * from [dbo].[GetIndivSalaryByPeriod]('20.09.2010','20.09.2010')
create FUNCTION [dbo].[GetIndivSalaryByPeriod] 
(
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
RETURNS  TABLE
 
AS

RETURN
	(SELECT PlanStaffSalary.id idSalary, idPlanStaff, SalarySize 
	FROM  dbo.PlanStaffSalary
		 
	WHERE 
		((PlanStaffSalary.DateBegin<=@PeriodBegin AND (PlanStaffSalary.DateEnd>=@PeriodBegin OR PlanStaffSalary.DateEnd IS NULL))
								OR (PlanStaffSalary.DateBegin>=@PeriodBegin AND PlanStaffSalary.DateBegin<=@PeriodEnd))		  
)


