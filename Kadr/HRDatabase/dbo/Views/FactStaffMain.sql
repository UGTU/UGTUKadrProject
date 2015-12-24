﻿

/*select * from [FactStaffMain] where id = 172 order by DateBegin
Представление со всеми параметрами FactStaff (первоначальными DateBegin...) */
CREATE VIEW [dbo].[FactStaffMain]
AS
SELECT        dbo.FactStaff.id, dbo.FactStaffHistory.StaffCount, dbo.FactStaffHistory.HourCount, dbo.FactStaffHistory.HourSalary, dbo.FactStaff.idPlanStaff, 
                         dbo.FactStaff.idEmployee, dbo.FactStaffHistory.idBeginPrikaz, dbo.FactStaff.idEndPrikaz, dbo.FactStaffHistory.idTypeWork, CONVERT(date, 
                         dbo.FactStaffHistory.DateBegin) AS DateBegin, CONVERT(date, dbo.FactStaff.DateEnd) AS DateEnd, dbo.FactStaff.IsReplacement, 
                         dbo.FactStaff.idTimeSheetSheduleType, dbo.FactStaffHistory.id AS idFactStaffHistory, dbo.FactStaffHistory.idSalaryKoeff, dbo.FactStaff.idlaborcontrakt, 
                         dbo.FactStaff.idreason, dbo.FactStaffHistory.HourStaffCount, dbo.FactStaffHistory.CalcStaffCount, dbo.FactStaffHistory.DateBegin AS DateBeginR, 
                         dbo.FactStaff.DateEnd AS DateEndR, dbo.FactStaffHistory.idlaborcontrakt AS FactStaffHistoryidlaborcontrakt,
						 FactStaff.idOKVED, FactStaff.[idFundingCenter]
FROM            dbo.FactStaff INNER JOIN
                         dbo.FactStaffHistory ON dbo.FactStaff.id = dbo.FactStaffHistory.idFactStaff AND dbo.FactStaffHistory.DateBegin =
                             (SELECT        MIN(DateBegin) AS Expr1
                               FROM            dbo.FactStaffHistory
                               WHERE        (idFactStaff = dbo.FactStaff.id))



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
         Begin Table = "FactStaffHistory"
            Begin Extent = 
               Top = 6
               Left = 299
               Bottom = 135
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FactStaffMain';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 1, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'FactStaffMain';
