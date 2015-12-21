
CREATE VIEW [dbo].[EmployeeView]
AS
SELECT     
	Employee.*,
	LastName+' '+FirstName+' '+Otch as EmployeeName,
	LastName+' '+CONVERT(VARCHAR(1),FirstName)+'.'+CONVERT(VARCHAR(1),Otch)+'.' as EmployeeFIO
FROM    dbo.Employee  



