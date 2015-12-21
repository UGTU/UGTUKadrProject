CREATE FUNCTION [ShemaTabel].[GetFactStaffForTimeSheet] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idFactStaff		INT NOT NULL,
    StaffCount	numeric(4,2) NOT NULL,
    idDepartment	INT NOT NULL,
    IsReplacement	BIT NOT NULL,
	idTypeWork		INT,
	idPost		 INT,
	idPlanStaff  INT,
	idEmployee   INT,
	isMain		BIT,
	DateBegin	DATETIME,
	DateEnd		DATETIME,
	idSheduler	INT,
	SexBit bit,
	idCategory int
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	INSERT INTO @Result
	SELECT DISTINCT FactStaff.id, FactStaff.StaffCount, idDepartment,WorkType.IsReplacement, WorkType.id, idPost,
	idPlanStaff, idEmployee, 0, ISNULL(FactStaff.DateBegin, @PeriodBegin), 
	ISNULL(FactStaff.DateEnd,@PeriodEnd), FactStaff.IDShedule,SexBit, idCategory=Post.idCategory
	FROM  dbo.FactStaffWithHistory as FactStaff, PlanStaff, dbo.WorkType,dbo.Employee,dbo.Post
	WHERE
		((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
								OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
		AND FactStaff.idPlanStaff=PlanStaff.id
		AND FactStaff.idTypeWork=WorkType.id
		and idEmployee=dbo.Employee.id
		and PlanStaff.idPost = Post.id
		  
RETURN
END
