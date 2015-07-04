USE [kadr]
GO

/****** Object:  View [dbo].[DepEmplCount]    Script Date: 09/16/2010 11:01:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--select * from [dbo].[GetPlanStaffByPeriod]('1.02.2011','31.03.2011') where idDepartment=143
alter FUNCTION [dbo].[GetPlanStaffByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idPlanStaff		INT,
    StaffCount	numeric(4,2),
    idCategory			INT,
    idDepartment		INT,
    idPost				INT,
    idFinancingSource	INT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN
	SET @PeriodBegin=CONVERT(date,@PeriodBegin) 
	SET @PeriodEnd=CONVERT(date,@PeriodEnd)
	
	INSERT INTO @Result
	SELECT PlanStaff.id, StaffCount, idCategory, idDepartment, idPost, idFinancingSource 
	FROM  PlanStaffWithHistory as PlanStaff inner join dbo.Post
		ON PlanStaff.idPost=Post.id 
	inner join
	(SELECT PlanStaff.id, MAX(PlanStaff.DateBegin) DateBegin
	FROM PlanStaffWithHistory as PlanStaff
	WHERE 
		((PlanStaff.DateBegin<=@PeriodBegin AND (PlanStaff.DateEnd>@PeriodBegin OR PlanStaff.DateEnd IS NULL))
								OR (PlanStaff.DateBegin>=@PeriodBegin AND PlanStaff.DateBegin<=@PeriodEnd))
	GROUP BY PlanStaff.id)LastPlanStaff
	ON PlanStaff.id=LastPlanStaff.id AND PlanStaff.DateBegin=LastPlanStaff.DateBegin
										  
RETURN
END

GO

--select * from [dbo].[GetFactStaffByPeriod]('20.01.2011','20.02.2011')where idPlanStaff=1066
alter FUNCTION [dbo].[GetFactStaffByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idFactStaff		INT,
    idPlanStaff			INT,
    idEmployee		INT,
    idTypeWork				INT,
    StaffCount	numeric(4,2),
    IsReplacement	BIT,
    DateBegin		DATETIME
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	INSERT INTO @Result
	SELECT FactStaff.id, idPlanStaff, idEmployee, idTypeWork, StaffCount, IsReplacement, LastFactStaff.DateBegin
	FROM  dbo.FactStaffWithHistory as FactStaff 
	INNER JOIN							
	(SELECT FactStaff.id, MAX(DateBegin) as DateBegin
	FROM  dbo.FactStaffWithHistory as FactStaff 
	WHERE 
		((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
								OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
	GROUP BY FactStaff.id) LastFactStaff
	ON FactStaff.id=LastFactStaff.id AND FactStaff.DateBegin=LastFactStaff.DateBegin		  
		  
RETURN
END

go
--select * from [dbo].[GetSalaryByPeriod]('31.03.2011','31.03.2011') where idPlanStaff=172
alter FUNCTION [dbo].[GetSalaryByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idPlanStaff		INT,
    SalarySize		money,
    IsIndividual	BIT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

	INSERT INTO @Result
	SELECT  DISTINCT   PlanStaff.id as idPlanStaff, ISNULL(dbo.PlanStaffSalary.SalarySize, PKCategorySalary.SalarySize) as SalarySize,
		CONVERT(BIT,PlanStaffSalary.idPlanStaff) 
	FROM         
		PlanStaffWithHistory as PlanStaff INNER JOIN
		 dbo.Post ON PlanStaff.idPost=Post.id	
			 INNER JOIN
		  dbo.PKCategory ON Post.idPKCategory = dbo.PKCategory.id INNER JOIN
		  dbo.PKCategorySalary ON dbo.PKCategory.id = dbo.PKCategorySalary.idPKCategory
		  AND ((PKCategorySalary.DateBegin<=@PeriodBegin AND (PKCategorySalary.DateEnd>=@PeriodBegin OR PKCategorySalary.DateEnd IS NULL))
				OR (PKCategorySalary.DateBegin>=@PeriodBegin AND PKCategorySalary.DateBegin<=@PeriodEnd))	
		LEFT JOIN
		  dbo.PlanStaffSalary ON PlanStaff.id = dbo.PlanStaffSalary.idPlanStaff 
			AND ((PlanStaffSalary.DateBegin<=@PeriodBegin AND (PlanStaffSalary.DateEnd>=@PeriodBegin OR PlanStaffSalary.DateEnd IS NULL))
					OR (PlanStaffSalary.DateBegin>=@PeriodBegin AND PlanStaffSalary.DateBegin<=@PeriodEnd))		  

RETURN
END



go
--select * from [dbo].[GetIndivSalaryByPeriod]('20.09.2010','20.09.2010')
ALTER FUNCTION [dbo].[GetIndivSalaryByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idSalary		INT,
    idPlanStaff		INT,
    SalarySize		money
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN


	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	INSERT INTO @Result
	SELECT PlanStaffSalary.id, idPlanStaff, SalarySize 
	FROM  dbo.PlanStaffSalary
		 
	WHERE 
		((PlanStaffSalary.DateBegin<=@PeriodBegin AND (PlanStaffSalary.DateEnd>=@PeriodBegin OR PlanStaffSalary.DateEnd IS NULL))
								OR (PlanStaffSalary.DateBegin>=@PeriodBegin AND PlanStaffSalary.DateBegin<=@PeriodEnd))		  
RETURN
END


GO

--select * from [dbo].[GetStaffByPeriod]('1.02.2011','15.03.2011') WHERE idDepartment=143 idPlanStaff=172
--select * from [GetStaffByPeriod]('19.09.2010','19.09.2010')
ALTER FUNCTION [dbo].[GetStaffByPeriod] 
(
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
RETURNS @Result TABLE
   (
		idDepartment INT,
		idPost		 INT,
		idPlanStaff  INT,
		idFactStaff  INT,
		idEmployee   INT,
		StaffCount	 NUMERIC(7,2),
		StaffCountWithoutReplacement NUMERIC(7,2),	--кол-во ставок без замещений
		idReplacementReason	INT,					--причина замещения
		IsMain			BIT,							--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		IsReplacement	BIT,
		idFinancingSource	INT,
		idTypeWork			INT
   
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

	--Указываем занятые ставки
	INSERT INTO @Result(idPost, idPlanStaff, idFactStaff, idEmployee, idDepartment, StaffCount, StaffCountWithoutReplacement, IsMain, IsReplacement, idFinancingSource, idTypeWork)
	SELECT idPost, PlanStaff.idPlanStaff, FactStaff.idFactStaff, idEmployee, idDepartment, FactStaff.StaffCount, FactStaff.StaffCount, WorkType.IsMain, WorkType.IsReplacement, PlanStaff.idFinancingSource, idTypeWork
	FROM [dbo].[GetPlanStaffByPeriod](@PeriodBegin, @PeriodEnd)  PlanStaff, [dbo].[GetFactStaffByPeriod](@PeriodBegin, @PeriodEnd) FactStaff, dbo.WorkType 
	WHERE PlanStaff.idPlanStaff=FactStaff.idPlanStaff
		AND FactStaff.idTypeWork=WorkType.id
			
	--отмечаем замещающих (обнуляем ставку)
	UPDATE @Result
	SET StaffCountWithoutReplacement = 0, idReplacementReason=FactStaffReplacement.idReplacementReason
	FROM @Result as res, dbo.FactStaffReplacement
	WHERE res.idFactStaff= FactStaffReplacement.idFactStaff
	
	UPDATE  @Result  
	SET IsMain=1
	FROM @Result as Result
	WHERE idEmployee NOT IN (SELECT idEmployee FROM @Result WHERE IsMain=1)
		AND idFactStaff=
		(SELECT MIN(idFactStaff) FROM @Result as res
			WHERE res.idEmployee=Result.idEmployee
				AND res.StaffCount=(SELECT MAX(StaffCount) FROM @Result as resl 
									WHERE resl.idEmployee=res.idEmployee))
				
	--заполняем вакансии	
	INSERT INTO @Result(idPost, idPlanStaff, idFactStaff, idEmployee, idDepartment, StaffCount, StaffCountWithoutReplacement, IsMain, idFinancingSource)
	SELECT PlanStaff.idPost, PlanStaff.idPlanStaff, null, null, PlanStaff.idDepartment, 
		PlanStaff.StaffCount-ISNULL(SUM(staff.StaffCountWithoutReplacement),0), 
		PlanStaff.StaffCount-ISNULL(SUM(staff.StaffCountWithoutReplacement),0), 0, 
		PlanStaff.idFinancingSource
	FROM [dbo].[GetPlanStaffByPeriod](@PeriodBegin, @PeriodEnd) as PlanStaff 
		 LEFT JOIN @Result staff ON PlanStaff.idPlanStaff=staff.idPlanStaff
		 
	GROUP BY PlanStaff.idPost, PlanStaff.idPlanStaff, PlanStaff.idDepartment, PlanStaff.StaffCount, PlanStaff.idFinancingSource
	HAVING PlanStaff.StaffCount-ISNULL(SUM(staff.StaffCountWithoutReplacement),0)>0
	
	--UPDATE @Result
	
 
		
RETURN
END











GO


--select * from [dbo].[GetBonusByPeriod]('08.08.2010','30.10.2010') 

alter FUNCTION [dbo].[GetBonusByPeriod] 
(
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
RETURNS @Result TABLE
   (
    idBonus	INT
    
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN
		
	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

	INSERT INTO @Result(idBonus)
	SELECT Bonus.id
	FROM dbo.Bonus	
	WHERE (CONVERT(date,Bonus.DateBegin)<=@PeriodBegin AND (CONVERT(date,Bonus.DateEnd)>=@PeriodBegin OR Bonus.DateEnd IS NULL))
		OR (CONVERT(date,Bonus.DateBegin)>=@PeriodBegin AND CONVERT(date,Bonus.DateBegin)<=@PeriodEnd)
		
 
		
RETURN
END

