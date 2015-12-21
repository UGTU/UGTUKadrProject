













/*select * from [FactStaffHourContract] 
Представление [FactStaffHourContract] - контрактники-почасовики */
CREATE VIEW [dbo].[FactStaffHourContract]
AS
SELECT    [id],[idPlanStaff],[idEmployee],[idEndPrikaz],[DateEnd],[IsReplacement],[PhoneNumber],[IDShedule],
[idFundingDepartment],[idTimeSheetSheduleType],[idFundingCenter],[idDepartment],[idFinancingSource],[Comment],
FactStaff.idOKVED
FROM            dbo.FactStaff
WHERE [idMainFactStaff] IS NOT NULL AND [idDepartment] IS NOT NULL














