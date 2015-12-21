--select * from [dbo].[GetSubDepartmentsWithManagersWithPeriod](1,'01.01.2015','09.02.2015')   order by DepTreeIndex
--возвращает подотделы переданного отдела (вместе с переданным отделом) с ФИО менеджеров
CREATE FUNCTION [dbo].[GetSubDepartmentsWithManagersWithPeriod] 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
	idManagerPlanStaff	INT,
    IsMain			BIT,
	[DepartmentName] VARCHAR(500),
	[DepartmentSmallName] VARCHAR(50),
	DepNumber				INT,
	DepTreeIndex			VARCHAR(30),
	idOKVED INT,
	[idFundingCenter] INT
   ) 
AS
BEGIN
	
	DECLARE @idCurrManagerPlanStaff INT

	--выбираем менеджера для главного отдела
	SELECT @idCurrManagerPlanStaff=[dbo].[GetDepartmentsManager](@idManagerDepartment);

	WITH DepRecursiveInfo(idDepartment,IsMain,[DepartmentName],[DepartmentSmallName],idManagerDepartment,idManagerPlanStaff,
		SubLevel, DepTreeIndex, idOKVED, [idFundingCenter])
	AS
	(
	SELECT id,1,[DepartmentName],[DepartmentSmallName],idManagerDepartment,ISNULL(idManagerPlanStaff,@idCurrManagerPlanStaff),0, CONVERT(VARCHAR(40),'1'), idOKVED
	, [idFundingCenter]
		FROM dbo.Department
		WHERE [id]=@idManagerDepartment
	UNION ALL
	SELECT deps.idDepartment,deps.idManagerDepartment,deps.[DepartmentName],deps.[DepartmentSmallName],deps.idManagerDepartment,
		ISNULL(deps.idManagerPlanStaff,DepRecursiveInfo.idManagerPlanStaff)
		,SubLevel+1 
		,IIF(row_number() over(order by deps.DepartmentName)>9, 
		CONVERT(VARCHAR(32),DepTreeIndex)+CONVERT(VARCHAR(4),'.')+CONVERT(VARCHAR(4),80+row_number() over(order by deps.DepartmentName)),
		CONVERT(VARCHAR(32),DepTreeIndex)+CONVERT(VARCHAR(4),'.')+CONVERT(VARCHAR(4),row_number() over(order by deps.DepartmentName)))
		, deps.idOKVED, deps.[idFundingCenter]
		FROM [dbo].[GetDepartmentByPeriod](@PeriodBegin, @PeriodEnd) deps
			INNER JOIN DepRecursiveInfo ON deps.idManagerDepartment=DepRecursiveInfo.idDepartment
	)
	
	INSERT INTO @Result(idDepartment,IsMain,[DepartmentName],[DepartmentSmallName],idManagerDepartment,idManagerPlanStaff,
		 DepTreeIndex, idOKVED, [idFundingCenter])
	SELECT idDepartment,IsMain,[DepartmentName],[DepartmentSmallName],idManagerDepartment,idManagerPlanStaff,
		 DepTreeIndex, idOKVED, [idFundingCenter] FROM DepRecursiveInfo
	ORDER BY DepRecursiveInfo.DepTreeIndex
	



RETURN
END







