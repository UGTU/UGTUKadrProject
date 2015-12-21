CREATE PROCEDURE [dbo].[add_EmplLogin]
@itab_n varchar(50),
@EmployeeSid varbinary(85),
@Login NVARCHAR(128)
AS
update dbo.Employee
set EmployeeSid=@EmployeeSid,
	EmployeeLogin=@Login
where itab_n=@itab_n