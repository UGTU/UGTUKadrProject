USE [Kadr]
GO

/****** Object:  View [dbo].[FactStaffMain]    Script Date: 26.08.2013 14:04:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






--select * from [FullPKCategory] 
--Представление PKCategory с полным названием категории 
CREATE VIEW [dbo].[FullPKCategory]
AS
--выбираем последние изменения - которые берем из PlanStaff
SELECT  [PKCategory].*,
	CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber)+' '+CONVERT(VARCHAR(3),PKSubCategoryNumber)+' '+
		ISNULL(CONVERT(VARCHAR(3),PKSubSubCategoryNumber),'') PKCategoryFullName,
	[PKGroup].GroupName, [PKGroup].GroupNumber
FROM         
	[dbo].[PKCategory] INNER JOIN
	[dbo].[PKGroup]
	ON [PKCategory].idPKGroup=[PKGroup].id
	








GO


