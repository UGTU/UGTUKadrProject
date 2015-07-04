
update dbo.FactStaffHistory
set StaffCount=[dbo].[GetStaffCountForHour] 
(FactStaff.idPlanStaff,
FactStaffHistory.HourCount
)
FROM
dbo.FactStaffHistory inner join dbo.FactStaff
on FactStaffHistory.idFactStaff=FactStaff.id
where FactStaffHistory.HourCount is not null

