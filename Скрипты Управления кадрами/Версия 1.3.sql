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

--указываем им в доп соглашени€х договора


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


---------------------------------¬оенный учет---------------------------------------------------------------------------------------------
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MilitaryCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MilitaryCategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_MilitaryCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MilitaryFitness]    Script Date: 27.08.2015 13:33:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MilitaryFitness](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Letter] [varchar](10) NOT NULL,
	[Description] [varchar](500) NOT NULL,
 CONSTRAINT [PK_MilitaryFitness] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MilitaryRank]    Script Date: 27.08.2015 13:33:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MilitaryRank](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MilitaryRankName] [varchar](500) NOT NULL,
 CONSTRAINT [PK_MilitaryRank] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MilitaryStructure]    Script Date: 27.08.2015 13:33:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MilitaryStructure](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MilitaryStructureName] [varchar](500) NOT NULL,
 CONSTRAINT [PK_MilitaryStructure] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MilitaryType]    Script Date: 27.08.2015 13:33:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MilitaryType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[MilitaryTypeName] [varchar](500) NOT NULL,
 CONSTRAINT [PK_MilitaryType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OK_Military]    Script Date: 27.08.2015 13:33:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OK_Military](
	[id] [int] NOT NULL,
	[idEmployee] [int] NOT NULL,
	[idCategory] [int] NULL,
	[idRank] [int] NULL,
	[VUSCode] [varchar](50) NULL,
	[idFitness] [int] NULL,
	[MilitaryCommissariat] [varchar](900) NULL,
	[idType] [int] NULL,
	[RemovalMark] [varchar](900) NULL,
 CONSTRAINT [PK_OK_Military] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MilitaryCategory]    Script Date: 27.08.2015 13:33:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryCategory] ON [dbo].[MilitaryCategory]
(
	[MilitaryCategoryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MilitaryFitness]    Script Date: 27.08.2015 13:33:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryFitness] ON [dbo].[MilitaryFitness]
(
	[Letter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MilitaryFitness_1]    Script Date: 27.08.2015 13:33:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryFitness_1] ON [dbo].[MilitaryFitness]
(
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MilitaryRank]    Script Date: 27.08.2015 13:33:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryRank] ON [dbo].[MilitaryRank]
(
	[MilitaryRankName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MilitaryStructure]    Script Date: 27.08.2015 13:33:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryStructure] ON [dbo].[MilitaryStructure]
(
	[MilitaryStructureName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MilitaryType]    Script Date: 27.08.2015 13:33:32 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryType] ON [dbo].[MilitaryType]
(
	[MilitaryTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OK_Military]    Script Date: 27.08.2015 13:33:32 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Military] ON [dbo].[OK_Military]
(
	[idCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OK_Military_1]    Script Date: 27.08.2015 13:33:32 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Military_1] ON [dbo].[OK_Military]
(
	[idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OK_Military_2]    Script Date: 27.08.2015 13:33:32 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Military_2] ON [dbo].[OK_Military]
(
	[idFitness] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OK_Military_3]    Script Date: 27.08.2015 13:33:32 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Military_3] ON [dbo].[OK_Military]
(
	[idRank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OK_Military_4]    Script Date: 27.08.2015 13:33:32 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Military_4] ON [dbo].[OK_Military]
(
	[idType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_OK_Military_5]    Script Date: 27.08.2015 13:33:32 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Military_5] ON [dbo].[OK_Military]
(
	[MilitaryCommissariat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OK_Military]  WITH CHECK ADD  CONSTRAINT [FK_OK_Military_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[OK_Military] CHECK CONSTRAINT [FK_OK_Military_Employee]
GO
ALTER TABLE [dbo].[OK_Military]  WITH CHECK ADD  CONSTRAINT [FK_OK_Military_MilitaryCategory] FOREIGN KEY([idCategory])
REFERENCES [dbo].[MilitaryCategory] ([id])
GO
ALTER TABLE [dbo].[OK_Military] CHECK CONSTRAINT [FK_OK_Military_MilitaryCategory]
GO
ALTER TABLE [dbo].[OK_Military]  WITH CHECK ADD  CONSTRAINT [FK_OK_Military_MilitaryFitness] FOREIGN KEY([idFitness])
REFERENCES [dbo].[MilitaryFitness] ([id])
GO
ALTER TABLE [dbo].[OK_Military] CHECK CONSTRAINT [FK_OK_Military_MilitaryFitness]
GO
ALTER TABLE [dbo].[OK_Military]  WITH CHECK ADD  CONSTRAINT [FK_OK_Military_MilitaryRank] FOREIGN KEY([idRank])
REFERENCES [dbo].[MilitaryRank] ([id])
GO
ALTER TABLE [dbo].[OK_Military] CHECK CONSTRAINT [FK_OK_Military_MilitaryRank]
GO
ALTER TABLE [dbo].[OK_Military]  WITH CHECK ADD  CONSTRAINT [FK_OK_Military_MilitaryType] FOREIGN KEY([idType])
REFERENCES [dbo].[MilitaryType] ([id])
GO
ALTER TABLE [dbo].[OK_Military] CHECK CONSTRAINT [FK_OK_Military_MilitaryType]
GO

ALTER TABLE [dbo].[OK_Military] add idStructure int

/****** Object:  Index [IX_OK_Military_6]    Script Date: 27.08.2015 13:50:58 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Military_6] ON [dbo].[OK_Military]
(
	[idStructure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OK_Military]  WITH CHECK ADD  CONSTRAINT [FK_OK_Military_MilitaryStructure] FOREIGN KEY([idStructure])
REFERENCES [dbo].[MilitaryStructure] ([id])
GO
ALTER TABLE [dbo].[OK_Military] CHECK CONSTRAINT [FK_OK_Military_MilitaryStructure]
GO

----------------------- орректировка мат. ответственности---------------------------------------------------------------------------------------------------------------------
alter table [dbo].[MaterialResponsibility] add idFactStaffPrikazEnd int null
alter table [dbo].[MaterialResponsibility] add Perc numeric(4,2)

/****** Object:  Index [IX_MaterialResponsibility_2]    Script Date: 31.08.2015 9:52:19 ******/
CREATE NONCLUSTERED INDEX [IX_MaterialResponsibility_2] ON [dbo].[MaterialResponsibility]
(
	[idFactStaffPrikazEnd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MaterialResponsibility]  WITH CHECK ADD  CONSTRAINT [FK_MaterialResponsibility_FactStaffPrikaz1] FOREIGN KEY([idFactStaffPrikazEnd])
REFERENCES [dbo].[FactStaffPrikaz] ([id])
GO
ALTER TABLE [dbo].[MaterialResponsibility] CHECK CONSTRAINT [FK_MaterialResponsibility_FactStaffPrikaz1]
GO