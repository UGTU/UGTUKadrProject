


/*
select  
from DistinctFactStaffHistory
GROUP BY idFactStaff, DateBegin
HAVING COUNT(*)>1
*/
--Представление с изменениями FactStaff, в котором только уникальные даты (из-за исключ. ситуаций, 
--когда в один и тот же день выпущено несколько изменений)
CREATE VIEW [dbo].[DistinctFactStaffHistory]
AS
SELECT  FactStaffHistory.*
FROM	
	(SELECT idFactStaff, DateBegin, MAX(id) id
		FROM dbo.FactStaffHistory
		GROUP BY idFactStaff, DateBegin) DistinctFactStaffHistory
	INNER JOIN
	 dbo.FactStaffHistory
		ON DistinctFactStaffHistory.id=FactStaffHistory.id
		--AND DistinctBonusHistory.idBonus=BonusHistory.idBonus
		--AND DistinctBonusHistory.DateBegin=BonusHistory.DateBegin








