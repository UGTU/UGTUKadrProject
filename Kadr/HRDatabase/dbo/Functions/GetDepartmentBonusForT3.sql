
--SELECT * from [dbo].[GetDepartmentBonusForT3](1, '9.01.2014','09.21.2014',1,4) where PostName IS NULL
--SELECT * from [dbo].[GetDepartmentBonusForT3](1, '1.01.2014','01.01.2014',1,7) where PostName IS NULL
--функция выбора надбавок для формирования отчета по форме Т3 на уровне отдела 
--Настройки: @WithSubDeps - с зависимыми отделами
--обозначение оклада -1
--последовательность столбцов надбавок фиксированное
CREATE FUNCTION [dbo].[GetDepartmentBonusForT3] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT,
@idBonusReport INT
)
RETURNS @Result TABLE
   (
    --TypeWorkName			VARCHAR(50) NULL,
	DepartmentName			VARCHAR(500),
    PKCategoryName			VARCHAR(50),
    FinancingSourceName		VARCHAR(50),
	FinancingSourceLowName	VARCHAR(50),
    PostName				VARCHAR(150) NULL,
    StaffCount				DECIMAL(14,4),
	SalaryBase				DECIMAL(14,2),
    Salary					DECIMAL(14,2),
	RealSalary				DECIMAL(14,2),
    idFactStaff				INT,
    idPlanStaff				INT,
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	StaffCountWithoutReplacement NUMERIC(14,4),	--кол-во ставок без замещений (т.е. если замещение, то эта ставка будет равна 0)
	StaffCountReal			NUMERIC(14,4),				--расчетная реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
	CalcStaffCountReal		NUMERIC(14,4),
	idReplacementReason	INT,						--причина замещения	 			
	HasEnvironmentBonus		BIT,
	HasIndivSalary			BIT,
	CategoryName			VARCHAR(50),
	idCategory				INT,
    --FinancingSourceFullName		VARCHAR(50),
	CategoryOrderBy INT,
	FinancingSourceOrderBy INT,
	idFinancingSource		INT,
	ManagerBit  BIT,
	BonusSum1				DECIMAL(14,2),
	BonusSum2				DECIMAL(14,2),
	BonusSum3				DECIMAL(14,2),
	BonusSum4				DECIMAL(14,2),
	BonusSum5				DECIMAL(14,2),
	BonusSum6				DECIMAL(14,2),
	BonusSum7				DECIMAL(14,2),
	BonusSum8				DECIMAL(14,2),
	DirectionManagerName	VARCHAR(70),
	idDepartment			INT,
	DepTreeIndex			VARCHAR(30),
	SalaryKoeffc			NUMERIC(6,2)	

   ) 
AS
BEGIN
	--если период задан некорректно, выходим
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	--объявляем временную таблицу, в которую внесем все надбавки за период
	DECLARE @BonusTable Table
	(
		id INT,
		BonusCount numeric(8,2),
		idBonusType INT,	
		BonusOrderNumber	INT,
		IsStaffRateable	BIT,
		IsCalcStaffRateable BIT,
		idBonusMeasure INT
	)
	
	--выбираем все надбавки за период
	INSERT INTO @BonusTable(id, BonusCount, idBonusType, BonusOrderNumber, IsStaffRateable, IsCalcStaffRateable, idBonusMeasure)
	SELECT idBonus, PeriodBonus.BonusCount, Bonus.idBonusType, BonusOrderNumber, [BonusType].IsStaffRateable, IsCalcStaffRateable, [BonusType].idBonusMeasure
	FROM [dbo].[GetBonusByPeriod](@PeriodBegin, @PeriodEnd) as PeriodBonus 
		INNER JOIN dbo.Bonus ON PeriodBonus.idBonus=Bonus.id
		INNER JOIN [dbo].[GetReportBonusOrder](@idBonusReport) bonusOrder ON bonusOrder.idBonusType=Bonus.idBonusType
		INNER JOIN [dbo].[BonusType] ON Bonus.idBonusType=[BonusType].id

