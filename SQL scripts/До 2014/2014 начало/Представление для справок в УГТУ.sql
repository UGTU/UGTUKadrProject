USE [Kadr]
GO

/****** Object:  View [dbo].[PlanStaffCurrent]    Script Date: 25.02.2014 14:00:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/*select * from [Shared].DepartmentMainData order by DepartmentName
ѕредставление с текущими параметрами отдела */
ALTER VIEW [Shared].DepartmentMainData
AS
SELECT [Department].DepartmentGUID, [Department].DepartmentName, [Department].DepartmentSmallName,  DepartmentIndex,
	Employee.EmployeeSmallName, Employee.EmployeeName, [DepPhoneNumber] PhoneNumber
	  
FROM  
    [dbo].[Department] LEFT JOIN  --выбираем руководител€                   
	(SELECT Staff.idDepartment, MIN(Staff.idEmployee) idEmployee
		FROM [dbo].[GetStaffByPeriod](GETDATE(),GETDATE()) Staff
		INNER JOIN [dbo].[Post] ON Staff.idPost=[Post].id
			AND Post.[ManagerBit]=1
		GROUP BY Staff.idDepartment)FactStaff ON [Department].id=FactStaff.idDepartment
	LEFT JOIN dbo.Employee ON FactStaff.idEmployee=Employee.id






