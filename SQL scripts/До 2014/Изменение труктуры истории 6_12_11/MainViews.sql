USE [Kadr]
GO

/****** Object:  View [dbo].[FactStaffWithHistory]    Script Date: 12/06/2011 14:09:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*
select idPlanStaff, DateChange, COUNT(*) 
from VPlanStaffChangesHistory 
GROUP BY idPlanStaff, DateChange 
HAVING COUNT(*)>1
*/
--ѕредставление с изменени€ми, в котором только уникальные даты (из-за исключ. ситуаций, 
--когда в один и тот же день выпущено несколько изменений)
CREATE VIEW dbo.VPlanStaffChangesHistory
AS
SELECT  PlanStaffHistoryChanges.*
FROM	
	(SELECT idPlanStaff, DateChange, MAX(id) id
		FROM dbo.PlanStaffHistoryChanges
		GROUP BY idPlanStaff, DateChange) DistinctPlanStaffHistoryChanges
	INNER JOIN
	dbo.PlanStaffHistoryChanges 
		ON DistinctPlanStaffHistoryChanges.id=PlanStaffHistoryChanges.id
		AND DistinctPlanStaffHistoryChanges.idPlanStaff=PlanStaffHistoryChanges.idPlanStaff
		AND DistinctPlanStaffHistoryChanges.DateChange=PlanStaffHistoryChanges.DateChange


GO
/*
select idFactStaff, DateChange, COUNT(*) 
from VFactStaffChangesHistory 
GROUP BY idFactStaff, DateChange 
HAVING COUNT(*)>1
*/
--ѕредставление с изменени€ми, в котором только уникальные даты (из-за исключ. ситуаций, 
--когда в один и тот же день выпущено несколько изменений)
CREATE VIEW dbo.VFactStaffChangesHistory
AS
SELECT  FactStaffChangesHistory.*
FROM	
	(SELECT idFactStaff, DateChange, MAX(id) id
		FROM dbo.FactStaffChangesHistory
		GROUP BY idFactStaff, DateChange) DistinctFactStaffHistoryChanges
	INNER JOIN
	dbo.FactStaffChangesHistory
		ON DistinctFactStaffHistoryChanges.id=FactStaffChangesHistory.id
		AND DistinctFactStaffHistoryChanges.idFactStaff=FactStaffChangesHistory.idFactStaff
		AND DistinctFactStaffHistoryChanges.DateChange=FactStaffChangesHistory.DateChange




GO

/*
select id, COUNT(*)
from VPlanStaff
GROUP BY id
HAVING COUNT(*)>1
*/
--ѕредставление с текущими значени€ми штатов (т.е. с учетом изменений)
CREATE VIEW dbo.VPlanStaff
AS
SELECT PlanStaff.id, ISNULL(LastChange.NewStaffCount, PlanStaff.StaffCount) StaffCount,
	PlanStaff.idDepartment, PlanStaff.idPost, 
	ISNULL(LastChange.idPrikazChange, PlanStaff.idBeginPrikaz) idBeginPrikaz, PlanStaff.idEndPrikaz,
	ISNULL(LastChange.idNewFinancingSource, PlanStaff.idFinancingSource) as idFinancingSource,
	PlanStaff.DateBegin, PlanStaff.DateEnd 
FROM 
	dbo.PlanStaff LEFT JOIN  
	(SELECT VPlanStaffChangesHistory.*
	FROM
		(SELECT idPlanStaff, MAX(DateChange) DateChange
			FROM dbo.VPlanStaffChangesHistory
			GROUP BY idPlanStaff) LastChange
		INNER JOIN
		dbo.VPlanStaffChangesHistory 
			ON LastChange.idPlanStaff=VPlanStaffChangesHistory.idPlanStaff
			AND LastChange.DateChange=VPlanStaffChangesHistory.DateChange)LastChange
	ON PlanStaff.id=LastChange.idPlanStaff


GO

/*
select id, COUNT(*)
from FactStaff
GROUP BY id
HAVING COUNT(*)>1
*/
--ѕредставление с текущими значени€ми штатов (т.е. с учетом изменений)
create VIEW dbo.VFactStaff
AS
SELECT FactStaff.id, ISNULL(LastChange.NewStaffCount, FactStaff.StaffCount) StaffCount,
	FactStaff.idPlanStaff, FactStaff.idEmployee, FactStaff.idTypeWork, 
	ISNULL(LastChange.idPrikazChange, FactStaff.idBeginPrikaz) idBeginPrikaz, FactStaff.idEndPrikaz,
	ISNULL(LastChange.idNewTypeWork, FactStaff.idTypeWork) as idFinancingSource,
	FactStaff.DateBegin, FactStaff.DateEnd,
	FactStaff.IsReplacement, FactStaff.idTimeSheetSheduleType 
FROM 
	dbo.FactStaff LEFT JOIN  
	(SELECT VFactStaffChangesHistory.*
	FROM
		(SELECT idFactStaff, MAX(DateChange) DateChange
			FROM dbo.VFactStaffChangesHistory
			GROUP BY idFactStaff) LastChange
		INNER JOIN
		dbo.VFactStaffChangesHistory 
			ON LastChange.idFactStaff=VFactStaffChangesHistory.idFactStaff
			AND LastChange.DateChange=VFactStaffChangesHistory.DateChange)LastChange
	ON FactStaff.id=LastChange.idFactStaff

