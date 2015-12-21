--select * from [dbo].[GetDegreesForEmployees]('1.01.2014','1.01.2014')
--возвращает последнюю научную степень для сотрудников
CREATE FUNCTION [dbo].[GetDegreesForEmployees] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS  TABLE
 
AS
RETURN
(SELECT [EmployeeDegree].[idEmployee], MAX([DegreeAbbrev]+' '+[ScienceTypeAbbrev]) DegreeName
	FROM  [dbo].[Degree] INNER JOIN
		[dbo].[EmployeeDegree] ON [Degree].[id]=[EmployeeDegree].[idDegree] INNER JOIN
		[dbo].[ScienceType] ON [EmployeeDegree].[idScienceType]=[ScienceType].id INNER JOIN
		(SELECT [EmployeeDegree].[idEmployee],MAX([DegreeOrder])[DegreeOrder]
			FROM [dbo].[Degree] INNER JOIN
			[dbo].[EmployeeDegree] ON [Degree].[id]=[EmployeeDegree].[idDegree]
			WHERE [degreeDate]<=@PeriodEnd OR [degreeDate] IS NULL
			GROUP BY [EmployeeDegree].[idEmployee])MaxDegree
		ON MaxDegree.[idEmployee]=[EmployeeDegree].[idEmployee] AND MaxDegree.[DegreeOrder]=[Degree].[DegreeOrder]
GROUP BY [EmployeeDegree].[idEmployee]
		)