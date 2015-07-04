CREATE TYPE StuffTable
AS TABLE 
	(
		idDepartment INT,
		idPost		 INT,
		idPlanStaff  INT,
		idFactStaff  INT,
		idEmployee   INT,
		StaffCount	 NUMERIC(8,2),
		StaffCountWithoutReplacement NUMERIC(8,2),	--кол-во ставок без замещений
		CalcStaffCount	 NUMERIC(8,2),
		StaffCountReal	NUMERIC(14,4),				--реальна€ ставка (т.е. если человека замещают на х ставки, то дл€ замещаемого реальна€ ставка будет у-х, где у - его ставка  
		CalcStaffCountWithoutReplacement DECIMAL(14,4),
		CalcStaffCountReal NUMERIC(14,4),
		idReplacementReason	INT,					--причина замещени€
		IsMain			BIT,							--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		IsReplacement	BIT,
		idFinancingSource	INT,
		idTypeWork			INT,
		idSalaryKoeff INT,
		DirectionManagerName	VARCHAR(70),
		ReplacedEmployeeName	VARCHAR(150) NULL,	--‘»ќ замещаемого
		DateBegin		DATETIME,		--дата прин€ти€ на работу (первоначальна€)
		DateEnd			DATETIME,		--дата увольнени€ (если он уволен в данный период)
		HourCount NUMERIC(14,2),
		Salary					DECIMAL(14,2),
		HasIndivSalary  BIT,
		[idlaborcontrakt] INT,
		PKSubSubCategoryNumberForSPO INT,
		[DepartmentName] VARCHAR(500),
		[DepartmentSmallName] VARCHAR(500),
		DepTreeIndex			VARCHAR(30),
		[OKVEDName]			VARCHAR(500)
	)



GO
--select * from [dbo].[GetBonusWithBonusLevel](1, '09.01.2013','09.30.2013') where EmployeeName like '%јмосова%'
--возвращает данные дл€ отчетов по надбавкам
CREATE FUNCTION [dbo].[GetBonusWithBonusLevel] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
@WithSubDeps BIT,
@idBonusReport		 INT,
@StaffTable StuffTable READONLY
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
	idReplacementReason	INT,						--причина замещени€	 			
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
	DateBegin		DATE,		--дата прин€ти€ на работу (первоначальна€)
	DateEnd			DATE		--дата увольнени€ (если он уволен в данный период)
   ) 
AS
BEGIN






		(SELECT idBonus,
			Staff.idEmployee, '—отрудник' as BonusLevel, 
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
			Staff.idEmployee, '–аспределение штатов' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL, Bonus.idFinancingSource
		FROM @BonusTable as Bonus, dbo.BonusFactStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusFactStaff.idBonus
			AND BonusFactStaff.idFactStaff=Staff.idFactStaff
		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Ўтатное расписание' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			ForEmployee, Bonus.idFinancingSource
		FROM @BonusTable as Bonus, dbo.BonusPlanStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusPlanStaff.idBonus
			AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff

		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'ƒолжность' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL, Bonus.idFinancingSource
		FROM @BonusTable as Bonus, dbo.BonusPost, @StaffTable as Staff
		WHERE Bonus.id=BonusPost.idBonus
			AND BonusPost.idPost=Staff.idPost
END