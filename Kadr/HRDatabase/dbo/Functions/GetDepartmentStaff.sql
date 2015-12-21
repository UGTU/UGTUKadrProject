
--select * from [dbo].[GetDepartmentStaff](1, '01.01.2013','21.12.2015',1) order by PKCategoryName desc where DepartmentName  like '%ремонту%' 
CREATE FUNCTION [dbo].[GetDepartmentStaff] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
@WithSubDeps BIT
)
RETURNS  TABLE
   /*(
    PostName				VARCHAR(150) NULL,
    PKCategoryName			VARCHAR(150) NULL,
    CategoryName			VARCHAR(50)  NULL,
    FinancingSourceName		VARCHAR(50)  NULL,
    factStaffCount			decimal(12,4) NULL,
    EmplName				VARCHAR(150) NULL,
    TypeWorkName			VARCHAR(150) NULL,
    DepartmentName			VARCHAR(500) NULL,
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
	idDepartment int,
	[itab_n] VARCHAR(50)

	
   )*/ 
AS
RETURN
(
	SELECT PostName, PKCategory.PKCategoryFullName+' '+ISNULL(CONVERT(VARCHAR(3),SalaryKoeff.PKSubSubCategoryNumber),PKCategory.PKSubSubCategoryNumber)+IIF(indSal.idPlanStaff IS NULL, '','*') as PKCategoryName,
		CategorySmallName CategoryName, FinancingSourceName, PeriodStaff.StaffCount, PeriodStaff.StaffCount factStaffCount, 
		ISNULL(EmployeeSmallName,'Вакансия') as EmplName,
		WorkType.TypeWorkShortName + IsNull(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')', '') TypeWorkName, 
		Deps.DepartmentName,@PeriodBegin PeriodBegin, @PeriodEnd PeriodEnd, 
		StaffCountWithoutReplacement, PeriodStaff.idPlanStaff,
		ISNULL(EmployeeName,'Вакансия') EmplFullName, 
		EmployeeSid, Employee.id idEmployee, Post.id idPost, Post.ManagerBit, PeriodStaff.idFactStaff, EmployeeLogin
		, DepartmentGUID, GUID, WorkType.IsMain, otpusk.otpTypeShortName MatOtpusk,
		Deps.idDepartment, [itab_n], DepTreeIndex
	FROM  
		  dbo.[GetDepartmentDataForReports](@idDepartment, @PeriodBegin, @PeriodEnd, @WithSubDeps,-1) as Deps  INNER JOIN
		  dbo.Dep Department ON Deps.idDepartment=Department.id LEFT JOIN 
		  dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff ON PeriodStaff.idDepartment=Deps.idDepartment LEFT JOIN
		  dbo.Post ON PeriodStaff.idPost=Post.id LEFT join
		  dbo.[GetFullPKCategory](@PeriodBegin,@PeriodEnd) PKCategory ON Post.idPKCategory=PKCategory.id LEFT JOIN
		  dbo.FinancingSource ON PeriodStaff.idFinancingSource = dbo.FinancingSource.id LEFT JOIN
          dbo.Category ON Post.idCategory = dbo.Category.id LEFT JOIN
          dbo.WorkType ON PeriodStaff.idTypeWork = dbo.WorkType.id LEFT JOIN
          dbo.Employee ON PeriodStaff.idEmployee = dbo.Employee.id LEFT JOIN
          dbo.FactStaffReplacementReason ON PeriodStaff.idReplacementReason=FactStaffReplacementReason.id LEFT JOIN
          [dbo].[GetOtpuskByPeriod](@PeriodBegin,@PeriodEnd) otpusk 
			ON PeriodStaff.idFactStaff=otpusk.idFactStaff AND otpusk.isMaternity=1 LEFT JOIN 
		  [dbo].[SalaryKoeff] ON PeriodStaff.idSalaryKoeff=[SalaryKoeff].id LEFT JOIN
		  dbo.GetIndivSalaryByPeriod(@PeriodBegin,@PeriodEnd)indSal ON PeriodStaff.idPlanStaff=indSal.idPlanStaff
	
)
