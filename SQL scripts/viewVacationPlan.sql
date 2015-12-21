USE [Kadr]
GO

/****** Object:  View [dbo].[ViewVacationPlan]    Script Date: 18.12.2015 14:27:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER view [dbo].[ViewVacationPlan] as
SELECT distinct       
dbo.Employee.FirstName, dbo.Employee.LastName, dbo.Employee.Otch
,dbo.Post.PostName,  dbo.UptodateDepartmentHistory.DepartmentName, dbo.Dep.DepartmentGUID, DepManager.DepartmentGUID as [DepManagerGUID],
dbo.OK_OtpuskPlan.DateBegin, dbo.OK_OtpuskPlan.DateEnd, dbo.OK_OtpuskPlan.OtpuskYear,   dbo.OK_OtpuskPlan.CountDay
FROM            dbo.Employee INNER JOIN
                        dbo.FactStaff ON dbo.Employee.id = dbo.FactStaff.idEmployee 						
						 INNER JOIN dbo.PlanStaff ON dbo.FactStaff.idPlanStaff = dbo.PlanStaff.id 
						 INNER JOIN  dbo.Post ON dbo.PlanStaff.idPost = dbo.Post.id
						 inner JOIN dbo.OK_OtpuskPlan ON dbo.FactStaff.id = dbo.OK_OtpuskPlan.idFactStaff
						 INNER JOIN  dbo.Dep ON dbo.PlanStaff.idDepartment = dbo.Dep.id 
						 INNER JOIN  dbo.UptodateDepartmentHistory ON dbo.Dep.id = dbo.UptodateDepartmentHistory.idDepartment 
						 inner join  dbo.Dep DepManager on [dbo].[UptodateDepartmentHistory].idManagerDepartment = DepManager.id	 
								
GO

CREATE FUNCTION dbo.FetchVacationPlansByDepartmentId(@DepartmenGuid uniqueidentifier, @Year int) RETURNS TABLE 
AS
RETURN 
(
	WITH tblChild AS
	(
		SELECT *
			FROM ViewVacationPlan WHERE DepManagerGUID = @DepartmenGuid and OtpuskYear = @Year
		UNION ALL
			SELECT ViewVacationPlan.* FROM ViewVacationPlan  JOIN tblChild  ON ViewVacationPlan.DepManagerGUID = tblChild.DepartmentGUID and ViewVacationPlan.OtpuskYear = @Year
	) select * from tblChild
)

GO

select * from FetchVacationPlansByDepartmentId('{BAEE3FD5-664D-E111-96A2-0018FE865BEC}', 2016)