/*
	DECLARE  @DepTable Table
	(
		[idDepartment]		INT,
		[idManagerDepartment]			INT,
		[DepartmentName] VARCHAR(500),
		[DepartmentSmallName] VARCHAR(50),
		idOKVED		INT
	)

	INSERT INTO @DepTable([idDepartment],[idManagerDepartment], DepartmentName,DepartmentSmallName, idOKVED)
	SELECT [idDepartment],[idManagerDepartment], DepartmentName,DepartmentSmallName, idOKVED
	FROM [dbo].[GetDepartmentByPeriod]('08.01.2015','09.02.2015');--(@PeriodBegin, @PeriodEnd);

	WITH DepRecursiveInfo(idDepartment,IsMain,[DepartmentName],[DepartmentSmallName],idManagerDepartment,
		SubLevel, DepTreeIndex)
	AS
	(
	SELECT idDepartment,1,[DepartmentName],[DepartmentSmallName],idManagerDepartment,0, CONVERT(VARCHAR(40),'1')
		FROM @DepTable
		WHERE [idDepartment]=1
	UNION ALL
	SELECT deps.idDepartment,1,deps.[DepartmentName],deps.[DepartmentSmallName],deps.idManagerDepartment,SubLevel+1, 
		IIF(row_number() over(order by deps.DepartmentName)>9, 
		CONVERT(VARCHAR(32),DepTreeIndex)+CONVERT(VARCHAR(4),'.')+CONVERT(VARCHAR(4),80+row_number() over(order by deps.DepartmentName)),
		CONVERT(VARCHAR(32),DepTreeIndex)+CONVERT(VARCHAR(4),'.')+CONVERT(VARCHAR(4),row_number() over(order by deps.DepartmentName)))
		FROM @DepTable deps
			INNER JOIN DepRecursiveInfo ON deps.idManagerDepartment=DepRecursiveInfo.idDepartment
	)
	
	SELECT DepRecursiveInfo.*, deps.DepTreeIndex FROM DepRecursiveInfo
	INNER JOIN [dbo].[GetSubDepartmentsWithPeriod](1,'08.01.2015','09.02.2015') deps
	ON DepRecursiveInfo.idDepartment=deps.idDepartment
	ORDER BY DepRecursiveInfo.DepTreeIndex,deps.DepTreeIndex
	
	
	
	
	
	



--select * from [dbo].[GetSubDepartmentsWithPeriod](1,'08.01.2015','09.02.2015')  order by DepTreeIndex
--возвращает подотделы переданного отдела (вместе с переданным отделом)
ALTER FUNCTION [dbo].[GetSubDepartmentsWithPeriod] 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
    IsMain			BIT,
	[DepartmentName] VARCHAR(500),
	[DepartmentSmallName] VARCHAR(50),
	DepNumber				INT,
	DepTreeIndex			VARCHAR(30),
	idOKVED INT
   ) 
AS
BEGIN
	
	DECLARE  @DepTable Table
	(
		[idDepartment]		INT,
		[idManagerDepartment]			INT,
		[DepartmentName] VARCHAR(500),
		[DepartmentSmallName] VARCHAR(50),
		idOKVED		INT
	)

	INSERT INTO @DepTable([idDepartment],[idManagerDepartment], DepartmentName,DepartmentSmallName, idOKVED)
	SELECT [idDepartment],[idManagerDepartment], DepartmentName,DepartmentSmallName, idOKVED
	FROM [dbo].[GetDepartmentByPeriod](@PeriodBegin, @PeriodEnd)

	--выбираем непосредственно подчиненные отделы (подчиняются непосредственно отделу)
	INSERT INTO @Result
		SELECT [idDepartment], idManagerDepartment, 0, DepartmentName,DepartmentSmallName, 
			row_number() over(order by DepartmentName),  '1', idOKVED
			FROM @DepTable WHERE idManagerDepartment=@idManagerDepartment
		UNION 
		SELECT @idManagerDepartment, @idManagerDepartment, 1, DepartmentName,DepartmentSmallName, 0, '0', idOKVED
			FROM @DepTable WHERE [idDepartment]=@idManagerDepartment
			
	SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
		WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
	
	UPDATE @Result
	SET DepNumber=80+DepNumber
	WHERE DepNumber BETWEEN 10 AND 20

	--выбираем вложенные отделы
	WHILE @idManagerDepartment IS NOT NULL
	BEGIN
		INSERT INTO @Result
		VALUES(null, @idManagerDepartment, 0,'','',0,'',0)
		
		INSERT INTO @Result
		SELECT deps.[idDepartment], deps.idManagerDepartment, 0, deps.DepartmentName,deps.DepartmentSmallName
			, row_number() over(order by deps.DepartmentName), CONCAT(mainDep.DepTreeIndex,'.', CONVERT(VARCHAR(2),mainDep.DepNumber)) DepTreeIndex, deps.idOKVED
			FROM @DepTable deps  
				INNER JOIN @Result mainDep ON deps.idManagerDepartment=mainDep.idDepartment  
			WHERE deps.idManagerDepartment=@idManagerDepartment 
		
		UPDATE @Result
		SET DepNumber=80+DepNumber
		WHERE DepNumber BETWEEN 10 AND 20

		SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
			WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
	END
	
	DELETE FROM @Result
	WHERE idDepartment IS NULL

	UPDATE @Result
		SET DepTreeIndex = DepTreeIndex+'.'+CONVERT(VARCHAR(2),DepNumber)

		
RETURN
END














	
	
	
	
	
	
	
	
	
--select * from [dbo].[GetSubDepartmentsWithManagersWithPeriod](1,'01.01.2015','09.02.2015')   order by DepTreeIndex
--возвращает подотделы переданного отдела (вместе с переданным отделом) с ФИО менеджеров
ALTER FUNCTION [dbo].[GetSubDepartmentsWithManagersWithPeriod] 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
	idManagerPlanStaff	INT,
    IsMain			BIT,
	[DepartmentName] VARCHAR(500),
	[DepartmentSmallName] VARCHAR(50),
	DepNumber				INT,
	DepTreeIndex			VARCHAR(30),
	idOKVED INT
   ) 
AS
BEGIN
	DECLARE  @DepTable Table
	(
		[idDepartment]		INT,
		[idManagerDepartment]			INT,
		idManagerPlanStaff INT,
		[DepartmentName] VARCHAR(500),
		[DepartmentSmallName] VARCHAR(50),
		idOKVED		INT
	)

	INSERT INTO @DepTable([idDepartment],[idManagerDepartment], idManagerPlanStaff, DepartmentName,DepartmentSmallName, idOKVED)
	SELECT [idDepartment],[idManagerDepartment], idManagerPlanStaff, DepartmentName,DepartmentSmallName, idOKVED
	FROM [dbo].[GetDepartmentByPeriod](@PeriodBegin, @PeriodEnd)

	DECLARE @idCurrManagerPlanStaff INT

	--выбираем менеджера для главного отдела
	SELECT @idCurrManagerPlanStaff=[dbo].[GetDepartmentsManager](@idManagerDepartment)
	
	--выбираем непосредственно подчиненные отделы (подчиняются непосредственно отделу)
	INSERT INTO @Result
		SELECT [idDepartment], idManagerDepartment, ISNULL(idManagerPlanStaff,@idCurrManagerPlanStaff), 
			0, DepartmentName,DepartmentSmallName, 
			row_number() over(order by DepartmentName),  '1', idOKVED
			FROM @DepTable WHERE idManagerDepartment=@idManagerDepartment
		UNION 
		SELECT @idManagerDepartment, @idManagerDepartment, @idCurrManagerPlanStaff, 
			1, DepartmentName,DepartmentSmallName, 0, '0', idOKVED
			FROM @DepTable WHERE [idDepartment]=@idManagerDepartment
		
	UPDATE @Result
	SET DepNumber=80+DepNumber
	WHERE DepNumber BETWEEN 10 AND 20
		
	SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
		WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
	SELECT @idCurrManagerPlanStaff=ISNULL(idManagerPlanStaff, @idCurrManagerPlanStaff) FROM @Result
			WHERE idDepartment=@idManagerDepartment	
	--выбираем вложенные отделы
	WHILE @idManagerDepartment IS NOT NULL
	BEGIN
		INSERT INTO @Result
		VALUES(null, @idManagerDepartment, @idCurrManagerPlanStaff, 0,'','',0,'',0)
		
		INSERT INTO @Result
		SELECT deps.idDepartment, deps.idManagerDepartment, ISNULL(deps.idManagerPlanStaff,@idCurrManagerPlanStaff), 0, deps.DepartmentName,deps.DepartmentSmallName
			, row_number() over(order by deps.DepartmentName), CONCAT(mainDep.DepTreeIndex,'.', CONVERT(VARCHAR(2),mainDep.DepNumber)) DepTreeIndex, deps.idOKVED
			FROM @DepTable deps
				INNER JOIN @Result mainDep ON deps.idManagerDepartment=mainDep.idDepartment  
			WHERE deps.idManagerDepartment=@idManagerDepartment 
		
		UPDATE @Result
		SET DepNumber=80+DepNumber
		WHERE DepNumber BETWEEN 10 AND 20

		SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
			WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
		SELECT @idCurrManagerPlanStaff=ISNULL(idManagerPlanStaff, @idCurrManagerPlanStaff) FROM @Result
			WHERE idDepartment=@idManagerDepartment
	END
	
	DELETE FROM @Result
	WHERE idDepartment IS NULL

	UPDATE @Result
		SET DepTreeIndex = DepTreeIndex+'.'+CONVERT(VARCHAR(2),DepNumber)
RETURN
END





	
	*/











































	/*
Первоначальные варианты

	USE [Kadr]
GO
GO

--select * from [dbo].[GetSubDepartmentsWithPeriod](1,'08.01.2015','09.02.2015')  order by DepTreeIndex
--возвращает подотделы переданного отдела (вместе с переданным отделом)
ALTER FUNCTION [dbo].[GetSubDepartmentsWithPeriod] 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
    IsMain			BIT,
	[DepartmentName] VARCHAR(500),
	[DepartmentSmallName] VARCHAR(50),
	DepNumber				INT,
	DepTreeIndex			VARCHAR(30),
	idOKVED INT
   ) 
AS
BEGIN
	
	DECLARE  @DepTable Table
	(
		[idDepartment]		INT,
		[idManagerDepartment]			INT,
		[DepartmentName] VARCHAR(500),
		[DepartmentSmallName] VARCHAR(50),
		idOKVED		INT
	)

	INSERT INTO @DepTable([idDepartment],[idManagerDepartment], DepartmentName,DepartmentSmallName, idOKVED)
	SELECT [idDepartment],[idManagerDepartment], DepartmentName,DepartmentSmallName, idOKVED
	FROM [dbo].[GetDepartmentByPeriod](@PeriodBegin, @PeriodEnd)

	--выбираем непосредственно подчиненные отделы (подчиняются непосредственно отделу)
	INSERT INTO @Result
		SELECT [idDepartment], idManagerDepartment, 0, DepartmentName,DepartmentSmallName, 
			row_number() over(order by DepartmentName),  '1', idOKVED
			FROM @DepTable WHERE idManagerDepartment=@idManagerDepartment
		UNION 
		SELECT @idManagerDepartment, @idManagerDepartment, 1, DepartmentName,DepartmentSmallName, 0, '0', idOKVED
			FROM @DepTable WHERE [idDepartment]=@idManagerDepartment
			
	SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
		WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
	
	UPDATE @Result
	SET DepNumber=80+DepNumber
	WHERE DepNumber BETWEEN 10 AND 20

	--выбираем вложенные отделы
	WHILE @idManagerDepartment IS NOT NULL
	BEGIN
		INSERT INTO @Result
		VALUES(null, @idManagerDepartment, 0,'','',0,'',0)
		
		INSERT INTO @Result
		SELECT deps.[idDepartment], deps.idManagerDepartment, 0, deps.DepartmentName,deps.DepartmentSmallName
			, row_number() over(order by deps.DepartmentName), CONCAT(mainDep.DepTreeIndex,'.', CONVERT(VARCHAR(2),mainDep.DepNumber)) DepTreeIndex, deps.idOKVED
			FROM @DepTable deps  
				INNER JOIN @Result mainDep ON deps.idManagerDepartment=mainDep.idDepartment  
			WHERE deps.idManagerDepartment=@idManagerDepartment 
		
		UPDATE @Result
		SET DepNumber=80+DepNumber
		WHERE DepNumber BETWEEN 10 AND 20

		SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
			WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
	END
	
	DELETE FROM @Result
	WHERE idDepartment IS NULL

	UPDATE @Result
		SET DepTreeIndex = DepTreeIndex+'.'+CONVERT(VARCHAR(2),DepNumber)

		
RETURN
END
*/