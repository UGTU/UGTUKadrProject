use kadr

go




GO

--select * from [dbo].[GetPPSDepartmentBonus](1, '1.02.2011','15.03.2011',1) 
alter FUNCTION [dbo].[GetPPSDepartmentBonus] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
    ReportMainObjectName	VARCHAR(150),
    --TypeWorkName			VARCHAR(50) NULL,
    PKCategoryName			VARCHAR(50),
    FinancingSourceName		VARCHAR(50),
    BonusTypeName			VARCHAR(50),
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    BonusLevel				VARCHAR(50)  NULL,
    --BonusCount				VARCHAR(50) NULL,
    BonusSum				DECIMAL(10,2),
    --AllBonusSum				DECIMAL(10,2),
    StaffCount				DECIMAL(10,2),
    --Salary					DECIMAL(10,2),
    --idFactStaff				INT,
    --idPlanStaff				INT,
    SeverKoeff				INT,
    RayonKoeff				INT,
    NDFLKoeff				INT,
	DepartmentName			VARCHAR(150),
	idBonusType				INT,
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	StaffCountWithoutReplacement			DECIMAL(10,2),	--кол-во ставок без замещений
	idReplacementReason	INT,						--причина замещения	 			
	BonusSuperTypeName		VARCHAR(50),
	DegreeName				VARCHAR(50),
	DegreeOrder				INT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	

	INSERT INTO @Result(ReportMainObjectName, PKCategoryName, EmployeeName, BonusSum, SeverKoeff, RayonKoeff,
			StaffCount, DepartmentName, PostName, NDFLKoeff, 
			BonusTypeName, idBonusType, FinancingSourceName, idReplacementReason,
			PeriodBegin, PeriodEnd, StaffCountWithoutReplacement,  
			BonusSuperTypeName, DegreeName, DegreeOrder)
	SELECT ReportMainObjectName, PKCategoryName, EmployeeName, BonusSum, SeverKoeff, RayonKoeff,
			StaffCount, DepartmentName, PostName, NDFLKoeff, 
			BonusTypeName, idBonusType, FinancingSourceName, idReplacementReason,
			PeriodBegin, PeriodEnd, StaffCountWithoutReplacement,  
			BonusSuperTypeName,
			Degree.DegreeShortName, DegreeOrder
	FROM dbo.GetDepartmentBonus(@idDepartment, @PeriodBegin, @PeriodEnd, @WithSubDeps) as DepBonus INNER JOIN
		dbo.Category ON DepBonus.idCategory=Category.id
		LEFT JOIN dbo.Degree ON Degree.DegreeOrder=(SELECT ISNULL(MAX(DegreeOrder),0) FROM dbo.Degree, dbo.EmployeeDegree,dbo.FactStaff
		WHERE Degree.id=EmployeeDegree.idDegree 
			AND EmployeeDegree.idEmployee=FactStaff.idEmployee AND DepBonus.idFactStaff=FactStaff.id)
	WHERE 
	Category.IsPPS=1

	
		
		

RETURN
END






