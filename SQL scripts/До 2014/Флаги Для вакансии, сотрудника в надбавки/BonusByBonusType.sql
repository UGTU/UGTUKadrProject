USE [Kadr]
GO
/****** Object:  UserDefinedFunction [dbo].[GetBonusByBonusType]    Script Date: 05/16/2012 12:17:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--select * from [dbo].[GetBonusByBonusType](75, '01.10.2011','30.10.2011') order by EmployeeName
--возвращает данные для отчета по надбавкам, отобранным по виду надбавки
ALTER FUNCTION [dbo].[GetBonusByBonusType] 
(
@idBonusType INT,
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
RETURNS @Result TABLE
   (
    idDepartment			INT,
    DepartmentName			VARCHAR(200),
    TypeWorkName			VARCHAR(50) NULL,
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    BonusLevel				VARCHAR(50)  NULL,
    BonusCount				VARCHAR(50) NULL,
    BonusSum				DECIMAL(8,2),
    AllBonusSum				DECIMAL(8,2),
    StaffCount				DECIMAL(8,2),
    idFactStaff				INT,
    idPlanStaff				INT,
    SeverKoeff				INT,
    RayonKoeff				INT,
    PrikazBegin				VARCHAR(50),
    DateBegin				DATETIME,
    DateEnd					DATETIME,
	Comment					VARCHAR(100),
	CategoryName			VARCHAR(50),
	DirectionManagerName	VARCHAR(70),
	IntermediateDateEnd		DATETIME,
	ForEmployee				BIT
   ) 
AS
BEGIN

	IF (@PeriodBegin>@PeriodEnd)
		RETURN


	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
--объявляем временную таблицу, в которую внесем все надбавки за период
DECLARE @BonusTable Table
(
	id INT,
	BonusCount numeric(8,2),
    DateBegin DATETIME,
    DateEnd DATETIME,
    idPrikaz	INT
)

	INSERT INTO @BonusTable(id, BonusCount, idPrikaz, DateBegin, DateEnd)
	SELECT idBonus, PeriodBonus.BonusCount, PeriodBonus.idPrikaz, PeriodBonus.DateBegin, PeriodBonus.DateEnd 
	FROM [dbo].[GetBonusByPeriodWithHistory](@PeriodBegin, @PeriodEnd) as PeriodBonus, dbo.Bonus
	WHERE PeriodBonus.idBonus=Bonus.id
		AND Bonus.idBonusType=@idBonusType

--объявляем временную таблицу, в которую внесем всех сотрудников в периоде
	DECLARE @StaffTable Table
	(
		idDepartment INT,
		idPost		 INT,
		idPlanStaff  INT,
		idFactStaff  INT,
		idEmployee   INT,
		StaffCount	 NUMERIC(7,2),
		StaffCountWithoutReplacement NUMERIC(7,2),	--кол-во ставок без замещений
		idReplacementReason	INT,					--причина замещения
		IsMain			BIT,							--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		IsReplacement	BIT,
		idFinancingSource	INT,
		idTypeWork			INT
	)

	INSERT INTO @StaffTable(idDepartment, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason, IsMain, IsReplacement,
		idFinancingSource, idTypeWork)
	SELECT DISTINCT idDepartment, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason, IsMain, IsReplacement,
		idFinancingSource, idTypeWork
	FROM dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff

	--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ с их руководителями (т.к. нужно вывести руководителей)
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
	idManagerPlanStaff	INT,
	DirectionManagerName	VARCHAR(70)
	)
	
	--Начинаем цикл по всем корневым отделам 
	DECLARE @idDepartment INT
	SELECT @idDepartment=MIN(id) FROM dbo.Department WHERE idManagerDepartment IS NULL
	WHILE @idDepartment IS NOT NULL
	BEGIN
		INSERT INTO @DepTable
				SELECT idDepartment, idManagerPlanStaff, null
				FROM [dbo].[GetSubDepartmentsWithManagers](@idDepartment)	--с менеджерами
			
		SELECT @idDepartment=MIN(id) FROM dbo.Department WHERE idManagerDepartment IS NULL
			AND id>@idDepartment
	END
	--Заносим имена 
	UPDATE 	@DepTable
	SET DirectionManagerName=Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'. '+CONVERT(VARCHAR(1),Employee.Otch)+'.'
	FROM @DepTable as Deps
		INNER JOIN dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff ON PeriodStaff.idPlanStaff=Deps.idManagerPlanStaff
		--INNER JOIN dbo.FactStaff ON PeriodStaff.idFactStaff=FactStaff.id
		INNER JOIN dbo.Employee ON PeriodStaff.idEmployee=Employee.id
	
	
	
	
	INSERT INTO @Result(EmployeeName,BonusLevel,BonusCount, BonusSum, idFactStaff, SeverKoeff, RayonKoeff,
			TypeWorkName, StaffCount, DepartmentName, idDepartment, PostName, idPlanStaff,
			PrikazBegin, DateBegin, DateEnd, Comment, CategoryName, DirectionManagerName, IntermediateDateEnd, 
			ForEmployee)
	SELECT  Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch as EmployeeName, 
			AllBonus.BonusLevel, AllBonus.BonusCount, AllBonus.BonusCount, 
			AllBonus.idFactStaff, Employee.SeverKoeff, Employee.RayonKoeff, 
			WorkType.TypeWorkShortName+ISNULL(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')',''), 
			Staff.StaffCount, 
			Department.DepartmentName, Department.id, Post.PostName, Staff.idPlanStaff,
			Prikaz.PrikazName PrikazBegin, AllBonus.DateBegin, AllBonus.DateEnd,
			Bonus.Comment, CategorySmallName, DirectionManagerName, IntermediateEndPrikaz.DatePrikaz,
			ForEmployee
	FROM
		(SELECT idBonus,
			Staff.idEmployee, 'Сотрудник' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL as ForEmployee
		FROM @BonusTable as Bonus, dbo.BonusEmployee, @StaffTable as Staff
		WHERE  Bonus.id=BonusEmployee.idBonus
			AND BonusEmployee.idEmployee=Staff.idEmployee
			AND Staff.StaffCount=(SELECT MAX(StaffCount) FROM @StaffTable as Staff 
									WHERE Staff.idEmployee=BonusEmployee.idEmployee)
		--GROUP BY Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch, BonusCount, SeverKoeff, RayonKoeff
	 
		UNION		
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Распределение штатов' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL
		FROM @BonusTable as Bonus, dbo.BonusFactStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusFactStaff.idBonus
			AND BonusFactStaff.idFactStaff=Staff.idFactStaff
		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Штатное расписание' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			ForEmployee
		FROM @BonusTable as Bonus, dbo.BonusPlanStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusPlanStaff.idBonus
			AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff

		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Должность' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL
		FROM @BonusTable as Bonus, dbo.BonusPost, @StaffTable as Staff
		WHERE Bonus.id=BonusPost.idBonus
			AND BonusPost.idPost=Staff.idPost) AllBonus INNER JOIN
		dbo.Employee ON AllBonus.idEmployee=Employee.id INNER JOIN
		dbo.Bonus ON AllBonus.idBonus=Bonus.id INNER JOIN
		dbo.Prikaz ON Prikaz.id=AllBonus.idPrikaz INNER JOIN
	
		@StaffTable as Staff ON AllBonus.idFactStaff=Staff.idfactStaff INNER JOIN 
		dbo.WorkType ON Staff.idTypeWork=WorkType.id  INNER JOIN
		dbo.Department ON Staff.idDepartment=Department.id INNER JOIN 
		dbo.Post ON Staff.idPost=Post.id INNER JOIN 
		dbo.Category ON Post.idCategory=Category.id INNER JOIN 
		dbo.PKCategory ON Post.idPKCategory=PKCategory.id INNER JOIN 
		dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id INNER JOIN
		@DepTable deps ON Department.id=deps.idDepartment  LEFT JOIN
		dbo.Prikaz IntermediateEndPrikaz ON Bonus.idIntermediateEndPrikaz=IntermediateEndPrikaz.id LEFT JOIN 
		dbo.FactStaffReplacement ON FactStaffReplacement.idFactStaff=AllBonus.idFactStaff LEFT JOIN
		dbo.FactStaffReplacementReason ON FactStaffReplacement.idReplacementReason=FactStaffReplacementReason.id
	ORDER BY Department.DepartmentSmallName, Category.OrderBy, PKGroup.GroupNumber desc, 
		PKCategory.PKCategoryNumber desc, Post.PostShortName, EmployeeName, AllBonus.DateBegin
	
	--удаляем надбавки для сотрудников, если они для них не предназначены
	DELETE FROM  @Result
	FROM  @Result res
	WHERE ForEmployee=0

	
	--если проценты
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND idBonusMeasure=1)
	begin
		UPDATE @Result
		SET BonusSum = CONVERT(DECIMAL(8,2),BonusCount)*SalarySize/100
		FROM @Result as res, [dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd) PlanStaffsWithSalaries
		WHERE  res.idPlanStaff=PlanStaffsWithSalaries.idPlanStaff
	end
	
	
	--если зависит от ставки
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND IsStaffRateable=1)
	begin
		UPDATE @Result
		SET BonusSum = CONVERT(DECIMAL(8,2), BonusSum*StaffCount)
	end

	--если cеверные накручиваются
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND HasEnvironmentBonus=1)
	begin
		UPDATE @Result
		SET AllBonusSum = CONVERT(DECIMAL(8,2), BonusSum*(100+SeverKoeff+RayonKoeff)/100)
	end
	ELSE
	begin
		UPDATE @Result
		SET AllBonusSum = BonusSum
	end
	
	
	UPDATE @Result
	SET BonusCount=BonusCount+' '+BonusMeasure.Sign
	FROM  @Result res, dbo.BonusType, dbo.BonusMeasure
	WHERE BonusType.id=@idBonusType
		AND BonusType.idBonusMeasure=BonusMeasure.id
		
RETURN
END


