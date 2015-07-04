USE [Kadr]
GO

/****** Object:  UserDefinedFunction [dbo].[GetBonusByBonusType]    Script Date: 21.03.2015 10:59:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




--select * from [dbo].[GetBonusFor BonusProlong](67, '09.01.2013','09.30.2013') where EmployeeName like '%Амосова%'
--возвращает данные для отчета по надбавкам, отобранным по виду надбавки
CREATE FUNCTION [dbo].[GetBonusForProlong] 
(
@idBonusType INT,
@idDepartment	INT,
@ProlongDate	DATE
)
RETURNS @Result TABLE
   (
    idDepartment			INT,
    DepartmentName			VARCHAR(500),
    TypeWorkName			VARCHAR(50) NULL,
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    BonusLevel				VARCHAR(50)  NULL,
    BonusCount				VARCHAR(50) NULL,
    BonusSum				DECIMAL(14,2),
    AllBonusSum				DECIMAL(14,2),
    StaffCount				DECIMAL(14,4),
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
	IntermediatePrikaz		VARCHAR(50),
	ForEmployee				BIT,
    MatOtpusk VARCHAR(10),
	SalaryKoeff  NUMERIC(6,2),
	FinancingSourceName     VARCHAR(50),
	RealFinancingSourceName VARCHAR(50),
	BonusFinancingSourceName VARCHAR(50),
    CalcStaffCount			DECIMAL(14,4)
   ) 
AS
BEGIN

	
--объявляем временную таблицу, в которую внесем все надбавки за период
DECLARE @BonusTable Table
(
	id INT,
	BonusCount numeric(8,2),
    DateBegin DATETIME,
    DateEnd DATETIME,
    idPrikaz	INT,
	idFinancingSource INT 
)

	INSERT INTO @BonusTable(id, BonusCount, idPrikaz, DateBegin, DateEnd, idFinancingSource)
	SELECT idBonus, PeriodBonus.BonusCount, PeriodBonus.idPrikaz, PeriodBonus.DateBegin, PeriodBonus.DateEnd,idFinancingSource  
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
		StaffCount	 NUMERIC(8,2),
		StaffCountWithoutReplacement NUMERIC(8,2),	--кол-во ставок без замещений
		idReplacementReason	INT,					--причина замещения
		IsMain			BIT,							--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		IsReplacement	BIT,
		idFinancingSource	INT,
		idTypeWork			INT,
		idSalaryKoeff INT,
		CalcStaffCount	 NUMERIC(8,2)
	)

	INSERT INTO @StaffTable(idDepartment, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason, IsMain, IsReplacement,
		idFinancingSource, idTypeWork, idSalaryKoeff, CalcStaffCount)
	SELECT DISTINCT idDepartment, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason, IsMain, IsReplacement,
		idFinancingSource, idTypeWork, idSalaryKoeff, CalcStaffCount
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
				SELECT idDepartment, 0, null
				FROM [dbo].GetSubDepartments/*WithManagers*/(@idDepartment)	--с менеджерами
			
		SELECT @idDepartment=MIN(id) FROM dbo.Department WHERE idManagerDepartment IS NULL
			AND id>@idDepartment
	END
	/*--Заносим имена 
	UPDATE 	@DepTable
	SET DirectionManagerName=Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'. '+CONVERT(VARCHAR(1),Employee.Otch)+'.'
	FROM @DepTable as Deps
		INNER JOIN dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff ON PeriodStaff.idPlanStaff=Deps.idManagerPlanStaff
		--INNER JOIN dbo.FactStaff ON PeriodStaff.idFactStaff=FactStaff.id
		INNER JOIN dbo.Employee ON PeriodStaff.idEmployee=Employee.id
	*/
	
	
	
	INSERT INTO @Result(EmployeeName,BonusLevel,BonusCount, BonusSum, idFactStaff, SeverKoeff, RayonKoeff,
			TypeWorkName, StaffCount, DepartmentName, idDepartment, PostName, idPlanStaff,
			PrikazBegin, DateBegin, DateEnd, Comment, CategoryName, DirectionManagerName, IntermediateDateEnd, IntermediatePrikaz, 
			ForEmployee,MatOtpusk, SalaryKoeff, FinancingSourceName, BonusFinancingSourceName, RealFinancingSourceName, CalcStaffCount)
	SELECT  EmployeeName, 
			AllBonus.BonusLevel, AllBonus.BonusCount, AllBonus.BonusCount, 
			AllBonus.idFactStaff, Employee.SeverKoeff, Employee.RayonKoeff, 
			WorkType.TypeWorkName+ISNULL(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')',''), 
			Staff.StaffCount, 
			Department.DepartmentName, Department.id, Post.PostName, Staff.idPlanStaff,
			Prikaz.PrikazName PrikazBegin, AllBonus.DateBegin, AllBonus.DateEnd,
			Bonus.Comment, CategorySmallName, DirectionManagerName, IntermediateEndPrikaz.DatePrikaz, IntermediateEndPrikaz.PrikazName,
			ForEmployee, otpusk.otpTypeShortName, ISNULL(SalaryKoeff.SalaryKoeffc,1), 
			FinancingSource.FinancingSourceName, RealFinancingSource.FinancingSourceName, RealFinancingSource.FinancingSourceName, CalcStaffCount
	FROM
		(SELECT idBonus,
			Staff.idEmployee, 'Сотрудник' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL as ForEmployee, Bonus.idFinancingSource
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
			NULL, Bonus.idFinancingSource
		FROM @BonusTable as Bonus, dbo.BonusFactStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusFactStaff.idBonus
			AND BonusFactStaff.idFactStaff=Staff.idFactStaff
		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Штатное расписание' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			ForEmployee, Bonus.idFinancingSource
		FROM @BonusTable as Bonus, dbo.BonusPlanStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusPlanStaff.idBonus
			AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff

		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Должность' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL, Bonus.idFinancingSource
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
		--dbo.PKCategory ON Post.idPKCategory=PKCategory.id INNER JOIN 
		--dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id INNER JOIN
		[dbo].[FinancingSource] ON Staff.idFinancingSource=[FinancingSource].id INNER JOIN
		@DepTable deps ON Department.id=deps.idDepartment  LEFT JOIN
		[dbo].[FinancingSource] RealFinancingSource ON AllBonus.idFinancingSource=RealFinancingSource.id LEFT JOIN		
		dbo.Prikaz IntermediateEndPrikaz ON Bonus.idIntermediateEndPrikaz=IntermediateEndPrikaz.id LEFT JOIN 
		dbo.FactStaffReplacement ON FactStaffReplacement.idFactStaff=AllBonus.idFactStaff LEFT JOIN
		dbo.FactStaffReplacementReason ON FactStaffReplacement.idReplacementReason=FactStaffReplacementReason.id
		LEFT JOIN
		(SELECT idFactStaff, MIN(otpTypeShortName) otpTypeShortName  FROM
			[dbo].[GetOtpuskByPeriod](@PeriodBegin,@PeriodEnd)
			WHERE isMaternity=1
			GROUP BY idFactStaff) otpusk 
			ON Staff.idFactStaff=otpusk.idFactStaff 
		LEFT JOIN [dbo].[SalaryKoeff] ON Staff.idSalaryKoeff=[SalaryKoeff].id
	--ORDER BY Department.DepartmentSmallName, Category.OrderBy, PKGroup.GroupNumber desc, 
	--	PKCategory.PKCategoryNumber desc, Post.PostShortName, EmployeeName, AllBonus.DateBegin
	
	--удаляем надбавки для сотрудников, если они для них не предназначены
	DELETE FROM  @Result
	FROM  @Result res
	WHERE ForEmployee=0

	
	--если проценты
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND idBonusMeasure=1)
	begin
		UPDATE @Result
		SET BonusSum = CONVERT(DECIMAL(8,2),BonusCount)*SalarySize*SalaryKoeff/100
		FROM @Result as res, [dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd) PlanStaffsWithSalaries
		WHERE  res.idPlanStaff=PlanStaffsWithSalaries.idPlanStaff
	end
	
	
	--если зависит от ставки
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND IsStaffRateable=1)
	begin
		UPDATE @Result
		SET BonusSum = CONVERT(DECIMAL(8,2), BonusSum*StaffCount)
	end

	--если зависит от расчетной ставки
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND IsCalcStaffRateable=1)
	begin
		UPDATE @Result
		SET BonusSum = CONVERT(DECIMAL(8,2), BonusSum*CalcStaffCount)
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



GO


