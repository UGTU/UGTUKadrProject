
--select * from Employee where LastName like 'Солдатенков%'
--select * from dbo.GetStaffByPeriod('08.02.2011','30.03.2011') where idEmployee=366
--select * from FactStaffWithHistory where idEmployee=366

--select * from [dbo].[GetEmployeesSum](18499,'1.1.2012','1.1.2015') 
--select * from [dbo].[GetEmployeesSum](826772,'1.7.2015','18.7.2015') 

CREATE FUNCTION [dbo].[GetEmployeesSum] 
(
@idEmployee INT,
@PeriodBegin	DATE,
@PeriodEnd	DATE
)
RETURNS @Result TABLE
   (
    ReportMainObjectName	VARCHAR(50),
    TypeWorkName			VARCHAR(50) NULL,
    PKCategoryName			VARCHAR(50),
    FinancingSourceName		VARCHAR(50),
    BonusTypeName			VARCHAR(50),
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    BonusLevel				VARCHAR(50)  NULL,
    BonusCount				VARCHAR(50) NULL,
    BonusSum				DECIMAL(14,4),
    AllBonusSum				DECIMAL(14,4),
    StaffCount				DECIMAL(14,4),
    Salary					DECIMAL(14,4),
    idFactStaff				INT,
    idPlanStaff				INT,
    SeverKoeff				INT,
    RayonKoeff				INT,
    NDFLKoeff				INT,
	DepartmentName			VARCHAR(50),
	idBonusType				INT,
	PeriodBegin				DATE,
	PeriodEnd				DATE,
	StaffCountWithoutReplacement			DECIMAL(8,2),	--кол-во ставок без замещений
	idReplacementReason	INT,						--причина замещения	 			
	HasEnvironmentBonus		BIT,
	CategoryName			VARCHAR(50),
	PostFullName			VARCHAR(150),
	DepartmentFullName		VARCHAR(150),
	ForEmployee				BIT,
    MatOtpusk VARCHAR(10),
	[SalaryKoeff] NUMERIC(6,2),
	idBonusMeasure INT,
	IsStaffRateable BIT,
	IsCalcStaffRateable BIT,
	CalcStaffCount DECIMAL(14,4),
    ReplacedEmployeeName	VARCHAR(150) NULL, --нерасчетное кол-во ставок
	HourCount NUMERIC(14,2),
	CalcStaffCountWithoutReplacement DECIMAL(14,4),
	DateBegin		DATE,		--дата принятия на работу (первоначальная)
	DateEnd			DATE		--дата увольнения (если он уволен в данный период)
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

--объявляем временную таблицу, в которую внесем все надбавки за период
	DECLARE @BonusTable Table
	(
		id INT,
		BonusCount numeric(8,2),
		idBonusType INT
	)

	INSERT INTO @BonusTable(id, BonusCount, idBonusType)
	SELECT idBonus, PeriodBonus.BonusCount, idBonusType 
	FROM [dbo].[GetBonusByPeriod](@PeriodBegin, @PeriodEnd) as PeriodBonus--, dbo.Bonus
	--WHERE PeriodBonus.idBonus=Bonus.id


--объявляем временную таблицу, в которую внесем всех сотрудников отдела в периоде
	DECLARE @StaffTable Table
	(
		idDepartment INT,
		idFinancingSource	INT,
		idTypeWork			INT,
		idPost		INT,
		idPlanStaff INT,
		idFactStaff INT,
		idEmployee  INT,
		StaffCount	 NUMERIC(14,4),
		StaffCountWithoutReplacement			DECIMAL(8,2),	--кол-во ставок без замещений
		idReplacementReason	INT,								--причина замещения	 	
		IsMain			BIT,							--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		[SalaryKoeff] NUMERIC(6,2),
		Salary		DECIMAL(14,4),
		CalcStaffCount DECIMAL(14,4), --нерасчетное кол-во ставок
		CalcStaffCountWithoutReplacement DECIMAL(14,4),
		HourCount NUMERIC(14,2),
		PKSubSubCategoryNumberForSPO INT,
		DateBegin		DATE,		--дата принятия на работу (первоначальная)
		DateEnd			DATE,		--дата увольнения (если он уволен в данный период)
		HistoryDateBegin		DATE,	--дата изменения
		HistoryDateEnd			DATE	--дата окончания изменения
	)

	INSERT INTO @StaffTable(idDepartment, idFinancingSource, idTypeWork, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason,  [SalaryKoeff], Salary,PKSubSubCategoryNumberForSPO,
		CalcStaffCount, CalcStaffCountWithoutReplacement, DateBegin, DateEnd, HourCount,
		HistoryDateBegin, HistoryDateEnd)
	SELECT DISTINCT PeriodStaff.idDepartment, idFinancingSource, [FactStaffWithHistory].idTypeWork, idPost, 
		PeriodStaff.idPlanStaff, FactStaff.id, [FactStaff].idEmployee, [FactStaffWithHistory].StaffCount, 
		IIF([FactStaffWithHistory].IsReplacement=1, 0, [FactStaffWithHistory].StaffCount) StaffCountWithoutReplacement, 
		idReplacementReason, ISNULL(SalaryKoeff.SalaryKoeffc,1), SalarySize*ISNULL(SalaryKoeff.SalaryKoeffc,1), SalaryKoeff.PKSubSubCategoryNumber,
		[FactStaffWithHistory].CalcStaffCount, 
		IIF([FactStaffWithHistory].IsReplacement=1, 0, [FactStaffWithHistory].CalcStaffCount) CalcStaffCountWithoutReplacement, 
		FactStaff.DateBegin, FactStaff.DateEnd, [FactStaffWithHistory].HourCount,
		[FactStaffWithHistory].DateBegin, [FactStaffWithHistory].[DateEnd]
	FROM dbo.GetPlanStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff
		INNER JOIN [dbo].[FactStaffWithHistory] ON PeriodStaff.idPlanStaff=[FactStaffWithHistory].idPlanStaff
		INNER JOIN dbo.[FactStaffMain] FactStaff ON [FactStaffWithHistory].id=FactStaff.id
		INNER JOIN [dbo].[GetAllSalaryByPeriod](@PeriodBegin,@PeriodEnd) PlanStaffsWithSalaries
			ON  PeriodStaff.idPlanStaff=PlanStaffsWithSalaries.idPlanStaff
				AND ((PlanStaffsWithSalaries.DateBegin<=[FactStaffWithHistory].DateBegin AND (PlanStaffsWithSalaries.DateEnd>=[FactStaffWithHistory].DateBegin OR PlanStaffsWithSalaries.DateEnd IS NULL))
						OR (PlanStaffsWithSalaries.DateBegin>=[FactStaffWithHistory].DateBegin AND (PlanStaffsWithSalaries.DateBegin<=[FactStaffWithHistory].DateEnd OR [FactStaffWithHistory].DateEnd IS NULL)))
		LEFT JOIN [dbo].[SalaryKoeff] ON [FactStaffWithHistory].idSalaryKoeff=[SalaryKoeff].id	
		LEFT JOIN dbo.FactStaffReplacement
				ON [FactStaffWithHistory].id=FactStaffReplacement.idFactStaff
			AND (FactStaffReplacement.[DateEnd]>@PeriodBegin OR FactStaffReplacement.[DateEnd] IS NULL) AND [FactStaffWithHistory].IsReplacement=1
	WHERE [FactStaffWithHistory].idEmployee=@idEmployee
		AND (([FactStaffWithHistory].DateBegin<=@PeriodBegin AND ([FactStaffWithHistory].DateEnd>=@PeriodBegin OR [FactStaffWithHistory].DateEnd IS NULL))
			OR ([FactStaffWithHistory].DateBegin>=@PeriodBegin AND [FactStaffWithHistory].DateBegin<=@PeriodEnd))


	INSERT INTO @Result(ReportMainObjectName, EmployeeName,BonusLevel,BonusCount, idFactStaff, SeverKoeff, RayonKoeff,
			TypeWorkName, StaffCount, DepartmentName, PostName, idPlanStaff, NDFLKoeff, 
			BonusTypeName, idBonusType, StaffCountWithoutReplacement, PeriodBegin, PeriodEnd, 
			FinancingSourceName, PKCategoryName, HasEnvironmentBonus, CategoryName, PostFullName, DepartmentFullName,
			ForEmployee, MatOtpusk, SalaryKoeff, DateBegin, DateEnd,
			idBonusMeasure,IsStaffRateable,IsCalcStaffRateable, CalcStaffCount, CalcStaffCountWithoutReplacement, ReplacedEmployeeName, Salary)
	SELECT DISTINCT Employee.EmployeeSmallName,
			Employee.EmployeeSmallName EmployeeName,   AllBonus.BonusLevel, AllBonus.BonusCount, 
			AllBonus.idFactStaff, Employee.SeverKoeff, Employee.RayonKoeff, 
			WorkType.TypeWorkShortName+ISNULL(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')',''), PlanStaff.StaffCount, 
			Department.DepartmentSmallName, Post.PostShortName, PlanStaff.idPlanStaff, 
			(SELECT NDFLKoeff FROM [dbo].[GetBonusKoeffs](@PeriodBegin)), 
			ISNULL(BonusType.BonusTypeShortName, 'Базовый оклад'), BonusType.id, PlanStaff.StaffCountWithoutReplacement,
			@PeriodBegin, @PeriodEnd, FinancingSourceName,
			PKCategoryFullName+' '+ISNULL(CONVERT(VARCHAR(3),PKSubSubCategoryNumberForSPO),PKCategory.PKSubSubCategoryNumber),
			HasEnvironmentBonus, CategorySmallName,
			Post.PostShortName,Department.DepartmentSmallName,
			ForEmployee, otpusk.otpTypeShortName,[SalaryKoeff], PlanStaff.DateBegin, PlanStaff.DateEnd,
			idBonusMeasure,IsStaffRateable,IsCalcStaffRateable, CalcStaffCount, CalcStaffCountWithoutReplacement, '',Salary
	FROM
	
	(SELECT DISTINCT 'Сотрудник' BonusLevel, BonusCount, Staff.idFactStaff, idBonusType, 
		idReplacementReason, Staff.idPlanStaff, 
		NULL ForEmployee
	FROM @BonusTable as Bonus, dbo.BonusEmployee, @StaffTable as Staff
	
	WHERE  Bonus.id=BonusEmployee.idBonus
		AND BonusEmployee.idEmployee=@idEmployee
					AND Staff.IsMain=1
		
	UNION
	SELECT DISTINCT 'Распределение штатов', 
		BonusCount, Staff.idFactStaff, idBonusType,  
		idReplacementReason, Staff.idPlanStaff , NULL
	FROM @BonusTable as Bonus, @StaffTable as Staff, dbo.BonusFactStaff
	
	WHERE Bonus.id=BonusFactStaff.idBonus
		AND Staff.idFactStaff=BonusFactStaff.idFactStaff

	UNION
	SELECT DISTINCT 'Штатное расписание', 
		BonusCount, Staff.idFactStaff, idBonusType,  
		idReplacementReason, Staff.idPlanStaff , ForEmployee
	FROM @BonusTable as Bonus, @StaffTable as Staff, dbo.BonusPlanStaff
	
	WHERE Bonus.id=BonusPlanStaff.idBonus
		AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff
		
	UNION
	SELECT DISTINCT 'Должность', 
		BonusCount, Staff.idFactStaff, idBonusType,  
		idReplacementReason, Staff.idPlanStaff ,  NULL
	FROM @BonusTable as Bonus, @StaffTable as Staff, dbo.BonusPost
	
	WHERE Bonus.id=BonusPost.idBonus
		AND BonusPost.idPost=Staff.idPost
		
	UNION
	SELECT DISTINCT 'Оклад', 
		null, Staff.idFactStaff, null, idReplacementReason, 
		Staff.idPlanStaff,  NULL 
	FROM @StaffTable as Staff
	
		)AllBonus
			
		INNER JOIN dbo.Employee ON Employee.id=@idEmployee	
		INNER JOIN @StaffTable PlanStaff ON AllBonus.idPlanStaff=PlanStaff.idPlanStaff 
			AND (AllBonus.idFactStaff=PlanStaff.idFactStaff )
		INNER JOIN dbo.Department ON PlanStaff.idDepartment=Department.id
		INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.[GetFullPKCategory](@PeriodBegin,@PeriodEnd) PKCategory ON Post.idPKCategory=PKCategory.id
		INNER JOIN dbo.FinancingSource ON PlanStaff.idFinancingSource=FinancingSource.id
		
		LEFT JOIN dbo.BonusType ON AllBonus.idBonusType=BonusType.id
		--LEFT JOIN dbo.FactStaffWithHistory FactStaff ON AllBonus.idFactStaff=FactStaff.id
		LEFT JOIN dbo.WorkType ON PlanStaff.idTypeWork=WorkType.id
		LEFT JOIN dbo.FactStaffReplacementReason
			ON AllBonus.idReplacementReason=FactStaffReplacementReason.id
		LEFT JOIN
		  (SELECT idFactStaff, MIN(otpTypeShortName) otpTypeShortName  FROM
			[dbo].[GetOtpuskByPeriod](@PeriodBegin,@PeriodEnd)
			WHERE isMaternity=1
			GROUP BY idFactStaff) otpusk 

			ON PlanStaff.idFactStaff=otpusk.idFactStaff 
		
		--dbo.FactStaff, dbo.WorkType, dbo.PlanStaff, dbo.Department, 
		--dbo.Post, dbo.Category, dbo.PKCategory, dbo.PKGroup, dbo.BonusType,
		--dbo.Employee, dbo.FinancingSource
	--WHERE AllBonus.idFactStaff=FactStaff.id
	--	AND FactStaff.idTypeWork=WorkType.id
	--	AND FactStaff.idPlanStaff=PlanStaff.id
	--	AND PlanStaff.idDepartment=Department.id
	--	AND PlanStaff.idPost=Post.id
	--	AND PlanStaff.idCategory=Category.id
	--	AND Post.idPKCategory=PKCategory.id
	--	AND PKCategory.idPKGroup=PKGroup.id
	--	AND AllBonus.idBonusType=BonusType.id
	--	AND Employee.id=idEmployee
	--	AND PlanStaff.idFinancingSource=FinancingSource.id
	--ORDER BY --Department.DepartmentSmallName, 
		--Category.OrderBy, PKCategory.GroupNumber desc, 
		--PKCategory.PKCategoryNumber desc, EmployeeName, BonusCount 

		
		

	
		
	--размер оклада (независимо от ставки)
	--UPDATE @Result
	--SET Salary = SalarySize*SalaryKoeff
	--FROM @Result as res, [dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd) PlanStaffsWithSalaries
	--WHERE  res.idPlanStaff=PlanStaffsWithSalaries.idPlanStaff
			
			

	-- проценты
	UPDATE @Result
	SET BonusSum = CONVERT(DECIMAL(10,2),BonusCount)*Salary/100, 
		AllBonusSum=CONVERT(DECIMAL(10,2),BonusCount)*Salary/100
	FROM @Result as res
	WHERE   idBonusMeasure=1	--проценты

	--рубли
	UPDATE @Result
	SET BonusSum = BonusCount, AllBonusSum = BonusCount
	FROM @Result as res
	WHERE   idBonusMeasure<>1	--не проценты


	-- в зависимости от ставки
	UPDATE @Result
	SET BonusSum = CONVERT(DECIMAL(8,2),BonusSum*StaffCount), AllBonusSum=CONVERT(DECIMAL(8,2),BonusSum*StaffCount)
	FROM @Result as res
	WHERE   IsStaffRateable=1	--зависит от ставки
			
	-- в зависимости от расч ставки
	UPDATE @Result
	SET BonusSum = CONVERT(DECIMAL(8,2),BonusSum*CalcStaffCount), AllBonusSum=CONVERT(DECIMAL(8,2),BonusSum*CalcStaffCount)
	FROM @Result as res
	WHERE   IsCalcStaffRateable=1	--зависит от ставки
		
	-- не начисляются северные
	UPDATE @Result
	SET SeverKoeff=0, RayonKoeff=0
	FROM @Result as res, dbo.BonusType
	WHERE  res.idBonusType = BonusType.id
			AND BonusType.HasEnvironmentBonus=0

	UPDATE @Result 
	SET BonusSum = Salary*StaffCount, AllBonusSum = Salary*StaffCount
	WHERE idBonusType is null
	
	--Удаляем надбавки не для сотрудников
	DELETE FROM @Result 
	WHERE ForEmployee=0 
	
	UPDATE @Result
	SET AllBonusSum = BonusSum, BonusCount=BonusCount+' '+BonusMeasure.Sign
	FROM @Result as res, dbo.BonusType, dbo.BonusMeasure
	WHERE  res.idBonusType = BonusType.id
		AND BonusType.idBonusMeasure=BonusMeasure.id

	UPDATE @Result
	SET StaffCountWithoutReplacement=0, StaffCount=0, CalcStaffCountWithoutReplacement=0
	WHERE	idBonusType IS NOT NULL

/*
	--если cеверные накручиваются
	UPDATE @Result
	SET AllBonusSum = CONVERT(DECIMAL(8,2), BonusSum*(100+SeverKoeff+RayonKoeff)/100)
	FROM @Result as res, dbo.BonusType
	WHERE  res.idBonusType = BonusType.id
			AND HasEnvironmentBonus=1	--северные*/
			
		
 
		
RETURN
END



