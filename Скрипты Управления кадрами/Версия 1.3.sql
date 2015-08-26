--ƒоговора и доп соглашени€ сотрудника

alter table Contract 
add [idMainContract] int null
go
CREATE NONCLUSTERED INDEX [IX_Contract_idMainContract] ON [dbo].[Contract]
(
	[idMainContract] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Contract] FOREIGN KEY([idMainContract])
REFERENCES [dbo].[Contract] ([id])
GO

ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Contract]
GO

--добавление договора и доп соглашени€
alter table [dbo].[FactStaffHistory]
add idContract int null


  --убираем неуникальные строки из ѕриказа (договора)
  select *
  from [dbo].[Prikaz] inner join
  (select [PrikazName], [DatePrikaz], [DateBegin], [idPrikazType], [DateEnd], CONVERT(varchar(500), [resume]) resume, COUNT(id) col
  from dbo.Prikaz
  where
  Prikaz.id in (select idlaborcontrakt from dbo.FactStaff)
  or
   Prikaz.id in (select idlaborcontrakt from dbo.FactStaffHistory) 
   GROUP BY [PrikazName], [DatePrikaz], [DateBegin], [idPrikazType], [DateEnd], CONVERT(varchar(500), [resume])
   HAVING COUNT(id)>1)doublePrikaz
   ON [Prikaz].DateBegin=doublePrikaz.DateBegin and ([Prikaz].DateEnd=doublePrikaz.DateEnd OR ([Prikaz].DateEnd IS NULL AND doublePrikaz.DateEnd IS NULL))
	 and [Prikaz].PrikazName=doublePrikaz.PrikazName  and [Prikaz].DatePrikaz=doublePrikaz.DatePrikaz  
	 and [Prikaz].idPrikazType=doublePrikaz.idPrikazType
--1
update dbo.FactStaff
set idlaborcontrakt=22049
where idlaborcontrakt=22088

update dbo.FactStaffHistory
set idlaborcontrakt=22049
where idlaborcontrakt=22088

delete from dbo.Prikaz
where id=22088

--2
update dbo.FactStaff
set idlaborcontrakt=4839
where idlaborcontrakt=9530

update dbo.FactStaffHistory
set idlaborcontrakt=4839
where idlaborcontrakt=9530

delete from dbo.Prikaz
where id=9530

--3
update dbo.FactStaff
set idlaborcontrakt=11744
where idlaborcontrakt=11745

update dbo.FactStaffHistory
set idlaborcontrakt=11744
where idlaborcontrakt=11745

delete from dbo.Prikaz
where id=11745

--4
update dbo.FactStaff
set idlaborcontrakt=10157
where idlaborcontrakt=10159

update dbo.FactStaffHistory
set idlaborcontrakt=10157
where idlaborcontrakt=10159

delete from dbo.Prikaz
where id=10159

--5
update dbo.FactStaff
set idlaborcontrakt=6775
where idlaborcontrakt=9439

update dbo.FactStaffHistory
set idlaborcontrakt=6775
where idlaborcontrakt=9439

delete from dbo.Prikaz
where id=9439

go
alter table Contract 
add [idPrikazType] int null

go
insert into dbo.[Contract]([ContractName],[DateContract],[idPrikazType],[DataBegin],[DataEnd])
select [PrikazName], [DatePrikaz],[idPrikazType],[DateBegin],[DateEnd]
from [dbo].[Prikaz]
  where
 ( Prikaz.id in (select idlaborcontrakt from dbo.FactStaff)
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






