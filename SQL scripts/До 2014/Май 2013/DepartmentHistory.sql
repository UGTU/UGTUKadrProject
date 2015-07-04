USE [Kadr]
GO

/****** Object:  UserDefinedFunction [dbo].[GetFactStaffByPeriod]    Script Date: 29.05.2013 15:11:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
GO



--select * from [PlanStaffWithHistory] where id = 172 order by DateBegin
--Представление со всей историей штатного расписания
alter VIEW [dbo].[DepartmentWithHistory]
AS

SELECT  Department.id, DistinctDepartmentHistory.DepartmentName, DistinctDepartmentHistory.DepartmentSmallName, 
	Department.idFundingCenter, Department.idDepartmentType, Department.idManagerPlanStaff, 
	DistinctDepartmentHistory.idBeginPrikaz, 
	ISNULL(NextDistinctDepartmentHistory.idBeginPrikaz, Department.idEndPrikaz) idEndPrikaz, 
	DistinctDepartmentHistory.idManagerDepartment, 
	DistinctDepartmentHistory.DateBegin, 
	ISNULL(NextDistinctDepartmentHistory.DateBegin-1, Department.[dateExit]) [dateExit] ,
	DistinctDepartmentHistory.id idDepartmentHistory
	--,DistinctDepartmentHistory.[SeverKoeff],DistinctDepartmentHistory.[RayonKoeff]
FROM 
	[dbo].[Dep] Department
	INNER JOIN 
	/*(SELECT idPlanStaff, DateBegin, MAX(id) id
		FROM dbo.PlanStaffHistory
		GROUP BY idPlanStaff, DateBegin) DistPlanStaffHistory
	ON PlanStaff.id=DistPlanStaffHistory.idPlanStaff
	INNER JOIN*/
	 /*(SELECT  PlanStaffHistory.*
		FROM	
			(SELECT idPlanStaff, DateBegin, MAX(id) id
				FROM dbo.PlanStaffHistory
				GROUP BY idPlanStaff, DateBegin) DistinctPlanStaffHistory
			INNER JOIN
			 dbo.PlanStaffHistory
				ON DistinctPlanStaffHistory.id=PlanStaffHistory.id
)*/[dbo].[DepartmentHistory] DistinctDepartmentHistory
		ON DistinctDepartmentHistory.idDepartment=Department.id
	 LEFT JOIN	--выбираем ближайшее следующее изменение
	 dbo.[DepartmentHistory] NextDistinctDepartmentHistory ON Department.id=NextDistinctDepartmentHistory.idDepartment
			AND CONVERT(date, NextDistinctDepartmentHistory.DateBegin) =
				(SELECT CONVERT(date, MIN(history.DateBegin)) FROM dbo.[DepartmentHistory] history 
					WHERE DistinctDepartmentHistory.idDepartment=history.idDepartment 
						AND history.DateBegin>DistinctDepartmentHistory.DateBegin)





GO


--select * from [dbo].[GetDepartmentByPeriod]('12.11.2012','12.11.2012')where idPlanStaff=1066
CREATE FUNCTION [dbo].[GetDepartmentByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    [idDepartment]		INT,
    [idManagerDepartment]			INT,
    [idManagerPlanStaff]				INT,
	[idFundingCenter] INT,
    [idBeginPrikaz]		INT,
    DateBegin		DATETIME
	--,[SeverKoeff] INT,
	--[RayonKoeff] INT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	INSERT INTO @Result([idDepartment],[idManagerDepartment],[idManagerPlanStaff],[idFundingCenter],
			[idBeginPrikaz],DateBegin/*,[SeverKoeff],[RayonKoeff]*/)
	SELECT Department.id,[idManagerDepartment],[idManagerPlanStaff],[idFundingCenter],
			[idBeginPrikaz],Department.DateBegin--,[SeverKoeff],[RayonKoeff]
	FROM  dbo.DepartmentWithHistory as Department 
	INNER JOIN							
	(SELECT Department.id, MAX(DateBegin) as DateBegin
	FROM  dbo.DepartmentWithHistory as Department 
	WHERE 
		((Department.DateBegin<=@PeriodBegin AND (Department.dateExit>@PeriodBegin OR Department.dateExit IS NULL))
								OR (Department.DateBegin>=@PeriodBegin AND Department.DateBegin<=@PeriodEnd))
	GROUP BY Department.id) LastDepartment
	ON Department.id=LastDepartment.id AND Department.DateBegin=LastDepartment.DateBegin
	--group by FactStaff.id, idPlanStaff, idEmployee, idTypeWork, IsReplacement, LastFactStaff.DateBegin		  
		  
RETURN
END


GO

GO

--select * from [dbo].[GetSubDepartmentsWithPeriod](1,0) 
--возвращает подотделы переданного отдела (вместе с переданным отделом)
CREATE FUNCTION [dbo].[GetSubDepartmentsWithPeriod] 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
    IsMain			BIT
   ) 
