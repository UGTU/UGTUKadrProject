

--select * from [dbo].[GetPPSDepartmentBonus](1, '02.9.2014','15.09.2014',1) where PostName like '%кафедрой%' order by PostName
CREATE FUNCTION [dbo].[GetPPSDepartmentBonus] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
@WithSubDeps BIT
)
RETURNS TABLE

AS
RETURN
(
	SELECT ReportMainObjectName, PKCategoryName, EmployeeName, BonusSum, SeverKoeff, RayonKoeff,
			StaffCount, DepartmentName, PostName, NDFLKoeff, 
			BonusTypeName, idBonusType, FinancingSourceName, idReplacementReason,
			PeriodBegin, PeriodEnd, StaffCountWithoutReplacement,  
			BonusSuperTypeName,
			'' DegreeName, 2 DegreeOrder, Salary
	FROM dbo.GetDepartmentBonusWithSettings(@idDepartment, @PeriodBegin, @PeriodEnd, @WithSubDeps, 5, -1) as DepBonus INNER JOIN
		dbo.Category ON DepBonus.idCategory=Category.id
		--LEFT JOIN dbo.Degree ON Degree.DegreeOrder=(SELECT ISNULL(MAX(DegreeOrder),0) FROM dbo.Degree, dbo.EmployeeDegree,dbo.FactStaff
		--WHERE Degree.id=EmployeeDegree.idDegree 
		--	AND EmployeeDegree.idEmployee=FactStaff.idEmployee AND DepBonus.idFactStaff=FactStaff.id)
	WHERE 
	Category.IsPPS=1
)







