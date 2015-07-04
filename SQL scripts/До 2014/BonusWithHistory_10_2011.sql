USE [Kadr]
GO

/****** Object:  View [dbo].[FactStaffWithHistory]    Script Date: 10/22/2011 13:34:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--select * from [BonusWithHistory] where id = 10554 

ALTER VIEW [dbo].[BonusWithHistory]
AS
--выбираем последние изменения - которые берем из Bonus (оттуда берем размер и приказ надбавки, 
--дату берем из последнего изменения (если такое есть))
SELECT Bonus.id, Bonus.BonusCount, CONVERT(date,ISNULL(BonusChangesHistory.DateChange, Bonus.DateBegin)) DateBegin, 
	Bonus.DateEnd, Bonus.idBonusType, Bonus.idPrikaz, Bonus.idEndPrikaz, Bonus.Comment
FROM 
	dbo.Bonus LEFT JOIN
	dbo.BonusChangesHistory ON dbo.Bonus.id=dbo.BonusChangesHistory.idBonus
	--Проверяем, чтобы изменение было последним (т.е. оно не являеься предыдущим ни для какого другого изменения)
		AND  BonusChangesHistory.id NOT IN 
			(SELECT idPrevBonusChange FROM dbo.BonusChangesHistory WHERE idPrevBonusChange IS NOT NULL)
	--выбираем предыдущее изменение
	--LEFT JOIN dbo.BonusChangesHistory PrevChange ON dbo.Bonus.id=PrevChange.idBonus
	--	AND PrevChange.id=BonusChangesHistory.idPrevBonusChange
	
			
--выбираем первое изменение - дату назначения берем из надбавки, остальное из первого изменения
UNION
SELECT Bonus.id, BonusChangesHistory.PrevBonusCount, CONVERT(date,Bonus.DateBegin) DateBegin, 
	CONVERT(date,BonusChangesHistory.DateChange-1) as DateEnd, Bonus.idBonusType, BonusChangesHistory.idPrevPrikaz, 
	ISNULL(NextChange.idPrevPrikaz, Bonus.idEndPrikaz), Bonus.Comment
FROM 
	dbo.Bonus
	INNER JOIN dbo.BonusChangesHistory ON dbo.Bonus.id=dbo.BonusChangesHistory.idBonus
--Проверяем, чтобы изменение было первым (т.е. для него нет предыдущего)
		AND BonusChangesHistory.idPrevBonusChange IS NULL  
	--выбираем следующее за ним изменение (если есть)
	LEFT JOIN dbo.BonusChangesHistory NextChange ON dbo.Bonus.id=NextChange.idBonus
		AND NextChange.idPrevBonusChange=BonusChangesHistory.id
		
--выбираем "серединные" изменения	
UNION
SELECT Bonus.id, BonusChangesHistory.PrevBonusCount, CONVERT(date,PrevChange.DateChange) DateBegin, 
	CONVERT(date,BonusChangesHistory.DateChange-1) as DateEnd, Bonus.idBonusType, BonusChangesHistory.idPrevPrikaz, 
	ISNULL(NextChange.idPrevPrikaz,Bonus.idPrikaz) idEndPrikaz, Bonus.Comment
FROM 
	dbo.Bonus
	INNER JOIN dbo.BonusChangesHistory ON dbo.Bonus.id=dbo.BonusChangesHistory.idBonus
	--выбираем предыдущее изменение
	INNER JOIN dbo.BonusChangesHistory PrevChange ON dbo.Bonus.id=PrevChange.idBonus
		AND PrevChange.id=BonusChangesHistory.idPrevBonusChange
	--выбираем следующее за ним изменение (если есть)
	LEFT JOIN dbo.BonusChangesHistory NextChange ON dbo.Bonus.id=NextChange.idBonus
		AND NextChange.idPrevBonusChange=BonusChangesHistory.id



GO