AS
BEGIN
	
	DECLARE  @DepTable Table
	(
		[idDepartment]		INT,
		[idManagerDepartment]			INT
	)

	INSERT INTO @DepTable([idDepartment],[idManagerDepartment])
	SELECT [idDepartment],[idManagerDepartment]
	FROM [dbo].[GetDepartmentByPeriod](@PeriodBegin, @PeriodEnd)

	--выбираем непосредственно подчиненные отделы (подчиняются непосредственно отделу)
	INSERT INTO @Result
		SELECT [idDepartment], idManagerDepartment, 0 
			FROM @DepTable WHERE idManagerDepartment=@idManagerDepartment
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
		SELECT [idDepartment], idManagerDepartment, 0
			FROM @DepTable WHERE idManagerDepartment=@idManagerDepartment
		
		SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
			WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
	END
	
	DELETE FROM @Result
	WHERE idDepartment IS NULL
		
RETURN
END


GO

--select * from [dbo].[GetSubDepartmentsWithManagersWithPeriod](19) 
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
    IsMain			BIT
   ) 
AS
BEGIN
	DECLARE  @DepTable Table
	(
		[idDepartment]		INT,
		[idManagerDepartment]			INT,
		idManagerPlanStaff INT
	)

	INSERT INTO @DepTable([idDepartment],[idManagerDepartment], idManagerPlanStaff)
	SELECT [idDepartment],[idManagerDepartment], idManagerPlanStaff
	FROM [dbo].[GetDepartmentByPeriod](@PeriodBegin, @PeriodEnd)

	DECLARE @idCurrManagerPlanStaff INT

	--выбираем менеджера для главного отдела
	SELECT @idCurrManagerPlanStaff=[dbo].[GetDepartmentsManager](@idManagerDepartment)
	
	--выбираем непосредственно подчиненные отделы (подчиняются непосредственно отделу)
	INSERT INTO @Result
		SELECT [idDepartment], idManagerDepartment, ISNULL(idManagerPlanStaff,@idCurrManagerPlanStaff), 0 
			FROM @DepTable WHERE idManagerDepartment=@idManagerDepartment
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
		SELECT idDepartment, idManagerDepartment, ISNULL(idManagerPlanStaff,@idCurrManagerPlanStaff), 0
			FROM @DepTable WHERE idManagerDepartment=@idManagerDepartment
		
		SELECT @idManagerDepartment = MIN(idDepartment) FROM @Result
			WHERE idDepartment NOT IN (SELECT idManagerDepartment FROM @Result)
		SELECT @idCurrManagerPlanStaff=ISNULL(idManagerPlanStaff, @idCurrManagerPlanStaff) FROM @Result
			WHERE idDepartment=@idManagerDepartment
	END
	
	DELETE FROM @Result
	WHERE idDepartment IS NULL

RETURN
END

GO

--SELECT * from [dbo].[GetDepartmentBonusWithSettings](1, '1.01.2013','1.02.2013',1,1,-1) where BonusTypeName is null
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
	PostCode VARCHAR(20)

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
		idBonusType INT
	)

	
	--выбираем все надбавки за период
	INSERT INTO @BonusTable(id, BonusCount, idBonusType)
	SELECT idBonus, PeriodBonus.BonusCount, Bonus.idBonusType
	FROM [dbo].[GetBonusByPeriod](@PeriodBegin, @PeriodEnd) as PeriodBonus INNER JOIN dbo.Bonus
	ON PeriodBonus.idBonus=Bonus.id


	
