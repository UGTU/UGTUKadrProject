SELECT *
  FROM [Kadr].[dbo].[FactStaffHistory]
  --inner join dbo.Prikaz
--ON [FactStaffHistory].idBeginPrikaz=Prikaz.id
  where [FactStaffHistory].[id] not in
  (select [idFactStaffHistory] from [dbo].[Event]
  inner join [dbo].[EventKind] ON [Event].idEventKind=EventKind.id
	where EventKind.ForFactStaff = 1
  )
  and [FactStaffHistory].HourCount is null

  go
  /*delete 
  --select *
  from [dbo].[Contract]
  where id not in
  (select idContract from dbo.event where idContract is not null)
  */

 /*alter table dbo.Contract
 add idFactStaffHistory int null
 go*/
  
insert into dbo.[Contract]([ContractName],[DateContract],[DateBegin],[DateEnd], [idFactStaffHistory])
select distinct ISNULL(Prikaz.PrikazName, '<не внесен номер>'), [DatePrikaz],ISNULL([FactStaffHistory].[DateBegin],Prikaz.DateBegin),null, [FactStaffHistory].id
from [dbo].[FactStaffHistory]
inner join dbo.Prikaz
ON [FactStaffHistory].idBeginPrikaz=Prikaz.id
and [FactStaffHistory].[id] not in
  (select [idFactStaffHistory] from [dbo].[Event]
  inner join [dbo].[EventKind] ON [Event].idEventKind=EventKind.id
	where EventKind.ForFactStaff = 1 and idlaborcontrakt is null)

go


insert into dbo.[Contract]([ContractName],[DateContract],[DateBegin],[DateEnd], [idFactStaffHistory])
select distinct ISNULL(Prikaz.PrikazName, '<не внесен номер>'), [DatePrikaz],ISNULL([FactStaffHistory].[DateBegin],Prikaz.DateBegin),null, [FactStaffHistory].id
from [dbo].[FactStaffHistory]
inner join dbo.FactStaff on [FactStaffHistory].idFactStaff=FactStaff.id
inner join dbo.Prikaz
ON [FactStaffHistory].idBeginPrikaz=Prikaz.id
and [FactStaffHistory].[id] not in
  (select [idFactStaffHistory] from [dbo].[Event]
  inner join [dbo].[EventKind] ON [Event].idEventKind=EventKind.id
	where EventKind.ForFactStaff = 1 and idlaborcontrakt is null)

go
/*
update [dbo].[FactStaffHistory]
set [idContract]=[Contract].id
--select *
from  [dbo].[FactStaffHistory]
inner join dbo.Prikaz
ON [FactStaffHistory].idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] 
	ON (ISNULL([FactStaffHistory].[DateBegin],Prikaz.DateBegin)=[Contract].DateBegin or (Prikaz.DateBegin is null and [Contract].DateBegin is null))
	AND (Prikaz.DatePrikaz=[Contract].DateContract or (Prikaz.DatePrikaz is null and [Contract].DateContract is null))
	and [FactStaffHistory].[idContract] is null and [Contract].ContractName='<не внесен номер>'
	and [Contract].id not in (select ISNULL(idContract,0) from [dbo].[FactStaffHistory])

	delete from dbo.[Contract]
where  [ContractName]='<не внесен номер>'
and 
id not in (select isnull(idContract,0) from [dbo].[FactStaffHistory])
*/

go

--вносим переводы
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],3,[Contract].id
from dbo.FactStaffHistory
inner join dbo.[Contract] ON FactStaffHistory.id=[Contract].idFactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id

where Prikaz.idPrikazType=6 
and [Contract].id not in (select idContract from Event where idContract is not null)

go
--вносим ввод/вывод ставок
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],6,[Contract].id
from dbo.FactStaffHistory
inner join dbo.[Contract] ON FactStaffHistory.id=[Contract].idFactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id

where Prikaz.idPrikazType=7
and [Contract].id not in (select idContract from Event where idContract is not null)

go
--смена ист фин
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],4,[Contract].id
from dbo.FactStaffHistory
inner join dbo.[Contract] ON FactStaffHistory.id=[Contract].idFactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id

where Prikaz.idPrikazType =13
and [Contract].id not in (select idContract from Event where idContract is not null)

go
--вносим изменения оклада
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],5,[Contract].id
from dbo.FactStaffHistory
inner join dbo.[Contract] ON FactStaffHistory.id=[Contract].idFactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id

where (Prikaz.idPrikazType between 33 and 37 ) 
and [Contract].id not in (select idContract from Event where idContract is not null)
go
--вносим изменения условий труда
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],2,[Contract].id
from dbo.FactStaffHistory
inner join dbo.[Contract] ON FactStaffHistory.id=[Contract].idFactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id

where (Prikaz.idPrikazType not between 33 and 37 ) and Prikaz.idPrikazType not in (10,13,6,7)
and [Contract].id not in (select idContract from Event where idContract is not null)


go
--вносим приемы сотрудников
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],1,[Contract].id
from dbo.FactStaffHistory
inner join dbo.[Contract] ON FactStaffHistory.id=[Contract].idFactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id

where (Prikaz.idPrikazType =10 ) 
and [Contract].id not in (select idContract from Event where idContract is not null)

go

select * from Event where idEventKind = 4

--вносим почасовиков-договорников
select *
from [dbo].[FactStaffHistory]
where [id] not in (select [idFactStaffHistory] from [dbo].[Event])

insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], FactStaff.DateEnd,FactStaffHistory.[id],14,[Contract].id
from dbo.FactStaffHistory
inner join dbo.FactStaff on FactStaffHistory.idFactStaff=FactStaff.id
where FactStaffHistory.[id] not in (select [idFactStaffHistory] from [dbo].[Event])
and [Contract].id not in (select idContract from Event where idContract is not null)



select  *
from dbo.FactStaffHistory
INNER JOIN dbo.Event ON FactStaffHistory.id=Event.idFactStaffHistory
--inner join dbo.[Contract] ON FactStaffHistory.id=[Contract].idFactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id

where [idEventKind]=14 --(Prikaz.idPrikazType =10 ) 
--and [Contract].id not in (select idContract from Event where idContract is not null)


update dbo.Event
set [idEventKind]=6
--select *
from  dbo.Event
inner join dbo.FactStaffHistory
ON FactStaffHistory.id=Event.idFactStaffHistory
where [idEventKind]=14 and FactStaffHistory.HourCount is null
and 




