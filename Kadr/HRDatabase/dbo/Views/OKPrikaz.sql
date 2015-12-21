
CREATE VIEW [dbo].[OKPrikaz]
AS
SELECT        dbo.Prikaz.id, dbo.Prikaz.PrikazName, dbo.Prikaz.DatePrikaz, dbo.Prikaz.idPrikazType, dbo.Prikaz.DateBegin, dbo.Prikaz.DateEnd, dbo.Prikaz.resume, 
                         dbo.PrikazType.PrikazTypeName, dbo.PrikazSuperType.PrikazSuperTypeName
FROM            dbo.Prikaz INNER JOIN
                         dbo.PrikazType ON dbo.Prikaz.idPrikazType = dbo.PrikazType.id INNER JOIN
                         dbo.PrikazSuperType ON dbo.PrikazType.idPrikazSuperType = dbo.PrikazSuperType.id