--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
	idManagerPlanStaff	INT,
	DirectionManagerName	VARCHAR(70)
	)
	
	--заполняем отделы с менеджерами
	IF EXISTS(SELECT 'TRUE' FROM dbo.BonusReport WHERE id=@idBonusReport AND WithManagers = 1)	
	BEGIN
			
		
		IF (@WithSubDeps = 1)	--подотделы
			INSERT INTO @DepTable
				SELECT idDepartment, idManagerPlanStaff, null
				FROM [dbo].GetSubDepartmentsWithManagersWithPeriod(@idDepartment, @PeriodBegin, @PeriodEnd)	--с менеджерами
		ELSE	--текущий отдел
			INSERT INTO @DepTable	
				SELECT @idDepartment, [dbo].[GetDepartmentsManager](@idDepartment), null
			
		UPDATE 	@DepTable
		SET DirectionManagerName=Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'. '+CONVERT(VARCHAR(1),Employee.Otch)+'.'
		FROM @DepTable as Deps
			INNER JOIN dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff ON PeriodStaff.idPlanStaff=Deps.idManagerPlanStaff
			INNER JOIN dbo.FactStaff ON PeriodStaff.idFactStaff=FactStaff.id
			INNER JOIN dbo.Employee ON FactStaff.idEmployee=Employee.id
	END
	--без менеджеров
	ELSE	
	BEGIN
		IF (@WithSubDeps = 1)	--подотделы
			INSERT INTO @DepTable
			SELECT idDepartment, null, null
			FROM [dbo].GetSubDepartmentsWithPeriod(@idDepartment, @PeriodBegin, @PeriodEnd)	--без менеджеров
		ELSE	--текущий отдел
		INSERT INTO @DepTable	--текущий отдел
			SELECT @idDepartment, null, null	
	END

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
		idSalaryKoeff INT
	)

	--выбираем свех сотрудников одела за период
	INSERT INTO @StaffTable(idDepartment, idFinancingSource, idTypeWork, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason, IsMain, ReplacedEmployeeName,
		DateBegin, DateEnd, HourCount, Salary, HasIndivSalary, idSalaryKoeff, DirectionManagerName)
	SELECT PeriodStaff.idDepartment, idFinancingSource, PeriodStaff.idTypeWork, idPost, PeriodStaff.idPlanStaff, 
		idFactStaff, PeriodStaff.idEmployee, PeriodStaff.StaffCount, 
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason, IsMain, 
		ReplacedEmployeeName,
		FactStaff.DateBegin,FactStaff.DateEnd,PeriodStaff.HourCount, SalarySize*ISNULL(SalaryKoeff.[SalaryKoeffc],1), IsIndividual, PeriodStaff.idSalaryKoeff, DirectionManagerName
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
			CategoryOrderBy,FinancingSourceOrderBy, ManagerBit, PostTypeName, PostCode, Salary, HasIndivSalary)
	SELECT Department.DepartmentName, AllBonus.EmployeeName, AllBonus.BonusLevel, AllBonus.BonusCount, 
			AllBonus.idFactStaff, ISNULL(50, AllBonus.SeverKoeff) ,ISNULL(30, AllBonus.RayonKoeff), 
			WorkType.TypeWorkShortName+ISNULL(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')',''), AllBonus.StaffCount, 
			Department.DepartmentSmallName, Post.PostShortName, PlanStaff.idPlanStaff, 
			(SELECT NDFLKoeff FROM [dbo].[GetBonusKoeffs](@PeriodBegin)), 
			ISNULL(BonusType.BonusTypeShortName,'Базовый оклад'), ISNULL(BonusType.BonusTypeName,'Базовый оклад'), BonusType.id, FinancingSourceName,
			CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber)+' '+CONVERT(VARCHAR(3),PKSubCategoryNumber)+' '+ISNULL(CONVERT(VARCHAR(3),[SalaryKoeff].PKSubSubCategoryNumber),''),
			@PeriodBegin, @PeriodEnd, AllBonus.StaffCountWithoutReplacement, AllBonus.StaffCountReal, AllBonus.idReplacementReason, 
			HasEnvironmentBonus, ISNULL(CONVERT(VARCHAR(10), GlobalPrikaz.DateBegin,103),'') +' № '+ ISNULL(GlobalPrikaz.PrikazNumber,'') GlobalPrikazName,
			GlobalPrikaz.PrikazName GlobalPrikazFullName,
			BonusSuperType.BonusSuperTypeName, CategorySmallName, Post.idCategory,
			ISNULL(WorkSuperTypeShortName,'Вак.'), DirectionManagerName, ReplacedEmployeeName, BonusOrderNumber,
			Post.PostName, Department.DepartmentName,
			CONVERT(VARCHAR(10),AllBonus.DateBegin,104),
			CONVERT(VARCHAR(10),AllBonus.DateEnd,104),
			ForVacancy,ForEmployee, otpusk.otpTypeShortName, PlanStaff.HourCount, LOWER(FinancingSourceName), Comment, ISNULL(SalaryKoeffc,1),
			CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber)+' '+CONVERT(VARCHAR(3),PKSubCategoryNumber)+' '+ISNULL(CONVERT(VARCHAR(3),[SalaryKoeff].PKSubSubCategoryNumber),''),
			Category.OrderBy,FinancingSource.OrderBy, Post.ManagerBit, PostTypeName, PostCode, PlanStaff.Salary, PlanStaff.HasIndivSalary
	FROM
	
	(
	--выбираем надбавки сотрудника (Employee)
	SELECT DISTINCT Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch EmployeeName,'Сотрудник' BonusLevel, 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount as StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee
	FROM @BonusTable as Bonus 
		INNER JOIN dbo.BonusEmployee ON Bonus.id=BonusEmployee.idBonus
		INNER JOIN dbo.Employee ON BonusEmployee.idEmployee=Employee.id
		INNER JOIN @StaffTable as Staff ON Staff.idEmployee=BonusEmployee.idEmployee
			AND Staff.IsMain=1
		
		
	--выбираем надбавки записи штатного расписания (FactStaff)	
	UNION
	SELECT Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch, 'Распределение штатов', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee
	FROM @BonusTable as Bonus
		INNER JOIN  dbo.BonusFactStaff ON Bonus.id=BonusFactStaff.idBonus	
		INNER JOIN @StaffTable as Staff ON BonusFactStaff.idFactStaff=Staff.idFactStaff	
		INNER JOIN dbo.Employee ON Staff.idEmployee=Employee.ID --BonusFactStaff.idEmployee=Employee.id	WHERE 
		
	--выбираем надбавки штатной единицы (planStaff)
	UNION
	SELECT ISNULL(Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch, 'Вакансия'), 'Штатное расписание', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		ForVacancy, ForEmployee
	FROM @BonusTable as Bonus, dbo.BonusPlanStaff, 
		@StaffTable as Staff left join dbo.Employee on Staff.idEmployee=Employee.ID
	WHERE Bonus.id=BonusPlanStaff.idBonus
		AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff
	
	--выбираем надбавки должности (Post)	
	UNION
	SELECT ISNULL(Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch, 'Вакансия'),'Должность', 
		BonusCount, Staff.idPlanStaff, Staff.idFactStaff, SeverKoeff, RayonKoeff, idBonusType, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason ,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee
	FROM @BonusTable as Bonus, dbo.BonusPost, @StaffTable as Staff left join dbo.Employee on Staff.idEmployee=Employee.ID
	WHERE Bonus.id=BonusPost.idBonus
		AND BonusPost.idPost=Staff.idPost
	
	--выбираем оклад	
	UNION	
	SELECT ISNULL(Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch, 'Вакансия'),'Оклад', 
		null as BonusCount, Staff.idPlanStaff, Staff.idFactStaff, ISNULL(SeverKoeff, 50), ISNULL(RayonKoeff, 30), -1, StaffCount,
		StaffCountWithoutReplacement, StaffCountReal, idReplacementReason,
		Staff.DateBegin,Staff.DateEnd, 
		NULL ForVacancy,NULL ForEmployee
	FROM @StaffTable as Staff 
		left join dbo.Employee on Staff.idEmployee=Employee.ID)AllBonus
		
		INNER JOIN @StaffTable PlanStaff ON AllBonus.idPlanStaff=PlanStaff.idPlanStaff 
			AND (AllBonus.idFactStaff=PlanStaff.idFactStaff or (AllBonus.idFactStaff IS NULL AND PlanStaff.idFactStaff IS NULL))
		INNER JOIN dbo.Department ON PlanStaff.idDepartment=Department.id
		INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.PKCategory ON Post.idPKCategory=PKCategory.id
		INNER JOIN dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id
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
		LEFT JOIN [dbo].[SalaryKoeff] ON PlanStaff.idSalaryKoeff=[SalaryKoeff].id
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




