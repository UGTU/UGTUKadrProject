USE [Kadr]
GO

/****** Object:  View [dbo].[PlanStaffsWithSalaries]    Script Date: 10/14/2010 13:32:08 ******/

GO



ALTER VIEW [dbo].[pkCategorySalaryView]
AS
SELECT distinct    
	pkCategory.*,
	PKCategorySalary.SalarySize,
	DateBegin, DateEnd
FROM dbo.pkCategory,  dbo.PKCategorySalary 
where  pkCategory.id= PKCategorySalary.idPKCategory 
and   (DateEnd is null or DateEnd>GETDATE())



GO

SELECT  *
  FROM [Kadr].[dbo].[PlanStaffsWithSalaries]

go
ALTER VIEW [dbo].[PlanStaffsWithSalaries]
AS
SELECT     dbo.PlanStaff.id as idPlanStaff, ISNULL(dbo.PlanStaffSalary.SalarySize, PKCategorySalary.SalarySize) as SalarySize
FROM         
	dbo.PlanStaff INNER JOIN
	 dbo.Post ON PlanStaff.idPost=Post.id	
		 INNER JOIN
      dbo.PKCategory ON Post.idPKCategory = dbo.PKCategory.id INNER JOIN
      dbo.PKCategorySalary ON dbo.PKCategory.id = dbo.PKCategorySalary.idPKCategory
      AND (PKCategorySalary.DateEnd IS NULL OR PKCategorySalary.DateEnd>= GETDATE()) AND PKCategorySalary.DateBegin<=GETDATE()
	LEFT JOIN
      dbo.PlanStaffSalary ON dbo.PlanStaff.id = dbo.PlanStaffSalary.idPlanStaff 
		AND (PlanStaffSalary.DateEnd IS NULL OR PlanStaffSalary.DateEnd>= GETDATE()) AND PlanStaffSalary.DateBegin<=GETDATE()
GO


