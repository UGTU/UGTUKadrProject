USE [Kadr]
GO
/****** Object:  UserDefinedFunction [dbo].[GetDepartmentBonusWithSettings]    Script Date: 04.09.2013 11:40:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SELECT * from [dbo].[GetDepartmentBonusWithSettings](1, '1.08.2013','28.09.2013',1,1,-1) where BonusTypeName is null
--функция выбора надбавок для формирования отчетов на уровне отдела 
--Настройки: @WithSubDeps - с зависимыми отделами, @idBonusReport - код отчета для получения остальных настроек отчета
--обозначение оклада -1
ALTER FUNCTION [dbo].[GetDepartmentBonusWithSettings] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT,
@idBonusReport		 INT,
@idWorkType INT		--фильтр по типу работы сотрудника
)
RETURNS @Result TABLE
   (
    ReportMainObjectName	VARCHAR(200),
    TypeWorkName			VARCHAR(50) NULL,
    PKCategoryName			VARCHAR(50),
    FinancingSourceName		VARCHAR(50),
    BonusTypeName			VARCHAR(50),
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    ReplacedEmployeeName	VARCHAR(150) NULL,	--ФИО замещаемого
    BonusLevel				VARCHAR(50)  NULL,
    BonusCount				VARCHAR(50) NULL,	--размер надбавки (м.б. задан в %, в руб...)
    BonusSum				DECIMAL(14,2),		--итоговая сумма надбавки (уже с учетом оклада и ставки)
    AllBonusSum			DECIMAL(14,2),		--реальная сумма надбавки (учитывается для расчета итоговых сумм - учитывает замещения, но не учитывает тех, кого замещают)
    StaffCount				DECIMAL(14,4),
    Salary					DECIMAL(14,2),
    idFactStaff				INT,
    idPlanStaff				INT,
    SeverKoeff				INT,
    RayonKoeff				INT,
    NDFLKoeff				INT,
	DepartmentName			VARCHAR(150),
	idBonusType				INT,
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	StaffCountWithoutReplacement NUMERIC(14,4),	--кол-во ставок без замещений (т.е. если замещение, то эта ставка будет равна 0)
	StaffCountReal	NUMERIC(14,4),				--реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
	idReplacementReason	INT,						--причина замещения	 			
	HasEnvironmentBonus		BIT,
	HasIndivSalary			BIT,
	GlobalPrikazName		VARCHAR(50),
	GlobalPrikazFullName	VARCHAR(50),
	BonusSuperTypeName		VARCHAR(50),
	CategoryName			VARCHAR(50),
	idCategory				INT,
	WorkSuperTypeName		VARCHAR(50),
	DirectionManagerName	VARCHAR(70),
	BonusOrderNumber		INT,
	PostFullName			VARCHAR(150),
	DepartmentFullName		VARCHAR(200),
	DateBegin		VARCHAR(10),		--дата принятия на работу (первоначальная)
	DateEnd			VARCHAR(10),
	ForVacancy				BIT,
	ForEmployee				BIT,
    MatOtpusk VARCHAR(10),
    BonusTypeFullName			VARCHAR(50),
    HourCount NUMERIC(10,2),
    FinancingSourceFullName		VARCHAR(50),
	PostComment VARCHAR(150),
	SalaryKoeff  NUMERIC(14,2),
	PKCategoryFullName VARCHAR(50),
	CategoryOrderBy INT,
	FinancingSourceOrderBy INT,
	ManagerBit  BIT,
	PostTypeName VARCHAR(50),
	PostCode VARCHAR(20),
	BonusFinancingSourceName VARCHAR(50),
	idEmployee INT,
	[idlaborcontrakt] INT,
	EmployeeSmallName VARCHAR(60)
   ) 
AS
BEGIN
	--если период задан некорректно, выходим
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	--если такого отчета нет, выходим
	IF NOT EXISTS (SELECT 'TRUE' FROM dbo.BonusReport WHERE id=@idBonusReport)
		RETURN
		
	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
--объявляем временную таблицу, в которую внесем все надбавки за период
	DECLARE @BonusTable Table
	(
		id INT,
		BonusCount numeric(8,2),
		idBonusType INT,
		BonusFinancingSourceName VARCHAR(50)
	)

	
	--выбираем все надбавки за период
	INSERT INTO @BonusTable(id, BonusCount, idBonusType, BonusFinancingSourceName)
	SELECT idBonus, PeriodBonus.BonusCount, Bonus.idBonusType, BonusFinancingSource.FinancingSourceName
	FROM [dbo].[GetBonusByPeriod](@PeriodBegin, @PeriodEnd) as PeriodBonus INNER JOIN dbo.Bonus ON PeriodBonus.idBonus=Bonus.id
		LEFT JOIN dbo.FinancingSource BonusFinancingSource ON PeriodBonus.idFinancingSource=BonusFinancingSource.id
			AND PeriodBonus.idFinancingSource>0
	


	
--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
	idManagerPlanStaff	INT,
	DirectionManagerName	VARCHAR(70)
	)
	
	INSERT INTO @DepTable	
	SELECT idDepartment, idManagerPlanStaff, DirectionManagerName
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
		StaffCountReal	NUMERIC(14,4),				--реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
		idReplacementReason	INT,								--причина замещения	 	
		IsMain			BIT,							--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		DirectionManagerName	VARCHAR(70),
		ReplacedEmployeeName	VARCHAR(150) NULL,	--ФИО замещаемого
		DateBegin		DATETIME,		--дата принятия на работу (первоначальная)
		DateEnd			DATETIME,		--дата увольнения (если он уволен в данный период)
		HourCount NUMERIC(14,2),
		Salary					DECIMAL(14,2),
		HasIndivSalary  BIT,
		idSalaryKoeff INT,
		[idlaborcontrakt] INT,
		PKSubSubCategoryNumberForSPO INT
	)

	--выбираем свех сотрудников одела за период
	INSERT INTO @StaffTable(idDepartment, idFinancingSource, idTypeWork, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason, IsMain, ReplacedEmployeeName,
		DateBegin, DateEnd, HourCount, Salary, HasIndivSalary, idSalaryKoeff, DirectionManagerName,[idlaborcontrakt],
		PKSubSubCategoryNumberForSPO)
	SELECT PeriodStaff.idDepartment, idFinancingSource, PeriodStaff.idTypeWork, idPost, PeriodStaff.idPlanStaff, 
		idFactStaff, PeriodStaff.idEmployee, PeriodStaff.StaffCount, 
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason, IsMain, 
		ReplacedEmployeeName,
		FactStaff.DateBegin,FactStaff.DateEnd,PeriodStaff.HourCount, SalarySize*ISNULL(SalaryKoeff.[SalaryKoeffc],1), IsIndividual, PeriodStaff.idSalaryKoeff, DirectionManagerName,
		FactStaff.[idlaborcontrakt], SalaryKoeff.PKSubSubCategoryNumber
	FROM dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff 
		INNER JOIN @DepTable as Deps ON PeriodStaff.idDepartment=Deps.idDepartment
		INNER JOIN [dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd) PlanStaffsWithSalaries ON PeriodStaff.idPlanStaff=PlanStaffsWithSalaries.idPlanStaff
		LEFT JOIN dbo.[FactStaffMain] FactStaff ON PeriodStaff.idFactStaff=FactStaff.id
		LEFT JOIN [dbo].[SalaryKoeff] ON PeriodStaff.idSalaryKoeff=[SalaryKoeff].id
	WHERE ((PeriodStaff.idTypeWork = @idWorkType OR PeriodStaff.idTypeWork IS NULL) AND @idWorkType>-1)
		OR (@idWorkType = -1)
		
	--Обнуляем DateEnd, если он не в периоде
	UPDATE @StaffTable
	SET DateEnd=NULL
	WHERE DateEnd NOT BETWEEN @PeriodBegin	AND @PeriodEnd
	
	--Удаляем замещения, если это указано в параметрах отчета
	IF EXISTS(SELECT 'TRUE' FROM dbo.BonusReport WHERE id=@idBonusReport AND WithReplacements=0)
		DELETE FROM @StaffTable 
			WHERE idReplacementReason is not null
		
	--итоговый запрос, объединяющий надбавки и сотрудников за период
	INSERT INTO @Result(ReportMainObjectName, EmployeeName, BonusLevel, BonusCount, idFactStaff, SeverKoeff, RayonKoeff,
			TypeWorkName, StaffCount, DepartmentName, PostName, idPlanStaff, NDFLKoeff, 
			BonusTypeName, BonusTypeFullName, idBonusType, FinancingSourceName, PKCategoryName,
			PeriodBegin, PeriodEnd, StaffCountWithoutReplacement, StaffCountReal, idReplacementReason, 
			HasEnvironmentBonus, GlobalPrikazName, GlobalPrikazFullName, 
			BonusSuperTypeName, CategoryName, idCategory, WorkSuperTypeName,
			DirectionManagerName, ReplacedEmployeeName, BonusOrderNumber, 
			PostFullName, DepartmentFullName,
			DateBegin,DateEnd,
			ForVacancy,ForEmployee, MatOtpusk, HourCount, FinancingSourceFullName, PostComment, SalaryKoeff, PKCategoryFullName,
			CategoryOrderBy,FinancingSourceOrderBy, ManagerBit, PostTypeName, PostCode, Salary, HasIndivSalary,
			BonusFinancingSourceName, idEmployee, [idlaborcontrakt], EmployeeSmallName)
	SELECT Department.DepartmentName, AllBonus.EmployeeName, AllBonus.BonusLevel, AllBonus.BonusCount, 
			AllBonus.idFactStaff, ISNULL(50, AllBonus.SeverKoeff) ,ISNULL(30, AllBonus.RayonKoeff), 
			WorkType.TypeWorkShortName+ISNULL(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')',''), AllBonus.StaffCount, 
			Department.DepartmentSmallName, Post.PostShortName, PlanStaff.idPlanStaff, 
			(SELECT NDFLKoeff FROM [dbo].[GetBonusKoeffs](@PeriodBegin)), 
			ISNULL(BonusType.BonusTypeShortName,'Базовый оклад'), ISNULL(BonusType.BonusTypeName,'Базовый оклад'), BonusType.id, FinancingSource.FinancingSourceName,
			PKCategoryFullName+ISNULL(' '+CONVERT(VARCHAR(3),PKSubSubCategoryNumberForSPO),''),
			@PeriodBegin, @PeriodEnd, AllBonus.StaffCountWithoutReplacement, AllBonus.StaffCountReal, AllBonus.idReplacementReason, 
			HasEnvironmentBonus, ISNULL(CONVERT(VARCHAR(10), GlobalPrikaz.DateBegin,103),'') +' № '+ ISNULL(GlobalPrikaz.PrikazNumber,'') GlobalPrikazName,
			GlobalPrikaz.PrikazName GlobalPrikazFullName,
			BonusSuperType.BonusSuperTypeName, CategorySmallName, Post.idCategory,
			ISNULL(WorkSuperTypeShortName,'Вак.'), DirectionManagerName, ReplacedEmployeeName, BonusOrderNumber,
			Post.PostName, Department.DepartmentName,
			CONVERT(VARCHAR(10),AllBonus.DateBegin,104),
			CONVERT(VARCHAR(10),AllBonus.DateEnd,104),
			ForVacancy,ForEmployee, otpusk.otpTypeShortName, PlanStaff.HourCount, LOWER(FinancingSource.FinancingSourceName), Comment, null,
			PKCategoryFullName+ISNULL(' '+CONVERT(VARCHAR(3),PKSubSubCategoryNumberForSPO),''),
			Category.OrderBy,FinancingSource.OrderBy, Post.ManagerBit, PostTypeName, PostCode, PlanStaff.Salary, PlanStaff.HasIndivSalary, ISNULL(AllBonus.BonusFinancingSourceName, FinancingSource.FinancingSourceName), idEmployee,
			[idlaborcontrakt], EmployeeSmallName
	FROM
	
	(
	--выбираем надбавки сотрудника (Employee)
	SELECT DISTINCT Employee.EmployeeName,
		Employee.EmployeeSmallName, 'Сотрудник' BonusLevel, 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount as StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee, BonusFinancingSourceName
	FROM @BonusTable as Bonus 
		INNER JOIN dbo.BonusEmployee ON Bonus.id=BonusEmployee.idBonus
		INNER JOIN dbo.Employee ON BonusEmployee.idEmployee=Employee.id
		INNER JOIN @StaffTable as Staff ON Staff.idEmployee=BonusEmployee.idEmployee
			AND Staff.IsMain=1
		
		
	--выбираем надбавки записи штатного расписания (FactStaff)	
	UNION
	SELECT Employee.EmployeeName,
		Employee.EmployeeSmallName, 'Распределение штатов', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee, BonusFinancingSourceName
	FROM @BonusTable as Bonus
		INNER JOIN  dbo.BonusFactStaff ON Bonus.id=BonusFactStaff.idBonus	
		INNER JOIN @StaffTable as Staff ON BonusFactStaff.idFactStaff=Staff.idFactStaff	
		INNER JOIN dbo.Employee ON Staff.idEmployee=Employee.ID --BonusFactStaff.idEmployee=Employee.id	WHERE 
		
	--выбираем надбавки штатной единицы (planStaff)
	UNION
	SELECT ISNULL(Employee.EmployeeName, 'Вакансия'),
		ISNULL(Employee.EmployeeSmallName, 'Вакансия') EmployeeSmallName, 'Штатное расписание', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		ForVacancy, ForEmployee, BonusFinancingSourceName
	FROM @BonusTable as Bonus, dbo.BonusPlanStaff, 
		@StaffTable as Staff left join dbo.Employee on Staff.idEmployee=Employee.ID
	WHERE Bonus.id=BonusPlanStaff.idBonus
		AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff
	
	--выбираем надбавки должности (Post)	
	UNION
	SELECT ISNULL(Employee.EmployeeName, 'Вакансия'),
		ISNULL(Employee.EmployeeSmallName, 'Вакансия'),'Должность', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason ,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee, BonusFinancingSourceName
	FROM @BonusTable as Bonus, dbo.BonusPost, @StaffTable as Staff left join dbo.Employee on Staff.idEmployee=Employee.ID
	WHERE Bonus.id=BonusPost.idBonus
		AND BonusPost.idPost=Staff.idPost
	
	--выбираем оклад	
	UNION	
	SELECT ISNULL(Employee.EmployeeName, 'Вакансия'),
		ISNULL(Employee.EmployeeSmallName, 'Вакансия'),'Оклад', 
		null as BonusCount, Staff.idPlanStaff, Staff.idFactStaff, ISNULL(SeverKoeff, 50), ISNULL(RayonKoeff, 30), -1, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee, NULL
	FROM @StaffTable as Staff 
		left join dbo.Employee on Staff.idEmployee=Employee.ID)AllBonus
		
		INNER JOIN @StaffTable PlanStaff ON AllBonus.idPlanStaff=PlanStaff.idPlanStaff 
			AND (AllBonus.idFactStaff=PlanStaff.idFactStaff or (AllBonus.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		INNER JOIN dbo.Department ON PlanStaff.idDepartment=Department.id
		INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.[GetFullPKCategory](@PeriodBegin,@PeriodEnd) PKCategory ON Post.idPKCategory=PKCategory.id
		INNER JOIN dbo.FinancingSource ON PlanStaff.idFinancingSource=FinancingSource.id
		INNER JOIN [dbo].[GetReportBonusOrder](@idBonusReport) bonusOrder ON bonusOrder.idBonusType=AllBonus.idBonusType
		LEFT JOIN dbo.GlobalPrikaz ON Post.idGlobalPrikaz=GlobalPrikaz.id
		LEFT JOIN dbo.BonusType ON AllBonus.idBonusType=BonusType.id
		LEFT JOIN dbo.BonusSuperType ON BonusType.idBonusSuperType=BonusSuperType.id
		--LEFT JOIN dbo.FactStaffWithHistory FactStaff ON AllBonus.idFactStaff=FactStaff.id
		LEFT JOIN dbo.WorkType ON PlanStaff.idTypeWork=WorkType.id
		LEFT JOIN dbo.WorkSuperType ON WorkType.idWorkSuperType=WorkSuperType.id
		LEFT JOIN dbo.FactStaffReplacementReason
			ON AllBonus.idReplacementReason=FactStaffReplacementReason.id
		LEFT JOIN 
		(SELECT idFactStaff, MIN(otpTypeShortName) otpTypeShortName  FROM
			[dbo].[GetOtpuskByPeriod](@PeriodBegin,@PeriodEnd)
			WHERE isMaternity=1
			GROUP BY idFactStaff) otpusk 
			ON PlanStaff.idFactStaff=otpusk.idFactStaff 
		LEFT JOIN [dbo].[PostType] ON Post.idPostType=PostType.id
		
	--ORDER BY Department.DepartmentSmallName, Category.OrderBy, PKGroup.GroupNumber desc, 
	--	PKCategory.PKCategoryNumber desc, Post.PostShortName, FinancingSource.OrderBy, EmployeeName, BonusOrderNumber

	
	
	
	UPDATE @Result
	SET BonusSuperTypeName='За должность'
	WHERE BonusLevel='Должность'
	
	UPDATE @Result
	SET BonusSuperTypeName='Оклад'
	WHERE BonusLevel='Оклад'
			
		

	-- проценты
	UPDATE @Result
	SET BonusSum = CONVERT(DECIMAL(14,2),BonusCount)*Salary/100, 
		AllBonusSum=CONVERT(DECIMAL(14,2),BonusCount)*Salary/100
	FROM @Result as res, dbo.BonusType
	WHERE  res.idBonusType = BonusType.id
			AND idBonusMeasure=1	--проценты

	--рубли
	UPDATE @Result
	SET BonusSum = BonusCount, AllBonusSum = BonusCount
	FROM @Result as res, dbo.BonusType
	WHERE  res.idBonusType = BonusType.id
			AND idBonusMeasure<>1	--не проценты


	-- в зависимости от ставки
	UPDATE @Result
	SET BonusSum = CONVERT(DECIMAL(14,2),BonusSum*StaffCount), 
		AllBonusSum = CONVERT(DECIMAL(14,2),AllBonusSum*StaffCountReal)
	FROM @Result as res, dbo.BonusType
	WHERE  res.idBonusType = BonusType.id
			AND IsStaffRateable=1	--зависит от ставки
			
			
	UPDATE @Result 
	SET BonusSum = Salary*StaffCount, AllBonusSum = Salary*StaffCountReal
	WHERE idBonusType is null
	
	--Удаляем надбавки не для сотрудников
	DELETE FROM  @Result 
	WHERE ForEmployee=0 AND EmployeeName!='Вакансия'
	
	--Удаляем надбавки не для "вакансий"
	DELETE FROM  @Result 
	WHERE ForVacancy=0 AND EmployeeName='Вакансия'
	
	--для индивидуальных окладов ПКГ отмечаем звездочкой
	UPDATE @Result
	SET PKCategoryName = PKCategoryName + '*', PKCategoryFullName=PKCategoryFullName + '*'
	WHERE HasIndivSalary=1
	
	-- не начисляются северные
	UPDATE @Result
	SET SeverKoeff=0, RayonKoeff=0
	FROM @Result as res, dbo.BonusType
	WHERE  res.idBonusType = BonusType.id
			AND BonusType.HasEnvironmentBonus=0

	--ставку обнуляем для не окладов (чтобы не суммировалась)
	UPDATE @Result
	SET StaffCountWithoutReplacement=0, StaffCount=0
	FROM @Result as res
	WHERE  res.idBonusType is not null

	/*IF (@idBonusReport=4)
	begin
		insert into @Result(ReportMainObjectName, EmployeeName, BonusLevel, BonusCount, idFactStaff, SeverKoeff, RayonKoeff,
			TypeWorkName, StaffCount, DepartmentName, PostName, idPlanStaff, NDFLKoeff, 
			BonusTypeFullName, idBonusType, FinancingSourceName, PKCategoryName,
			PeriodBegin, PeriodEnd, StaffCountWithoutReplacement, StaffCountReal, idReplacementReason, 
			HasEnvironmentBonus, GlobalPrikazName, GlobalPrikazFullName, 
			BonusSuperTypeName, CategoryName, idCategory, WorkSuperTypeName,
			DirectionManagerName, ReplacedEmployeeName, BonusOrderNumber, 
			PostFullName, DepartmentFullName,
			DateBegin,DateEnd,
			ForVacancy,ForEmployee, MatOtpusk, Salary, BonusSum, AllBonusSum,
			PKCategoryFullName,CategoryOrderBy,FinancingSourceOrderBy,ManagerBit, FinancingSourceFullName  
   )
		SELECT 
		ReportMainObjectName, null, BonusLevel, 1, null, SeverKoeff, RayonKoeff,
			TypeWorkName, 0, DepartmentName, PostName, idPlanStaff, NDFLKoeff, 
			Bonus.BonusTypeName, Bonus.id, FinancingSourceName, PKCategoryName,
			PeriodBegin, PeriodEnd, 0, 0, idReplacementReason, 
			Result.HasEnvironmentBonus, GlobalPrikazName, GlobalPrikazFullName, 
			BonusSuperTypeName, CategoryName, idCategory, WorkSuperTypeName,
			DirectionManagerName, ReplacedEmployeeName, Bonus.BonusOrderNumber, 
			PostFullName, DepartmentFullName,
			DateBegin,DateEnd,
			ForVacancy,ForEmployee, MatOtpusk, Salary, 0, 0,
			PKCategoryFullName,CategoryOrderBy,FinancingSourceOrderBy,ManagerBit, FinancingSourceFullName  
		FROM  
		(SELECT TOP 1 *
			FROM @Result) Result
		CROSS JOIN
		( SELECT * FROM [dbo].[GetReportBonusOrder](@idBonusReport) AllBonus 
			INNER JOIN dbo.BonusType ON AllBonus.idBonusType=BonusType.id
		WHERE AllBonus.idBonusType NOT IN (SELECT idBonusType FROM @Result WHERE idBonusType IS NOT NULL))Bonus
		--ORDER BY Bonus.BonusOrderNumber
	END*/

		

RETURN
END




