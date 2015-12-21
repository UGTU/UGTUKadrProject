

--select * from [GetAllSalaryByPeriod]('01.01.2013', '01.01.2016') order by idPlanStaff
CREATE FUNCTION [dbo].[GetAllSalaryByPeriod] 
(
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
RETURNS  TABLE

AS

RETURN	(SELECT  DISTINCT   PlanStaff.id as idPlanStaff, ISNULL(PlanStaffSalary.SalarySize, PKCategorySalary.SalarySize) as SalarySize,
		CONVERT(BIT,PlanStaffSalary.idPlanStaff) IsIndividual, PKCategory.idSalaryKoeff as idCatSalaryKoeff, 
		ISNULL(PlanStaffSalary.DateBegin, PKCategorySalary.DateBegin) DateBegin, 
		ISNULL(PlanStaffSalary.DateEnd, PKCategorySalary.DateEnd) DateEnd
	FROM         
		PlanStaffWithHistory as PlanStaff INNER JOIN
		 dbo.Post ON PlanStaff.idPost=Post.id	
			 INNER JOIN
		  dbo.PKCategory ON Post.idPKCategory = dbo.PKCategory.id INNER JOIN
		  (SELECT * FROM dbo.PKCategorySalary 
				  WHERE ((PKCategorySalary.DateBegin<=@PeriodBegin AND (PKCategorySalary.DateEnd>=@PeriodBegin OR PKCategorySalary.DateEnd IS NULL))
						OR (PKCategorySalary.DateBegin>=@PeriodBegin AND PKCategorySalary.DateBegin<=@PeriodEnd)))PKCategorySalary	
				ON dbo.PKCategory.id = PKCategorySalary.idPKCategory
		LEFT JOIN
		  (SELECT * FROM 
			  dbo.PlanStaffSalary 
					WHERE ((PlanStaffSalary.DateBegin<=@PeriodBegin AND (PlanStaffSalary.DateEnd>=@PeriodBegin OR PlanStaffSalary.DateEnd IS NULL))
						OR (PlanStaffSalary.DateBegin>=@PeriodBegin AND PlanStaffSalary.DateBegin<=@PeriodEnd)))PlanStaffSalary
			ON PlanStaff.id = PlanStaffSalary.idPlanStaff)	  