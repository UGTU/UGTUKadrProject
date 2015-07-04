USE [kadr]
GO

/****** Object:  View [dbo].[DepEmplCount]    Script Date: 09/16/2010 11:01:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


GO

--select * from [dbo].GetSubDepartmentStaffCounts(1,'20.06.2010','20.06.2010') 
--select * from [dbo].GetSubDepartmentStaffCounts(2)
alter FUNCTION [dbo].GetSubDepartmentStaffCounts 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idPKCategory		INT NULL,
    planStaffCount     decimal(6,2)    NULL,
    factStaffCount	   decimal(6,2)         	   NULL
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
		SELECT idDepartment FROM [dbo].[GetSubDepartments](@idManagerDepartment)
	
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
						WHERE FactStaff.idPlanStaff NOT IN (SELECT idFactStaff FROM dbo.FactStaffReplacement)
							GROUP BY FactStaff.idPlanStaff)FactStaffCount
						ON PlanStaff.idPlanStaff = FactStaffCount.idPlanStaff 
		GROUP BY idPKCategory

RETURN
END





GO

--select * from [dbo].GetDepartmentStaffCounts(0, '20.01.2011', '20.01.2011') 
--select * from [dbo].GetDepartmentStaffCounts(300, '20.01.2011', '20.01.2011')
--select * from [dbo].GetDepartmentStaffCounts(251, '31.03.2011', '31.03.2011')
alter FUNCTION [dbo].GetDepartmentStaffCounts 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    PKCatName				VARCHAR(150) NULL,
    planStaffCount			decimal(6,2)    NULL,
    factStaffCount			decimal(6,2)         	   NULL,
    subPlanStaffCount		decimal(6,2)    NULL,
    subFactStaffCount		decimal(6,2)         	   NULL
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

	INSERT INTO @Result(PKCatName, planStaffCount, factStaffCount, subPlanStaffCount, subFactStaffCount)
	SELECT 	
		RTRIM(PKGroup.GroupNumber)+' '+RTRIM(PKCategory.PKCategoryNumber) AS PKCatName,
		ISNULL(SUM(PlanStaff.StaffCount),0) as planCount, ISNULL(SUM(FactStaffCount.factCount),0) as factCount,
		ISNULL(SubDepsStaffCount.planStaffCount,0) AS subPlanCount,
		ISNULL(SubDepsStaffCount.factStaffCount,0) AS subFactCount

FROM  --dbo.Department CROSS JOIN      
			dbo.PKGroup INNER JOIN
             dbo.PKCategory ON dbo.PKCategory.idPKGroup = dbo.PKGroup.id LEFT JOIN
             dbo.Post ON dbo.Post.idPKCategory = dbo.PKCategory.id LEFT JOIN
             (SELECT * FROM [dbo].[GetPlanStaffByPeriod](@PeriodBegin, @PeriodEnd) as PlanStaff 
				WHERE idDepartment=@idDepartment)PlanStaff 
				ON PlanStaff.idPost = dbo.Post.id --AND PlanStaff.idDepartment=Department.id 
             LEFT JOIN
			 (SELECT FactStaff.idPlanStaff, SUM(FactStaff.StaffCount) as factCount 
				FROM [dbo].[GetFactStaffByPeriod](@PeriodBegin, @PeriodEnd) as FactStaff 
				WHERE FactStaff.idFactStaff NOT IN (SELECT idFactStaff FROM dbo.FactStaffReplacement)
					GROUP BY FactStaff.idPlanStaff)FactStaffCount
				ON PlanStaff.idPlanStaff = FactStaffCount.idPlanStaff 
		
			LEFT JOIN
			[dbo].GetSubDepartmentStaffCounts(@idDepartment, @PeriodBegin, @PeriodEnd) SubDepsStaffCount
			ON SubDepsStaffCount.idPKCategory=PKCategory.id
GROUP BY dbo.PKGroup.GroupNumber, dbo.PKCategory.PKCategoryNumber,
	SubDepsStaffCount.planStaffCount, SubDepsStaffCount.factStaffCount
ORDER BY PKCatName
	

RETURN
END

