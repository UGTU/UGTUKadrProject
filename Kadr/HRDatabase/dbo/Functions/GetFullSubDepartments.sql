

--select * from [dbo].[GetFullSubDepartments](1,GETDATE(),GETDATE()) 
--возвращает подотделы переданного отдела (вместе с переданным отделом) с ФИО менеджеров
CREATE FUNCTION [dbo].[GetFullSubDepartments] 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS  TABLE

AS
RETURN
(
	SELECT Department.id idDepartment,ManagerDepartment.id idManagerDepartment,subDeps.idManagerDepartment idManagerPlanStaff,IsMain,
		Department.DepartmentName,Department.DepartmentSmallName,
		ManagerDepartment.DepartmentName DepartmentManagerName,ManagerDepartment.DepartmentSmallName DepartmentManagerSmallName,
		Employee.EmployeeSmallName ManagerName
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
		
)


