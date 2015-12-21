
/* [ShemaIndex].[GetBonusForEmployeep]
'11EF3FD5-664D-E111-96A2-0018FE865BEC','04447E65-64A2-4C04-9DF2-AA369ACA0394',
 '603BEDE9-68C0-E111-8738-0018FE865BEC','01.07.2012','02.07.2012' */
--возвращает стимулирующие надбавки сотрудника на опред должности в отделе
CREATE procedure [ShemaIndex].[GetBonusForEmployeep] 
(
@departmentGUID UNIQUEIDENTIFIER,
@employeeGUID UNIQUEIDENTIFIER,
@postGUID			UNIQUEIDENTIFIER,
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
AS

	IF (@PeriodBegin>@PeriodEnd)
		RETURN


	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
DECLARE @idEmployee INT
SELECT @idEmployee = id FROM dbo.Employee WHERE GUID=@employeeGUID

DECLARE @idDepartment INT
SELECT @idDepartment = id FROM dbo.Dep WHERE DepartmentGUID=@departmentGUID

DECLARE @idPost INT
SELECT @idPost = id FROM dbo.Post WHERE PostGUID=@postGUID

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
	FROM [dbo].[GetBonusByPeriodWithHistory](@PeriodBegin, @PeriodEnd) as PeriodBonus, dbo.Bonus, dbo.BonusType
	WHERE PeriodBonus.idBonus=Bonus.id
		AND Bonus.idBonusType=BonusType.id
		AND BonusType.idBonusSuperType=2	--выбираем только стимулирующие надбавки





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

	INSERT INTO @StaffTable(idPlanStaff, idFactStaff, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason, IsMain, IsReplacement,
		idFinancingSource, idTypeWork)
	SELECT DISTINCT idPlanStaff, idFactStaff, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason, IsMain, IsReplacement,
		idFinancingSource, idTypeWork
	FROM dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff
	WHERE idDepartment=@idDepartment AND idPost=@idPost AND idEmployee=@idEmployee

		SELECT * from @StaffTable

--объявляем временную таблицу-результат
	DECLARE @PredResult Table
		(
			BonusCount				VARCHAR(50) NULL,
			BonusSum				DECIMAL(8,2),
			AllBonusSum				DECIMAL(8,2),
			StaffCount				DECIMAL(8,2),
			SeverKoeff				INT,
			RayonKoeff				INT,
			idBonusMeasure			INT,
			IsStaffRateable			BIT,
			HasEnvironmentBonus			BIT,
			ForEmployee				BIT,
			idPlanStaff				INT
		) 


	INSERT INTO @PredResult(BonusCount, BonusSum, SeverKoeff, RayonKoeff,
			StaffCount,	ForEmployee, idBonusMeasure, IsStaffRateable, HasEnvironmentBonus, idPlanStaff)
	SELECT  AllBonus.BonusCount, AllBonus.BonusCount, 
			Employee.SeverKoeff, Employee.RayonKoeff, 
			Staff.StaffCount, 
			ForEmployee, idBonusMeasure, IsStaffRateable, HasEnvironmentBonus, idPlanStaff
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
		dbo.BonusType ON Bonus.idBonusType=BonusType.id  INNER JOIN
		@StaffTable as Staff ON AllBonus.idFactStaff=Staff.idfactStaff
		 
		--@DepTable deps ON Department.id=deps.idDepartment  LEFT JOIN
		--dbo.FactStaffReplacement ON FactStaffReplacement.idFactStaff=AllBonus.idFactStaff LEFT JOIN
		--dbo.FactStaffReplacementReason ON FactStaffReplacement.idReplacementReason=FactStaffReplacementReason.id
		SELECT * from @PredResult