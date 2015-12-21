
--SELECT * FROM [dbo].[GetFullPKCategory](GETDATE(),GETDATE())
CREATE FUNCTION [dbo].[GetFullPKCategory] 
(
@PeriodBegin	DATETIME,
@PeriodEnd		DATETIME
)
RETURNS  TABLE

AS
RETURN
(
	--INSERT INTO @Result([id],[idPKGroup],[PKCategoryNumber],[PKSubCategoryNumber],[PKSubSubCategoryNumber],
		--[PKComment],[PKCategoryFullName],[GroupName],[GroupNumber], idCatSalaryKoeff)
	SELECT [id],[idPKGroup],[PKCategoryNumber],[PKSubCategoryNumber],IIF(@PeriodBegin<'01.09.2013','', ISNULL(CONVERT(VARCHAR(3),[PKSubSubCategoryNumber]),'')) [PKSubSubCategoryNumber],
		[PKComment],[PKCategoryPrevName] [PKCategoryFullName],[GroupName],[GroupNumber], idSalaryKoeff
	FROM [dbo].[FullPKCategory]
)