--SELECT * from [dbo].[GetPPSDepartmentBonusForT3](1, '1.03.2013','31.03.2013',1) 
--функция выбора надбавок для формирования отчета по форме Т3 на уровне отдела 
--Настройки: @WithSubDeps - с зависимыми отделами
--обозначение оклада -1
--последовательность столбцов надбавок фиксированное
alter FUNCTION [dbo].[GetPPSDepartmentBonusForT3] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
    --TypeWorkName			VARCHAR(50) NULL,
	DepartmentName			VARCHAR(200),
    PKCategoryName			VARCHAR(50),
    FinancingSourceName		VARCHAR(50),
	FinancingSourceLowName	VARCHAR(50),
    PostName				VARCHAR(150) NULL,
    StaffCount				DECIMAL(14,4),
    Salary					DECIMAL(14,2),
    idFactStaff				INT,
    idPlanStaff				INT,
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	StaffCountWithoutReplacement NUMERIC(14,4),	--кол-во ставок без замещений (т.е. если замещение, то эта ставка будет равна 0)
	StaffCountReal			NUMERIC(14,4),				--реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
	idReplacementReason	INT,						--причина замещения	 			
	HasEnvironmentBonus		BIT,
	HasIndivSalary			BIT,
	CategoryName			VARCHAR(50),
	idCategory				INT,
    --FinancingSourceFullName		VARCHAR(50),
	CategoryOrderBy INT,
	FinancingSourceOrderBy INT,
	ManagerBit  BIT,
	BonusSum1				DECIMAL(14,2),
	BonusSum2				DECIMAL(14,2),
	BonusSum3				DECIMAL(14,2),
	BonusSum4				DECIMAL(14,2),
	BonusSum5				DECIMAL(14,2),
	BonusSum6				DECIMAL(14,2),
	BonusSum7				DECIMAL(14,2),
	BonusSum8				DECIMAL(14,2),
	FacultyName				VARCHAR(70),
	idDepartment			INT

   ) 
AS
BEGIN
INSERT INTO @Result(DepartmentName, PKCategoryName, FinancingSourceName, FinancingSourceLowName, PostName, StaffCount, Salary, idFactStaff, idPlanStaff,
	PeriodBegin, PeriodEnd, StaffCountWithoutReplacement, StaffCountReal,  --HasEnvironmentBonus,
	HasIndivSalary, CategoryName, idCategory, 
 	CategoryOrderBy, FinancingSourceOrderBy, ManagerBit,
	BonusSum1, BonusSum2, BonusSum3, BonusSum4, BonusSum5, BonusSum6, BonusSum7, BonusSum8, idDepartment)
	SELECT DepartmentName, PKCategoryName, FinancingSourceName, FinancingSourceLowName, PostName, StaffCount, Salary, idFactStaff, idPlanStaff,
	PeriodBegin, PeriodEnd, StaffCountWithoutReplacement, StaffCountReal,  --HasEnvironmentBonus,
	HasIndivSalary, CategoryName, idCategory, 
 	CategoryOrderBy, FinancingSourceOrderBy, ManagerBit,
	BonusSum1, BonusSum2, BonusSum3, BonusSum4, BonusSum5, BonusSum6, BonusSum7, BonusSum8, idDepartment
	FROM [dbo].[GetDepartmentBonusForT3](@idDepartment,@PeriodBegin,@PeriodEnd,@WithSubDeps,6)
	WHERE idCategory=2

	UPDATE @Result
	SET DepartmentName=FacultyDep.DepartmentName, idDepartment=FacultyDep.id
	FROM @Result res
	INNER JOIN
	[dbo].[Department] ON res.idDepartment=[Department].id
	INNER JOIN
	[dbo].[Department] FacultyDep ON [Department].idManagerDepartment=FacultyDep.id AND FacultyDep.id <> 2

	RETURN
END