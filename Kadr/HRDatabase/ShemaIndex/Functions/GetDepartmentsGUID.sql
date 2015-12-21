
--select * from ShemaIndex.[GetDepartmentsGUID]('УГТУ') 

--Вычисляем GUID отдела по его названию
CREATE FUNCTION ShemaIndex.[GetDepartmentsGUID] 
(
@DepartmentName VARCHAR(200)
)
RETURNS uniqueidentifier
AS
BEGIN
	DECLARE @depsGUID uniqueidentifier
	SELECT @depsGUID=DepartmentGUID FROM dbo.Department WHERE DepartmentName LIKE @DepartmentName
	
				

RETURN @depsGUID
END





