
CREATE VIEW [dbo].[OKPlanStaffWithSalaries]
AS
SELECT        idPlanStaff, SalarySize, IsIndividual
FROM            dbo.GetSalaryByPeriod(GETDATE() - 1, GETDATE() + 1) AS GetSalaryByPeriod_1

