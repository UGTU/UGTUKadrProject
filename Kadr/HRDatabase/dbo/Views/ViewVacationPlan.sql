
CREATE view [dbo].[ViewVacationPlan] as
SELECT DISTINCT 
                  Employee.FirstName, Employee.LastName, Employee.Otch, Post.PostName, UptodateDepartmentHistory.DepartmentName, Dep.DepartmentGUID, DepManager.DepartmentGUID AS DepManagerGUID, 
                  OK_OtpuskPlan.DateBegin, OK_OtpuskPlan.DateEnd, OK_OtpuskPlan.OtpuskYear, OK_OtpuskPlan.CountDay, WorkType.TypeWorkName
FROM     Employee INNER JOIN
                  FactStaff ON Employee.id = FactStaff.idEmployee INNER JOIN
                  PlanStaff ON FactStaff.idPlanStaff = PlanStaff.id INNER JOIN
                  Post ON PlanStaff.idPost = Post.id INNER JOIN
                  OK_OtpuskPlan ON FactStaff.id = OK_OtpuskPlan.idFactStaff INNER JOIN
                  Dep ON PlanStaff.idDepartment = Dep.id INNER JOIN
                  UptodateDepartmentHistory ON Dep.id = UptodateDepartmentHistory.idDepartment INNER JOIN
                  Dep AS DepManager ON UptodateDepartmentHistory.idManagerDepartment = DepManager.id INNER JOIN
                  FactStaffHistory ON FactStaff.id = FactStaffHistory.idFactStaff INNER JOIN
                  WorkType ON FactStaffHistory.idTypeWork = WorkType.id
								
