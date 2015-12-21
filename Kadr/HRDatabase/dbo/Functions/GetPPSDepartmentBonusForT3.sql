--SELECT * from [dbo].[GetPPSDepartmentBonusForT3](1, '9.3.2014','9.23.2014',1,7) 
--функция выбора надбавок для формирования отчета по форме Т3 на уровне отдела 
--Настройки: @WithSubDeps - с зависимыми отделами
--обозначение оклада -1
--последовательность столбцов надбавок фиксированное
CREATE FUNCTION [dbo].[GetPPSDepartmentBonusForT3] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
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
    Salary					DECIMAL(14,2),
	RealSalary				DECIMAL(14,2),
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
	FacultyName				VARCHAR(200),
	idDepartment			INT

   ) 
AS
BEGIN
INSERT INTO @Result(DepartmentName, PKCategoryName, FinancingSourceName, FinancingSourceLowName, PostName, StaffCount, Salary, RealSalary, idFactStaff, idPlanStaff,
	PeriodBegin, PeriodEnd, StaffCountWithoutReplacement, StaffCountReal,  --HasEnvironmentBonus,
	HasIndivSalary, CategoryName, idCategory, 
 	CategoryOrderBy, FinancingSourceOrderBy, idFinancingSource, ManagerBit,
	BonusSum1, BonusSum2, BonusSum3, BonusSum4, BonusSum5, BonusSum6, BonusSum7, BonusSum8, idDepartment, FacultyName)
	SELECT DepartmentName, PKCategoryName, FinancingSourceName, FinancingSourceLowName, PostName, StaffCount, Salary, RealSalary, idFactStaff, idPlanStaff,
	PeriodBegin, PeriodEnd, StaffCountWithoutReplacement, StaffCountReal,  --HasEnvironmentBonus,
	HasIndivSalary, CategoryName, idCategory, 
 	CategoryOrderBy, FinancingSourceOrderBy, idFinancingSource,ManagerBit,
	BonusSum1, BonusSum2, BonusSum3, BonusSum4, BonusSum5, BonusSum6, BonusSum7, BonusSum8, idDepartment, DepartmentName
	FROM [dbo].[GetDepartmentBonusForT3](@idDepartment,@PeriodBegin,@PeriodEnd,@WithSubDeps,@idBonusReport)
	WHERE idCategory=2

	UPDATE @Result
	SET FacultyName=FacultyDep.DepartmentName--, idDepartment=FacultyDep.id
	FROM @Result res
	INNER JOIN
	[dbo].[Department] ON res.idDepartment=[Department].id
	INNER JOIN
	[dbo].[Department] FacultyDep ON [Department].idManagerDepartment=FacultyDep.id AND FacultyDep.id <> 2

	RETURN
END