create view [dbo].[UptodateDepartmentHistory] 
as 
SELECT * 
FROM [dbo].[DepartmentHistory] T1 
WHERE [DateBegin] = ( 
SELECT max([DateBegin]) 
FROM [dbo].[DepartmentHistory] T2 
WHERE T1.idDepartment = T2.idDepartment)