GO

--select * from [dbo].[GetDepartmentStaff](1, '30.05.2012','30.05.2012', 0) where DepartmentName  like '%ремонту%' 
ALTER FUNCTION [dbo].[GetDepartmentStaff] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
    PostName				VARCHAR(150) NULL,
    PKCategoryName			VARCHAR(150) NULL,
    CategoryName			VARCHAR(50)  NULL,
    FinancingSourceName		VARCHAR(50)  NULL,
    factStaffCount			decimal(12,4) NULL,
    EmplName				VARCHAR(150) NULL,
    TypeWorkName			VARCHAR(150) NULL,
    DepartmentName			VARCHAR(200) NULL,
    PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	StaffCountWithoutReplacement			DECIMAL(12,4),
	idPlanStaff				INT,
    EmplFullName				VARCHAR(250) NULL,
    EmplSid					VARBINARY(85),
    idEmployee int,
    idPost		INT,
    ManagerBit BIT,
    idFactStaff INT,
    EmployeeLogin		NVARCHAR(128),
    DepartmentGUID UNIQUEIDENTIFIER,
    EmployeeGUID UNIQUEIDENTIFIER,
    IsMain BIT,
    MatOtpusk VARCHAR(10),
	idDepartment int
	
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
    IsMain			BIT
	)
	
		
	IF (@WithSubDeps = 1)	--если с подотделами
		INSERT INTO @DepTable
		SELECT idDepartment, IsMain
		FROM [dbo].GetSubDepartmentsWithPeriod(@idDepartment, @PeriodBegin, @PeriodEnd)
	ELSE
		INSERT INTO @DepTable	--текущий отдел
			SELECT @idDepartment, 1
	
		
			
	INSERT INTO @Result
	SELECT PostName, CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber)+' '+CONVERT(VARCHAR(3),PKSubCategoryNumber)+' '+ISNULL(CONVERT(VARCHAR(3),[SalaryKoeff].PKSubSubCategoryNumber),'') as PKCategoryName,
		CategorySmallName, FinancingSourceName, PeriodStaff.StaffCount, 
		ISNULL(Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'.'+CONVERT(VARCHAR(1),Employee.Otch)+'.','Вакансия') as EmplName,
		WorkType.TypeWorkShortName + IsNull(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')', '') TypeWorkName, 
		Department.DepartmentName,@PeriodBegin, @PeriodEnd, 
		StaffCountWithoutReplacement, PeriodStaff.idPlanStaff,
		ISNULL(Employee.LastName+' '+ISNULL(Employee.FirstName,'')+' '+ISNULL(Employee.Otch,''),''), 
		EmployeeSid, Employee.id, Post.id, Post.ManagerBit, PeriodStaff.idFactStaff, EmployeeLogin
		, DepartmentGUID, GUID, WorkType.IsMain, otpusk.otpTypeShortName,
		Deps.idDepartment
	FROM  
		  dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff INNER JOIN
		  @DepTable as Deps ON PeriodStaff.idDepartment=Deps.idDepartment INNER JOIN
		  dbo.Post ON PeriodStaff.idPost=Post.id inner join
		  dbo.Department ON Deps.idDepartment=Department.id INNER JOIN
          dbo.PKCategory ON dbo.Post.idPKCategory = dbo.PKCategory.id INNER JOIN
          dbo.PKGroup ON dbo.PKCategory.idPKGroup = dbo.PKGroup.id INNER JOIN
		  dbo.FinancingSource ON PeriodStaff.idFinancingSource = dbo.FinancingSource.id INNER JOIN
          dbo.Category ON Post.idCategory = dbo.Category.id LEFT JOIN
          dbo.WorkType ON PeriodStaff.idTypeWork = dbo.WorkType.id LEFT JOIN
          dbo.Employee ON PeriodStaff.idEmployee = dbo.Employee.id LEFT JOIN
          dbo.FactStaffReplacementReason ON PeriodStaff.idReplacementReason=FactStaffReplacementReason.id LEFT JOIN
          [dbo].[GetOtpuskByPeriod](@PeriodBegin,@PeriodEnd) otpusk 
			ON PeriodStaff.idFactStaff=otpusk.idFactStaff AND otpusk.isMaternity=1 LEFT JOIN 
		  [dbo].[SalaryKoeff] ON PeriodStaff.idSalaryKoeff=[SalaryKoeff].id
	order by Deps.Ismain desc, Department.DepartmentName, FinancingSource.OrderBy, Category.OrderBy, PKCategoryName desc, PostName, EmplName
	
	UPDATE @Result
	SET PKCategoryName=PKCategoryName+'*'
	WHERE idPlanStaff IN (SELECT idPlanStaff FROM dbo.GetIndivSalaryByPeriod(@PeriodBegin,@PeriodEnd))
