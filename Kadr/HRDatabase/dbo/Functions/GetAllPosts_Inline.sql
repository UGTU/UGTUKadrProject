
--select * from [dbo].[GetAllPosts](1, '01.01.2014','01.01.2014',1) 
create FUNCTION [dbo].[GetAllPosts_Inline] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
@WithSubDeps BIT
)
RETURNS  TABLE

AS
RETURN
(select DISTINCT GlobalPrikaz.PrikazName, staff.PKCategoryName, salary.SalarySize, Post.PostName, @PeriodBegin PeriodBegin,@PeriodEnd PeriodEnd
from [dbo].[GetDepartmentStaff](1, @PeriodBegin,@PeriodEnd,1)staff
INNER JOIN [dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd)salary
	ON staff.idPlanStaff=salary.idPlanStaff
INNER JOIN dbo.Post ON staff.idPost=Post.id
INNER JOIN dbo.GlobalPrikaz ON Post.idGlobalPrikaz=GlobalPrikaz.id
)

