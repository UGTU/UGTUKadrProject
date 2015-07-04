alter table UGTU.[dbo].[IMPORT_KafTeachers]
add idFactStaffHistory int not null


INSERT INTO UGTU.[dbo].[IMPORT_KafTeachers]([TypeWorkName],[PostName],[EmployeeGUID],[FirstName],[LastName],[Otch],[DepartmentGUID],
	[PostGUID],[DateBegin],[DateEnd],[StaffCount],[HourCount], idFactStaffHistory)
SELECT [TypeWorkName],[PostName],Employee.GUID,[FirstName],[LastName],[Otch],
	Dep.DepartmentGUID,[PostGUID],[FactStaffWithHistory].DateBegin,[FactStaffWithHistory].DateEnd,[StaffCount],[HourCount], idFactStaffHistory
FROM KADR.[dbo].[FactStaffWithHistory]
INNER JOIN KADR.dbo.PlanStaff ON [FactStaffWithHistory].idPlanStaff=PlanStaff.id
INNER JOIN KADR.dbo.Post ON PlanStaff.idPost=Post.id
INNER JOIN KADR.dbo.WorkType ON [FactStaffWithHistory].idTypeWork=WorkType.id
INNER JOIN KADR.dbo.Employee ON [FactStaffWithHistory].idEmployee=Employee.id
INNER JOIN KADR.dbo.Dep ON PlanStaff.idDepartment=Dep.id
INNER JOIN KADR.dbo.Category ON Post.idCategory=Category.id
WHERE Category.IsPPS=1



DELETE FROM
UGTU.dbo.[IMPORT_KafTeachers]