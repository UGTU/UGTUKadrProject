USE [kadrTest]
GO
/****** Object:  UserDefinedFunction [dbo].[GetDepartmentStaff]    Script Date: 02/02/2012 10:11:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



GO

--select * from [dbo].[GetDepartmentStaff](323, '22.02.2011','22.02.2011', 0) where idPlanStaff=172 
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
    factStaffCount			decimal(6,2) NULL,
    EmplName				VARCHAR(150) NULL,
    TypeWorkName			VARCHAR(150) NULL,
    DepartmentName			VARCHAR(200) NULL,
    PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	StaffCountWithoutReplacement			DECIMAL(8,2),
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
    IsMain BIT 
	
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
		FROM [dbo].[GetSubDepartments](@idDepartment)
	ELSE
		INSERT INTO @DepTable	--текущий отдел
			SELECT @idDepartment, 1
	
		
			
	INSERT INTO @Result
	SELECT PostName, RTRIM(GroupNumber)+' '+RTRIM(PKCategoryNumber) as PKCategoryName,
		CategorySmallName, FinancingSourceName, PeriodStaff.StaffCount, 
		ISNULL(Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'.'+CONVERT(VARCHAR(1),Employee.Otch)+'.','Вакансия') as EmplName,
		WorkType.TypeWorkShortName + IsNull(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')', '') TypeWorkName, 
		Department.DepartmentName,@PeriodBegin, @PeriodEnd, 
		StaffCountWithoutReplacement, PeriodStaff.idPlanStaff,
		ISNULL(Employee.LastName+' '+ISNULL(Employee.FirstName,'')+' '+ISNULL(Employee.Otch,''),''), 
		EmployeeSid, Employee.id, Post.id, Post.ManagerBit, PeriodStaff.idFactStaff, EmployeeLogin
		, DepartmentGUID, GUID, WorkType.IsMain
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
          dbo.FactStaffReplacementReason ON PeriodStaff.idReplacementReason=FactStaffReplacementReason.id 
	order by Deps.Ismain desc, Department.DepartmentName, FinancingSource.OrderBy, Category.OrderBy, PKCategoryName desc, PostName, EmplName
	
	UPDATE @Result
	SET PKCategoryName=PKCategoryName+'*'
	WHERE idPlanStaff IN (SELECT idPlanStaff FROM dbo.GetIndivSalaryByPeriod(@PeriodBegin,@PeriodEnd))
RETURN
END




go
--select * from dbo.AllMainEmployees
--Возвращает всех основных сотрудников университета
alter VIEW dbo.AllMainEmployees
AS
SELECT staff.EmployeeGUID,
	Employee.FirstName, Employee.LastName, Employee.Otch, Employee.BirthDate,
	staff.PostName, staff.DepartmentName, SemPol.sempolName, staff.DepartmentGUID,
	FactStaffWithHistory.DateBegin
	 


	from [dbo].[GetDepartmentStaff](1, getdate(),getdate(), 1) staff
      INNER JOIN dbo.Employee ON staff.idEmployee = Employee.id 
      INNER JOIN dbo.SemPol ON dbo.Employee.idSemPol = dbo.SemPol.id
      INNER JOIN (SELECT idEmployee, MIN(DateBegin) DateBegin
					FROM dbo.FactStaffWithHistory
					GROUP BY idEmployee)FactStaffWithHistory 
      
      ON Employee.id=FactStaffWithHistory.idEmployee


--dbo.EducDocument INNER JOIN
--      dbo.EducDocumentType ON dbo.EducDocument.idEducDocType = dbo.EducDocumentType.id INNER JOIN
--      dbo.EmployeeRank ON dbo.EducDocument.id = dbo.EmployeeRank.idEducDocument AND dbo.Employee.id = dbo.EmployeeRank.idEmployee INNER JOIN
--      dbo.EmployeeDegree ON dbo.EducDocument.id = dbo.EmployeeDegree.idEducDocument AND dbo.Employee.id = dbo.EmployeeDegree.idEmployee INNER JOIN
       

WHERE IsMain=1
