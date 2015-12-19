
--SELECT        dbo.Employee.FirstName, dbo.Employee.LastName, dbo.Employee.Otch, dbo.Post.PostName, dbo.OK_OtpuskPlan.DateBegin, dbo.OK_OtpuskPlan.DateEnd, dbo.OK_OtpuskPlan.OtpuskYear, 
--                         dbo.OK_OtpuskPlan.CountDay, dbo.DepartmentHistory.DepartmentName
--FROM            dbo.Employee INNER JOIN
--                         dbo.FactStaff ON dbo.Employee.id = dbo.FactStaff.idEmployee 
--						 INNER JOIN dbo.PlanStaff ON dbo.FactStaff.idPlanStaff = dbo.PlanStaff.id 
--						 INNER JOIN  dbo.Post ON dbo.PlanStaff.idPost = dbo.Post.id
--						 INNER JOIN  dbo.Dep ON dbo.FactStaff.idDepartment = dbo.Dep.id
--						 INNER JOIN  dbo.DepartmentHistory ON dbo.Dep.id = dbo.DepartmentHistory.idDepartment
--						 INNER JOIN dbo.OK_OtpuskPlan ON dbo.FactStaff.id = dbo.OK_OtpuskPlan.idFactStaff


create view ViewVacationPlan as
SELECT distinct       
dbo.Employee.FirstName, dbo.Employee.LastName, dbo.Employee.Otch
,dbo.Post.PostName,  dbo.DepartmentHistory.DepartmentName,
dbo.OK_OtpuskPlan.DateBegin, dbo.OK_OtpuskPlan.DateEnd, dbo.OK_OtpuskPlan.OtpuskYear,   dbo.OK_OtpuskPlan.CountDay
FROM            dbo.Employee INNER JOIN
                        dbo.FactStaff ON dbo.Employee.id = dbo.FactStaff.idEmployee 						
						 INNER JOIN dbo.PlanStaff ON dbo.FactStaff.idPlanStaff = dbo.PlanStaff.id 
						 INNER JOIN  dbo.Post ON dbo.PlanStaff.idPost = dbo.Post.id
						 inner JOIN dbo.OK_OtpuskPlan ON dbo.FactStaff.id = dbo.OK_OtpuskPlan.idFactStaff
						 INNER JOIN  dbo.Dep ON dbo.PlanStaff.idDepartment = dbo.Dep.id
						 INNER JOIN  dbo.DepartmentHistory ON dbo.Dep.id = dbo.DepartmentHistory.idDepartment				