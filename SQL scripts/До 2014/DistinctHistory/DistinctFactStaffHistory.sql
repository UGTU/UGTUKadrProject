USE [Kadr]
GO

/****** Object:  View [dbo].[DistinctBonusHistory]    Script Date: 05/31/2012 10:33:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
select  idFactStaff, DateBegin
from DistinctFactStaffHistory
GROUP BY idFactStaff, DateBegin
HAVING COUNT(*)>1
*/
--ѕредставление с изменени€ми FactStaff, в котором только уникальные даты (из-за исключ. ситуаций, 
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







GO

/*
select  idPlanStaff, DateBegin
from DistinctPlanStaffHistory
GROUP BY idPlanStaff, DateBegin
HAVING COUNT(*)>1
*/
--ѕредставление с изменени€ми PlanStaff, в котором только уникальные даты (из-за исключ. ситуаций, 
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


