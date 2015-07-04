USE Kadr
GO

/****** Object:  Trigger [dbo].[trUpdatePGorod]    Script Date: 11/21/2012 14:09:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





--указывает ставку для почасовиков
ALTER TRIGGER dbo.FactStaffHistoryForHoursInsert 
	ON dbo.FactStaffHistory
INSTEAD OF INSERT
AS
BEGIN
IF ((SELECT COUNT(*) FROM Inserted WHERE HourCount IS NOT NULL) > 0 ) --почасовики
   BEGIN
       INSERT INTO dbo.FactStaffHistory(idFactStaff,idBeginPrikaz,
			DateBegin,StaffCount,idTypeWork,idlaborcontrakt,HourCount,HourSalary)
        SELECT Inserted.idFactStaff,Inserted.idBeginPrikaz,Inserted.DateBegin,(Inserted.HourCount/TimeNorm.NormHoursCount),
			Inserted.idTypeWork,Inserted.idlaborcontrakt,Inserted.HourCount,Inserted.HourSalary
         FROM Inserted  
			INNER JOIN dbo.FactStaff ON Inserted.idFactStaff=FactStaff.id
			INNER JOIN dbo.PlanStaffCurrent PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id
			INNER JOIN dbo.DepartmentTimeNormCurrent TimeNorm 
				ON PlanStaff.idDepartment=TimeNorm.idDepartment
					AND PlanStaff.idFinancingSource=TimeNorm.idFinancingSource
      commit tran
   END  
END

go
--указывает ставку для почасовиков
CREATE TRIGGER dbo.FactStaffHistoryForHoursUpdate
	ON dbo.FactStaffHistory
INSTEAD OF UPDATE
AS
BEGIN
IF ((SELECT COUNT(*) FROM Inserted WHERE HourCount IS NOT NULL) > 0 ) --почасовики
   BEGIN
       UPDATE dbo.FactStaffHistory
       SET 
          idFactStaff=Inserted.idFactStaff,
          idBeginPrikaz=Inserted.idBeginPrikaz,
          DateBegin=Inserted.DateBegin,
          StaffCount=(Inserted.HourCount/TimeNorm.NormHoursCount),
		  idTypeWork=Inserted.idTypeWork,
		  idlaborcontrakt=Inserted.idlaborcontrakt,
		  HourCount=Inserted.HourCount,
		  HourSalary=Inserted.HourSalary
         FROM dbo.FactStaffHistory
			INNER JOIN Inserted ON FactStaffHistory.id=Inserted.id
			INNER JOIN dbo.FactStaff ON Inserted.idFactStaff=FactStaff.id
			INNER JOIN dbo.PlanStaffCurrent PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id
			INNER JOIN dbo.DepartmentTimeNormCurrent TimeNorm 
				ON PlanStaff.idDepartment=TimeNorm.idDepartment
					AND PlanStaff.idFinancingSource=TimeNorm.idFinancingSource
		 
      commit tran
   END  
END




GO


