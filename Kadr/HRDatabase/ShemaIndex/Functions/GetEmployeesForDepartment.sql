
--select * from ShemaIndex.GetEmployeesForDepartment('F3EE3FD5-664D-E111-96A2-0018FE865BEC','20.01.2011','20.02.2011')
CREATE FUNCTION ShemaIndex.GetEmployeesForDepartment
(
@departmentGUID UNIQUEIDENTIFIER,
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
    ManagerBit			BIT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	DECLARE @idDepartment INT
	SELECT @idDepartment = id FROM dbo.Dep WHERE DepartmentGUID=@departmentGUID
	
	INSERT INTO @Result
	SELECT DISTINCT Employee.GUID, LastName+' '+FirstName+' '+Otch,
		Post.PostGUID, PostName, PostShortName, ManagerBit
	FROM  
	(SELECT * FROM dbo.FactStaffMain as FactStaff 
		WHERE 
			((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
			OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))) FactStaff
	INNER JOIN
	dbo.PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id AND idDepartment=@idDepartment
	INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id 
	INNER JOIN dbo.Employee ON FactStaff.idEmployee=Employee.id
		  
RETURN
END

