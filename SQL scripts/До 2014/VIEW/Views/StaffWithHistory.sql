USE [Kadr]
GO

/****** Object:  View [dbo].[PlanStaffsWithSalaries]    Script Date: 02/15/2011 11:35:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--select * from [PlanStaffWithHistory] where id = 172 order by DateBegin
alter VIEW [dbo].[PlanStaffWithHistory]
AS
--выбираем последние изменения - которые берем из PlanStaff
SELECT  PlanStaff.id, PlanStaff.StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, ISNULL(PlanStaffHistoryChanges.idPrikazChange,PlanStaff.idBeginPrikaz) idBeginPrikaz, 
	PlanStaff.idEndPrikaz, PlanStaff.idFinancingSource, 
	CONVERT(date,ISNULL(PlanStaffHistoryChanges.DateChange, PlanStaff.DateBegin)) DateBegin, CONVERT(date,PlanStaff.DateEnd) DateEnd 
FROM         
	dbo.PlanStaff LEFT JOIN
	 dbo.PlanStaffHistoryChanges ON PlanStaff.id=PlanStaffHistoryChanges.idPlanStaff
		AND PlanStaffHistoryChanges.DateChange = 
			(SELECT MAX(PlanStaffHistoryChanges.DateChange) FROM PlanStaffHistoryChanges WHERE PlanStaffHistoryChanges.idPlanStaff=PlanStaff.id)
	
--выбираем первое изменение
UNION
SELECT  PlanStaff.id, PlanStaffHistoryChanges.PrevStaffCount StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, PlanStaffHistoryChanges.idPrevPrikaz idBeginPrikaz, 
	PlanStaffHistoryChanges.idPrikazChange idEndPrikaz, PlanStaffHistoryChanges.idPrevFinancingSource idFinancingSource, 
	CONVERT(date,PlanStaff.DateBegin) DateBegin, CONVERT(date,PlanStaffHistoryChanges.DateChange) as DateEnd  
FROM         
	dbo.PlanStaff INNER JOIN
	 dbo.PlanStaffHistoryChanges ON PlanStaff.id=PlanStaffHistoryChanges.idPlanStaff 
WHERE PlanStaffHistoryChanges.DateChange = 
	(SELECT MIN(PlanStaffHistoryChanges.DateChange) FROM PlanStaffHistoryChanges WHERE PlanStaffHistoryChanges.idPlanStaff=PlanStaff.id)

--выбираем "серединные" изменения
UNION
SELECT  PlanStaff.id, PlanStaffHistoryChanges.PrevStaffCount StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, PredPlanStaffHistoryChanges.idPrikazChange as idBeginPrikaz, 
	PlanStaffHistoryChanges.idPrikazChange, PlanStaffHistoryChanges.idPrevFinancingSource idFinancingSource, 
	CONVERT(date,PredPlanStaffHistoryChanges.DateChange) DateBegin, CONVERT(date,PlanStaffHistoryChanges.DateChange) as DateEnd  
FROM         
	dbo.PlanStaff INNER JOIN
	 dbo.PlanStaffHistoryChanges ON PlanStaff.id=PlanStaffHistoryChanges.idPlanStaff 
			AND PlanStaffHistoryChanges.DateChange >
				(SELECT MIN(PlanStaffHistoryChanges.DateChange) FROM PlanStaffHistoryChanges WHERE PlanStaffHistoryChanges.idPlanStaff=PlanStaff.id)
	INNER JOIN
	 dbo.PlanStaffHistoryChanges AS PredPlanStaffHistoryChanges ON PlanStaff.id=PredPlanStaffHistoryChanges.idPlanStaff 
			AND PlanStaffHistoryChanges.DateChange >
				PredPlanStaffHistoryChanges.DateChange
			AND PredPlanStaffHistoryChanges.DateChange =
				(SELECT MAX(PrevPlanStaffHistoryChanges.DateChange) FROM PlanStaffHistoryChanges PrevPlanStaffHistoryChanges 
					WHERE PrevPlanStaffHistoryChanges.idPlanStaff=PlanStaff.id
						AND PrevPlanStaffHistoryChanges.DateChange<PlanStaffHistoryChanges.DateChange
						)
	


GO
--select * from [FactStaffWithHistory] where id = 2827 order by DateBegin CONVERT(date,)

alter VIEW [dbo].[FactStaffWithHistory]
AS
--выбираем последние изменения - которые берем из PlanStaff
SELECT  FactStaff.id, FactStaff.StaffCount, FactStaff.idPlanStaff, 
	FactStaff.idEmployee, ISNULL(FactStaffChangesHistory.idPrikazChange,FactStaff.idBeginPrikaz) idBeginPrikaz, 
	FactStaff.idEndPrikaz, FactStaff.idTypeWork, 
	CONVERT(date,ISNULL(FactStaffChangesHistory.DateChange, FactStaff.DateBegin)) DateBegin, CONVERT(date,FactStaff.DateEnd) DateEnd, FactStaff.IsReplacement  
FROM         
	dbo.FactStaff LEFT JOIN
	FactStaffChangesHistory ON FactStaff.id=FactStaffChangesHistory.idFactStaff
		AND FactStaffChangesHistory.DateChange = 
			(SELECT MAX(FactStaffChangesHistory.DateChange) FROM FactStaffChangesHistory WHERE FactStaffChangesHistory.idFactStaff=FactStaff.id)
	
--выбираем первое изменение
UNION
SELECT  FactStaff.id, FactStaffChangesHistory.PrevStaffCount StaffCount, FactStaff.idPlanStaff, 
	FactStaff.idEmployee, FactStaffChangesHistory.idPrevPrikaz idBeginPrikaz, 
	FactStaffChangesHistory.idPrikazChange idEndPrikaz, FactStaffChangesHistory.idPrevTypeWork idTypeWork, 
	CONVERT(date,FactStaff.DateBegin) DateBegin, CONVERT(date,FactStaffChangesHistory.DateChange-1) as DateEnd, FactStaff.IsReplacement   
FROM         
	dbo.FactStaff INNER JOIN
	 dbo.FactStaffChangesHistory ON FactStaff.id=FactStaffChangesHistory.idFactStaff
WHERE FactStaffChangesHistory.DateChange = 
	(SELECT MIN(FactStaffChangesHistory.DateChange) FROM FactStaffChangesHistory WHERE FactStaffChangesHistory.idFactStaff=FactStaff.id)

--выбираем "серединные" изменения
UNION
SELECT  FactStaff.id, FactStaffChangesHistory.PrevStaffCount StaffCount, FactStaff.idPlanStaff, 
	FactStaff.idEmployee, PredFactStaffChangesHistory.idPrikazChange as idBeginPrikaz, 
	FactStaffChangesHistory.idPrikazChange, FactStaffChangesHistory.idPrevTypeWork idTypeWork, 
	CONVERT(date,PredFactStaffChangesHistory.DateChange) DateBegin, CONVERT(date,FactStaffChangesHistory.DateChange-1) as DateEnd, FactStaff.IsReplacement   
FROM         
	dbo.FactStaff INNER JOIN
	 dbo.FactStaffChangesHistory ON FactStaff.id=FactStaffChangesHistory.idFactStaff
			AND FactStaffChangesHistory.DateChange >
				(SELECT MIN(FactStaffChangesHistory.DateChange) FROM FactStaffChangesHistory WHERE FactStaffChangesHistory.idFactStaff=FactStaff.id)
	INNER JOIN
	 dbo.FactStaffChangesHistory AS PredFactStaffChangesHistory ON FactStaff.id=PredFactStaffChangesHistory.idFactStaff 
			AND FactStaffChangesHistory.DateChange >
				PredFactStaffChangesHistory.DateChange
			AND PredFactStaffChangesHistory.DateChange =
				(SELECT MAX(PrevFactStaffChangesHistory.DateChange) FROM FactStaffChangesHistory PrevFactStaffChangesHistory 
					WHERE PrevFactStaffChangesHistory.idFactStaff=FactStaff.id
						AND PrevFactStaffChangesHistory.DateChange<FactStaffChangesHistory.DateChange
						)
	

