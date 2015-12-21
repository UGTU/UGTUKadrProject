
--select * from [dbo].[GetSubDepartments](1) 
--возвращает подотделы переданного отдела (вместе с переданным отделом)
CREATE FUNCTION [dbo].[GetSubDepartments] 
(
@idManagerDepartment INT
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
    IsMain			BIT
   ) 
AS
BEGIN
	
	--выбираем непосредственно подчиненные отделы (подчиняются непосредственно отделу)
	INSERT INTO @Result
		SELECT id, idManagerDepartment, 0 
			FROM dbo.Department WHERE idManagerDepartment=@idManagerDepartment
		UNION 
		SELECT @idManagerDepartment, @idManagerDepartment, 1
			
	SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
		WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
		
	--выбираем вложенные отделы
	WHILE @idManagerDepartment IS NOT NULL
	BEGIN
		INSERT INTO @Result
		VALUES(null, @idManagerDepartment, 0)
		
		INSERT INTO @Result
		SELECT id, idManagerDepartment, 0
			FROM dbo.Department WHERE idManagerDepartment=@idManagerDepartment
		
		SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
			WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
	END
	
	DELETE FROM @Result
	WHERE idDepartment IS NULL
		
RETURN
END


/*
	--выбираем непосредственно подчиненные отделы (подчиняются непосредственно отделу)
	INSERT INTO @Result
		SELECT id, IIF(id=@idManagerDepartment,@idManagerDepartment,idManagerDepartment), IIF(id=@idManagerDepartment,1, 0), [idOKVED]
			FROM dbo.Department WHERE idManagerDepartment=@idManagerDepartment
				OR id=@idManagerDepartment
			
	SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
		WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
		
	--выбираем вложенные отделы
	WHILE @idManagerDepartment IS NOT NULL
	BEGIN
		--INSERT INTO @Result
		--VALUES(null, @idManagerDepartment, 0)
		
		INSERT INTO @Result
		SELECT id, idManagerDepartment, 0, [idOKVED]
			FROM dbo.Department WHERE idManagerDepartment=@idManagerDepartment
		
		SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
			WHERE idDepartment > @idManagerDepartment
	END
	
	--DELETE FROM @Result
	--WHERE idDepartment IS NULL*/
