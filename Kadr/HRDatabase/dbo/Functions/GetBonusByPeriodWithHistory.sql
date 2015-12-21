


--select * from [dbo].[GetBonusByPeriodWithHistory]('08.10.2010','30.10.2010')  where idBonus=10554
--выдает список надбавок за период вместе с историей
CREATE FUNCTION [dbo].[GetBonusByPeriodWithHistory] 
(
@PeriodBegin	DATE,
@PeriodEnd	DATE
)
RETURNS  TABLE

AS

RETURN	(SELECT Bonus.id idBonus, DateBegin, DateEnd, BonusCount, idPrikaz, idEndPrikaz, idFinancingSource
	FROM dbo.BonusWithHistory as Bonus	
	WHERE (CONVERT(date,Bonus.DateBegin)<=@PeriodBegin AND (CONVERT(date,Bonus.DateEnd)>=@PeriodBegin OR Bonus.DateEnd IS NULL))
		OR (CONVERT(date,Bonus.DateBegin)>=@PeriodBegin AND CONVERT(date,Bonus.DateBegin)<=@PeriodEnd))
		
 
		



