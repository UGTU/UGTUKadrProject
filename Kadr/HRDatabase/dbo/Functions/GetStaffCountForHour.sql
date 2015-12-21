

--select  [dbo].GetStaffCountForHour(1972,881) 
--Вычисляем кол-во ставок для заданного кол-ва часов
CREATE FUNCTION [dbo].[GetStaffCountForHour] 
(
@idDepartment INT,
@idFinancingSource INT,
@HourCount		numeric(10,2)
)
RETURNS numeric(10,4)
AS
BEGIN
	DECLARE @StaffCount DECIMAL(10,4)
    SELECT @StaffCount=CONVERT(DECIMAL(10,4),@HourCount)/CONVERT(DECIMAL(10,4),TimeNorm.NormHoursCount)
	 FROM dbo.DepartmentTimeNormCurrent TimeNorm 
	WHERE TimeNorm.idDepartment=@idDepartment
				AND TimeNorm.idFinancingSource=@idFinancingSource

RETURN @StaffCount
END






