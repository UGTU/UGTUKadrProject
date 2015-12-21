
CREATE VIEW [dbo].[OK_vDepartment]
AS
SELECT     TOP (100) PERCENT dbo.Department.id, dbo.Department.DepartmentName, dbo.Department.DepartmentSmallName, dbo.Department.idDepartmentType, 
                      dbo.DepartmentType.DepartmentTypeName, dbo.Department.dateCreate, dbo.Department.dateExit
FROM         dbo.Department INNER JOIN
                      dbo.DepartmentType ON dbo.Department.idDepartmentType = dbo.DepartmentType.id
ORDER BY dbo.DepartmentType.DepartmentTypeName, dbo.Department.DepartmentName

