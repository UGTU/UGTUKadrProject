
--select * from [dbo].[GetSubDepartmentsWithManagers](19) 
--возвращает подотделы переданного отдела (вместе с переданным отделом) с ФИО менеджеров
CREATE FUNCTION [dbo].[GetSubDepartmentsWithManagers] 
(
@idManagerDepartment INT
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
	idManagerPlanStaff	INT,
    IsMain			BIT
   ) 
AS
BEGIN
	DECLARE @idCurrManagerPlanStaff INT

	--выбираем менеджера для главного отдела
	SELECT @idCurrManagerPlanStaff=[dbo].[GetDepartmentsManager](@idManagerDepartment)
	
	--выбираем непосредственно подчиненные отделы (подчиняются непосредственно отделу)
	INSERT INTO @Result
		SELECT id, idManagerDepartment, ISNULL(idManagerPlanStaff,@idCurrManagerPlanStaff), 0 
			FROM dbo.Department WHERE idManagerDepartment=@idManagerDepartment
		UNION 
		SELECT @idManagerDepartment, @idManagerDepartment, @idCurrManagerPlanStaff, 1
		
		
	SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
		WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
	SELECT @idCurrManagerPlanStaff=ISNULL(idManagerPlanStaff, @idCurrManagerPlanStaff) FROM @Result
			WHERE idDepartment=@idManagerDepartment	
	--выбираем вложенные отделы
	WHILE @idManagerDepartment IS NOT NULL
	BEGIN
		INSERT INTO @Result
		VALUES(null, @idManagerDepartment, @idCurrManagerPlanStaff, 0)
		
		INSERT INTO @Result
		SELECT id, idManagerDepartment, ISNULL(idManagerPlanStaff,@idCurrManagerPlanStaff), 0
			FROM dbo.Department WHERE idManagerDepartment=@idManagerDepartment
		
		SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
			WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
		SELECT @idCurrManagerPlanStaff=ISNULL(idManagerPlanStaff, @idCurrManagerPlanStaff) FROM @Result
			WHERE idDepartment=@idManagerDepartment
	END
	
	DELETE FROM @Result
	WHERE idDepartment IS NULL

RETURN
END

