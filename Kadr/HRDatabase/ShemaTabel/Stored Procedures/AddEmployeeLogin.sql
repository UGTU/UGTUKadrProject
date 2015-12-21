CREATE PROCEDURE ShemaTabel.AddEmployeeLogin
	@id int,
	@login nvarchar(128)
AS
    update Employee
	set EmployeeLogin=@login
	where id=@id
