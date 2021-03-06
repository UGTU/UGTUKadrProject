USE [Kadr]
GO
/****** Object:  Trigger [dbo].[FactStaffNotMoreStaffs]    Script Date: 09/29/2010 12:35:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



GO
ALTER TRIGGER [dbo].[FactStaffNotMoreStaffs]
 ON [dbo].[FactStaff]
  FOR UPDATE, INSERT
AS


IF EXISTS(SELECT PlanStaff.id, PlanStaff.StaffCount, SUM(FactStaff.StaffCount) AS FactStaffCount 
		FROM INSERTED, dbo.FactStaff, dbo.PlanStaff
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



go
--проверяем, чтобы основная должность была 1
alter TRIGGER [dbo].[FactStaffOneMainStaff]
 ON [dbo].[FactStaff]
  FOR UPDATE, INSERT
AS


IF EXISTS(SELECT FactStaff.idEmployee, COUNT(FactStaff.StaffCount) AS FactStaffCount 
		FROM INSERTED, dbo.FactStaff, dbo.PlanStaff 
				WHERE INSERTED.idEmployee=FactStaff.idEmployee
					AND FactStaff.idPlanStaff=PlanStaff.id  
					AND INSERTED.idEndPrikaz IS NULL		--ТЕКУЩАЯ СТАВКА ОТКРЫТА
					AND FactStaff.idEndPrikaz IS NULL		--СТАВКИ ОТКРЫТЫ
					AND PlanStaff.idEndPrikaz IS NULL		--ШТАТНОЕ ОТКРЫТО
					AND FactStaff.idTypeWork IN (SELECT WorkType.id
						FROM WorkType WHERE WorkType.IsMain=1)
					AND INSERTED.idTypeWork IN (SELECT WorkType.id
						FROM WorkType WHERE WorkType.IsMain=1)
		GROUP BY FactStaff.idEmployee
		HAVING COUNT(FactStaff.StaffCount)>1
)			
BEGIN
      RAISERROR('Ошибка! Вы пытаетесь добавить сотруднику еще одну основную должность.', 16,1)
      ROLLBACK TRAN 
END



