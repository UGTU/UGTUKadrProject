use Kadr

go
--select * from [dbo].[GetRecruitedFactStaffByPeriod]('20.01.2011','20.02.2011')where idPlanStaff=1066
alter FUNCTION [dbo].[GetRecruitedFactStaffByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idFactStaff		INT,
    idPlanStaff			INT,
    idEmployee		INT,
    idTypeWork				INT,
    StaffCount	numeric(4,2),
    IsReplacement	BIT,
    DateBegin		DATETIME,
    idBeginPrikaz	INT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	INSERT INTO @Result
	SELECT FactStaff.id, idPlanStaff, idEmployee, idTypeWork, StaffCount, IsReplacement, LastFactStaff.DateBegin, FactStaff.idBeginPrikaz
	FROM  dbo.FactStaffWithHistory as FactStaff 
	INNER JOIN							
	(SELECT FactStaff.id, MIN(DateBegin) as DateBegin
	FROM  dbo.FactStaffWithHistory as FactStaff 
	WHERE 
		((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
								OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
	GROUP BY FactStaff.id) LastFactStaff
	ON FactStaff.id=LastFactStaff.id AND FactStaff.DateBegin=LastFactStaff.DateBegin		  
		  
RETURN
END





go
--select * from [dbo].[GetFactStaffChangesByPeriod](141,'20.01.2011','20.02.2011',1)where idPlanStaff=1066
alter FUNCTION [dbo].[GetFactStaffChangesByPeriod] 
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
	OperationPrikazName		VARCHAR(50)
	
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
	
	INSERT INTO @DepTable	--текущий отдел
		SELECT @idDepartment, 1
		
	IF (@WithSubDeps = 1)	--если с подотделами
		INSERT INTO @DepTable
		SELECT idDepartment, 0
		FROM [dbo].[GetSubDepartments](@idDepartment)

	
	INSERT INTO @Result
	SELECT
	WorkSuperTypeShortName, CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber) PKCategoryName, 
	FinancingSourceName, PostShortName, 
	Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'. '+CONVERT(VARCHAR(1),Employee.Otch)+'.' EmployeeName,
    FactStaff.StaffCount, DepartmentSmallName, @PeriodBegin, @PeriodEnd,
	CategorySmallName, OperationName, 
	OperationDate, PrikazName+' от '+CONVERT(VARCHAR(10),CONVERT(Date,DatePrikaz)) OperationPrikazName
	FROM
	
	(SELECT 'Принят' as OperationName, idFactStaff, idPlanStaff, idEmployee, 
			idTypeWork, StaffCount, IsReplacement, DateBegin OperationDate, idBeginPrikaz idOperationPrikaz
	FROM  [dbo].GetRecruitedFactStaffByPeriod(@PeriodBegin, @PeriodEnd) as FactStaff 
	WHERE 
		((FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
		
	UNION
	SELECT 'Уволен' as Operation, FactStaff.id idFactStaff, idPlanStaff, idEmployee, 
			idTypeWork, StaffCount, IsReplacement, DateEnd OperationDate, idEndPrikaz idOperationPrikaz
	FROM dbo.FactStaff
	WHERE FactStaff.DateEnd>=@PeriodBegin AND FactStaff.DateEnd<=@PeriodEnd) FactStaff
	INNER JOIN dbo.PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id  
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
		


		  
		  
RETURN
END
