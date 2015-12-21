CREATE VIEW dbo.OKFactStaff
AS
SELECT        dbo.FactStaff.id, dbo.FactStaff.idPlanStaff, dbo.FactStaff.idEmployee, dbo.FactStaffCurrent.StaffCount, dbo.FactStaff.DateEnd, dbo.FactStaff.IsReplacement, 
                         dbo.FactStaff.idlaborcontrakt, dbo.FactStaff.idreason, dbo.FactStaff.idEndPrikaz, dbo.OK_Reason.reasonname, dbo.OK_Reason.isUvoln, 
                         OKPrikaz_1.PrikazName AS EndPrikazName, OKPrikaz_1.DatePrikaz AS EndDatePrikaz, OKPrikaz_2.PrikazName AS laborcontraktPrikazName, 
                         OKPrikaz_2.DatePrikaz AS laborcontraktDatePrikaz, OKPrikaz_2.DateBegin AS laborcontraktDatebegin, OKPrikaz_2.DateEnd AS laborcontraktDateEnd, 
                         dbo.FactStaffMain.DateBeginR, OKPrikaz_3.PrikazName AS agreementPrikazName, OKPrikaz_3.DatePrikaz AS agreementDatePrikaz, 
                         OKPrikaz_3.DateBegin AS agreementDateBegin, OKPrikaz_3.DateEnd AS agreementDateEnd, OKPrikaz_3.resume AS agreementResume, 
                         dbo.FactStaffMain.idBeginPrikaz, dbo.FactStaffMain.idlaborcontrakt AS agreementidLaborContrakt, dbo.OKPrikaz.PrikazName AS BeginPrikazName, 
                         dbo.OKPrikaz.DatePrikaz AS BeginDatePrikaz, dbo.OKPrikaz.DateBegin AS BeginDateBegin, dbo.OKPrikaz.DateEnd AS BeginDateEnd, 
                         dbo.OKPrikaz.resume AS BeginResume, dbo.OKPlanStaff.DepartmentName, dbo.OKPlanStaff.DepartmentSmallName, dbo.OKPlanStaff.PostName, 
                         dbo.OKPlanStaff.PostShortName, dbo.OKPlanStaff.GroupNumber, dbo.OKPlanStaff.PKCategoryNumber, dbo.OKPlanStaff.PKSubCategoryNumber, 
                         dbo.OKPlanStaff.PKSubSubCategoryNumber, dbo.OKPlanStaff.FinancingSourceName, dbo.OKPlanStaff.SalarySize, 
                         dbo.OKPlanStaff.DateBeginR AS PlanStaffDateBegin, dbo.OKPlanStaff.DateEndR AS PlanStaffDateEnd, dbo.WorkType.TypeWorkName, 
                         dbo.WorkType.TypeWorkShortName, dbo.OKPlanStaff.CategoryName, dbo.OKPlanStaff.CategorySmallName, dbo.OKPlanStaff.IsPPS
FROM            dbo.FactStaff INNER JOIN
                         dbo.FactStaffCurrent ON dbo.FactStaff.id = dbo.FactStaffCurrent.id INNER JOIN
                         dbo.OKPlanStaff ON dbo.FactStaff.idPlanStaff = dbo.OKPlanStaff.id INNER JOIN
                         dbo.FactStaffMain ON dbo.FactStaff.id = dbo.FactStaffMain.id INNER JOIN
                         dbo.WorkType ON dbo.FactStaffCurrent.idTypeWork = dbo.WorkType.id LEFT OUTER JOIN
                         dbo.OKPrikaz ON dbo.FactStaffMain.idBeginPrikaz = dbo.OKPrikaz.id LEFT OUTER JOIN
                         dbo.OKPrikaz AS OKPrikaz_3 ON dbo.FactStaffMain.FactStaffHistoryidlaborcontrakt = OKPrikaz_3.id LEFT OUTER JOIN
                         dbo.OKPrikaz AS OKPrikaz_2 ON dbo.FactStaff.idlaborcontrakt = OKPrikaz_2.id LEFT OUTER JOIN
                         dbo.OKPrikaz AS OKPrikaz_1 ON dbo.FactStaff.idEndPrikaz = OKPrikaz_1.id LEFT OUTER JOIN
                         dbo.OK_Reason ON dbo.FactStaff.idreason = dbo.OK_Reason.idreason

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
               Bottom = 135
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FactStaffCurrent"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 251
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OKPlanStaff"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 399
               Right = 273
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "FactStaffMain"
            Begin Extent = 
               Top = 402
               Left = 38
               Bottom = 531
               Right = 292
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "WorkType"
            Begin Extent = 
               Top = 534
               Left = 38
               Bottom = 663
               Right = 241
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OKPrikaz"
            Begin Extent = 
               Top = 666
               Left = 38
               Bottom = 795
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OKPrikaz_3"
            Begin Extent = 
               Top = 798
               Left = 38
               Bottom = 927
               Right = 246
            End
       ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OKFactStaff';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'     DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OKPrikaz_2"
            Begin Extent = 
               Top = 930
               Left = 38
               Bottom = 1059
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OKPrikaz_1"
            Begin Extent = 
               Top = 1062
               Left = 38
               Bottom = 1191
               Right = 246
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OK_Reason"
            Begin Extent = 
               Top = 6
               Left = 299
               Bottom = 118
               Right = 473
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OKFactStaff';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'OKFactStaff';

