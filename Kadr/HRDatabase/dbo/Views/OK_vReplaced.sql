CREATE VIEW dbo.OK_vReplaced
AS
SELECT     dbo.FactStaffReplacement.idFactStaff, dbo.FactStaffReplacement.idReplacedFactStaff, dbo.FactStaffReplacement.idReplacementReason, 
                      dbo.FactStaffReplacementReason.ReplacementReasonName, dbo.FactStaff.idEmployee, dbo.FactStaff.idPlanStaff, 
                      dbo.Employee.LastName + ' ' + dbo.Employee.FirstName + ' ' + dbo.Employee.Otch AS FIO, dbo.PlanStaff.idDepartment, 
                      dbo.OK_vDepartment.DepartmentName, dbo.FactStaff.id, dbo.PlanStaff.idPost, dbo.Post.PostName, dbo.Employee.itab_n
FROM         dbo.FactStaffReplacement INNER JOIN
                      dbo.FactStaffReplacementReason ON dbo.FactStaffReplacement.idReplacementReason = dbo.FactStaffReplacementReason.id INNER JOIN
                      dbo.FactStaff ON dbo.FactStaffReplacement.idReplacedFactStaff = dbo.FactStaff.id INNER JOIN
                      dbo.Employee ON dbo.FactStaff.idEmployee = dbo.Employee.id INNER JOIN
                      dbo.PlanStaff ON dbo.FactStaff.idPlanStaff = dbo.PlanStaff.id INNER JOIN
                      dbo.OK_vDepartment ON dbo.PlanStaff.idDepartment = dbo.OK_vDepartment.id INNER JOIN
                      dbo.Post ON dbo.PlanStaff.idPost = dbo.Post.id

GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane1', @value = N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Begin Table = "FactStaffReplacement"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 106
               Right = 225
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FactStaffReplacementReason"
            Begin Extent = 
               Top = 6
               Left = 263
               Bottom = 106
               Right = 495
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FactStaff"
            Begin Extent = 
               Top = 108
               Left = 38
               Bottom = 223
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 6
               Left = 533
               Bottom = 121
               Right = 694
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PlanStaff"
            Begin Extent = 
               Top = 108
               Left = 277
               Bottom = 223
               Right = 438
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OK_vDepartment"
            Begin Extent = 
               Top = 126
               Left = 476
               Bottom = 241
               Right = 665
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Post"
            Begin Extent = 
               Top = 228
               Left = 38
               Bottom = 343
               Right = 199
         ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vReplaced';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'   End
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
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vReplaced';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vReplaced';

