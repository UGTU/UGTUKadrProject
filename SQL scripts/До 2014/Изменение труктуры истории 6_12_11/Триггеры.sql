USE [Kadr]
GO

/****** Object:  Trigger [dbo].[FactStaffNotMoreStaffs]    Script Date: 12/07/2011 10:35:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER TRIGGER [dbo].[FactStaffNotMoreStaffs]
 ON [dbo].[FactStaff]
  FOR UPDATE, INSERT
AS


IF EXISTS(SELECT PlanStaff.id, PlanStaff.StaffCount, SUM(FactStaff.StaffCount) AS FactStaffCount 
		FROM INSERTED, dbo.FactStaff, dbo.vPlanStaff PlanStaff
				WHERE INSERTED.idPlanStaff=FactStaff.idPlanStaff
					AND FactStaff.idPlanStaff=PlanStaff.id  
					AND INSERTED.idEndPrikaz IS NULL		--ТЕКУЩАЯ СТАВКА ОТКРЫТА
					AND FactStaff.idEndPrikaz IS NULL		--СТАВКИ ОТКРЫТЫ
					AND PlanStaff.idEndPrikaz IS NULL		--ШТАТНОЕ ОТКРЫТО
					AND FactStaff.IsReplacement=0	--не совмещение
					AND INSERTED.IsReplacement=0	--не совмещение
		GROUP BY PlanStaff.id,PlanStaff.StaffCount
		HAVING SUM(FactStaff.StaffCount)>PlanStaff.StaffCount
)			
BEGIN
      RAISERROR('Ошибка! Вы пытаетесь добавить ставку в запись штатного расписания, в которой уже заняты все ставки.', 16,1)
      ROLLBACK TRAN 
END




GO

--проверяем, чтобы кол-во ставок было не больше, чем указано в штатном
ALTER TRIGGER [dbo].[PlanStaffNotLessStaffs]
 ON [dbo].[PlanStaff]
  FOR UPDATE, INSERT
AS


IF EXISTS(SELECT INSERTED.id, INSERTED.StaffCount, SUM(FactStaff.StaffCount) AS FactStaffCount 
		FROM INSERTED, dbo.vFactStaff FactStaff
				WHERE INSERTED.id=FactStaff.idPlanStaff
					AND INSERTED.idEndPrikaz IS NULL		--ТЕКУЩАЯ СТАВКА ОТКРЫТА
					AND FactStaff.idEndPrikaz IS NULL		--СТАВКИ ОТКРЫТЫ
					AND FactStaff.IsReplacement=0
		GROUP BY INSERTED.id,INSERTED.StaffCount
		HAVING SUM(FactStaff.StaffCount)>INSERTED.StaffCount
)			
BEGIN
      RAISERROR('Ошибка! Вы пытаетесь указать меньше ставок в запись штатного расписания, чем за ней уже закреплено.', 16,1)
      ROLLBACK TRAN 
END



