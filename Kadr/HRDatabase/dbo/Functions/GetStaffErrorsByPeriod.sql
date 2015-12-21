--select * from [dbo].[GetStaffErrorsByPeriod](266,'1.07.2015','1.07.2015',1)where idPlanStaff=1066
--select * from [dbo].[GetFactStaffByPeriod]('1.07.2015','1.07.2015') where idPlanStaff=1530
--select * from [dbo].[GetStaffErrorsByPeriod](1,'9.08.2014','9.12.2014',1)where idPlanStaff=1066
--Возвращает все переполнения ставок за период
CREATE FUNCTION [dbo].[GetStaffErrorsByPeriod] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
    DepartmentName VARCHAR(500), 
	PostName VARCHAR(150),
	idDepartment INT,
	idPlanStaff INT,
	BeginPlanStaffCount NUMERIC(6,4),
	BeginFactStaffCount NUMERIC(6,4),
	EndPlanStaffCount  NUMERIC(6,4),
	EndFactStaffCount  NUMERIC(6,4),
	[FinancingSourceName] VARCHAR(50)
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN;
	
	WITH DepTable (idDepartment, DepartmentName)	
	AS
	(SELECT idDepartment, DepartmentName
			FROM dbo.[GetDepartmentDataForReports](@idDepartment, @PeriodBegin, @PeriodEnd, @WithSubDeps,-1))


	INSERT INTO @Result
	SELECT ISNULL(BeginPeriodData.DepartmentName, EndPeriodData.DepartmentName) DepartmentName, 
			ISNULL(BeginPeriodData.PostName, EndPeriodData.PostName) PostName,
			ISNULL(BeginPeriodData.idDepartment, EndPeriodData.idDepartment) idDepartment,
			ISNULL(BeginPeriodData.id, EndPeriodData.id) idPlanStaff,
			BeginPeriodData.StaffCount as BeginPlanStaffCount,
			BeginPeriodData.FactStaffCount as BeginFactStaffCount,
			EndPeriodData.StaffCount as EndPlanStaffCount,
			EndPeriodData.FactStaffCount as EndFactStaffCount,
			ISNULL(BeginPeriodData.[FinancingSourceName], EndPeriodData.[FinancingSourceName]) [FinancingSourceName]
	FROM  						
	(SELECT deps.DepartmentName, Post.PostName, PlanStaff.idDepartment, FinancingSourceName, 
		PlanStaff.id, CurrentPlanStaff.StaffCount, SUM(FactStaff.StaffCount) FactStaffCount
		FROM 
		DepTable deps INNER JOIN
		[dbo].[PlanStaffCurrent] PlanStaff ON deps.idDepartment=PlanStaff.idDepartment
		INNER JOIN 
		[dbo].[GetFactStaffByPeriod](@PeriodBegin,@PeriodBegin)FactStaff
		ON PlanStaff.id=FactStaff.idPlanStaff AND FactStaff.IsReplacement=0 AND
			idFactStaff NOT IN (SELECT [idFactStaff] FROM [dbo].[FactStaffReplacement] WHERE [DateEnd] > @PeriodBegin)
		INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id 
		INNER JOIN [dbo].[FinancingSource] ON PlanStaff.idFinancingSource=FinancingSource.id
		LEFT JOIN
		[dbo].[GetPlanStaffByPeriod](@PeriodBegin,@PeriodBegin) CurrentPlanStaff ON PlanStaff.id=CurrentPlanStaff.idPlanStaff 
		GROUP BY deps.DepartmentName, Post.PostName, PlanStaff.idDepartment, PlanStaff.id, CurrentPlanStaff.StaffCount, FinancingSourceName
		HAVING ISNULL(CurrentPlanStaff.StaffCount,0)<SUM(FactStaff.StaffCount) )BeginPeriodData
	FULL JOIN
	(SELECT deps.DepartmentName, Post.PostName, PlanStaff.idDepartment, FinancingSourceName, 
		PlanStaff.id, CurrentPlanStaff.StaffCount, SUM(FactStaff.StaffCount) FactStaffCount
		FROM 
		DepTable deps INNER JOIN
		[dbo].[PlanStaffCurrent] PlanStaff ON deps.idDepartment=PlanStaff.idDepartment
		INNER JOIN 
		[dbo].[GetFactStaffByPeriod](@PeriodEnd,@PeriodEnd)FactStaff
		ON PlanStaff.id=FactStaff.idPlanStaff AND FactStaff.IsReplacement=0 AND
			idFactStaff NOT IN (SELECT [idFactStaff] FROM [dbo].[FactStaffReplacement] WHERE [DateEnd] > @PeriodBegin)
		INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id 
		INNER JOIN [dbo].[FinancingSource] ON PlanStaff.idFinancingSource=FinancingSource.id
		LEFT JOIN
		[dbo].[GetPlanStaffByPeriod](@PeriodEnd,@PeriodEnd) CurrentPlanStaff ON PlanStaff.id=CurrentPlanStaff.idPlanStaff 
		GROUP BY deps.DepartmentName, Post.PostName, PlanStaff.idDepartment, PlanStaff.id, CurrentPlanStaff.StaffCount, FinancingSourceName
		HAVING ISNULL(CurrentPlanStaff.StaffCount,0)<SUM(FactStaff.StaffCount) )EndPeriodData	
	ON BeginPeriodData.id=EndPeriodData.id
		  
RETURN
END





