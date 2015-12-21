



--select * from [BonusMain] where id = 10554 
--Первоначальное изменение надбавки
CREATE VIEW [dbo].[BonusMain]
AS
SELECT  Bonus.id, BonusHistory.BonusCount, BonusHistory.DateBegin, 
	Bonus.DateEnd DateEnd, Bonus.idBonusType, 
	BonusHistory.idBeginPrikaz idPrikaz, 
	Bonus.idEndPrikaz idEndPrikaz, Bonus.Comment, BonusHistory.idFinancingSource,
	BonusHistory.id idBonusHistory
FROM 
dbo.Bonus INNER JOIN
	 dbo.BonusHistory ON Bonus.id=BonusHistory.idBonus
		AND BonusHistory.DateBegin = 
			(SELECT MIN(BonusHistory.DateBegin) FROM dbo.BonusHistory 
				WHERE BonusHistory.idBonus=Bonus.id)





