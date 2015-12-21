CREATE VIEW dbo.OK_vFactStaff
AS
SELECT     dbo.FactStaff.id, dbo.FactStaff.idPlanStaff, dbo.FactStaff.idEmployee, dbo.FactStaff.idEndPrikaz, dbo.FactStaff.DateEnd, Prikaz_2.PrikazName, 
                      Prikaz_2.DatePrikaz, dbo.PlanStaff.idDepartment, dbo.PlanStaff.idPost, dbo.FactStaffHistory.idBeginPrikaz, dbo.FactStaffHistory.DateBegin, 
                      dbo.FactStaffHistory.StaffCount, dbo.FactStaffHistory.idTypeWork, Prikaz_1.PrikazName AS PrikazNameBegin, 
                      Prikaz_1.DatePrikaz AS DatePrikazbegin, dbo.WorkType.TypeWorkName, dbo.Post.idCategory, dbo.Category.CategorySmallName, 
                      dbo.Post.PostName, dbo.Department.DepartmentName, dbo.Post.PostShortName, dbo.Category.CategoryName, 
                      dbo.Department.DepartmentSmallName, dbo.FactStaff.IsReplacement, dbo.FactStaff.idlaborcontrakt AS idlaborcontraktmain, 
                      dbo.FactStaffHistory.idlaborcontrakt AS idlaborcontrakthistory, dbo.Prikaz.PrikazName AS contraktmain, dbo.Prikaz.DatePrikaz AS contraktmaindate, 
                      dbo.Prikaz.DateBegin AS contraktmainbegin, dbo.Prikaz.DateEnd AS contraktmainend, Prikaz_3.PrikazName AS contrakthistory, 
                      Prikaz_3.DatePrikaz AS contrakthistorydate, Prikaz_3.DateBegin AS contrakthistorybegin, Prikaz_3.DateEnd AS contrakthistoryend, 
                      dbo.FactStaff.idreason, dbo.OK_Reason.reasonname, dbo.FactStaffHistory.id AS idHistory
FROM         dbo.FactStaff INNER JOIN
                      dbo.FactStaffHistory ON dbo.FactStaff.id = dbo.FactStaffHistory.idFactStaff INNER JOIN
                      dbo.WorkType ON dbo.FactStaffHistory.idTypeWork = dbo.WorkType.id INNER JOIN
                      dbo.PlanStaff ON dbo.FactStaff.idPlanStaff = dbo.PlanStaff.id INNER JOIN
                      dbo.Post ON dbo.PlanStaff.idPost = dbo.Post.id INNER JOIN
                      dbo.Department ON dbo.PlanStaff.idDepartment = dbo.Department.id INNER JOIN
                      dbo.Category ON dbo.Post.idCategory = dbo.Category.id LEFT OUTER JOIN
                      dbo.OK_Reason ON dbo.FactStaff.idreason = dbo.OK_Reason.idreason LEFT OUTER JOIN
                      dbo.Prikaz ON dbo.FactStaff.idlaborcontrakt = dbo.Prikaz.id LEFT OUTER JOIN
                      dbo.Prikaz AS Prikaz_3 ON dbo.FactStaffHistory.idlaborcontrakt = Prikaz_3.id LEFT OUTER JOIN
                      dbo.Prikaz AS Prikaz_1 ON dbo.FactStaffHistory.idBeginPrikaz = Prikaz_1.id LEFT OUTER JOIN
                      dbo.Prikaz AS Prikaz_2 ON dbo.FactStaff.idEndPrikaz = Prikaz_2.id

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
         Top = -480
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
         Begin Table = "WorkType"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 241
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PlanStaff"
            Begin Extent = 
               Top = 126
               Left = 259
               Bottom = 241
               Right = 420
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
         Begin Table = "Department"
            Begin Extent = 
               Top = 246
               Left = 237
               Bottom = 361
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Category"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 481
               Right = 215
            End
            Di', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vFactStaff';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'splayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Prikaz_1"
            Begin Extent = 
               Top = 366
               Left = 253
               Bottom = 481
               Right = 414
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Prikaz"
            Begin Extent = 
               Top = 486
               Left = 38
               Bottom = 601
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OK_Reason"
            Begin Extent = 
               Top = 486
               Left = 237
               Bottom = 571
               Right = 398
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Prikaz_3"
            Begin Extent = 
               Top = 486
               Left = 436
               Bottom = 601
               Right = 597
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Prikaz_2"
            Begin Extent = 
               Top = 576
               Left = 237
               Bottom = 691
               Right = 398
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vFactStaff';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OK_vFactStaff';

