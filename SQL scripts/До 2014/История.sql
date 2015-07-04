DECLARE StaffCursor CURSOR LOCAL FAST_FORWARD READ_ONLY FOR 
--выбираем все нужные группы (учащиеся на данном факультете)
--экзамены и практики, которые они должны сдать в текущем семестре
SELECT DISTINCT id, idPlanStaff, DateChange FROM
dbo.PlanStaffHistoryChanges
ORDER BY idPlanStaff, DateChange
	


OPEN StaffCursor




DECLARE @idPrevChange INT
DECLARE @idNextChange INT
DECLARE @idPrevPlanStaff INT
DECLARE @idNextPlanStaff INT
DECLARE @idPlanStaff INT
DECLARE @DateChange DATETIME



FETCH NEXT FROM StaffCursor INTO @idPrevChange, @idPrevPlanStaff, @DateChange
FETCH NEXT FROM StaffCursor INTO @idNextChange, @idNextPlanStaff, @DateChange

WHILE @@FETCH_STATUS = 0
BEGIN



--IF (@idNextPlanStaff=@idPrevPlanStaff)
	update dbo.PlanStaffHistoryChanges
	set idPrevPlanStaffChange=@idPrevChange
	where id=@idNextChange AND idPlanStaff=@idPrevPlanStaff

	SET @idPrevChange=@idNextChange
	SET @idPrevPlanStaff=@idNextPlanStaff


	FETCH NEXT FROM StaffCursor INTO @idNextChange, @idNextPlanStaff, @DateChange

END


--
go
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

END