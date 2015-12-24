
CREATE view [dbo].[ViewVacationPlan] as
SELECT DISTINCT 
                  dbo.Employee.FirstName, dbo.Employee.LastName, dbo.Employee.Otch, dbo.Post.PostName, dbo.UptodateDepartmentHistory.DepartmentName, dbo.Dep.DepartmentGUID, 
                  DepManager.DepartmentGUID AS DepManagerGUID, dbo.OK_OtpuskPlan.DateBegin, dbo.OK_OtpuskPlan.DateEnd, dbo.OK_OtpuskPlan.OtpuskYear, dbo.OK_OtpuskPlan.CountDay, 
                  dbo.WorkType.TypeWorkName
FROM     dbo.Dep INNER JOIN
                  dbo.UptodateDepartmentHistory ON dbo.Dep.id = dbo.UptodateDepartmentHistory.idDepartment LEFT OUTER JOIN
                  dbo.Dep AS DepManager ON dbo.UptodateDepartmentHistory.idManagerDepartment = DepManager.id LEFT OUTER JOIN
                  dbo.PlanStaff ON dbo.PlanStaff.idDepartment = dbo.Dep.id LEFT OUTER JOIN
                  dbo.FactStaff ON dbo.FactStaff.idPlanStaff = dbo.PlanStaff.id LEFT OUTER JOIN
                  dbo.Employee ON dbo.Employee.id = dbo.FactStaff.idEmployee LEFT OUTER JOIN
                  dbo.Post ON dbo.PlanStaff.idPost = dbo.Post.id LEFT OUTER JOIN
                  dbo.FactStaffHistory ON dbo.FactStaff.id = dbo.FactStaffHistory.idFactStaff LEFT OUTER JOIN
                  dbo.WorkType ON dbo.FactStaffHistory.idTypeWork = dbo.WorkType.id LEFT OUTER JOIN
                  dbo.OK_OtpuskPlan ON dbo.FactStaff.id = dbo.OK_OtpuskPlan.idFactStaff