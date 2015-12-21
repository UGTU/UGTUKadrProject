

--select * from [dbo].[GetDepartmentByPeriod]('1.02.2015,'1.03.2015')where [idDepartment]=149
CREATE FUNCTION [dbo].[GetDepartmentByPeriod] 
(
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL
)
RETURNS  TABLE
AS
RETURN
(
	
	--INSERT INTO @Result([idDepartment],[idManagerDepartment],[idManagerPlanStaff],[idFundingCenter],
		--	[idBeginPrikaz],DateBegin, [DepartmentName], [DepartmentSmallName]/*,[SeverKoeff],[RayonKoeff]*/)
	SELECT Department.id [idDepartment],[idManagerDepartment],[idManagerPlanStaff],[idFundingCenter],
			[idBeginPrikaz],Department.DateBegin,--,[SeverKoeff],[RayonKoeff]
			[DepartmentName], [DepartmentSmallName], Department.idOKVED
	FROM  dbo.DepartmentWithHistory as Department 
	INNER JOIN							
	(SELECT Department.id, MAX(DateBegin) as DateBegin
	FROM  dbo.DepartmentWithHistory as Department 
	WHERE 
		((Department.DateBegin<=@PeriodBegin AND (Department.dateExit>=@PeriodBegin OR Department.dateExit IS NULL))
								OR (Department.DateBegin>=@PeriodBegin AND Department.DateBegin<=@PeriodEnd))
	GROUP BY Department.id) LastDepartment
	ON Department.id=LastDepartment.id AND Department.DateBegin=LastDepartment.DateBegin
	--group by FactStaff.id, idPlanStaff, idEmployee, idTypeWork, IsReplacement, LastFactStaff.DateBegin		  
)



