--// ИМПОРТ отпусков из старой схемы БД

--   создание Event  ----------------------------------------------------------------------------------------------------------------------------------------------
INSERT INTO [dbo].Event(DateBegin, DateEnd, idContract, idEventKind, idEventType,idFactStaffHistory,idPrikaz)
  SELECT DISTINCT [OK_Otpusk].[DateBegin],[OK_Otpusk].[DateEnd], null, 15, 1, FSH.id, idOtpuskPrikaz
  FROM [dbo].[OK_Otpusk] inner join FactStaff on [OK_Otpusk].[idFactStaff]=FactStaff.id
  LEFT JOIN FactStaffHistory FSH on FactStaff.id = FSH.[idFactStaff] and 
    FSH.DateBegin = (select max(DateBegin) from FactStaffHistory TempFSH where  TempFSH.idFactStaff = FactStaff.id
					 and DateBegin<=[OK_Otpusk].DateBegin)
  WHERE [OK_Otpusk].idFactStaffPrikaz is null
  and FSH.id is not null 

--   ссылка на event в [OK_Otpusk]  -------------------------------------------------------------------------------------------------------------------------------
  update [OK_Otpusk] set idFactStaffPrikaz = (select top(1) Event.id 
											  from Event,FactStaffHistory where Event.idPrikaz = [OK_Otpusk].idOtpuskPrikaz
											  and Event.idFactStaffHistory = FactStaffHistory.id and FactStaffHistory.idFactStaff = [OK_Otpusk].idFactStaff
											  and Event.DateBegin = [OK_Otpusk].DateBegin and Event.idEventKind = 15)
  where idFactStaffPrikaz is null