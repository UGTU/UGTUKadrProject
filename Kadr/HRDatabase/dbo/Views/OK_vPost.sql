
CREATE VIEW [dbo].[OK_vPost]
AS
SELECT     dbo.Post.id, dbo.Post.PostName, dbo.Post.PostShortName, dbo.Post.idCategory, dbo.Category.CategorySmallName, dbo.Post.idPKCategory, 
                      dbo.PKCategory.idPKGroup, dbo.PKCategory.PKCategoryNumber, dbo.PKGroup.GroupNumber, dbo.PKGroup.GroupName
FROM         dbo.Post INNER JOIN
                      dbo.PKCategory ON dbo.Post.idPKCategory = dbo.PKCategory.id INNER JOIN
                      dbo.Category ON dbo.Post.idCategory = dbo.Category.id INNER JOIN
                      dbo.PKGroup ON dbo.PKCategory.idPKGroup = dbo.PKGroup.id