--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
	idManagerPlanStaff	INT,
	DirectionManagerName	VARCHAR(70),
	[DepartmentName] VARCHAR(500),
	[DepartmentSmallName] VARCHAR(50),
	DepTreeIndex			VARCHAR(30)
	)
	
	INSERT INTO @DepTable	
	SELECT idDepartment, idManagerPlanStaff, DirectionManagerName, DepartmentName,DepartmentSmallName, DepTreeIndex
			FROM dbo.[GetDepartmentDataForReports](@idDepartment, @PeriodBegin, @PeriodEnd, @WithSubDeps,@idBonusReport)

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
		StaffCountWithoutReplacement NUMERIC(14,4),	--кол-во ставок без замещений (т.е. если замещение, то эта ставка будет равна 0)
		StaffCountReal	NUMERIC(14,4),				--расчетная реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
		CalcStaffCountReal		NUMERIC(14,4),				--реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
		IsMain			BIT,							--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		--DateBegin		DATETIME,		--дата принятия на работу (первоначальная)
		--DateEnd			DATETIME,		--дата увольнения (если он уволен в данный период)
		HourCount NUMERIC(14,2),
		SalaryBase				DECIMAL(14,2),
		Salary					DECIMAL(14,2),
		HasIndivSalary  BIT,
		idSalaryKoeff INT,
		DirectionManagerName VARCHAR(70),
		PKSubSubCategoryNumberForSPO INT,
		[DepartmentName] VARCHAR(500),
		[DepartmentSmallName] VARCHAR(50),
		DepTreeIndex			VARCHAR(30),
		SalaryKoeffc		NUMERIC(6,2)		
	)
	--выбираем свех сотрудников одела за период
	INSERT INTO @StaffTable(idDepartment, idFinancingSource, idTypeWork, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal, IsMain, 
		HourCount, SalaryBase, Salary, HasIndivSalary, idSalaryKoeff, DirectionManagerName, PKSubSubCategoryNumberForSPO, 
		DepartmentName,DepartmentSmallName, DepTreeIndex, SalaryKoeffc)
	SELECT Deps.idDepartment, idFinancingSource, PeriodStaff.idTypeWork, idPost, PeriodStaff.idPlanStaff, 
		idFactStaff, PeriodStaff.idEmployee, PeriodStaff.StaffCount, 
		StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal, IsMain, 
		PeriodStaff.HourCount, SalarySize, SalarySize*ISNULL(SalaryKoeff.[SalaryKoeffc],1), IsIndividual, PeriodStaff.idSalaryKoeff, 
		DirectionManagerName, SalaryKoeff.PKSubSubCategoryNumber, 
		DepartmentName,DepartmentSmallName, DepTreeIndex, (SalaryKoeff.[SalaryKoeffc]-1)*100
	FROM  @DepTable as Deps 
		INNER JOIN dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff
			ON PeriodStaff.idDepartment=Deps.idDepartment
		LEFT JOIN dbo.[FactStaffMain] FactStaff ON PeriodStaff.idFactStaff=FactStaff.id
		LEFT JOIN [dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd) PlanStaffsWithSalaries ON PeriodStaff.idPlanStaff=PlanStaffsWithSalaries.idPlanStaff
		LEFT JOIN [dbo].[SalaryKoeff] ON PlanStaffsWithSalaries.idCatSalaryKoeff=[SalaryKoeff].id
	WHERE idReplacementReason is null OR idPost is null
		

