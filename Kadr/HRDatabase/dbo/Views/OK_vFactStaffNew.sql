CREATE VIEW dbo.OK_vFactStaffNew
AS
SELECT     dbo.FactStaff.id AS idFactStaff, dbo.FactStaffHistory.StaffCount, dbo.FactStaff.idPlanStaff, dbo.FactStaff.idEmployee, dbo.FactStaffHistory.idBeginPrikaz, 
                      dbo.FactStaff.idEndPrikaz, dbo.FactStaffHistory.idTypeWork, dbo.FactStaffHistory.DateBegin, dbo.FactStaff.IsReplacement, 
                      dbo.FactStaffHistory.id AS idFactStaffHistory, dbo.FactStaff.DateEnd, dbo.FactStaff.idlaborcontrakt AS idLaborContraktFactStaff, 
                      dbo.FactStaffHistory.idlaborcontrakt AS idLaborContraktFactstaffHistory, dbo.PlanStaff.idDepartment, dbo.PlanStaff.idPost, 
                      dbo.Department.DepartmentName, dbo.Department.DepartmentSmallName, dbo.Post.PostName, dbo.Post.PostShortName, 
                      dbo.WorkType.TypeWorkName, dbo.WorkType.TypeWorkShortName, Prikaz_1.PrikazName AS EndPrikazName, 
                      dbo.Prikaz.PrikazName AS LaborContraktFactStaffName, Prikaz_3.PrikazName AS LaborContraktFactStaffHistoryName, 
                      Prikaz_2.PrikazName AS BeginPrikazName, dbo.PKGroup.GroupNumber, dbo.PKGroup.GroupName, dbo.PKCategory.idPKGroup, 
                      dbo.Post.idPKCategory, dbo.PKCategory.PKCategoryNumber, dbo.PKCategory.PKSubCategoryNumber, 
                      dbo.OK_vFactStaffDateBegin.DateBegin AS FactStaffDateBegin
FROM         dbo.FactStaff INNER JOIN
                      dbo.FactStaffHistory ON dbo.FactStaff.id = dbo.FactStaffHistory.idFactStaff AND dbo.FactStaffHistory.DateBegin =
                          (SELECT     MAX(DateBegin) AS Expr1
                            FROM          dbo.FactStaffHistory AS fsh
                            WHERE      (idFactStaff = dbo.FactStaff.id)) INNER JOIN
                      dbo.PlanStaff ON dbo.FactStaff.idPlanStaff = dbo.PlanStaff.id INNER JOIN
                      dbo.Department ON dbo.PlanStaff.idDepartment = dbo.Department.id INNER JOIN
                      dbo.Post ON dbo.PlanStaff.idPost = dbo.Post.id INNER JOIN
                      dbo.WorkType ON dbo.FactStaffHistory.idTypeWork = dbo.WorkType.id INNER JOIN
                      dbo.PKCategory ON dbo.Post.idPKCategory = dbo.PKCategory.id INNER JOIN
                      dbo.PKGroup ON dbo.PKCategory.idPKGroup = dbo.PKGroup.id INNER JOIN
                      dbo.OK_vFactStaffDateBegin ON dbo.FactStaff.id = dbo.OK_vFactStaffDateBegin.idFactStaff LEFT OUTER JOIN
                      dbo.Prikaz ON dbo.FactStaff.idlaborcontrakt = dbo.Prikaz.id LEFT OUTER JOIN
                      dbo.Prikaz AS Prikaz_1 ON dbo.FactStaff.idEndPrikaz = Prikaz_1.id LEFT OUTER JOIN
                      dbo.Prikaz AS Prikaz_3 ON dbo.FactStaffHistory.idlaborcontrakt = Prikaz_3.id LEFT OUTER JOIN
                      dbo.Prikaz AS Prikaz_2 ON dbo.FactStaffHistory.idBeginPrikaz = Prikaz_2.id

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
         Begin Table = "FactStaff"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 121
               Right = 239
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FactStaffHistory"
            Begin Extent = 
               Top = 6
               Left = 277
               Bottom = 121
               Right = 438
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PlanStaff"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Department"
            Begin Extent = 
               Top = 126
               Left = 237
               Bottom = 241
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Post"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 361
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WorkType"
            Begin Extent = 
               Top = 246
               Left = 237
               Bottom = 361
               Right = 420
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PKCategory"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 481
               Right = 231
            End
            Dis', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vFactStaffNew';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'playFlags = 280
            TopColumn = 0
         End
         Begin Table = "PKGroup"
            Begin Extent = 
               Top = 366
               Left = 269
               Bottom = 466
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Prikaz"
            Begin Extent = 
               Top = 468
               Left = 269
               Bottom = 583
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Prikaz_1"
            Begin Extent = 
               Top = 486
               Left = 38
               Bottom = 601
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Prikaz_3"
            Begin Extent = 
               Top = 588
               Left = 237
               Bottom = 703
               Right = 398
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Prikaz_2"
            Begin Extent = 
               Top = 606
               Left = 38
               Bottom = 721
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OK_vFactStaffDateBegin"
            Begin Extent = 
               Top = 6
               Left = 476
               Bottom = 106
               Right = 644
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vFactStaffNew';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vFactStaffNew';

