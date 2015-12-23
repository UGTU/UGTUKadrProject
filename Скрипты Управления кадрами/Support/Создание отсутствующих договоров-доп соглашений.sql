
--добавление договора и доп соглашения
alter table [dbo].[FactStaffHistory]
add idContract int null


go
--добавляем соответ столбец в Contract, чтобы знать к какому приказу он привязан
alter table [dbo].[Contract]
add idlaborContract_Prikaz int

go
update [dbo].[Contract]
set idlaborContract_Prikaz=ISNULL(FactStaffHistory.idlaborcontrakt,FactStaff.idlaborcontrakt)
--select *
from [dbo].[Contract]
inner join dbo.[Event] on [Event].idContract=[Contract].id
inner join dbo.FactStaffHistory on [Event].idFactStaffHistory=FactStaffHistory.id
inner join dbo.FactStaff on FactStaffHistory.idFactStaff=FactStaff.id
inner join dbo.EventKind on [Event].[idEventKind]=EventKind.id
where EventKind.ForFactStaff=1
and (FactStaffHistory.idlaborcontrakt is not null or FactStaff.idlaborcontrakt is not null)
--inner join dbo.Prikaz on [Contract].


go
insert into dbo.[Contract]([ContractName],[DateContract],[idPrikazType],[DateBegin],[DateEnd])
select [PrikazName], [DatePrikaz],[idPrikazType],[DateBegin],[DateEnd]
from [dbo].[Prikaz]
  where
 ( Prikaz.id in (select idlaborcontrakt from dbo.FactStaff where )
  or
   Prikaz.id in (select idlaborcontrakt from dbo.FactStaffHistory))
  







  update dbo.FactStaffHistory
  set idContract=[Contract].id
  --select *
  from 
   dbo.FactStaffHistory 
  inner join dbo.Prikaz ON FactStaffHistory.idlaborcontrakt=Prikaz.id
  -- where FactStaffHistory.idlaborcontrakt is not null
inner join dbo.[Contract]
   ON ([Prikaz].DateBegin=[Contract].DataBegin or ([Prikaz].DateBegin IS NULL AND [Contract].DataBegin IS NULL))
    and ([Prikaz].DateEnd=[Contract].DataEnd OR ([Prikaz].DateEnd IS NULL AND [Contract].DataEnd IS NULL))
	 and [Prikaz].PrikazName=[Contract].ContractName  and [Prikaz].DatePrikaz=[Contract].DateContract 
	 and [Prikaz].idPrikazType=[Contract].idPrikazType




  update dbo.FactStaffHistory
  set idContract=[Contract].id
  --select *
  from 
   dbo.FactStaffHistory 
   inner join dbo.FactStaff ON FactStaffHistory.idFactStaff=FactStaff.id
  inner join dbo.Prikaz ON FactStaff.idlaborcontrakt=Prikaz.id
  -- where FactStaffHistory.idlaborcontrakt is not null
inner join dbo.[Contract]
   ON ([Prikaz].DateBegin=[Contract].DataBegin or ([Prikaz].DateBegin IS NULL AND [Contract].DataBegin IS NULL))
    and ([Prikaz].DateEnd=[Contract].DataEnd OR ([Prikaz].DateEnd IS NULL AND [Contract].DataEnd IS NULL))
	 and [Prikaz].PrikazName=[Contract].ContractName  and [Prikaz].DatePrikaz=[Contract].DateContract 
	 and [Prikaz].idPrikazType=[Contract].idPrikazType
	 where FactStaffHistory.idContract is null

	 

update [dbo].[FactStaff]
set [idreason]=null
where [idreason]=0


GO

ALTER TABLE [dbo].[FactStaff]  WITH CHECK ADD  CONSTRAINT [FK_FactStaff_OK_Reason] FOREIGN KEY([idreason])
REFERENCES [dbo].[OK_Reason] ([idreason])
GO

ALTER TABLE [dbo].[FactStaff] CHECK CONSTRAINT [FK_FactStaff_OK_Reason]
GO

GO

ALTER TABLE [dbo].[FactStaffHistory]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffHistory_Contract] FOREIGN KEY([idContract])
REFERENCES [dbo].[Contract] ([id])
GO

ALTER TABLE [dbo].[FactStaffHistory] CHECK CONSTRAINT [FK_FactStaffHistory_Contract]
GO





select *
from [dbo].[Contract]
where [idPrikazType]!=27



update [dbo].[Contract]
set idMainContract=[Contract].id
--from [dbo].[Contract]
where [idPrikazType]!=27




--те, у кого только один договор внесен
select Employee.id, COUNT(distinct [Contract].id)

from dbo.Employee inner join
dbo.FactStaff on Employee.id=FactStaff.idEmployee
 inner join
dbo.FactStaffHistory on FactStaff.id=FactStaffHistory.idFactStaff
 inner join
dbo.[Contract] on [Contract].id=FactStaffHistory.idContract
where [Contract].idPrikazType=27
group by Employee.id
having COUNT(distinct [Contract].id)=1

--указываем им в доп соглашениях договора


update dbo.[Contract]
set [Contract].idMainContract=UniqueContract.idContract
--select * 
from

--dbo.Employee inner join
dbo.FactStaff --on Employee.id=FactStaff.
 inner join
dbo.FactStaffHistory on FactStaff.id=FactStaffHistory.idFactStaff
 inner join
dbo.[Contract] on [Contract].id=FactStaffHistory.idContract
--inner join dbo.[Contract] MainContract on [Contract].id=FactStaffHistory.idContract
inner join
	(select distinct Empl.id idEmployee, [Contract].id idContract
	from
	(select Employee.id--, COUNT(distinct [Contract].id)

	from dbo.Employee inner join
	dbo.FactStaff on Employee.id=FactStaff.idEmployee
	 inner join
	dbo.FactStaffHistory on FactStaff.id=FactStaffHistory.idFactStaff
	 inner join
	dbo.[Contract] on [Contract].id=FactStaffHistory.idContract
	where [Contract].idPrikazType=27
	group by Employee.id
	having COUNT(distinct [Contract].id)=1)empl
	 inner join
	dbo.FactStaff on empl.id=FactStaff.idEmployee
	 inner join
	dbo.FactStaffHistory on FactStaff.id=FactStaffHistory.idFactStaff
	 inner join
	dbo.[Contract] on [Contract].id=FactStaffHistory.idContract
	where [Contract].idPrikazType=27)UniqueContract
	ON FactStaff.idEmployee=UniqueContract.idEmployee
where [Contract].idPrikazType!=27
--and  in


