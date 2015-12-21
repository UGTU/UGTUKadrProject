
--select * from [dbo].GetSubDepartmentStaffCounts(1,'20.06.2010','20.06.2010') 
--select * from [dbo].GetSubDepartmentStaffCounts(2)
CREATE FUNCTION [dbo].[GetSubDepartmentStaffCounts] 
(
@idManagerDepartment	INT,
@PeriodBegin			DATETIME,
@PeriodEnd				DATETIME
)
RETURNS @Result TABLE
   (
    idPKCategory		INT NULL,
    planStaffCount     decimal(10,2)    NULL,
    factStaffCount	   decimal(10,4)         	   NULL
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	DECLARE @SubDeps Table
	(
		idDepartment 			INT
	)
	
	INSERT INTO @SubDeps
		SELECT idDepartment FROM [dbo].GetSubDepartmentsWithPeriod(@idManagerDepartment, @PeriodBegin, @PeriodEnd)
		WHERE IsMain=0
	
	INSERT INTO @Result(idPKCategory,planStaffCount,factStaffCount)
		SELECT     
			idPKCategory,
			SUM(PlanStaff.StaffCount) as planCount, SUM(FactStaffCount.factCount) as factCount
		FROM  dbo.PKGroup INNER JOIN
					 dbo.PKCategory ON dbo.PKCategory.idPKGroup = dbo.PKGroup.id LEFT JOIN
					 dbo.Post ON dbo.Post.idPKCategory = dbo.PKCategory.id LEFT JOIN
					 (SELECT * FROM [dbo].[GetPlanStaffByPeriod](@PeriodBegin, @PeriodEnd) as PlanStaff WHERE idDepartment IN
						(SELECT idDepartment FROM @SubDeps))PlanStaff 
					 ON PlanStaff.idPost = dbo.Post.id 
					 LEFT JOIN
					 (SELECT FactStaff.idPlanStaff, SUM(FactStaff.StaffCount) as factCount 
						FROM [dbo].[GetFactStaffByPeriod](@PeriodBegin, @PeriodEnd) FactStaff 
						WHERE FactStaff.idFactStaff NOT IN (SELECT idFactStaff FROM dbo.FactStaffReplacement)
							GROUP BY FactStaff.idPlanStaff)FactStaffCount
						ON PlanStaff.idPlanStaff = FactStaffCount.idPlanStaff 
		GROUP BY idPKCategory

RETURN
END





