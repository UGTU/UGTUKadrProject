USE [Kadr]
GO

/****** Object:  UserDefinedFunction [dbo].[GetSubDepartmentsWithManagers]    Script Date: 03/05/2012 09:51:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--select * from [dbo].[GetFullSubDepartments](51,GETDATE(),GETDATE()) 
--возвращает подотделы переданного отдела (вместе с переданным отделом) с ФИО менеджеров
alter FUNCTION [dbo].[GetFullSubDepartments] 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
	idManagerPlanStaff	INT,
    IsMain			BIT,
    DepartmentName  VARCHAR(200),
    DepartmentManagerName VARCHAR(200),
    ManagerName VARCHAR(200)    
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

	INSERT INTO @Result
	SELECT Department.id,ManagerDepartment.id,subDeps.idManagerDepartment,IsMain,
		Department.DepartmentSmallName,ManagerDepartment.DepartmentSmallName,
		Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'. '+CONVERT(VARCHAR(1),Employee.Otch)+'.' EmployeeName
    FROM 
		(SELECT * FROM dbo.GetSubDepartmentsWithManagers(@idManagerDepartment))subDeps
		INNER JOIN dbo.Department ON subDeps.idDepartment=Department.id
		INNER JOIN dbo.Department ManagerDepartment 
			ON subDeps.idManagerDepartment=ManagerDepartment.id
		LEFT JOIN
		(SELECT idPlanStaff, MIN(idEmployee) idEmployee FROM dbo.GetDepartmentStaff(1,@PeriodBegin,@PeriodEnd,1)
			GROUP BY idPlanStaff)staff
			ON subDeps.idManagerPlanStaff=staff.idPlanStaff
		LEFT JOIN dbo.Employee ON staff.idEmployee=Employee.id
		
RETURN
END


GO


