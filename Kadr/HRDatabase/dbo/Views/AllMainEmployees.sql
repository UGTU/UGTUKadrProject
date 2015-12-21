--select * from dbo.AllMainEmployees
--Возвращает всех основных сотрудников университета
CREATE VIEW dbo.AllMainEmployees
AS
SELECT staff.EmployeeGUID,
	Employee.FirstName, Employee.LastName, Employee.Otch, Employee.BirthDate,
	staff.PostName, staff.DepartmentName, SemPol.sempolName, staff.DepartmentGUID,
	FactStaffWithHistory.DateBegin
	 


	from [dbo].[GetDepartmentStaff](1, getdate(),getdate(), 1) staff
      INNER JOIN dbo.Employee ON staff.idEmployee = Employee.id 
      INNER JOIN dbo.SemPol ON dbo.Employee.idSemPol = dbo.SemPol.id
      INNER JOIN (SELECT idEmployee, MIN(DateBegin) DateBegin
					FROM dbo.FactStaffWithHistory
					GROUP BY idEmployee)FactStaffWithHistory 
      
      ON Employee.id=FactStaffWithHistory.idEmployee


--dbo.EducDocument INNER JOIN
--      dbo.EducDocumentType ON dbo.EducDocument.idEducDocType = dbo.EducDocumentType.id INNER JOIN
--      dbo.EmployeeRank ON dbo.EducDocument.id = dbo.EmployeeRank.idEducDocument AND dbo.Employee.id = dbo.EmployeeRank.idEmployee INNER JOIN
--      dbo.EmployeeDegree ON dbo.EducDocument.id = dbo.EmployeeDegree.idEducDocument AND dbo.Employee.id = dbo.EmployeeDegree.idEmployee INNER JOIN
       

WHERE IsMain=1
