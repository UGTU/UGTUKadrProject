/*select * from [Shared].DepartmentMainData 
where DepartmentGUID='81ef3fd5-664d-e111-96a2-0018fe865bec'
order by DepartmentName
Для службы idDepartmentType=1
Представление с текущими параметрами отдела 
LEFT JOIN [dbo].[GetDepartmentDataForReports](1, GETDATE(),GETDATE(),1,1)ExternalManager
	ON  [Department].id=ExternalManager.idDepartment*/
CREATE VIEW [Shared].[DepartmentMainData]
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

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[13] 4[13] 2[16] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Department"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 300
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "FactStaff_1"
            Begin Extent = 
               Top = 1
               Left = 448
               Bottom = 120
               Right = 642
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 94
               Left = 786
               Bottom = 257
               Right = 1062
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1800
         Width = 1656
         Width = 2484
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
         Width = 1200
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
', @level0type = N'SCHEMA', @level0name = N'Shared', @level1type = N'VIEW', @level1name = N'DepartmentMainData';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'Shared', @level1type = N'VIEW', @level1name = N'DepartmentMainData';

