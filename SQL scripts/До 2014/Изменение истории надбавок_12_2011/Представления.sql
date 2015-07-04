USE [Kadr]
GO

/****** Object:  View [dbo].[FactStaffWithHistory]    Script Date: 12/06/2011 14:09:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

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






GO


--select * from [BonusWithHistory] where id = 10554 
--История надбавок
alter VIEW [dbo].[BonusWithHistory]
AS
SELECT  Bonus.id, DistinctBonusHistory.BonusCount, DistinctBonusHistory.DateBegin, 
	ISNULL(NextDistinctBonusHistory.DateBegin-1, Bonus.DateEnd) DateEnd, Bonus.idBonusType, 
	DistinctBonusHistory.idBeginPrikaz idPrikaz, 
	ISNULL(NextDistinctBonusHistory.idBeginPrikaz, Bonus.idEndPrikaz) idEndPrikaz, Bonus.Comment
FROM dbo.Bonus        
	 INNER JOIN
	(SELECT idBonus, DateBegin, MAX(id) id
		FROM dbo.BonusHistory
		GROUP BY idBonus, DateBegin) DistBonusHistory
	ON Bonus.id=DistBonusHistory.idBonus
	INNER JOIN
	 dbo.BonusHistory DistinctBonusHistory
		ON DistinctBonusHistory.id=DistBonusHistory.id
	 LEFT JOIN	--выбираем ближайшее следующее изменение
	 dbo.BonusHistory NextDistinctBonusHistory ON Bonus.id=NextDistinctBonusHistory.idBonus
			AND CONVERT(date, NextDistinctBonusHistory.DateBegin) =
				(SELECT CONVERT(date, MIN(history.DateBegin)) FROM dbo.BonusHistory history 
					WHERE DistinctBonusHistory.idBonus=history.idBonus AND history.DateBegin>DistinctBonusHistory.DateBegin)
