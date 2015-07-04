
--вытаскиваем вакансии
SELECT Department.DepartmentName, Post.PostName, Vacations.StaffCountWithoutReplacement,
	Employee.EmployeeName,FactStaffCurrent.StaffCount,
	FactStaffCurrent.DateEnd, PlanStaffsWithSalaries.SalarySize, ISNULL(Bonus.BonusSum,0)
	 FROM

(select * from [dbo].[GetStaffByPeriod]('1.10.2013','30.10.2013') 
	WHERE idFactStaff is NULL)Vacations
INNER JOIN
(select [idPlanStaff], MAX([DateEnd]) DateEnd 
from [FactStaffCurrent]
GROUP BY [idPlanStaff])MaxFactStaff
ON Vacations.[idPlanStaff]=MaxFactStaff.[idPlanStaff]
INNER JOIN
[FactStaffCurrent]
ON [FactStaffCurrent].[idPlanStaff]=MaxFactStaff.[idPlanStaff]
AND [FactStaffCurrent].DateEnd=MaxFactStaff.DateEnd
INNER JOIN [dbo].[Department] ON [Department].id=Vacations.idDepartment
INNER JOIN Post ON Post.id=Vacations.idPost
INNER JOIN Employee ON Employee.id=FactStaffCurrent.idEmployee
LEFT JOIN [dbo].[GetSalaryByPeriod]('1.10.2013','30.10.2013') PlanStaffsWithSalaries
		ON  Vacations.idPlanStaff=PlanStaffsWithSalaries.idPlanStaff
LEFT JOIN (SELECT idFactStaff, MAX(BonusSum) BonusSum FROM [dbo].[GetBonusByBonusType](3, '01.09.2011','30.09.2013') bon
	GROUP BY idFactStaff)Bonus
	ON [FactStaffCurrent].[id]=Bonus.idFactStaff

