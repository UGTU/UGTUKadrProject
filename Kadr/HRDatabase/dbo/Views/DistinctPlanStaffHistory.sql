
/*
select  idPlanStaff, DateBegin
from DistinctPlanStaffHistory
GROUP BY idPlanStaff, DateBegin
HAVING COUNT(*)>1
*/
--Представление с изменениями PlanStaff, в котором только уникальные даты (из-за исключ. ситуаций, 
--когда в один и тот же день выпущено несколько изменений)
CREATE VIEW [dbo].[DistinctPlanStaffHistory]
AS
SELECT  PlanStaffHistory.*
FROM	
	(SELECT idPlanStaff, DateBegin, MAX(id) id
		FROM dbo.PlanStaffHistory
		GROUP BY idPlanStaff, DateBegin) DistinctPlanStaffHistory
	INNER JOIN
	 dbo.PlanStaffHistory
		ON DistinctPlanStaffHistory.id=PlanStaffHistory.id
		--AND DistinctBonusHistory.idBonus=BonusHistory.idBonus
		--AND DistinctBonusHistory.DateBegin=BonusHistory.DateBegin


