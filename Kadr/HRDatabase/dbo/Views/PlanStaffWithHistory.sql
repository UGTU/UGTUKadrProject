




--select * from [PlanStaffWithHistory] where id = 172 order by DateBegin
--Представление со всей историей штатного расписания
CREATE VIEW [dbo].[PlanStaffWithHistory]
AS

SELECT  PlanStaff.id, DistinctPlanStaffHistory.StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, DistinctPlanStaffHistory.idBeginPrikaz, 
	ISNULL(NextDistinctPlanStaffHistory.idBeginPrikaz, PlanStaff.idEndPrikaz) idEndPrikaz, 
	DistinctPlanStaffHistory.idFinancingSource, 
	DistinctPlanStaffHistory.DateBegin, 
	ISNULL(NextDistinctPlanStaffHistory.DateBegin, PlanStaff.DateEnd) DateEnd ,
	DistinctPlanStaffHistory.id idPlanStaffHistory
FROM 
	dbo.PlanStaff
	INNER JOIN 
	/*(SELECT idPlanStaff, DateBegin, MAX(id) id
		FROM dbo.PlanStaffHistory
		GROUP BY idPlanStaff, DateBegin) DistPlanStaffHistory
	ON PlanStaff.id=DistPlanStaffHistory.idPlanStaff
	INNER JOIN*/
	 /*(SELECT  PlanStaffHistory.*
		FROM	
			(SELECT idPlanStaff, DateBegin, MAX(id) id
				FROM dbo.PlanStaffHistory
				GROUP BY idPlanStaff, DateBegin) DistinctPlanStaffHistory
			INNER JOIN
			 dbo.PlanStaffHistory
				ON DistinctPlanStaffHistory.id=PlanStaffHistory.id
)*/dbo.PlanStaffHistory DistinctPlanStaffHistory
		ON DistinctPlanStaffHistory.idPlanStaff=PlanStaff.id
	 LEFT JOIN	--выбираем ближайшее следующее изменение
	 dbo.PlanStaffHistory NextDistinctPlanStaffHistory ON PlanStaff.id=NextDistinctPlanStaffHistory.idPlanStaff
			AND CONVERT(date, NextDistinctPlanStaffHistory.DateBegin) =
				(SELECT CONVERT(date, MIN(history.DateBegin)) FROM dbo.PlanStaffHistory history 
					WHERE DistinctPlanStaffHistory.idPlanStaff=history.idPlanStaff 
						AND history.DateBegin>DistinctPlanStaffHistory.DateBegin)







