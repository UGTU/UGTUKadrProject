--select * from [dbo].[GetRecruitedFactStaffByPeriod]('20.08.2013','20.09.2013')where idPlanStaff=1066
CREATE FUNCTION [dbo].[GetRecruitedFactStaffByPeriod] 
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
    DateBegin		DATETIME,
    idBeginPrikaz	INT,
	idSalaryKoeff INT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	INSERT INTO @Result
	SELECT FactStaff.id, idPlanStaff, idEmployee, idTypeWork, StaffCount, IsReplacement, LastFactStaff.DateBegin, FactStaff.idBeginPrikaz, idSalaryKoeff
	FROM  dbo.FactStaffWithHistory as FactStaff 
	INNER JOIN							
	(SELECT FactStaff.id, MIN(DateBegin) as DateBegin
	FROM  dbo.FactStaffWithHistory as FactStaff 
	WHERE 
		((FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
	GROUP BY FactStaff.id) LastFactStaff
	ON FactStaff.id=LastFactStaff.id AND FactStaff.DateBegin=LastFactStaff.DateBegin		  
		  
RETURN
END





