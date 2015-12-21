
CREATE VIEW [dbo].[OK_vWorkType]
AS
SELECT     dbo.WorkType.id, dbo.WorkType.TypeWorkName, dbo.WorkType.TypeWorkShortName, dbo.WorkType.idWorkSuperType, 
                      dbo.WorkSuperType.WorkSuperTypeName
FROM         dbo.WorkType INNER JOIN
                      dbo.WorkSuperType ON dbo.WorkType.idWorkSuperType = dbo.WorkSuperType.id					  