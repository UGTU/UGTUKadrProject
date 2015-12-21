
--select * from [dbo].[GetDepartmentBonusWithEmployees](1, '09.1.2015','19.1.2015',1,1)where FundingCenterName IS NOT NULL
CREATE FUNCTION [dbo].[GetDepartmentBonusWithEmployees] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
@WithSubDeps BIT,
@idBonusReport		 INT
)
RETURNS TABLE


AS
RETURN
(SELECT ReportMainObjectName, EmployeeName, BonusLevel, BonusCount, idFactStaff, Employees.SeverKoeff, Employees.RayonKoeff,
			TypeWorkName, StaffCount, DepartmentName, PostName, Employees.idPlanStaff, NDFLKoeff, 
			BonusTypeName, BonusTypeFullName, idBonusType, FinancingSourceName, PKCategoryName,
			PeriodBegin, PeriodEnd, StaffCountWithoutReplacement, StaffCountReal, idReplacementReason, 
			HasEnvironmentBonus, GlobalPrikazName, GlobalPrikazFullName, 
			BonusSuperTypeName, CategoryName, idCategory, WorkSuperTypeName,
			DirectionManagerName, ReplacedEmployeeName, BonusOrderNumber, 
			PostFullName, DepartmentFullName,
			Employees.DateBegin,Employees.DateEnd,BonusSum,AllBonusSum,	
			ForVacancy,ForEmployee, MatOtpusk, HourCount, FinancingSourceFullName, PostComment, SalaryKoeff, PKCategoryFullName,
			CategoryOrderBy,FinancingSourceOrderBy, ManagerBit, PostTypeName, PostCode, Salary, HasIndivSalary,
			BonusFinancingSourceName, Employees.idEmployee, Employees.[idlaborcontrakt], EmployeeSmallName, 
			EmpRank.RankName, EmpDegree.DegreeName, CONVERT(VARCHAR(10),[Prikaz].[DateEnd],104) PrikazDateEnd,
			CalcStaffCount,CalcStaffCountWithoutReplacement, DepTreeIndex, FundingCenterName,
			[CategoryVPOName],[CategoryVPOOrderBy],[CategoryZPName],[CategoryZPOrderBy], [OKVEDName], NewCategoryName
	FROM  [dbo].[GetDepartmentBonusWithSettings](@idDepartment,@PeriodBegin,@PeriodEnd,@WithSubDeps,@idBonusReport, -1)Employees
	INNER JOIN dbo.Dep ON Employees.idDepartment = Dep.id
	LEFT JOIN dbo.FactStaff ON Employees.idFactStaff=FactStaff.id
	LEFT JOIN
		[dbo].[GetRankForEmployees](@PeriodBegin,@PeriodEnd) EmpRank ON Employees.[idEmployee]=EmpRank.[idEmployee]
	LEFT JOIN
		[dbo].[GetDegreesForEmployees](@PeriodBegin,@PeriodEnd) EmpDegree ON Employees.[idEmployee]=EmpDegree.[idEmployee]
	LEFT JOIN
		[dbo].[Prikaz] ON Employees.[idlaborcontrakt]=[Prikaz].id
	--LEFT JOIN dbo.FundingCenter ON FundingCenter.id=ISNULL(FactStaff.idFundingCenter,Dep.idFundingCenter)
)