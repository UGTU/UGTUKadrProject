
CREATE VIEW [dbo].[OK_vFactStaffHistoryNew]
AS
SELECT     dbo.FactStaffHistory.id, dbo.FactStaffHistory.idFactStaff, dbo.FactStaffHistory.idBeginPrikaz, dbo.FactStaffHistory.DateBegin, dbo.FactStaffHistory.StaffCount, 
                      dbo.FactStaffHistory.idTypeWork, dbo.FactStaffHistory.idlaborcontrakt, dbo.WorkType.TypeWorkShortName, dbo.Prikaz.PrikazName AS BeginPrikazName, 
                      Prikaz_1.PrikazName AS LaborContraktName
FROM         dbo.FactStaffHistory INNER JOIN
                      dbo.WorkType ON dbo.FactStaffHistory.idTypeWork = dbo.WorkType.id LEFT OUTER JOIN
                      dbo.Prikaz AS Prikaz_1 ON dbo.FactStaffHistory.idlaborcontrakt = Prikaz_1.id LEFT OUTER JOIN
                      dbo.Prikaz ON dbo.FactStaffHistory.idBeginPrikaz = dbo.Prikaz.id

