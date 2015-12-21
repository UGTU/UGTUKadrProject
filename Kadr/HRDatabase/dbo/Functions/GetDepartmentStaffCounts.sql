
--select * from [dbo].GetDepartmentStaffCounts(1, '20.01.2015', '21.01.2015') 
--select * from [dbo].GetDepartmentStaffCounts(300, '20.01.2011', '20.01.2011')
--select * from [dbo].GetDepartmentStaffCounts(7, '1.03.2011', '31.03.2011')
CREATE FUNCTION [dbo].[GetDepartmentStaffCounts] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS  TABLE

AS
RETURN
(
	SELECT 	
		PKCategory.PKCategoryFullName+' '+ISNULL(CONVERT(VARCHAR(3),SalaryKoeff.PKSubSubCategoryNumber),PKCategory.PKSubSubCategoryNumber) PKCatName,
		ISNULL(SUM(PlanStaff.StaffCount),0) as planStaffCount, ISNULL(SUM(FactStaffCount.factCount),0) as factStaffCount,
		ISNULL(SubDepsStaffCount.planStaffCount,0) AS subPlanStaffCount,
		ISNULL(SubDepsStaffCount.factStaffCount,0) AS subFactStaffCount

FROM  --dbo.Department CROSS JOIN      
			dbo.[GetFullPKCategory](@PeriodBegin,@PeriodEnd) PKCategory LEFT JOIN
             dbo.Post ON dbo.Post.idPKCategory = PKCategory.id LEFT JOIN
             (SELECT * FROM [dbo].[GetPlanStaffByPeriod](@PeriodBegin, @PeriodEnd) as PlanStaff 
				WHERE idDepartment=@idDepartment)PlanStaff 
				ON PlanStaff.idPost = dbo.Post.id --AND PlanStaff.idDepartment=Department.id 
             LEFT JOIN
			 (SELECT FactStaff.idPlanStaff, idSalaryKoeff, SUM(FactStaff.StaffCount) as factCount 
				FROM [dbo].[GetFactStaffByPeriod](@PeriodBegin, @PeriodEnd) as FactStaff 
				WHERE FactStaff.idFactStaff NOT IN (SELECT idFactStaff FROM dbo.FactStaffReplacement)
					GROUP BY FactStaff.idPlanStaff, idSalaryKoeff)FactStaffCount
				ON PlanStaff.idPlanStaff = FactStaffCount.idPlanStaff 
		
			LEFT JOIN
			[dbo].GetSubDepartmentStaffCounts(@idDepartment, @PeriodBegin, @PeriodEnd) SubDepsStaffCount
			ON SubDepsStaffCount.idPKCategory=PKCategory.id
			LEFT JOIN [dbo].[SalaryKoeff] ON FactStaffCount.idSalaryKoeff=[SalaryKoeff].id
GROUP BY PKCategory.PKCategoryFullName,SalaryKoeff.PKSubSubCategoryNumber,
	SubDepsStaffCount.planStaffCount, SubDepsStaffCount.factStaffCount, PKCategory.PKSubSubCategoryNumber
)

