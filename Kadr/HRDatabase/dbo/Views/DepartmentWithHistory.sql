



--select * from [PlanStaffWithHistory] where id = 172 order by DateBegin
--Представление со всей историей штатного расписания
CREATE VIEW [dbo].[DepartmentWithHistory]
AS

SELECT  Department.id, DistinctDepartmentHistory.DepartmentName, DistinctDepartmentHistory.DepartmentSmallName, 
	Department.idFundingCenter, Department.idDepartmentType, Department.idManagerPlanStaff, 
	DistinctDepartmentHistory.idBeginPrikaz, 
	ISNULL(NextDistinctDepartmentHistory.idBeginPrikaz, Department.idEndPrikaz) idEndPrikaz, 
	DistinctDepartmentHistory.idManagerDepartment, 
	DistinctDepartmentHistory.DateBegin, 
	ISNULL(NextDistinctDepartmentHistory.DateBegin-1, Department.[dateExit]) [dateExit] ,
	DistinctDepartmentHistory.id idDepartmentHistory,
	idOKVED
FROM 
	[dbo].[Dep] Department
	INNER JOIN 
	/*(SELECT idPlanStaff, DateBegin, MAX(id) id
		FROM dbo.PlanStaffHistory
		GROUP BY idPlanStaff, DateBegin) DistPlanStaffHistory
	ON PlanStaff.id=DistPlanStaffHistory.idPlanStaff
	INNER JOIN*/
	 /*(SELECT  PlanStaffHistory.*
		FROM	
			(SELECT idPlanStaff, DateBegin, MAX(id) id
				FROM dbo.PlanStaffHistory
				GROUP BY idPlanStaff, DateBegin) DistinctPlanStaffHistory
			INNER JOIN
			 dbo.PlanStaffHistory
				ON DistinctPlanStaffHistory.id=PlanStaffHistory.id
)*/[dbo].[DepartmentHistory] DistinctDepartmentHistory
		ON DistinctDepartmentHistory.idDepartment=Department.id
	 LEFT JOIN	--выбираем ближайшее следующее изменение
	 dbo.[DepartmentHistory] NextDistinctDepartmentHistory ON Department.id=NextDistinctDepartmentHistory.idDepartment
			AND CONVERT(date, NextDistinctDepartmentHistory.DateBegin) =
				(SELECT CONVERT(date, MIN(history.DateBegin)) FROM dbo.[DepartmentHistory] history 
					WHERE DistinctDepartmentHistory.idDepartment=history.idDepartment 
						AND history.DateBegin>DistinctDepartmentHistory.DateBegin)






