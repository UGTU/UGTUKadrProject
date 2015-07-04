

 ALTER INDEX IX_PlanStaffSalary
   ON PlanStaffSalary
   REBUILD

 ALTER INDEX IX_BonusHistory
   ON BonusHistory
   REBUILD

 ALTER INDEX IX_BonusHistoryidBeginPrikaz
   ON BonusHistory
   REBUILD

 ALTER INDEX PK_PlanStaffSalary
   ON PlanStaffSalary
   REBUILD

 ALTER INDEX IX_PlanStaffSalary_DateBegin
   ON PlanStaffSalary
   REBUILD

 ALTER INDEX IX_PlanStaffSalary_DateEnd
   ON PlanStaffSalary
   REBUILD

 ALTER INDEX IX_FactStaffHistoryUnique
   ON FactStaffHistory
   REBUILD

 ALTER INDEX IX_FactStaffHistoryDateBegin
   ON FactStaffHistory
   REBUILD
 ALTER INDEX IX_FactStaffHistoryidBeginPrikaz
   ON FactStaffHistory
   REBUILD
 ALTER INDEX IX_FactStaffHistoryTypeWork
   ON FactStaffHistory
   REBUILD


 ALTER INDEX PK_FactStaff
   ON FactStaff
   REBUILD

 ALTER INDEX IX_FactStaffEmpl
   ON FactStaff
   REBUILD
 ALTER INDEX IX_FactStaff_idEndPrikaz
   ON FactStaff
   REBUILD
 ALTER INDEX IX_FactStaff_DateEnd
   ON FactStaff
   REBUILD


 ALTER INDEX IX_Employee_idSemPol
   ON Employee
   REBUILD

 ALTER INDEX IX_Employee
   ON Employee
   REBUILD

 ALTER INDEX PK_Employee
   ON Employee
   REBUILD

 ALTER INDEX IX_DepartmentHistoryUnique
   ON  DepartmentHistory
   REBUILD

 ALTER INDEX IX_BonusDateEnd
   ON Bonus
   REBUILD

 ALTER INDEX IX_BonusidBonusType
   ON Bonus
   REBUILD

 ALTER INDEX IX_BonusFactStaff
   ON BonusFactStaff
   REBUILD


 ALTER INDEX 
   ON 
   REBUILD

 ALTER INDEX 
   ON 
   REBUILD
   
 ALTER INDEX 
   ON 
   REBUILD

 ALTER INDEX 
   ON 
   REBUILD

 ALTER INDEX 
   ON 
   REBUILD

 ALTER INDEX 
   ON 
   REBUILD

 ALTER INDEX DateIDTabelIdFactStaffUnique
   ON TimeSheetRecord
   REBUILD

 ALTER INDEX IX_TimeSheetFSWorkingDaysIsClosed
   ON TimeSheetFSWorkingDays
   REBUILD

 ALTER INDEX IX_TimeSheetFSWorkingDaysFactStaff
   ON TimeSheetFSWorkingDays
   REBUILD

 ALTER INDEX IX_PrikazidPrikazType
   ON Prikaz
   REBUILD

 ALTER INDEX PK_Prikaz
   ON Prikaz
   REBUILD

 ALTER INDEX IX_PrikazDatePrikaz
   ON Prikaz
   REBUILD

 ALTER INDEX IX_PlanStaffSalary_DateEnd
   ON PlanStaffSalary
   REBUILD

 ALTER INDEX PK_PlanStaffSalary
   ON PlanStaffSalary
   REBUILD

 ALTER INDEX IX_PlanStaffHistoryidFinancingSource
   ON PlanStaffHistory
   REBUILD


 ALTER INDEX IX_PlanStaffHistoryidBeginPrikaz
   ON PlanStaffHistory
   REBUILD


 ALTER INDEX IX_PlanStaffHistoryDateBegin
   ON PlanStaffHistory
   REBUILD


 ALTER INDEX IX_PlanStaffHistoryUnique
   ON PlanStaffHistory
   REBUILD

 ALTER INDEX IX_PlanStaffDateEnd
   ON PlanStaff
   REBUILD

 ALTER INDEX IX_PlanStaffidEndPrikaz
   ON PlanStaff
   REBUILD


 ALTER INDEX IX_PlanStaffPost
   ON PlanStaff
   REBUILD


 ALTER INDEX IX_PlanStaffDep
   ON PlanStaff
   REBUILD

 ALTER INDEX IX_FactStaffEmpl
   ON FactStaff
   REBUILD

 ALTER INDEX IX_EmployeeZvanye
   ON EmployeeRank
   REBUILD

 ALTER INDEX IX_EmployeeDegree_1
   ON EmployeeDegree
   REBUILD

 ALTER INDEX IX_Employee_idSemPol
   ON Employee
   REBUILD

 ALTER INDEX PK_Department
   ON Dep
   REBUILD

SELECT object_name(i.object_id) as object_name ,i.name as IndexName
   ,ps.avg_fragmentation_in_percent
   ,avg_page_space_used_in_percent 
  FROM sys.dm_db_index_physical_stats(db_id(), NULL, NULL, NULL , 'DETAILED') as ps
  INNER JOIN sys.indexes as i 
     ON i.object_id = ps.object_id AND i.index_id = ps.index_id 
  WHERE ps.avg_fragmentation_in_percent > 50 
    AND ps.index_id > 0 
ORDER BY 1



