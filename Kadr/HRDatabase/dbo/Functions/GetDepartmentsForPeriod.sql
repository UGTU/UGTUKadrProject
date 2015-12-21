
--select * from [dbo].[GetDepartmentsForPeriod]('28.2.2013', '28.2.2013') where idDepartment=149
--Возвращает отделы на период: т.е. отдел существует в периоде и выводится название этого периода
CREATE FUNCTION [dbo].[GetDepartmentsForPeriod] 
(
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
RETURNS  TABLE
 AS
RETURN

(	SELECT DepartmentHistory.idDepartment, idManagerDepartment, DepartmentName, DepartmentSmallName
	FROM  
	dbo.Dep INNER JOIN
	dbo.DepartmentHistory as DepartmentHistory
	ON  Dep.id=DepartmentHistory.idDepartment
	INNER JOIN							
	(SELECT DepartmentHistory.idDepartment, MAX(DateBegin) as DateBegin
	FROM  dbo.DepartmentHistory as DepartmentHistory 
	WHERE DateBegin<@PeriodEnd
	GROUP BY DepartmentHistory.idDepartment) LastDepartmentHistory
	ON DepartmentHistory.idDepartment=LastDepartmentHistory.idDepartment AND DepartmentHistory.DateBegin=LastDepartmentHistory.DateBegin
	
	WHERE 
		((DepartmentHistory.DateBegin<=@PeriodBegin AND (Dep.dateExit>=@PeriodBegin OR Dep.dateExit IS NULL))
								OR (DepartmentHistory.DateBegin>=@PeriodBegin AND DepartmentHistory.DateBegin<=@PeriodEnd))
)




