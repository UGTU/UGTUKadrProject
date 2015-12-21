--select * from [dbo].[GetRankForEmployees]('1.01.2014','1.01.2014')
--возвращает последнее ученое звание для сотрудников
CREATE FUNCTION [dbo].[GetRankForEmployees] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS  TABLE
 
AS
RETURN
(SELECT [EmployeeRank].[idEmployee], MAX(RankName)RankName
	FROM  [dbo].[Rank] INNER JOIN
		[dbo].[EmployeeRank] ON [Rank].[id]=[EmployeeRank].[idRank] INNER JOIN
		(SELECT [EmployeeRank].[idEmployee],MAX([RankOrder])[RankOrder]
			FROM [dbo].[Rank] INNER JOIN
			[dbo].[EmployeeRank] ON [Rank].[id]=[EmployeeRank].[idRank]
			GROUP BY [EmployeeRank].[idEmployee])MaxRank
		ON MaxRank.[idEmployee]=[EmployeeRank].[idEmployee] AND MaxRank.[RankOrder]=[Rank].[RankOrder]
GROUP BY [EmployeeRank].[idEmployee]
		)