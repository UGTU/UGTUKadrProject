
--Возвращает должности сотрудника
--select * from ShemaIndex.GetEmployeesInfo('04447E65-64A2-4C04-9DF2-AA369ACA0394','20.01.2011','20.02.2012')
CREATE FUNCTION ShemaIndex.GetEmployeesInfo
(
@employeeGUID UNIQUEIDENTIFIER,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    employeeGUID		UNIQUEIDENTIFIER,
    FIO			VARCHAR(150),
    postGUID			UNIQUEIDENTIFIER,
    PostName			VARCHAR(150),
    PostShortName		VARCHAR(50),
    ManagerBit			BIT,
    IsWorking			BIT,
    DepartmentGUID      UNIQUEIDENTIFIER
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	DECLARE @idEmployee INT
	SELECT @idEmployee = id FROM dbo.Employee WHERE GUID=@employeeGUID
	
	INSERT INTO @Result
	SELECT DISTINCT Employee.GUID, LastName+' '+FirstName+' '+Otch,
		Post.PostGUID, PostName, PostShortName, ManagerBit, CONVERT(bit, ABS(datesDiff) + datesDiff),
		 Dep.DepartmentGUID
	FROM  
	(SELECT FactStaff.*, DATEDIFF(dd, GETDATE(), ISNULL(FactStaff.DateEnd, '31.12.2200')) datesDiff FROM dbo.FactStaffMain as FactStaff 
		WHERE 
			idEmployee=@idEmployee AND
			(((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
			OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd)))) FactStaff
	INNER JOIN
	dbo.PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id 
	INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id 
	INNER JOIN dbo.Employee ON Employee.id=@idEmployee
	INNER JOIN dbo.Dep ON PlanStaff.idDepartment=Dep.id
		  
RETURN
END

