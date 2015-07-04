--вид надбавки размер, даты, и для кого для сотрудников, для должности



select 
ReportMainObjectName, FinancingSourceName, BonusTypeName, PostName, EmployeeName, StaffCount, Salary,
BonusLevel, AllBonusSum, DateBegin, DateEnd
 from [dbo].[GetDepartmentBonusWithEmployees](39, GETDATE(),GETDATE(),1,1)
where idBonusType IS NOT NULL 
ORDER BY ReportMainObjectName, PostName, EmployeeName, BonusTypeName
