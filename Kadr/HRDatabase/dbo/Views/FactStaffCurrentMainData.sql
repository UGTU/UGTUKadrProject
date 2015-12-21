













/*select * from [FactStaffCurrentMainData] where id = 172 order by DateBegin
Представление со всеми текущими параметрами FactStaff (DateBegin...) и должностью */
CREATE VIEW [dbo].[FactStaffCurrentMainData]
AS
SELECT        [FactStaffCurrent].id, [FactStaffCurrent].StaffCount, [FactStaffCurrent].idPlanStaff, 
				[FactStaffCurrent].idEmployee, 
				Employee.EmployeeName +', '+Department.DepartmentSmallName+', '+[Post].PostName+', '+[WorkType].TypeWorkShortName+', '+FORMAT([FactStaffCurrent].StaffCount, 'N', 'ru-ru') +' ставки' FactStaffFullName,
				[FactStaffCurrent].idOKVED
FROM            [dbo].[FactStaffCurrent] INNER JOIN
                         dbo.PlanStaff ON [FactStaffCurrent].idPlanStaff = PlanStaff.id
                             INNER JOIN [dbo].[Post] ON PlanStaff.idPost=Post.id
							 INNER JOIN [dbo].[WorkType] ON [FactStaffCurrent].[idTypeWork]=[WorkType].id
							 INNER JOIN dbo.Employee ON [FactStaffCurrent].idEmployee=Employee.id
							 INNER JOIN dbo.Department ON PlanStaff.idDepartment=Department.id
WHERE [FactStaffCurrent].DateEnd IS NULL OR [FactStaffCurrent].DateEnd>GETDATE()













