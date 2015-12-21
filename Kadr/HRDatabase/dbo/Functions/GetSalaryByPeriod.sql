--select * from [dbo].[GetSalaryByPeriod]('15.01.2015','25.01.2015') where idPlanStaff=172
CREATE FUNCTION [dbo].[GetSalaryByPeriod] 
(
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME
)
RETURNS  TABLE

AS

RETURN	(SELECT  DISTINCT   PlanStaff.id as idPlanStaff, ISNULL(PlanStaffSalary.SalarySize, PKCategorySalary.SalarySize) as SalarySize,
		CONVERT(BIT,PlanStaffSalary.idPlanStaff) IsIndividual, PKCategory.idSalaryKoeff as idCatSalaryKoeff
	FROM         
		PlanStaffWithHistory as PlanStaff INNER JOIN
		 dbo.Post ON PlanStaff.idPost=Post.id	
			 INNER JOIN
		  dbo.PKCategory ON Post.idPKCategory = dbo.PKCategory.id INNER JOIN
		  dbo.PKCategorySalary ON dbo.PKCategory.id = dbo.PKCategorySalary.idPKCategory
		  --AND ((PKCategorySalary.DateBegin<=@PeriodBegin AND (PKCategorySalary.DateEnd>=@PeriodBegin OR PKCategorySalary.DateEnd IS NULL))
				--OR (PKCategorySalary.DateBegin>=@PeriodBegin AND PKCategorySalary.DateBegin<=@PeriodEnd))
				INNER JOIN
				 (SELECT idPKCategory, MAX(DateBegin) LastDateBegin
				  FROM dbo.PKCategorySalary 
				  WHERE ((PKCategorySalary.DateBegin<=@PeriodBegin AND (PKCategorySalary.DateEnd>=@PeriodBegin OR PKCategorySalary.DateEnd IS NULL))
						OR (PKCategorySalary.DateBegin>=@PeriodBegin AND PKCategorySalary.DateBegin<=@PeriodEnd))
				  GROUP BY idPKCategory)LastCategorySalary	
				 ON PKCategorySalary.idPKCategory=LastCategorySalary.idPKCategory 
					AND PKCategorySalary.DateBegin=LastCategorySalary.LastDateBegin
		LEFT JOIN
		  (SELECT PlanStaffSalary.idPlanStaff, SalarySize, DateEnd FROM 
			  dbo.PlanStaffSalary INNER JOIN 
				(SELECT idPlanStaff, MAX(DateBegin) LastDateBegin FROM dbo.PlanStaffSalary 
					WHERE ((PlanStaffSalary.DateBegin<=@PeriodBegin AND (PlanStaffSalary.DateEnd>=@PeriodBegin OR PlanStaffSalary.DateEnd IS NULL))
						OR (PlanStaffSalary.DateBegin>=@PeriodBegin AND PlanStaffSalary.DateBegin<=@PeriodEnd))
				 GROUP BY idPlanStaff)LastPlanStaffSalary
				ON PlanStaffSalary.idPlanStaff=LastPlanStaffSalary.idPlanStaff 
					AND PlanStaffSalary.DateBegin=LastPlanStaffSalary.LastDateBegin)PlanStaffSalary 
			ON PlanStaff.id = PlanStaffSalary.idPlanStaff 
				AND (PlanStaffSalary.DateEnd IS NULL OR PlanStaffSalary.DateEnd>=@PeriodEnd OR PlanStaffSalary.DateEnd>=PKCategorySalary.DateEnd))	  






