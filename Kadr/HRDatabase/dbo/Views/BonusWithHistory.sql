


--select * from [BonusWithHistory] where id = 10554 
--История надбавок
CREATE VIEW [dbo].[BonusWithHistory]
AS
SELECT  Bonus.id, DistinctBonusHistory.BonusCount, DistinctBonusHistory.DateBegin, 
	ISNULL(DATEADD(dd,-1,NextDistinctBonusHistory.DateBegin), Bonus.DateEnd) DateEnd, Bonus.idBonusType, 
	DistinctBonusHistory.idBeginPrikaz idPrikaz, 
	ISNULL(NextDistinctBonusHistory.idBeginPrikaz, Bonus.idEndPrikaz) idEndPrikaz, Bonus.Comment, DistinctBonusHistory.idFinancingSource,
	DistBonusHistory.id idBonusHistory
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
			AND NextDistinctBonusHistory.DateBegin =
				(SELECT MIN(history.DateBegin) FROM dbo.BonusHistory history 
					WHERE DistinctBonusHistory.idBonus=history.idBonus AND history.DateBegin>DistinctBonusHistory.DateBegin)



