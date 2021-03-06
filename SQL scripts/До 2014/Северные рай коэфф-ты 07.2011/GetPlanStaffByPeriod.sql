USE [Kadr]
GO
/****** Object:  UserDefinedFunction [dbo].[GetPlanStaffByPeriod]    Script Date: 07/01/2011 13:53:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select * from [dbo].[GetPlanStaffByPeriod]('1.02.2011','31.03.2011') where idDepartment=143
ALTER FUNCTION [dbo].[GetPlanStaffByPeriod] 
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
    idFinancingSource	INT,
	SeverKoeff			INT,
	RayonKoeff			INT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN
	SET @PeriodBegin=CONVERT(date,@PeriodBegin)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd)
	
	INSERT INTO @Result
	SELECT PlanStaff.id, StaffCount, idCategory, idDepartment, idPost, idFinancingSource,
		Department.SeverKoeff, Department.RayonKoeff 
	FROM  PlanStaffWithHistory as PlanStaff inner join dbo.Post
		ON PlanStaff.idPost=Post.id 
		INNER JOIN dbo.Department ON PlanStaff.idDepartment=Department.id 
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

