
--select * from [dbo].[GetSubDepartments](1) 
--select * from [dbo].GetSubDepartmentStaffCounts(2)
--Вычисляем менеджера по направлению
create FUNCTION [dbo].[GetDepartmentsManager] 
(
@idDepartment INT
)
RETURNS INT
AS
BEGIN
	DECLARE @idManagerPlanStaff INT
	SELECT @idManagerPlanStaff=idManagerPlanStaff FROM dbo.Department WHERE id=@idDepartment
	
	--идем "вверх" - может быть там есть менеджер
	WHILE (@idManagerPlanStaff IS NULL AND @idDepartment IS NOT NULL)
	BEGIN
		SELECT @idManagerPlanStaff=idManagerPlanStaff FROM dbo.Department WHERE id=@idDepartment
		SELECT @idDepartment = idManagerDepartment FROM dbo.Department WHERE id=@idDepartment
	END
				

RETURN @idManagerPlanStaff
END





