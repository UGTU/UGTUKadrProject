USE [Kadr]
GO

/****** Object:  View [dbo].[PlanStaffWithHistory]    Script Date: 12/07/2011 12:15:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


--select * from [PlanStaffWithHistory] where id = 172 order by DateBegin
ALTER VIEW [dbo].[PlanStaffWithHistory]
AS
--выбираем последние изменения - которые берем из последнего изменения
SELECT  PlanStaff.id, ISNULL(PlanStaffHistoryChanges.NewStaffCount,PlanStaff.StaffCount) StaffCount, 
	PlanStaff.idDepartment, PlanStaff.idPost, 
	ISNULL(PlanStaffHistoryChanges.idPrikazChange,PlanStaff.idBeginPrikaz) idBeginPrikaz, 
	PlanStaff.idEndPrikaz, ISNULL(PlanStaffHistoryChanges.idNewFinancingSource, PlanStaff.idFinancingSource) idFinancingSource, 
	CONVERT(date,ISNULL(PlanStaffHistoryChanges.DateChange, PlanStaff.DateBegin)) DateBegin, 
	CONVERT(date,PlanStaff.DateEnd) DateEnd 
FROM         
	dbo.PlanStaff LEFT JOIN
	 dbo.VPlanStaffChangesHistory PlanStaffHistoryChanges ON PlanStaff.id=PlanStaffHistoryChanges.idPlanStaff
		AND PlanStaffHistoryChanges.DateChange = 
			(SELECT MAX(PlanStaffHistoryChanges.DateChange) FROM dbo.PlanStaffHistoryChanges 
				WHERE PlanStaffHistoryChanges.idPlanStaff=PlanStaff.id)
--выбираем первоначальные значения - они хранятся в PlanStaff
UNION	
SELECT  PlanStaff.id, PlanStaff.StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, PlanStaff.idBeginPrikaz, 
	PlanStaff.idEndPrikaz, PlanStaff.idFinancingSource, 
	CONVERT(date,PlanStaff.DateBegin) DateBegin, ISNULL((SELECT MIN(PlanStaffHistoryChanges.DateChange) DateChange 
		FROM dbo.VPlanStaffChangesHistory PlanStaffHistoryChanges 
		WHERE PlanStaffHistoryChanges.idPlanStaff=PlanStaff.id), PlanStaff.DateEnd) as DateEnd
	--CONVERT(date,PlanStaffHistoryChanges.DateChange) as DateEnd  
FROM         
	dbo.PlanStaff 
		

--выбираем "серединные" изменения
UNION
SELECT  PlanStaff.id, PlanStaffHistoryChanges.PrevStaffCount StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, PredPlanStaffHistoryChanges.idPrikazChange as idBeginPrikaz, 
	PlanStaffHistoryChanges.idPrikazChange, PlanStaffHistoryChanges.idPrevFinancingSource idFinancingSource, 
	CONVERT(date,PredPlanStaffHistoryChanges.DateChange) DateBegin, CONVERT(date,PlanStaffHistoryChanges.DateChange) as DateEnd  
FROM         
	dbo.PlanStaff INNER JOIN
	dbo.VPlanStaffChangesHistory PlanStaffHistoryChanges ON PlanStaff.id=PlanStaffHistoryChanges.idPlanStaff 
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


