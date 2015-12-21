--select * from [dbo].[GetFactStaffChangesByPeriod](1,'1.01.2015','20.01.2015',1)where  OperationName='У.' order by OperationDate
CREATE FUNCTION [dbo].[GetFactStaffChangesByPeriod] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
    TypeWorkName			VARCHAR(50) NULL,
    PKCategoryName			VARCHAR(50),
    FinancingSourceName		VARCHAR(50),
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    StaffCount				DECIMAL(14,2),
	DepartmentName			VARCHAR(500),
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	--idReplacementReason	INT,						--причина замещения	 			
	CategoryName			VARCHAR(50),
	OperationName			VARCHAR(50),
	OperationDate			DATE,
	OperationPrikazName		VARCHAR(100),
	idPlanStaff				INT,
	SalarySize				DECIMAL(14,2),	
	[EmployeeLogin]			NVARCHAR(128),
	IsIndividual			BIT

   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN;

	
	WITH DepTable (idDepartment, IsMain, DepartmentName,DepartmentSmallName)
	AS	
	(SELECT idDepartment, IsMain, DepartmentName,DepartmentSmallName
			FROM dbo.[GetDepartmentDataForReports](@idDepartment, @PeriodBegin, @PeriodEnd, @WithSubDeps,-1))
	

	
	INSERT INTO @Result
	SELECT
	WorkSuperTypeShortName,PKCategory.PKCategoryFullName+' '+ISNULL(CONVERT(VARCHAR(3),SalaryKoeff.PKSubSubCategoryNumber),PKCategory.PKSubSubCategoryNumber) PKCategoryName, 
	FinancingSourceName, PostShortName, 
	Employee.EmployeeName EmployeeName,
    FactStaff.StaffCount, DepartmentName, @PeriodBegin, @PeriodEnd,
	CategorySmallName, OperationName, 
	OperationDate, PrikazName+' от '+CONVERT(VARCHAR(10),CONVERT(Date,DatePrikaz)) OperationPrikazName,
	PlanStaff.id, SalarySize*ISNULL(SalaryKoeff.[SalaryKoeffc],1), [EmployeeLogin], IsIndividual
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
		INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.[GetFullPKCategory](@PeriodBegin,@PeriodEnd) PKCategory ON Post.idPKCategory=PKCategory.id
		INNER JOIN dbo.FinancingSource ON PlanStaff.idFinancingSource=FinancingSource.id
		INNER JOIN dbo.WorkType ON FactStaff.idTypeWork=WorkType.id
		INNER JOIN dbo.WorkSuperType ON WorkType.idWorkSuperType=WorkSuperType.id
		INNER JOIN dbo.Employee ON FactStaff.idEmployee=Employee.id
		INNER JOIN dbo.Prikaz ON FactStaff.idOperationPrikaz=Prikaz.id
		INNER JOIN DepTable deps ON PlanStaff.idDepartment=deps.idDepartment
		LEFT JOIN [dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd) PlanStaffsWithSalaries
			ON PlanStaff.id=PlanStaffsWithSalaries.idPlanStaff
		LEFT JOIN 
		  [dbo].[SalaryKoeff] ON FactStaff.idSalaryKoeff=[SalaryKoeff].id


	UPDATE @Result
	SET PKCategoryName=PKCategoryName+'*'
	WHERE IsIndividual=1
		  
		  
RETURN
END