RETURN
END


GO

--select * from [dbo].GetSubDepartmentStaffCounts(1,'20.06.2010','20.06.2010') 
--select * from [dbo].GetSubDepartmentStaffCounts(2)
ALTER FUNCTION [dbo].[GetSubDepartmentStaffCounts] 
(
@idManagerDepartment	INT,
@PeriodBegin			DATETIME,
@PeriodEnd				DATETIME
)
RETURNS @Result TABLE
   (
    idPKCategory		INT NULL,
    planStaffCount     decimal(10,2)    NULL,
    factStaffCount	   decimal(10,4)         	   NULL
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	DECLARE @SubDeps Table
	(
		idDepartment 			INT
	)
	
	INSERT INTO @SubDeps
		SELECT idDepartment FROM [dbo].GetSubDepartmentsWithPeriod(@idManagerDepartment, @PeriodBegin, @PeriodEnd)
		WHERE IsMain=0
	
	INSERT INTO @Result(idPKCategory,planStaffCount,factStaffCount)
		SELECT     
			idPKCategory,
			SUM(PlanStaff.StaffCount) as planCount, SUM(FactStaffCount.factCount) as factCount
		FROM  dbo.PKGroup INNER JOIN
					 dbo.PKCategory ON dbo.PKCategory.idPKGroup = dbo.PKGroup.id LEFT JOIN
					 dbo.Post ON dbo.Post.idPKCategory = dbo.PKCategory.id LEFT JOIN
					 (SELECT * FROM [dbo].[GetPlanStaffByPeriod](@PeriodBegin, @PeriodEnd) as PlanStaff WHERE idDepartment IN
						(SELECT idDepartment FROM @SubDeps))PlanStaff 
					 ON PlanStaff.idPost = dbo.Post.id 
					 LEFT JOIN
					 (SELECT FactStaff.idPlanStaff, SUM(FactStaff.StaffCount) as factCount 
						FROM [dbo].[GetFactStaffByPeriod](@PeriodBegin, @PeriodEnd) FactStaff 
						WHERE FactStaff.idFactStaff NOT IN (SELECT idFactStaff FROM dbo.FactStaffReplacement)
							GROUP BY FactStaff.idPlanStaff)FactStaffCount
						ON PlanStaff.idPlanStaff = FactStaffCount.idPlanStaff 
		GROUP BY idPKCategory

RETURN
END


GO
--select * from [dbo].[GetFactStaffChangesByPeriod](141,'20.01.2011','20.02.2011',1)where idPlanStaff=1066
ALTER FUNCTION [dbo].[GetFactStaffChangesByPeriod] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
    TypeWorkName			VARCHAR(50) NULL,
    PKCategoryName			VARCHAR(50),
    FinancingSourceName		VARCHAR(50),
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    StaffCount				DECIMAL(10,2),
	DepartmentName			VARCHAR(150),
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	--idReplacementReason	INT,						--причина замещения	 			
	CategoryName			VARCHAR(50),
	OperationName			VARCHAR(50),
	OperationDate			DATETIME,
	OperationPrikazName		VARCHAR(50),
	idPlanStaff				INT,
	SalarySize				DECIMAL(10,2)				
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
    IsMain			BIT
	)
	
		
	IF (@WithSubDeps = 1)	--если с подотделами
		INSERT INTO @DepTable
		SELECT idDepartment, IsMain
		FROM [dbo].GetSubDepartmentsWithPeriod(@idDepartment, @PeriodBegin, @PeriodEnd)
	ELSE
		INSERT INTO @DepTable	--текущий отдел
			SELECT @idDepartment, 1
	

	
	INSERT INTO @Result
	SELECT
	WorkSuperTypeShortName, CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber)+' '+CONVERT(VARCHAR(3),PKSubCategoryNumber)+' '+ISNULL(CONVERT(VARCHAR(3),[SalaryKoeff].PKSubSubCategoryNumber),'') PKCategoryName, 
	FinancingSourceName, PostShortName, 
	Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch EmployeeName,
    FactStaff.StaffCount, DepartmentSmallName, @PeriodBegin, @PeriodEnd,
	CategorySmallName, OperationName, 
	OperationDate, PrikazName+' от '+CONVERT(VARCHAR(10),CONVERT(Date,DatePrikaz)) OperationPrikazName,
	PlanStaff.id, SalarySize
	FROM
	
	(SELECT 'П.' as OperationName, idFactStaff, idPlanStaff, idEmployee, 
			idTypeWork, StaffCount, IsReplacement, DateBegin OperationDate, idBeginPrikaz idOperationPrikaz, idSalaryKoeff
	FROM  [dbo].GetRecruitedFactStaffByPeriod(@PeriodBegin, @PeriodEnd) as FactStaff 
		
	UNION
	SELECT 'У.' as OperationName, FactStaff.id idFactStaff, idPlanStaff, idEmployee, 
			idTypeWork, StaffCount, IsReplacement, DateEnd OperationDate, idEndPrikaz idOperationPrikaz, idSalaryKoeff
	FROM dbo.FactStaffCurrent FactStaff
	WHERE FactStaff.DateEnd>=@PeriodBegin AND FactStaff.DateEnd<=@PeriodEnd) FactStaff
	INNER JOIN dbo.PlanStaffCurrent PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id  
		INNER JOIN dbo.Department ON PlanStaff.idDepartment=Department.id
		INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.PKCategory ON Post.idPKCategory=PKCategory.id
		INNER JOIN dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id
		INNER JOIN dbo.FinancingSource ON PlanStaff.idFinancingSource=FinancingSource.id
		INNER JOIN dbo.WorkType ON FactStaff.idTypeWork=WorkType.id
		INNER JOIN dbo.WorkSuperType ON WorkType.idWorkSuperType=WorkSuperType.id
		INNER JOIN dbo.Employee ON FactStaff.idEmployee=Employee.id
		INNER JOIN dbo.Prikaz ON FactStaff.idOperationPrikaz=Prikaz.id
		INNER JOIN @DepTable deps ON Department.id=deps.idDepartment
		LEFT JOIN [dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd) PlanStaffsWithSalaries
			ON PlanStaff.id=PlanStaffsWithSalaries.idPlanStaff
		LEFT JOIN 
		  [dbo].[SalaryKoeff] ON FactStaff.idSalaryKoeff=[SalaryKoeff].id


		  
		  
