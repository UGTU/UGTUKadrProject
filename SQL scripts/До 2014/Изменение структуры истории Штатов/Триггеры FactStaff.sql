USE [Kadr]
GO

/****** Object:  Trigger [dbo].[FactStaffOneMainStaff]    Script Date: 04/27/2012 10:48:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--проверяем, чтобы основная должность была 1
CREATE TRIGGER [dbo].[FactStaffHistoryOneMainStaff]
 ON dbo.FactStaffHistory
  FOR UPDATE, INSERT
AS


IF EXISTS(SELECT AllFactStaff.idEmployee, COUNT(AllFactStaff.StaffCount) AS FactStaffCount 
		FROM INSERTED
			INNER JOIN
				dbo.FactStaffCurrent ON INSERTED.id=FactStaffCurrent.idFactStaffHistory
			INNER JOIN
				dbo.FactStaffCurrent AllFactStaff ON FactStaffCurrent.idEmployee=AllFactStaff.idEmployee
		WHERE FactStaffCurrent.idEndPrikaz IS NULL		--СТАВКИ ОТКРЫТЫ
			AND AllFactStaff.idEndPrikaz IS NULL		--ШТАТНОЕ ОТКРЫТО
			AND AllFactStaff.idTypeWork IN (SELECT WorkType.id
				FROM WorkType WHERE WorkType.IsMain=1)
			AND INSERTED.idTypeWork IN (SELECT WorkType.id
				FROM WorkType WHERE WorkType.IsMain=1)
			--AND FactStaff.id NOT IN (SELECT id FROM INSERTED WHERE idEndPrikaz IS NOT NULL)--проверяем, чтобы прежняя основная ставка не отменялась в этой же транзакции
		GROUP BY AllFactStaff.idEmployee
		HAVING COUNT(AllFactStaff.StaffCount)>1
)			
BEGIN
      RAISERROR('Ошибка! Вы пытаетесь добавить сотруднику еще одну основную должность.', 16,1)
      ROLLBACK TRAN 
END




GO

GO

alter TRIGGER [dbo].[FactStaffHistoryNotMoreStaffs]
 ON dbo.FactStaffHistory
  FOR UPDATE, INSERT
AS


IF EXISTS(SELECT PlanStaff.id, PlanStaff.StaffCount, SUM(AllFactStaff.StaffCount) AS FactStaffCount 
		FROM INSERTED
			INNER JOIN
				dbo.FactStaffCurrent ON INSERTED.id=FactStaffCurrent.idFactStaffHistory
			INNER JOIN
				dbo.FactStaffCurrent AllFactStaff ON FactStaffCurrent.idPlanStaff=AllFactStaff.idPlanStaff
			INNER JOIN 
				dbo.PlanStaffCurrent PlanStaff ON AllFactStaff.idPlanStaff=PlanStaff.id
		WHERE FactStaffCurrent.idEndPrikaz IS NULL		--СТАВКИ ОТКРЫТЫ
			AND AllFactStaff.idEndPrikaz IS NULL		--ШТАТНОЕ ОТКРЫТО
			AND FactStaffCurrent.IsReplacement=0	--не совмещение
			AND AllFactStaff.IsReplacement=0	--не совмещение
		GROUP BY PlanStaff.id,PlanStaff.StaffCount
		HAVING SUM(AllFactStaff.StaffCount)>PlanStaff.StaffCount
)			
BEGIN
      RAISERROR('Ошибка! Вы пытаетесь добавить ставку в запись штатного расписания, в которой уже заняты все ставки.', 16,1)
      ROLLBACK TRAN 
END

