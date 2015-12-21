
CREATE VIEW [dbo].[EmployeeEducation]
AS
SELECT   dbo.Employee.LastName Фамилия, dbo.Employee.FirstName Имя, dbo.Employee.Otch Отчество, 
dbo.EducationType.EduTypeName Вид_образования, dbo.OK_Educ.EducWhen Год, 
dbo.OK_Educ.EducWhere Место_образования, dbo.OK_Educ.Spec Специальность, dbo.OK_Educ.Kvalif Квалификация, 
dbo.EducDocumentType.DocTypeName Документ, 
 dbo.EducDocument.DocSeries Серия, dbo.EducDocument.DocNumber Номер, dbo.EducDocument.DocDate Дата_выдачи, 
 dbo.Organisation.Name Организация_выдавшая_документ
                             
                          
FROM dbo.Employee 
left JOIN dbo.OK_Educ ON dbo.Employee.id = dbo.OK_Educ.idEmployee
left JOIN dbo.EducDocument ON dbo.EducDocument.id = dbo.OK_Educ.idEducDocument
left join dbo.EducationType ON dbo.EducationType.id = dbo.OK_Educ.idEducationType
left join dbo.EducDocumentType ON dbo.EducDocument.idEducDocType = dbo.EducDocumentType.id                         
left JOIN dbo.Organisation ON dbo.EducDocument.IdOrganisation = dbo.Organisation.id
where dbo.Employee.id in (select idEmployee from [dbo].[GetFactStaffByPeriod](GetDate(),GetDate()))


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
         Begin Table = "EducationType"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 182
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EducDocument"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 285
               Right = 418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "EducDocumentType"
            Begin Extent = 
               Top = 6
               Left = 456
               Bottom = 136
               Right = 626
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Employee"
            Begin Extent = 
               Top = 6
               Left = 664
               Bottom = 245
               Right = 895
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "OK_Educ"
            Begin Extent = 
               Top = 6
               Left = 933
               Bottom = 235
               Right = 1151
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Organisation"
            Begin Extent = 
               Top = 153
               Left = 458
               Bottom = 295
               Right = 703
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
         Column ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeEducation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPane2', @value = N'= 1440
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
', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeEducation';


GO
EXECUTE sp_addextendedproperty @name = N'MS_DiagramPaneCount', @value = 2, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'VIEW', @level1name = N'EmployeeEducation';

