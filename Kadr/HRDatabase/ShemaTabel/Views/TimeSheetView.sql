CREATE VIEW ShemaTabel.TimeSheetView AS
SELECT id,idDepartment,idCreater,DateBeginPeriod,DateEndPeriod,DateComposition,IsFake, 
	(select count(DISTINCT tsr.idFactStaffHistory)
	 from ShemaTabel.TimeSheetRecord tsr 
	 where tsr.idTimeSheet=ts.id) as EmployeeCount,
	 isnull((select top 1 iif(tsa.Result=1,at.ApproveNumber,0)
	 from ShemaTabel.TimeSheetApproval tsa
		inner join ShemaTabel.Approver a on tsa.idApprover=a.id
		inner join ShemaTabel.ApproverType at on at.id=a.idApproverType
		where tsa.idTimeSheet =ts.id
		order by  tsa.ApprovalDate desc
	 ),0) as ApproveStep
FROM ShemaTabel.TimeSheet ts
