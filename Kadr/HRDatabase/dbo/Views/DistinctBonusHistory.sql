
/*
select idBonus, DateBegin, COUNT(*) 
from DistinctBonusHistory
GROUP BY idBonus, DateBegin
HAVING COUNT(*)>1
*/
--Представление с изменениями надбавок, в котором только уникальные даты (из-за исключ. ситуаций, 
--когда в один и тот же день выпущено несколько изменений)
CREATE VIEW DistinctBonusHistory
AS
SELECT  BonusHistory.*
FROM	
	(SELECT idBonus, DateBegin, MAX(id) id
		FROM dbo.BonusHistory
		GROUP BY idBonus, DateBegin) DistinctBonusHistory
	INNER JOIN
	 dbo.BonusHistory
		ON DistinctBonusHistory.id=BonusHistory.id
		--AND DistinctBonusHistory.idBonus=BonusHistory.idBonus
		--AND DistinctBonusHistory.DateBegin=BonusHistory.DateBegin






