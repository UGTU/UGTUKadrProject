
CREATE VIEW [dbo].[OK_vFactStaffDateBegin]
AS
SELECT     dbo.FactStaff.id AS idFactStaff, dbo.FactStaffHistory.DateBegin, dbo.FactStaffHistory.id AS idFactStaffHistory
FROM         dbo.FactStaff INNER JOIN
                      dbo.FactStaffHistory ON dbo.FactStaff.id = dbo.FactStaffHistory.idFactStaff AND dbo.FactStaffHistory.DateBegin =
                          (SELECT     MIN(DateBegin) AS Expr1
                            FROM          dbo.FactStaffHistory
                            WHERE      (idFactStaff = dbo.FactStaff.id))

