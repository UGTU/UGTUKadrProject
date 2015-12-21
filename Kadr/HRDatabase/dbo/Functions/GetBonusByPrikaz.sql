

--select * from [dbo].[GetBonusByPrikaz]('1.01.2015','11.1.2015',10421) where idBonus=10554
--возвращает все надбавки за период (если есть история, то берет последнюю за период)
CREATE FUNCTION [dbo].[GetBonusByPrikaz] 
(
@PeriodBegin	DATETIME,
@PeriodEnd	DATETIME,
@idPrikaz	INT
)
RETURNS  TABLE

AS
RETURN (
	SELECT idBonus, BonusCount, idFinancingSource,idBonusType,
		[DateBegin],[DateEnd], PrikazAppointment
	FROM 
	(SELECT Bonus.id idBonus, (BonusHistory.id) [idBonusHistory], 
		IIF(BonusHistory.DateBegin=FirstBonusHistory.FirstDateBegin, 'Назначение', 'Продление') PrikazAppointment
		FROM dbo.BonusHistory 
		INNER JOIN dbo.Bonus ON BonusHistory.[idBonus]=Bonus.id
		INNER JOIN 
		(SELECT [idBonus], MIN([DateBegin]) FirstDateBegin
			FROM [dbo].[BonusHistory]
			GROUP BY [idBonus])FirstBonusHistory
			ON BonusHistory.[idBonus]=FirstBonusHistory.[idBonus]
		WHERE [idBeginPrikaz]=@idPrikaz 
		--GROUP BY Bonus.id
		UNION
		SELECT Bonus.id idBonus, MAX(BonusHistory.id) [idBonusHistory], 'Отмена' PrikazAppointment
		FROM dbo.BonusHistory 
		INNER JOIN dbo.Bonus ON BonusHistory.[idBonus]=Bonus.id
		WHERE Bonus.idEndPrikaz=@idPrikaz
		GROUP BY Bonus.id
		) LastBonusHistory
		INNER JOIN
	[dbo].[BonusWithHistory] ON LastBonusHistory.idBonusHistory=[BonusWithHistory].idBonusHistory
	)


