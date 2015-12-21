






/*select * from [FactStaffWithHistory] where id = 172 order by DateBegin
Представление со всей историей распределения штатов*/
CREATE VIEW [ShemaTabel].[FactStaffWithHistory]
AS
SELECT        [FactStaffWithHistory].id, [FactStaffWithHistory].StaffCount, [FactStaffWithHistory].HourCount, [FactStaffWithHistory].HourSalary,
			[FactStaffWithHistory].idPlanStaff, [FactStaffWithHistory].idEmployee, [FactStaffWithHistory].idBeginPrikaz, 
                [FactStaffWithHistory].idEndPrikaz, [FactStaffWithHistory].idTypeWork, 
                [FactStaffWithHistory].DateBegin, [FactStaffWithHistory].DateEnd, [FactStaffWithHistory].IsReplacement, 
                [FactStaffWithHistory].id AS idFactStaffHistory, [FactStaffWithHistory].IDShedule,
		[FactStaffWithHistory].idSalaryKoeff, [FactStaffWithHistory].[idlaborcontrakt], [FactStaffWithHistory].[idreason],
		[FactStaffWithHistory].[HourStaffCount],[FactStaffWithHistory].[CalcStaffCount],
		IdWorkShedule
FROM            dbo.[FactStaffWithHistory] [FactStaffWithHistory] INNER JOIN
			dbo.PlanStaff ON [FactStaffWithHistory].idPlanStaff=PlanStaff.id




