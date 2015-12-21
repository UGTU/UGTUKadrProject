


CREATE VIEW [dbo].[pkCategorySalaryView]
AS
SELECT distinct    
	pkCategory.*,
	PKCategorySalary.SalarySize,
	DateBegin, DateEnd
FROM dbo.pkCategory,  dbo.PKCategorySalary 
where  pkCategory.id= PKCategorySalary.idPKCategory 
and   (DateEnd is null or DateEnd>GETDATE())