--объявляем временную таблицу для надбавок и их связи с сотрудником
	DECLARE @BonusFactStaff TABLE
   (
		idPlanStaff INT,
		idFactStaff INT,
		StaffCount	 NUMERIC(14,4),
		StaffCountWithoutReplacement NUMERIC(14,4),	--кол-во ставок без замещений (т.е. если замещение, то эта ставка будет равна 0)
		StaffCountReal	NUMERIC(14,4),				--расчетная реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
		CalcStaffCountReal		NUMERIC(14,4),				--реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
		--BonusLevel				VARCHAR(50)  NULL,
		BonusCount				VARCHAR(50) NULL,	--размер надбавки (м.б. задан в %, в руб...)
		BonusSum				DECIMAL(14,2),		--итоговая сумма надбавки (уже с учетом оклада и ставки)
		--AllBonusSum			DECIMAL(10,2),		--реальная сумма надбавки (учитывается для расчета итоговых сумм - учитывает замещения, но не учитывает тех, кого замещают)
		SeverKoeff				INT,
		RayonKoeff				INT,
		idBonusType				INT,
		--HasEnvironmentBonus		BIT,
		ForVacancy				BIT,
		ForEmployee				BIT,
		IsStaffRateable	BIT,
		IsCalcStaffRateable BIT,
		idBonusMeasure INT,
		Salary DECIMAL(14,2),
		IsVacancy BIT,
		BonusOrderNumber INT
   ) 
   	--итоговый запрос, объединяющий надбавки и сотрудников за период
	INSERT INTO @BonusFactStaff(idPlanStaff, idFactStaff, StaffCount, StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal,
		 BonusCount, BonusSum,	
		SeverKoeff, RayonKoeff, idBonusType, ForVacancy, ForEmployee, IsStaffRateable, IsCalcStaffRateable,
		idBonusMeasure, Salary, IsVacancy, BonusOrderNumber)
	SELECT idPlanStaff, idFactStaff, StaffCount, StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal, 
		 SUM(BonusCount), 0,	
		SeverKoeff, RayonKoeff, idBonusType, ForVacancy, ForEmployee, IsStaffRateable, IsCalcStaffRateable,
		idBonusMeasure, Salary, IsVacancy, BonusOrderNumber
	FROM
	
	(
	--выбираем надбавки сотрудника (Employee)
	SELECT DISTINCT --'Сотрудник' BonusLevel, 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount as StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal, 
		NULL ForVacancy,NULL ForEmployee, IsStaffRateable, IsCalcStaffRateable, 
		idBonusMeasure, Staff.Salary, 0 as IsVacancy, BonusOrderNumber
	FROM @BonusTable as Bonus 
		INNER JOIN dbo.BonusEmployee ON Bonus.id=BonusEmployee.idBonus
		INNER JOIN dbo.Employee ON BonusEmployee.idEmployee=Employee.id
		INNER JOIN @StaffTable as Staff ON Staff.idEmployee=BonusEmployee.idEmployee
			AND Staff.IsMain=1
		
		
	--выбираем надбавки записи штатного расписания (FactStaff)	
	UNION
	SELECT --'Распределение штатов', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal, 
		NULL ForVacancy,NULL ForEmployee, IsStaffRateable, IsCalcStaffRateable, 
		idBonusMeasure, Staff.Salary, 0 as IsVacancy, BonusOrderNumber
	FROM @BonusTable as Bonus
		INNER JOIN  dbo.BonusFactStaff ON Bonus.id=BonusFactStaff.idBonus	
		INNER JOIN @StaffTable as Staff ON BonusFactStaff.idFactStaff=Staff.idFactStaff	
		INNER JOIN dbo.Employee ON Staff.idEmployee=Employee.ID --BonusFactStaff.idEmployee=Employee.id	WHERE 
		
	--выбираем надбавки штатной единицы (planStaff)
	UNION
	SELECT--'Штатное расписание', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal, 
		ForVacancy, ForEmployee, IsStaffRateable, IsCalcStaffRateable, 
		idBonusMeasure, Staff.Salary, ISNULL(Employee.ID-Employee.ID,1) as IsVacancy, BonusOrderNumber
	FROM @BonusTable as Bonus, dbo.BonusPlanStaff, 
		@StaffTable as Staff left join dbo.Employee on Staff.idEmployee=Employee.ID
	WHERE Bonus.id=BonusPlanStaff.idBonus
		AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff
	
	--выбираем надбавки должности (Post)	
	UNION
	SELECT --'Должность', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal, 
		NULL ForVacancy,NULL ForEmployee, IsStaffRateable, IsCalcStaffRateable, 
		idBonusMeasure, Staff.Salary, ISNULL(Employee.ID-Employee.ID,1) as IsVacancy, BonusOrderNumber
	FROM @BonusTable as Bonus, dbo.BonusPost, @StaffTable as Staff left join dbo.Employee on Staff.idEmployee=Employee.ID
	WHERE Bonus.id=BonusPost.idBonus
		AND BonusPost.idPost=Staff.idPost
	/*
	--выбираем оклад	
	UNION	
	SELECT ISNULL(Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch, 'Вакансия'),'Оклад', 
		null as BonusCount, Staff.idPlanStaff, Staff.idFactStaff, ISNULL(SeverKoeff, 50), ISNULL(RayonKoeff, 30), -1, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee, 0, 0
	FROM @StaffTable as Staff 
		left join dbo.Employee on Staff.idEmployee=Employee.ID*/)AllBonus
		
	GROUP BY  idPlanStaff, idFactStaff, StaffCount, StaffCountWithoutReplacement, StaffCountReal, CalcStaffCountReal, 
		SeverKoeff, RayonKoeff, idBonusType, ForVacancy, ForEmployee, IsStaffRateable, IsCalcStaffRateable, 
		idBonusMeasure, Salary, IsVacancy, BonusOrderNumber


	-- проценты
	UPDATE @BonusFactStaff
	SET BonusSum = CONVERT(DECIMAL(14,2),BonusCount)*Salary/100
	FROM @BonusFactStaff as res
	WHERE idBonusMeasure=1	--проценты

	--рубли
	UPDATE @BonusFactStaff
	SET BonusSum = BonusCount
	FROM @BonusFactStaff as res
	WHERE  idBonusMeasure<>1	--не проценты


	-- в зависимости от ставки
	UPDATE @BonusFactStaff
	SET BonusSum = CONVERT(DECIMAL(14,2),BonusSum*StaffCountReal)
	FROM @BonusFactStaff as res
	WHERE  IsStaffRateable=1	--зависит от ставки
			
	-- в зависимости от расч ставки
	UPDATE @BonusFactStaff
	SET BonusSum = CONVERT(DECIMAL(14,2),BonusSum*CalcStaffCountReal)
	FROM @BonusFactStaff as res
	WHERE  IsCalcStaffRateable=1	--зависит от ставки
	
	--Удаляем надбавки не для сотрудников
	DELETE FROM  @BonusFactStaff 
	WHERE ForEmployee=0 AND IsVacancy=0
	
	--Удаляем надбавки не для "вакансий"
	DELETE FROM  @BonusFactStaff 
	WHERE ForVacancy=0 AND IsVacancy=1




	--итоговый запрос, объединяющий надбавки и сотрудников за период
	INSERT INTO @Result(DepartmentName, PKCategoryName, FinancingSourceName, FinancingSourceLowName, PostName, StaffCount, SalaryBase, Salary, RealSalary,idFactStaff, idPlanStaff,
	PeriodBegin, PeriodEnd, StaffCountWithoutReplacement, StaffCountReal,  --HasEnvironmentBonus,
	HasIndivSalary, CategoryName, idCategory, 
 	CategoryOrderBy, FinancingSourceOrderBy, idFinancingSource, ManagerBit,
	BonusSum1, BonusSum2, BonusSum3, BonusSum4, BonusSum5, BonusSum6, BonusSum7, BonusSum8, DirectionManagerName, idDepartment, DepTreeIndex, SalaryKoeffc)
	SELECT PlanStaff.DepartmentName,
			PKCategory.PKCategoryFullName+' '+PKCategory.PKSubSubCategoryNumber,--ISNULL(CONVERT(VARCHAR(3),PKSubSubCategoryNumberForSPO),PKCategory.PKSubSubCategoryNumber),
			FinancingSourceName, LOWER(FinancingSourceName), [PostName],
			PlanStaff.StaffCount, PlanStaff.SalaryBase, PlanStaff.Salary, PlanStaff.Salary*PlanStaff.StaffCountWithoutReplacement, PlanStaff.idFactStaff,  PlanStaff.idPlanStaff, 
			@PeriodBegin, @PeriodEnd, PlanStaff.StaffCountWithoutReplacement, PlanStaff.StaffCountReal,  
			--PlanStaff.HasEnvironmentBonus, 
			PlanStaff.HasIndivSalary,
			CategorySmallName, Post.idCategory,
			Category.OrderBy,FinancingSource.OrderBy, PlanStaff.idFinancingSource, Post.ManagerBit,
			Bonus1.BonusSum, Bonus2.BonusSum, Bonus3.BonusSum, Bonus4.BonusSum, 
			Bonus5.BonusSum, Bonus6.BonusSum, Bonus7.BonusSum, Bonus8.BonusSum, PlanStaff.DirectionManagerName, PlanStaff.idDepartment, DepTreeIndex, SalaryKoeffc
	FROM
		@StaffTable PlanStaff
	-- ON 
		LEFT JOIN dbo.Post ON PlanStaff.idPost=Post.id
		LEFT JOIN dbo.Category ON Post.idCategory=Category.id
		LEFT JOIN dbo.[GetFullPKCategory](@PeriodBegin,@PeriodEnd) PKCategory ON Post.idPKCategory=PKCategory.id
		LEFT JOIN dbo.FinancingSource ON PlanStaff.idFinancingSource=FinancingSource.id
		LEFT JOIN (SELECT idFactStaff, idPlanStaff,SUM(BonusSum)BonusSum FROM @BonusFactStaff WHERE BonusOrderNumber=1 GROUP BY idFactStaff, idPlanStaff)Bonus1
			ON Bonus1.idPlanStaff=PlanStaff.idPlanStaff 
				AND (Bonus1.idFactStaff=PlanStaff.idFactStaff or (Bonus1.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		LEFT JOIN (SELECT idFactStaff, idPlanStaff,SUM(BonusSum)BonusSum FROM @BonusFactStaff WHERE BonusOrderNumber=2 GROUP BY idFactStaff, idPlanStaff)Bonus2
			ON Bonus2.idPlanStaff=PlanStaff.idPlanStaff 
				AND (Bonus2.idFactStaff=PlanStaff.idFactStaff or (Bonus2.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		LEFT JOIN (SELECT idFactStaff, idPlanStaff,SUM(BonusSum)BonusSum FROM @BonusFactStaff WHERE BonusOrderNumber=3 GROUP BY idFactStaff, idPlanStaff)Bonus3
			ON Bonus3.idPlanStaff=PlanStaff.idPlanStaff 
				AND (Bonus3.idFactStaff=PlanStaff.idFactStaff or (Bonus3.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		LEFT JOIN (SELECT idFactStaff, idPlanStaff,SUM(BonusSum)BonusSum FROM @BonusFactStaff WHERE BonusOrderNumber=4 GROUP BY idFactStaff, idPlanStaff)Bonus4
			ON Bonus4.idPlanStaff=PlanStaff.idPlanStaff 
				AND (Bonus4.idFactStaff=PlanStaff.idFactStaff or (Bonus4.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		LEFT JOIN (SELECT idFactStaff, idPlanStaff,SUM(BonusSum)BonusSum FROM @BonusFactStaff WHERE BonusOrderNumber=5 GROUP BY idFactStaff, idPlanStaff)Bonus5
			ON Bonus5.idPlanStaff=PlanStaff.idPlanStaff 
				AND (Bonus5.idFactStaff=PlanStaff.idFactStaff or (Bonus5.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		LEFT JOIN (SELECT idFactStaff, idPlanStaff,SUM(BonusSum)BonusSum FROM @BonusFactStaff WHERE BonusOrderNumber=6 GROUP BY idFactStaff, idPlanStaff)Bonus6
			ON Bonus6.idPlanStaff=PlanStaff.idPlanStaff 
				AND (Bonus6.idFactStaff=PlanStaff.idFactStaff or (Bonus6.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		LEFT JOIN (SELECT idFactStaff, idPlanStaff,SUM(BonusSum)BonusSum FROM @BonusFactStaff WHERE BonusOrderNumber=7 GROUP BY idFactStaff, idPlanStaff)Bonus7
			ON Bonus7.idPlanStaff=PlanStaff.idPlanStaff 
				AND (Bonus7.idFactStaff=PlanStaff.idFactStaff or (Bonus7.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		LEFT JOIN (SELECT idFactStaff, idPlanStaff,SUM(BonusSum)BonusSum FROM @BonusFactStaff WHERE BonusOrderNumber=8 GROUP BY idFactStaff, idPlanStaff)Bonus8
			ON Bonus8.idPlanStaff=PlanStaff.idPlanStaff 
				AND (Bonus8.idFactStaff=PlanStaff.idFactStaff or (Bonus8.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))

	--для индивидуальных окладов ПКГ отмечаем звездочкой
		UPDATE @Result
		SET PKCategoryName = PKCategoryName + '*'
		WHERE HasIndivSalary=1

	IF (@idBonusReport = 7)
		UPDATE @Result
		SET PKCategoryName = ''
		WHERE SalaryKoeffc IS NOT NULL

	--ELSE
	
	/*-- не начисляются северные
	UPDATE @Result
	SET SeverKoeff=0, RayonKoeff=0
	FROM @Result as res, dbo.BonusType
	WHERE  res.idBonusType = BonusType.id
			AND BonusType.HasEnvironmentBonus=0

	--ставку обнуляем для не окладов (чтобы не суммировалась)
	UPDATE @Result
	SET StaffCountWithoutReplacement=0, StaffCount=0
	FROM @Result as res
	WHERE  res.idBonusType is not null*/

	INSERT INTO @Result(DepartmentName, FinancingSourceName, FinancingSourceLowName, 
	PeriodBegin, PeriodEnd, FinancingSourceOrderBy, idFinancingSource, DirectionManagerName, idDepartment, DepTreeIndex, SalaryKoeffc)
	SELECT DepartmentName, FinancingSourceName, LOWER(FinancingSourceName), 
		@PeriodBegin, @PeriodEnd, FinancingSource.OrderBy, FinancingSource.id, DirectionManagerName, idDepartment, DepTreeIndex, NULL
	FROM (SELECT * FROM @DepTable deps WHERE deps.DepartmentName NOT IN (SELECT DepartmentName FROM @Result))deps
	CROSS JOIN (SELECT * FROM dbo.FinancingSource WHERE FinancingSource.id IN (SELECT idFinancingSource FROM @Result))FinancingSource
	-- AND 
		
		

RETURN
END




