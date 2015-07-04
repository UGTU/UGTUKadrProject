update [dbo].[BonusHistory]
set [BonusCount]=[BonusCount]/7.5

update [dbo].[PKCategorySalary]
set [SalarySize]=[SalarySize]/6.2

update [dbo].[PlanStaffSalary]
set [SalarySize]=[SalarySize]/5.7

update [dbo].[Employee]
set [FirstName]=CONVERT(VARCHAR(3),[FirstName])

update [dbo].[Employee]
set [LastName]=CONVERT(VARCHAR(3),[LastName])

update [dbo].[Employee]
set [Otch]=CONVERT(VARCHAR(3),[Otch])

update [dbo].[Employee]
set [LastName]=CONVERT(VARCHAR(3),[Otch]), [FirstName]=[LastName]