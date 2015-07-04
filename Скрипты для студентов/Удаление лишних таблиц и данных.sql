delete from dbo.BonusEmployee
delete from dbo.BonusFactStaff
delete from dbo.BonusPlanStaff
delete from dbo.BonusPost
delete from dbo.BonusHistory
delete from dbo.Bonus
delete from dbo.PlanStaffSalary
delete from dbo.PKCategorySalary
delete from dbo.BonusKoeffs
delete from dbo.BonusReportColumns
delete from dbo.BonusReport
delete from dbo.BonusType
delete from dbo.BonusSuperType
delete from dbo.BonusMeasure
delete from dbo.OKBufferEmployeeDegree
delete from dbo.OKBufferEmployeeRank
delete from dbo.OKBuffergeneral

go
update dbo.Employee
set FirstName=CONVERT(VARCHAR(1), FirstName)+LOWER(LastName),
LastName=CONVERT(VARCHAR(2), LastName)+LOWER(FirstName),
Otch=Otch