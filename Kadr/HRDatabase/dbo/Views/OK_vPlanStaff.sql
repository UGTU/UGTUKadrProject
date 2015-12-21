CREATE VIEW dbo.OK_vPlanStaff
AS
SELECT     dbo.PlanStaff.id, dbo.PlanStaffHistory.StaffCount, dbo.PlanStaff.idDepartment, dbo.PlanStaff.idPost, dbo.PlanStaffHistory.idBeginPrikaz, 
                      dbo.PlanStaff.idEndPrikaz, dbo.PlanStaffHistory.idFinancingSource, CONVERT(date, dbo.PlanStaffHistory.DateBegin) AS DateBegin, CONVERT(date, 
                      dbo.PlanStaff.DateEnd) AS DateEnd, dbo.PlanStaffHistory.id AS idPlanStaffHistory, dbo.PlanStaff.DateEnd AS DateEndR, 
                      dbo.PlanStaffHistory.DateBegin AS DateBeginR, dbo.Department.DepartmentName, dbo.Department.DepartmentSmallName, dbo.Post.PostName, 
                      dbo.Post.PostShortName, dbo.FinancingSource.FinancingSourceName,
                          (SELECT     SUM(StaffCount) AS Expr1
                            FROM          dbo.FactStaffCurrent
                            WHERE      (idPlanStaff = dbo.PlanStaff.id) AND (IsReplacement = 0) AND (DateEnd >= GETDATE() OR
                                                   DateEnd IS NULL)
                            GROUP BY idPlanStaff) AS sumstaff
FROM         dbo.PlanStaff INNER JOIN
                      dbo.PlanStaffHistory ON dbo.PlanStaff.id = dbo.PlanStaffHistory.idPlanStaff AND dbo.PlanStaffHistory.DateBegin =
                          (SELECT     MAX(DateBegin) AS Expr1
                            FROM          dbo.PlanStaffHistory
                            WHERE      (idPlanStaff = dbo.PlanStaff.id)) INNER JOIN
                      dbo.Post ON dbo.PlanStaff.idPost = dbo.Post.id INNER JOIN
                      dbo.Department ON dbo.PlanStaff.idDepartment = dbo.Department.id INNER JOIN
                      dbo.FinancingSource ON dbo.PlanStaffHistory.idFinancingSource = dbo.FinancingSource.id
WHERE     (dbo.PlanStaff.DateEnd >= GETDATE()) OR
                      (dbo.PlanStaff.DateEnd IS NULL)

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
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PlanStaff"
            Begin Extent = 
               Top = 126
               Left = 262
               Bottom = 241
               Right = 423
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PlanStaffHistory"
            Begin Extent = 
               Top = 126
               Left = 461
               Bottom = 241
               Right = 628
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Post"
            Begin Extent = 
               Top = 6
               Left = 470
               Bottom = 121
               Right = 631
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 6
               Left = 243
               Bottom = 121
               Right = 432
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FinancingSource"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 226
               Right = 224
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
      Begin ColumnWidths = 17
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vPlanStaff';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N' = 1500
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vPlanStaff';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vPlanStaff';

