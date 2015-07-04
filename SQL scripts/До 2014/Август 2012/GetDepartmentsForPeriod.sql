USE [Kadr]
GO
/****** Object:  UserDefinedFunction [dbo].[GetAverageNumEmpl]    Script Date: 08/07/2012 09:42:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from [dbo].[GetDepartmentsForPeriod]('1.1.2011', '31.1.2012') 

--Возвращает отделы на период: т.е. отдел существует в периоде и выводится название этого периода
alter FUNCTION [dbo].[GetDepartmentsForPeriod] 
(
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
RETURNS @Result TABLE
   (
	idDepartment	INT,
	idManagerDepartment	INT,
	DepartmentName		VARCHAR(200),
	DepartmentSmallName		VARCHAR(50) 
   ) 
AS
BEGIN

	IF (@PeriodBegin>@PeriodEnd)
		RETURN
		
	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)


	INSERT INTO @Result
	SELECT DepartmentHistory.idDepartment, idManagerDepartment, DepartmentName, DepartmentSmallName
	FROM  
	dbo.Dep INNER JOIN
	dbo.DepartmentHistory as DepartmentHistory
	ON  Dep.id=DepartmentHistory.idDepartment
	INNER JOIN							
	(SELECT DepartmentHistory.id, MAX(DateBegin) as DateBegin
	FROM  dbo.DepartmentHistory as DepartmentHistory 
	GROUP BY DepartmentHistory.id) LastDepartmentHistory
	ON DepartmentHistory.id=LastDepartmentHistory.id AND DepartmentHistory.DateBegin=LastDepartmentHistory.DateBegin
	
	WHERE 
		((DepartmentHistory.DateBegin<=@PeriodBegin AND (Dep.dateExit>=@PeriodBegin OR Dep.dateExit IS NULL))
								OR (DepartmentHistory.DateBegin>=@PeriodBegin AND DepartmentHistory.DateBegin<=@PeriodEnd))
RETURN

END




GO


