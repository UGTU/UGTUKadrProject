CREATE PROC ShemaTabel.TimeSheetRecordInsert(@ValidXMLInput XML)
AS BEGIN
       INSERT INTO ShemaTabel.TimeSheetRecord(RecordDate,JobTimeCount,idTimeSheet,idDayStatus,IsChecked,idFactStaffHistory,IdTimeSheetRecord)
       SELECT	Col.value('(RecordDate/text())[1]','datetime') ,
				Col.value('(JobTimeCount/text())[1]','FLOAT'),
				Col.value('(idTimeSheet/text())[1]','INT'),
				Col.value('(idDayStatus/text())[1]','INT'),
				Col.value('(IsChecked/text())[1]','BIT'),
				Col.value('(idFactStaffHistory/text())[1]','INT'),
				Col.value('(IdTimeSheetRecord/text())[1]','UNIQUEIDENTIFIER')
       FROM @ValidXMLInput.nodes('//TimeSheetRecords/Record') Tab(Col)
END