RETURN
END



GO
--select * from [dbo].[GetPostStaffChangesByPeriod](1,'20.01.2011','20.02.2012',1) order by DepartmentName OperationDate where idPlanStaff=1066
--Процедура возвращает все изменения в штатном расписании, произошедшие за период
ALTER FUNCTION [dbo].[GetPostStaffChangesByPeriod] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
	DepartmentName			VARCHAR(150),
	OperationName			VARCHAR(50),
 	OperationDate			date,
    StaffCount				DECIMAL(10,2),
    FinancingSourceName		VARCHAR(50),
    PostName				VARCHAR(150) NULL,
	CategoryName			VARCHAR(50),
    PKCategoryName			VARCHAR(50),
	SalarySize				DECIMAL(10,2),
	OperationPrikazName		VARCHAR(50),
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	--idReplacementReason	INT,						--причина замещения	 			
	idPlanStaff				INT,
	PredStaffCount			DECIMAL(10,2)
	
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

	--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
    IsMain			BIT
	)
	
		
	IF (@WithSubDeps = 1)	--если с подотделами
		INSERT INTO @DepTable
		SELECT idDepartment, IsMain
		FROM [dbo].GetSubDepartmentsWithPeriod(@idDepartment, @PeriodBegin, @PeriodEnd)
		
	ELSE
		INSERT INTO @DepTable	--текущий отдел
			SELECT @idDepartment, 1


	INSERT INTO @Result
	select Department.DepartmentSmallName, OperationName, CONVERT(date, OperationDate),
		StaffCount, FinancingSourceName, PostName,
		CategorySmallName, CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber)+' '+CONVERT(VARCHAR(3),PKSubCategoryNumber) PKCategoryName, SalarySize, 
		PrikazName+' от '+CONVERT(VARCHAR(10),CONVERT(Date,DatePrikaz)) OperationPrikazName, 
		@PeriodBegin, @PeriodEnd, PlanStaffHistory.id, PredStaffCount
		from 
		@DepTable deps 
		INNER JOIN dbo.Department ON deps.idDepartment=Department.id
		INNER JOIN (SELECT PlanStaffWithHistory.id, PlanStaffWithHistory.idDepartment,  
					(PlanStaffWithHistory.StaffCount-ISNULL(PredPlanStaffHistoryChanges.StaffCount,0)) as StaffCount,
					PlanStaffWithHistory.idPost, PlanStaffWithHistory.idBeginPrikaz idOperationPrikaz,
					PlanStaffWithHistory.idFinancingSource, PlanStaffWithHistory.DateBegin OperationDate,
					PredPlanStaffHistoryChanges.StaffCount PredStaffCount, 
					'Добавление' OperationName --добавление ставок
				FROM dbo.PlanStaffWithHistory  
					LEFT JOIN
					dbo.PlanStaffWithHistory AS PredPlanStaffHistoryChanges ON PlanStaffWithHistory.id=PredPlanStaffHistoryChanges.id--PlanStaff 
						AND PlanStaffWithHistory.DateBegin >
							PredPlanStaffHistoryChanges.DateBegin
						AND PredPlanStaffHistoryChanges.DateBegin =
							(SELECT MAX(PrevPlanStaffHistoryChanges.DateBegin) FROM dbo.PlanStaffWithHistory PrevPlanStaffHistoryChanges 
								WHERE PrevPlanStaffHistoryChanges.id=PlanStaffWithHistory.id
									AND PrevPlanStaffHistoryChanges.DateBegin<PlanStaffWithHistory.DateBegin)
				WHERE 
					PlanStaffWithHistory.DateBegin >= @PeriodBegin AND PlanStaffWithHistory.DateBegin <= @PeriodEnd
			UNION
				--отмена ставок
				SELECT PlanStaffWithHistory.id, PlanStaffWithHistory.idDepartment,  
					(PredPlanStaffHistoryChanges.StaffCount) as StaffCount,
					PlanStaffWithHistory.idPost, PlanStaffWithHistory.idEndPrikaz idOperationPrikaz,
					PredPlanStaffHistoryChanges.idFinancingSource, PlanStaffWithHistory.DateEnd OperationDate,
					PredPlanStaffHistoryChanges.StaffCount PredStaffCount, 'Вывод штатов' OperationName --добавление ставок
				FROM dbo.PlanStaff PlanStaffWithHistory
				INNER JOIN
					dbo.PlanStaffWithHistory AS PredPlanStaffHistoryChanges 
						ON PlanStaffWithHistory.id=PredPlanStaffHistoryChanges.id 
						AND PredPlanStaffHistoryChanges.DateBegin = 
							(SELECT MAX(PlanStaffWithHistory.DateBegin) 
								FROM dbo.PlanStaffWithHistory WHERE PlanStaffWithHistory.id=PredPlanStaffHistoryChanges.id) 
				WHERE 
					PlanStaffWithHistory.DateEnd >= @PeriodBegin AND PlanStaffWithHistory.DateEnd <= @PeriodEnd)PlanStaffHistory
			ON deps.idDepartment=PlanStaffHistory.idDepartment	
		INNER JOIN dbo.Post ON PlanStaffHistory.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.PKCategory ON Post.idPKCategory=PKCategory.id
		INNER JOIN dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id
		INNER JOIN dbo.FinancingSource ON PlanStaffHistory.idFinancingSource=FinancingSource.id
		INNER JOIN dbo.Prikaz ON PlanStaffHistory.idOperationPrikaz=Prikaz.id
		LEFT JOIN
		[dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd)Salary
		ON PlanStaffHistory.id=Salary.idPlanStaff		
		
		UPDATE @Result
		SET OperationName='Уменьшение', StaffCount=-StaffCount
		WHERE StaffCount<0
		
		UPDATE @Result
		SET OperationName='Ввод штатов'
		WHERE PredStaffCount IS NULL

	RETURN
	

		  
		  
RETURN
END



