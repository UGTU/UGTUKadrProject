









--select * from [FullPKCategory] 
--Представление PKCategory с полным названием категории 
CREATE VIEW [dbo].[FullPKCategory]
AS
--выбираем последние изменения - которые берем из PlanStaff
SELECT  [PKCategory].[id]
      ,[idPKGroup]
      ,[PKCategoryNumber]
      ,[PKSubCategoryNumber]
      ,[PKComment]
      ,[PKSubSubCategoryNumber]
      ,[idSalaryKoeff],
	CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber)+' '+CONVERT(VARCHAR(3),PKSubCategoryNumber)+' '+
		ISNULL(CONVERT(VARCHAR(3),PKSubSubCategoryNumber),'') PKCategoryFullName,
	CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber)+' '+CONVERT(VARCHAR(3),PKSubCategoryNumber) PKCategoryPrevName,
	[PKGroup].GroupName , [PKGroup].GroupNumber
FROM         
	[dbo].[PKCategory] INNER JOIN
	[dbo].[PKGroup]
	ON [PKCategory].idPKGroup=[PKGroup].id
	












