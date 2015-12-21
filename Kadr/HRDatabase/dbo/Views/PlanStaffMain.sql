
--select * from [PlanStaffMain] where id = 172 order by DateBegin
--Представление со всеми параметрами PlanStaff (первоначальными DateBegin...) 
CREATE VIEW [dbo].[PlanStaffMain]
AS
--выбираем первоначальные изменения из истории
SELECT  PlanStaff.id, PlanStaffHistory.StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, PlanStaffHistory.idBeginPrikaz, 
	PlanStaff.idEndPrikaz, PlanStaffHistory.idFinancingSource, 
	CONVERT(date,PlanStaffHistory.DateBegin) DateBegin, CONVERT(date,PlanStaff.DateEnd) DateEnd,
	PlanStaffHistory.id idPlanStaffHistory 
FROM         
	dbo.PlanStaff INNER JOIN
	 dbo.PlanStaffHistory ON PlanStaff.id=PlanStaffHistory.idPlanStaff
		AND PlanStaffHistory.DateBegin = 
			(SELECT MIN(PlanStaffHistory.DateBegin) FROM dbo.PlanStaffHistory 
				WHERE PlanStaffHistory.idPlanStaff=PlanStaff.id)
	



