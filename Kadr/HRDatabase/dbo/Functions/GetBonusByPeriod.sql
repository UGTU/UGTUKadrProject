

--select * from [dbo].[GetBonusByPeriod]('10.08.2011','11.30.2011') where idBonus=10554
--возвращает все надбавки за период (если есть история, то берет последнюю за период)
CREATE FUNCTION [dbo].[GetBonusByPeriod] 
(
@PeriodBegin	DATE,
@PeriodEnd	DATE
)
RETURNS  TABLE

AS
RETURN (
	SELECT Bonus.id idBonus, BonusCount, idFinancingSource, idBonusType, idPrikaz [idBeginPrikaz], Bonus.DateBegin, Bonus.DateEnd
	FROM dbo.BonusWithHistory as Bonus
	INNER JOIN
	(SELECT Bonus.id, MAX(DateBegin) DateBegin
	FROM dbo.BonusWithHistory as Bonus	
	WHERE (Bonus.DateBegin<=@PeriodBegin AND (Bonus.DateEnd>=@PeriodBegin OR Bonus.DateEnd IS NULL))
		OR (Bonus.DateBegin>=@PeriodBegin AND Bonus.DateBegin<=@PeriodEnd)
	GROUP BY Bonus.id) BonusMaxDates
	ON Bonus.id=BonusMaxDates.id AND Bonus.DateBegin=BonusMaxDates.DateBegin)


