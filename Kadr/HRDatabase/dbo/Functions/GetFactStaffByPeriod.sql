--select * from [dbo].[GetFactStaffByPeriod]('12.11.2012','12.11.2012')where idPlanStaff=1066
CREATE FUNCTION [dbo].[GetFactStaffByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS  TABLE
 
AS
RETURN
(SELECT FactStaff.id idFactStaff, idPlanStaff, idEmployee, idTypeWork, StaffCount,  
	IsReplacement, LastFactStaff.DateBegin, HourCount, HourSalary, idSalaryKoeff,
	FactStaff.[idlaborcontrakt], FactStaff.[idreason], [CalcStaffCount], HourStaffCount,
	FactStaff.idFactStaffHistory, FactStaff.idOKVED

	FROM  dbo.FactStaffWithHistory as FactStaff 
	INNER JOIN							
	(SELECT FactStaff.id, MAX(DateBegin) as DateBegin
	FROM  dbo.FactStaffWithHistory as FactStaff 
	WHERE 
		((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
								OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
	GROUP BY FactStaff.id) LastFactStaff
	ON FactStaff.id=LastFactStaff.id AND FactStaff.DateBegin=LastFactStaff.DateBegin
	)

