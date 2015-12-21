
/*select * from [FactStaffHour] 
Представление [FactStaffHour] - контрактники-почасовики */
CREATE VIEW [dbo].[FactStaffHour]
AS
SELECT    [id],[idPlanStaff],[idEmployee],[idEndPrikaz],[DateEnd],[IsReplacement],[PhoneNumber],[IDShedule],
[idFundingDepartment],[idTimeSheetSheduleType],[idFundingCenter],[idDepartment],[idFinancingSource],[Comment],
FactStaff.idOKVED
FROM            dbo.FactStaff
WHERE [idPlanStaff] IS NULL AND [idDepartment] IS NOT NULL
