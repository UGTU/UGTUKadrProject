use Kadr

DECLARE StaffCursor CURSOR LOCAL FAST_FORWARD READ_ONLY FOR 
SELECT DISTINCT PlanStaffHistoryChanges.idPlanStaff, idPrevPrikaz, PrevStaffCount, idPrevFinancingSource FROM
dbo.VPlanStaffChangesHistory PlanStaffHistoryChanges
INNER JOIN (SELECT idPlanStaff, MIN(DateChange)DateChange 
	FROM dbo.VPlanStaffChangesHistory
	GROUP BY idPlanStaff)FirstChanges
ON PlanStaffHistoryChanges.idPlanStaff=FirstChanges.idPlanStaff
	AND PlanStaffHistoryChanges.DateChange=FirstChanges.DateChange
WHERE PlanStaffHistoryChanges.PrevStaffCount>0 and PlanStaffHistoryChanges.PrevStaffCount is not null
ORDER BY PlanStaffHistoryChanges.idPlanStaff
	


OPEN StaffCursor




--DECLARE @idPrevChange INT
--DECLARE @idNextChange INT
--DECLARE @idPrevPlanStaff INT
--DECLARE @idNextPlanStaff INT
--DECLARE @DateChange DATETIME
DECLARE @idPlanStaff INT
DECLARE @idFirstPrikaz INT
DECLARE @PrevStaffCount INT
DECLARE @idPrevFinancingSource INT


FETCH NEXT FROM StaffCursor INTO @idPlanStaff, @idFirstPrikaz, @PrevStaffCount, @idPrevFinancingSource

WHILE @@FETCH_STATUS = 0
BEGIN
IF (@PrevStaffCount>0)
	update dbo.PlanStaff
	set idBeginPrikaz=@idFirstPrikaz,
		idFinancingSource=@idPrevFinancingSource,
		StaffCount=@PrevStaffCount
	where id=@idPlanStaff 



	FETCH NEXT FROM StaffCursor INTO @idPlanStaff, @idFirstPrikaz, @PrevStaffCount, @idPrevFinancingSource

END

go

DECLARE StaffCursor CURSOR LOCAL FAST_FORWARD READ_ONLY FOR 
SELECT DISTINCT FactStaffHistoryChanges.idFactStaff, idPrevPrikaz, PrevStaffCount, idPrevTypeWork 
FROM
dbo.VFactStaffChangesHistory FactStaffHistoryChanges
INNER JOIN (SELECT idFactStaff, MIN(DateChange)DateChange 
	FROM dbo.VFactStaffChangesHistory
	GROUP BY idFactStaff)FirstChanges
ON FactStaffHistoryChanges.idFactStaff=FirstChanges.idFactStaff
	AND FactStaffHistoryChanges.DateChange=FirstChanges.DateChange
WHERE FactStaffHistoryChanges.PrevStaffCount>0 and FactStaffHistoryChanges.PrevStaffCount is not null
ORDER BY FactStaffHistoryChanges.idFactStaff
	


OPEN StaffCursor




--DECLARE @idPrevChange INT
--DECLARE @idNextChange INT
--DECLARE @idPrevPlanStaff INT
--DECLARE @idNextPlanStaff INT
--DECLARE @DateChange DATETIME
DECLARE @idFactStaff INT
DECLARE @idFirstPrikaz INT
DECLARE @PrevStaffCount INT
DECLARE @idPrevTypeWork INT


FETCH NEXT FROM StaffCursor INTO @idFactStaff, @idFirstPrikaz, @PrevStaffCount, @idPrevTypeWork

WHILE @@FETCH_STATUS = 0
BEGIN
IF (@PrevStaffCount>0)
	update dbo.FactStaff
	set idBeginPrikaz=@idFirstPrikaz,
		idTypeWork=@idPrevTypeWork,
		StaffCount=@PrevStaffCount
	where id=@idFactStaff 



	FETCH NEXT FROM StaffCursor INTO @idFactStaff, @idFirstPrikaz, @PrevStaffCount, @idPrevTypeWork

END


/*go
DECLARE StaffCursor CURSOR LOCAL FAST_FORWARD READ_ONLY FOR 
--выбираем все нужные группы (учащиеся на данном факультете)
--экзамены и практики, которые они должны сдать в текущем семестре
SELECT DISTINCT id, idFactStaff, DateChange FROM
dbo.FactStaffChangesHistory
ORDER BY idFactStaff, DateChange
	


OPEN StaffCursor




DECLARE @idPrevChange INT
DECLARE @idNextChange INT
DECLARE @idPrevFactStaff INT
DECLARE @idNextFactStaff INT
DECLARE @idPlanStaff INT
DECLARE @DateChange DATETIME



FETCH NEXT FROM StaffCursor INTO @idPrevChange, @idPrevFactStaff, @DateChange
FETCH NEXT FROM StaffCursor INTO @idNextChange, @idNextFactStaff, @DateChange

WHILE @@FETCH_STATUS = 0
BEGIN



--IF (@idNextPlanStaff=@idPrevPlanStaff)
	update dbo.FactStaffChangesHistory
	set idPrevFactStaffChange=@idPrevChange
	where id=@idNextChange AND idFactStaff=@idPrevFactStaff

	SET @idPrevChange=@idNextChange
	SET @idPrevFactStaff=@idNextFactStaff


	FETCH NEXT FROM StaffCursor INTO @idNextChange, @idNextFactStaff, @DateChange

END*/