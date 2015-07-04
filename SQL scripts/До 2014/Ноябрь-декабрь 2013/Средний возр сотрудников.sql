
select /*[WorkType].TypeWorkName,*/[Department].DepartmentName, AVG(yearCount) yearCount
FROM
(select Employee.id, Employee.EmployeeName, datediff(yyyy, Employee.BirthDate, GETDATE()) yearCount, staff.idTypeWork, idDepartment from 
[dbo].[GetStaffByPeriod]('12.1.2013','12.30.2013')staff
inner join dbo.Employee ON staff.idEmployee=Employee.id
inner join dbo.Post ON staff.idPost=Post.id
 WHERE --idDepartment=51 and (idTypeWork!=6)
 --and 
 idCategory=2)empl
 inner join
[dbo].[Department] ON empl.idDepartment=[Department].id
-- inner join
--[dbo].[WorkType]
-- ON [WorkType].id=empl.idTypeWork
 GROUP BY [Department].DepartmentName
 ORDER BY [Department].DepartmentName

 --select datediff(yyyy,'01.01.2013','03/03/2000')