
--select * from [dbo].[GetPlanStaffByPeriod]('1.07.2015','1.07.2015') where idPlanStaff=1530
CREATE FUNCTION [dbo].[GetPlanStaffByPeriod] 
(
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL
)
RETURNS TABLE

AS
	RETURN
	
	(SELECT DISTINCT PlanStaff.id idPlanStaff, /*MAX*/(StaffCount), idCategory, idDepartment, idPost, idFinancingSource,
		Department.SeverKoeff, Department.RayonKoeff, idOKVED
	FROM  PlanStaffWithHistory as PlanStaff inner join dbo.Post
		ON PlanStaff.idPost=Post.id 
		INNER JOIN dbo.Department ON PlanStaff.idDepartment=Department.id 
	inner join
	(SELECT PlanStaff.id, MAX(PlanStaff.idPlanStaffHistory) MaxID
	FROM PlanStaffWithHistory as PlanStaff
	WHERE 
		((PlanStaff.DateBegin<=@PeriodBegin AND (PlanStaff.DateEnd>@PeriodBegin OR PlanStaff.DateEnd IS NULL))
								OR (PlanStaff.DateBegin>@PeriodBegin AND PlanStaff.DateBegin<@PeriodEnd))
	GROUP BY PlanStaff.id)LastPlanStaff
	ON PlanStaff.id=LastPlanStaff.id AND PlanStaff.idPlanStaffHistory=LastPlanStaff.MaxID
	--GROUP BY PlanStaff.id, idCategory, idDepartment, idPost, idFinancingSource,
	--	Department.SeverKoeff, Department.RayonKoeff 									  
)

