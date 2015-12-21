
--Представление используемое в интерфейсе для вывода должностей (и отчетах тоже)
CREATE VIEW [dbo].[UIViewPost]
AS
SELECT     
	Post.*, GlobalPrikaz.PrikazName, PKCategory.PKCategoryNumber, PKGroup.GroupNumber,
	PKGroup.GroupNumber+' - '+PKCategory.PKCategoryNumber as PKGName, Category.CategorySmallName
FROM      
dbo.Post INNER JOIN dbo.GlobalPrikaz ON Post.idGlobalPrikaz=GlobalPrikaz.id
INNER JOIN dbo.PKCategory ON Post.idPKCategory=PKCategory.id
INNER JOIN dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id
LEFT JOIN dbo.Category ON Post.idCategory=Category.id


