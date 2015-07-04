insert into FactStaffReplacement(idFactStaff,idReplacedFactStaff,idReplacementReason)
select idReplacedFactStaff,idFactStaff,idReplacementReason
from FactStaffReplacementCopy
where FactStaffReplacementCopy.id=25

insert into FactStaffReplacement(idFactStaff,idReplacedFactStaff,idReplacementReason)
select idFactStaff,idReplacedFactStaff,idReplacementReason
from FactStaffReplacementCopy
where FactStaffReplacementCopy.id=46

SELECT     FactStaffReplacementCopy.id,DepartmentName, Post.PostName, 
		ReplacedEmployee.LastName as ReplacedLastName, ReplacedFactStaff.StaffCount ReplacedStaffCount, 
		Employee.LastName, FactStaff.StaffCount
FROM         dbo.FactStaffReplacementCopy INNER JOIN
                      dbo.FactStaff as ReplacedFactStaff ON dbo.FactStaffReplacementCopy.idReplacedFactStaff = ReplacedFactStaff.id  INNER JOIN
                      dbo.FactStaff AS FactStaff ON dbo.FactStaffReplacementCopy.idFactStaff = FactStaff.id INNER JOIN
                      dbo.PlanStaff as ReplacedPlanStaff ON ReplacedFactStaff.idPlanStaff = ReplacedPlanStaff.id INNER JOIN
                      dbo.PlanStaff  ON FactStaff.idPlanStaff = PlanStaff.id INNER JOIN
                      dbo.Post ON ReplacedPlanStaff.idPost = dbo.Post.id AND PlanStaff.idPost = dbo.Post.id INNER JOIN
                      dbo.Department ON PlanStaff.idDepartment = dbo.Department.id  AND 
                      ReplacedPlanStaff.idDepartment = dbo.Department.id INNER JOIN
                      dbo.Employee ON FactStaff.idEmployee = Employee.id INNER JOIN
                      dbo.Employee AS ReplacedEmployee ON ReplacedFactStaff.idEmployee = ReplacedEmployee.id 
                      
                      order by Department.DepartmentName, Post.PostName, ReplacedEmployee.LastName
                      
                      
                      
                      
go
SELECT     Department.DepartmentName, Post.PostName, 
		ReplacedEmployee.LastName as ReplacedLastName, ReplacedFactStaff.StaffCount ReplacedStaffCount, 
		Employee.LastName, FactStaff.StaffCount
FROM         dbo.FactStaffReplacement INNER JOIN
                      dbo.FactStaff as ReplacedFactStaff ON dbo.FactStaffReplacement.idReplacedFactStaff = ReplacedFactStaff.id  INNER JOIN
                      dbo.FactStaff AS FactStaff ON dbo.FactStaffReplacement.idFactStaff = FactStaff.id INNER JOIN
                      dbo.PlanStaff as ReplacedPlanStaff ON ReplacedFactStaff.idPlanStaff = ReplacedPlanStaff.id INNER JOIN
                      dbo.PlanStaff  ON FactStaff.idPlanStaff = PlanStaff.id INNER JOIN
                      dbo.Post ON ReplacedPlanStaff.idPost = dbo.Post.id AND PlanStaff.idPost = dbo.Post.id INNER JOIN
                      dbo.Department ON PlanStaff.idDepartment = dbo.Department.id  AND 
                      ReplacedPlanStaff.idDepartment = dbo.Department.id INNER JOIN
                      dbo.Employee ON FactStaff.idEmployee = Employee.id INNER JOIN
                      dbo.Employee AS ReplacedEmployee ON ReplacedFactStaff.idEmployee = ReplacedEmployee.id 
                      
                      order by Department.DepartmentName, Post.PostName, ReplacedEmployee.LastName
                      
                      
                      
                      
                                    