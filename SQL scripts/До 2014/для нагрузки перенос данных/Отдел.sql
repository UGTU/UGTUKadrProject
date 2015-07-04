GO
  alter table UGTU.[dbo].[IMPORT_DepartmentMainData]
  add idManagerFactStaffHistory int 


use kadr
go
/*select * from [Shared].DepartmentMainData 
where DepartmentGUID='b7ee3fd5-664d-e111-96a2-0018fe865bec'
order by DepartmentName
Для службы idDepartmentType=1
Представление с текущими параметрами отдела 
LEFT JOIN [dbo].[GetDepartmentDataForReports](1, GETDATE(),GETDATE(),1,1)ExternalManager
	ON  [Department].id=ExternalManager.idDepartment*/
ALTER VIEW [Shared].[DepartmentMainData]
AS
SELECT dbo.Department.DepartmentGUID, dbo.Department.id AS idDepartment, dbo.Department.DepartmentName, dbo.Department.DepartmentSmallName, dbo.Department.DepartmentIndex, 
                  dbo.Employee.EmployeeSmallName AS ManagerSmallName, dbo.Employee.EmployeeName AS ManagerName, dbo.Department.idDepartmentType, dbo.Department.DepPhoneNumber AS PhoneNumber, 
                  dbo.Department.idManagerDepartment, PostName, Department.dateCreate, Department.dateExit ,
				  ManagerDepartment.DepartmentGUID [ManagerDepartmentGUID], idFactStaffHistory [idManagerFactStaffHistory]
FROM     dbo.Department LEFT OUTER JOIN
	dbo.Dep ManagerDepartment ON Department.idManagerDepartment=ManagerDepartment.id LEFT JOIN
    (SELECT PlanStaff.idDepartment, PostName, MIN(FactStaff.idFactStaffHistory) AS idFactStaffHistory
	FROM
	(SELECT Department.id AS idDepartment, MIN(PlanStaff.idPlanStaff) idPlanStaff
    FROM      dbo.GetPlanStaffByPeriod(GETDATE(), GETDATE()) AS PlanStaff INNER JOIN
        dbo.Post ON PlanStaff.idPost = dbo.Post.id
	INNER JOIN
        dbo.Department ON Department.id = PlanStaff.idDepartment AND dbo.Post.ManagerBit = 1 OR Department.idManagerPlanStaff = PlanStaff.idPlanStaff
	GROUP BY Department.id  )PlanStaff INNER JOIN
		dbo.PlanStaff PlanStaffCurr ON PlanStaff.idPlanStaff=PlanStaffCurr.id INNER JOIN
		dbo.Post ON PlanStaffCurr.idPost = Post.id INNER JOIN
		dbo.GetFactStaffByPeriod(GETDATE(), GETDATE()) AS FactStaff ON PlanStaff.idPlanStaff = FactStaff.idPlanStaff

    GROUP BY PlanStaff.idDepartment, PostName) AS CurrFactStaff ON dbo.Department.id = CurrFactStaff.idDepartment 
	LEFT JOIN dbo.FactStaffHistory ON CurrFactStaff.idFactStaffHistory=FactStaffHistory.id
	LEFT JOIN dbo.FactStaff ON FactStaffHistory.idfactStaff=FactStaff.id
	LEFT OUTER JOIN
                  dbo.Employee ON FactStaff.idEmployee = dbo.Employee.id


go

delete from UGTU.[dbo].[IMPORT_DepartmentMainData]

INSERT INTO UGTU.[dbo].[IMPORT_DepartmentMainData]
           ([DepartmentGUID],[DepartmentName],[DepartmentSmallName],[DepartmentIndex]
           ,[idDepartmentType],[DepPhoneNumber],[ManagerSmallName],[ManagerName]
		   ,[dateCreate],[dateExit],[idManagerFactStaffHistory],[ManagerDepartmentGUID]
		)
SELECT [DepartmentGUID],[DepartmentName],[DepartmentSmallName],[DepartmentIndex]
      ,[idDepartmentType],[PhoneNumber],[ManagerSmallName],[ManagerName]
	  ,[dateCreate],[dateExit],[idManagerFactStaffHistory],[ManagerDepartmentGUID]
  FROM [Kadr].[Shared].[DepartmentMainData]


