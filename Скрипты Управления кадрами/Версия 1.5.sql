

EXEC sp_rename 'dbo.FactStaffHistory', 'Event'


go

alter table [dbo].[Event]
add [idFactStaffHistory] int null

go
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_FactStaffHistory] FOREIGN KEY([idFactStaffHistory])
REFERENCES [dbo].[FactStaffHistory] ([id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_FactStaffHistory]
GO




go
update [dbo].[Event]
set [idFactStaffHistory]=MAXID
--select *
from 
[dbo].[Event]
inner join
(SELECT idFactStaff, MAX([FactStaffHistory].[id])  MAXID
FROM
 [dbo].[FactStaffHistory]
GROUP BY idFactStaff )MaxFactStaffHistory
  ON [Event].idFactStaff=MaxFactStaffHistory.idFactStaff

  /*--проверка правильности - ничего не должен выбрать
  select *
  from [dbo].[FactStaffHistoryEvent]
  inner join [FactStaffHistory] ON [FactStaffHistoryEvent].idFactStaffHistory=FactStaffHistory.id
  inner join [dbo].[FactStaff] on [FactStaffHistoryEvent].idFactStaff=[FactStaff].id and FactStaffHistory.idFactStaff<>[FactStaff].id 

  */





  GO

CREATE TABLE [dbo].[EventKind](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventKindName] [varchar](500) NOT NULL,
	[idMainEventKind] [int] NULL,
 CONSTRAINT [PK_EventKind] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EventKind_EventKindName] UNIQUE NONCLUSTERED 
(
	[EventKindName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EventKind]  WITH CHECK ADD  CONSTRAINT [FK_EventKind_EventKind] FOREIGN KEY([idMainEventKind])
REFERENCES [dbo].[EventKind] ([id])
GO

ALTER TABLE [dbo].[EventKind] CHECK CONSTRAINT [FK_EventKind_EventKind]
GO



GO

/****** Object:  Index [IX_EventKind_idMainEventKind]    Script Date: 09.09.2015 15:55:20 ******/
CREATE NONCLUSTERED INDEX [IX_EventKind_idMainEventKind] ON [dbo].[EventKind]
(
	[idMainEventKind] ASC
)

GO

/****** Object:  Index [IX_EventKind_EventKindName]    Script Date: 09.09.2015 15:55:16 ******/
ALTER TABLE [dbo].[EventKind] ADD  CONSTRAINT [IX_EventKind_EventKindName] UNIQUE NONCLUSTERED 
(
	[EventKindName] ASC
)



go
alter table [dbo].[Event]
add idEventKind int

go


GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventKind] FOREIGN KEY([idEventKind])
REFERENCES [dbo].[EventKind] ([id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventKind]
GO


GO

/****** Object:  Index [IX_Event_idEventKind]    Script Date: 09.09.2015 16:04:47 ******/
CREATE NONCLUSTERED INDEX [IX_Event_idEventKind] ON [dbo].[Event]
(
	[idEventKind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

GO

/****** Object:  Index [IX_Event_idFactStaffHistory]    Script Date: 09.09.2015 16:05:03 ******/
CREATE NONCLUSTERED INDEX [IX_Event_idFactStaffHistory] ON [dbo].[Event]
(
	[idFactStaffHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO













---ТИп события
GO

  GO

CREATE TABLE [dbo].[EventType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeName] [varchar](500) NOT NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_EvenType_EventTypeName] UNIQUE NONCLUSTERED 
(
	[EventTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF




/****** Object:  Index [IX_EventKind_EventKindName]    Script Date: 09.09.2015 15:55:16 ******/
ALTER TABLE [dbo].[EventType] ADD  CONSTRAINT [IX_EventType_EventTypeName] UNIQUE NONCLUSTERED 
(
	[EventTypeName] ASC
)



go
alter table [dbo].[Event]
add idEventType int

go


GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType] FOREIGN KEY([idEventType])
REFERENCES [dbo].[EventType] ([id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType]
GO


GO

/****** Object:  Index [IX_Event_idEventKind]    Script Date: 09.09.2015 16:04:47 ******/
CREATE NONCLUSTERED INDEX [IX_Event_idEventType] ON [dbo].[Event]
(
	[idEventType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

GO


insert into [dbo].[EventType]([EventTypeName])
values('Назначение')

GO
GO

ALTER TABLE [dbo].[Event] ADD  CONSTRAINT [DF_Event_idEventType]  DEFAULT ((1)) FOR [idEventType]
GO

set identity_insert [dbo].[EventKind] ON
insert into [dbo].[EventKind]([id],[EventKindName])
values(15,'Отпуск')
set identity_insert [dbo].[EventKind] OFF

go
update [dbo].[Event]
set [idEventType]=1

go
update [dbo].[Event]
set [idEventKind]=15
where id IN (select [idFactStaffPrikaz] from [dbo].[OK_Otpusk])



go
alter table [dbo].[Event]
add idContract int null

go
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Contract] FOREIGN KEY([idContract])
REFERENCES [dbo].[Contract] ([id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Contract]
GO

GO

/****** Object:  Index [IX_Event_idContract]    Script Date: 09.09.2015 16:25:32 ******/
CREATE NONCLUSTERED INDEX [IX_Event_idContract] ON [dbo].[Event]
(
	[idContract] ASC
)
GO



go
select *
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id




go
EXEC sp_rename 'dbo.Event.idMainFactStaffPrikaz', 'idMainEvent', 'COLUMN'


go
EXEC sp_rename '[dbo].[BusinessTrip].[idFactStaffPrikaz]', 'idEvent', 'COLUMN'

go
alter table [dbo].[Event]
drop constraint [FK_FactStaffPrikaz_FactStaff]
go
DROP INDEX [IX_FactStaffPrikazidFactStaff] 
    ON [dbo].[Event]

go
alter table [dbo].[Event]
drop column [idFactStaff]
		

go
EXEC sp_rename '[dbo].[MaterialResponsibility].[idFactStaffPrikaz]', 'idEvent', 'COLUMN'


go
EXEC sp_rename '[dbo].[Validation].[idFactStaffPrikaz]', 'idEvent', 'COLUMN'



go
EXEC sp_rename '[dbo].[OK_DopEducation].[idFactStaffPrikaz]', 'idEvent', 'COLUMN'




go
EXEC sp_rename '[dbo].[Award].[idFactStaffPrikaz]', 'idEvent', 'COLUMN'



go
EXEC sp_rename '[dbo].[SocialFareTransit].[idFactStaffPrikaz]', 'idEvent', 'COLUMN'




go
EXEC sp_rename '[dbo].[SocialFareTransit].[idFactStaffPrikaz]', 'idEvent', 'COLUMN'


go
alter table [dbo].[OK_DopEducation]
drop constraint [FK_OK_DopEducEmployee_FactStaffPrikaz]

GO

ALTER TABLE [dbo].[OK_DopEducation]  WITH CHECK ADD  CONSTRAINT [FK_OK_DopEducEmployee_Event] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([id])
GO

ALTER TABLE [dbo].[OK_DopEducation] CHECK CONSTRAINT [FK_OK_DopEducEmployee_Event]
GO



GO

ALTER TABLE [dbo].[Award] DROP CONSTRAINT [FK_Award_FactStaffPrikaz]
GO

GO

ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_Event] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([id])
GO

ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_Event]
GO




GO

ALTER TABLE [dbo].[Validation] DROP CONSTRAINT [FK_Validation_FactStaffPrikaz]
GO


GO

ALTER TABLE [dbo].[Validation]  WITH CHECK ADD  CONSTRAINT [FK_Validation_FactStaffPrikaz] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([id])
GO

ALTER TABLE [dbo].[Validation] CHECK CONSTRAINT [FK_Validation_FactStaffPrikaz]
GO



GO

ALTER TABLE [dbo].[OK_Otpusk] DROP CONSTRAINT [FK_OK_Otpusk_FactStaffPrikaz]
GO

GO

ALTER TABLE [dbo].[OK_Otpusk]  WITH CHECK ADD  CONSTRAINT [FK_OK_Otpusk_FactStaffPrikaz] FOREIGN KEY([idFactStaffPrikaz])
REFERENCES [dbo].[Event] ([id])
GO

ALTER TABLE [dbo].[OK_Otpusk] CHECK CONSTRAINT [FK_OK_Otpusk_FactStaffPrikaz]
GO



GO

ALTER TABLE [dbo].[SocialFareTransit] DROP CONSTRAINT [FK_SocialFareTransit_FactStaff]
GO

GO

ALTER TABLE [dbo].[SocialFareTransit]  WITH CHECK ADD  CONSTRAINT [FK_SocialFareTransit_Event] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([id])
GO

ALTER TABLE [dbo].[SocialFareTransit] CHECK CONSTRAINT [FK_SocialFareTransit_Event]
GO





set identity_insert [dbo].[EventKind] ON
insert into [dbo].[EventKind]([id],[EventKindName])
values(1,'Прием сотрудника')

insert into [dbo].[EventKind]([id],[EventKindName])
values(2,'Изменение условий трудового договора')


set identity_insert [dbo].[EventKind] OFF





go
ALTER TABLE [dbo].[Event]
ALTER COLUMN [idPrikaz] INT NULL

/****** Object:  Table [dbo].[Event_MaterialResponsibility]    Script Date: 12.09.2015 14:11:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_MaterialResponsibility](
	[idEvent] [int] NOT NULL,
	[idMaterialResponsibility] [int] NOT NULL,
 CONSTRAINT [PK_Event_MaterialResponsibility] PRIMARY KEY CLUSTERED 
(
	[idEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Table_Event]    Script Date: 12.09.2015 14:11:50 ******/
CREATE NONCLUSTERED INDEX [IX_Table_Event] ON [dbo].[Event_MaterialResponsibility]
(
	[idEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Table_Material]    Script Date: 12.09.2015 14:11:50 ******/
CREATE NONCLUSTERED INDEX [IX_Table_Material] ON [dbo].[Event_MaterialResponsibility]
(
	[idMaterialResponsibility] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Event_MaterialResponsibility]  WITH CHECK ADD  CONSTRAINT [FK_Event_MaterialResponsibility_Event] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([id])
GO
ALTER TABLE [dbo].[Event_MaterialResponsibility] CHECK CONSTRAINT [FK_Event_MaterialResponsibility_Event]
GO
ALTER TABLE [dbo].[Event_MaterialResponsibility]  WITH CHECK ADD  CONSTRAINT [FK_Event_MaterialResponsibility_MaterialResponsibility] FOREIGN KEY([idMaterialResponsibility])
REFERENCES [dbo].[MaterialResponsibility] ([id])
GO
ALTER TABLE [dbo].[Event_MaterialResponsibility] CHECK CONSTRAINT [FK_Event_MaterialResponsibility_MaterialResponsibility]
GO

delete from MaterialResponsibility
DROP INDEX MaterialResponsibility.IX_MaterialResponsibility_1
ALTER TABLE MaterialResponsibility DROP CONSTRAINT FK_MaterialResponsibility_FactStaffPrikaz
alter table MaterialResponsibility drop column [idEvent]
DROP INDEX MaterialResponsibility.IX_MaterialResponsibility
ALTER TABLE MaterialResponsibility DROP CONSTRAINT FK_MaterialResponsibility_Contract
alter table MaterialResponsibility drop column idContract

go
select *
from dbo.FactStaffHistory
where idContract is null

go
--вносим приемы на работу
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],1,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where Prikaz.idPrikazType=10  

go
alter table [dbo].[EventKind]
add EventKindApplName VARCHAR(100)

go
set identity_insert [dbo].[EventKind] ON
insert into [dbo].[EventKind]([id],[EventKindName], EventKindApplName)
values(3,'Перевод сотрудника','')

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [DecoratorName])
values(4,'Смена источника финансирования',2,'Источник финанасирования', 'Kadr.Data.FactStaffHistoryFinSourceDecorator')

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [DecoratorName])
values(5,'Установление должностного оклада',2,'Должностной оклад', 'Kadr.Data.FactStaffHistoryMinDecorator')

insert into [dbo].[EventKind]([id],[EventKindName])
values(6,'Ввод/вывод ставок')

insert into [dbo].[EventKind]([id],[EventKindName])
values(14,'Прием почасовика по договору')
set identity_insert [dbo].[EventKind] OFF

go
--вносим переводы
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  *--[idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],3,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where Prikaz.idPrikazType=6

go
--вносим ввод/вывод ставок
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],6,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where Prikaz.idPrikazType=7

go
--смена ист фин
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],4,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where Prikaz.idPrikazType =13

go
--вносим изменения оклада
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],5,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where (Prikaz.idPrikazType between 33 and 37 ) 
go
--вносим изменения условий труда
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],2,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where (Prikaz.idPrikazType not between 33 and 37 ) and Prikaz.idPrikazType not in (10,13,6,7)

go

--вносим почасовиков-договорников
select *
from [dbo].[FactStaffHistory]
where [id] not in (select [idFactStaffHistory] from [dbo].[Event])

insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], FactStaff.DateEnd,FactStaffHistory.[id],14,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.FactStaff on FactStaffHistory.idFactStaff=FactStaff.id
where FactStaffHistory.[id] not in (select [idFactStaffHistory] from [dbo].[Event])

go
alter table [dbo].EventKind
add ForFactStaff BIT NULL


go
update [dbo].[EventKind]
set [ForFactStaff]=1
where [id]<15
go
update [dbo].[EventKind]
set [ForFactStaff]=0
where [id]>=15

go
alter table [dbo].[EventKind]
alter column ForFactStaff bit not null

GO

ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_FactStaffHistoryEvent_FactStaffHistory]
GO
GO

/****** Object:  Index [IX_Event_idFactStaffHistory]    Script Date: 13.09.2015 11:48:36 ******/
DROP INDEX [IX_Event_idFactStaffHistory] ON [dbo].[Event]

go
alter table [dbo].[Event]
alter column [idFactStaffHistory] int not null
GO
GO

/****** Object:  Index [IX_Event_idFactStaffHistory]    Script Date: 13.09.2015 11:48:44 ******/
CREATE NONCLUSTERED INDEX [IX_Event_idFactStaffHistory] ON [dbo].[Event]
(
	[idFactStaffHistory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffHistoryEvent_FactStaffHistory] FOREIGN KEY([idFactStaffHistory])
REFERENCES [dbo].[FactStaffHistory] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_FactStaffHistoryEvent_FactStaffHistory]
GO

ALTER TABLE [dbo].[FactStaffHistory] DROP CONSTRAINT [FK_FactStaffHistory_Contract]
GO
alter table dbo.FactStaffHistory
drop column idContract




GO

ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_Contract]
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_Contract] FOREIGN KEY([idContract])
REFERENCES [dbo].[Contract] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_Contract]
GO
GO
/*
ALTER TABLE [dbo].[Event] DROP CONSTRAINT [FK_Event_EventKind]
GO

GO

/****** Object:  Index [IX_Event_idEventKind]    Script Date: 13.09.2015 11:50:31 ******/
DROP INDEX [IX_Event_idEventKind] ON [dbo].[Event]
GO

alter table [dbo].[Event]
alter column [idEventKind] int not null
go

/****** Object:  Index [IX_Event_idEventKind]    Script Date: 13.09.2015 11:50:31 ******/
CREATE NONCLUSTERED INDEX [IX_Event_idEventKind] ON [dbo].[Event]
(
	[idEventKind] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
GO

ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventKind] FOREIGN KEY([idEventKind])
REFERENCES [dbo].[EventKind] ([id])
GO

ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventKind]
GO*/





GO

ALTER TABLE [dbo].[EmployeeRank] DROP CONSTRAINT [FK_EmployeeZvanye_Employee]
GO

ALTER TABLE [dbo].[EmployeeRank]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeRank_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EmployeeRank] CHECK CONSTRAINT [FK_EmployeeRank_Employee]
GO


GO

ALTER TABLE [dbo].[EmployeeDegree] DROP CONSTRAINT [FK_EmployeeDegree_Employee]
GO

ALTER TABLE [dbo].[EmployeeDegree]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDegree_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[EmployeeDegree] CHECK CONSTRAINT [FK_EmployeeDegree_Employee]
GO



delete
--select *
from dbo.Employee
where id not in (select ISNULL(idEmployee,0) from dbo.FactStaff)
and itab_n is null


select *
from dbo.Employee
where [LastName] like '%true%'




go
update [dbo].[RegionType]
set [RegionTypeName]='Без особых условий', [RegionTypeSmallName]='БОУ'
where id=1




go
alter table [dbo].[EventKind]
add DecoratorName VARCHAR(500) NULL



go
update [dbo].[RegionType]
set [RegionTypeName]='Бех особых условий', [RegionTypeSmallName]='БОУ'
where id=1


================================================
Необязательное поле "Организация" для наград
=================================================
/*
   23 сентября 2015 г.16:47:58
   Пользователь: 
   Сервер: ugtudb
   База данных: KadrRealTest
   Приложение: 
*/

/* Чтобы предотвратить возможность потери данных, необходимо внимательно просмотреть этот скрипт, прежде чем запускать его вне контекста конструктора баз данных.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Award
	DROP CONSTRAINT FK_Award_Event
GO
ALTER TABLE dbo.Event SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Award
	DROP CONSTRAINT FK_Award_AwardLevel
GO
ALTER TABLE dbo.AwardLevel SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Award
	DROP CONSTRAINT FK_Award_AwardType
GO
ALTER TABLE dbo.AwardType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Award
	DROP CONSTRAINT FK_Award_Employee
GO
ALTER TABLE dbo.Employee SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Award
	DROP CONSTRAINT FK_Award_EducDocument
GO
ALTER TABLE dbo.EducDocument SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Award
	(
	ID int NOT NULL IDENTITY (1, 1),
	Name nvarchar(100) NULL,
	IDEmployee int NOT NULL,
	IDEducDocument int NOT NULL,
	IDAwardType int NOT NULL,
	idEvent int NULL,
	IDAwardLevel int NOT NULL,
	Organization nvarchar(100) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Award SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Award ON
GO
IF EXISTS(SELECT * FROM dbo.Award)
	 EXEC('INSERT INTO dbo.Tmp_Award (ID, Name, IDEmployee, IDEducDocument, IDAwardType, idEvent, IDAwardLevel)
		SELECT ID, CONVERT(nvarchar(100), Name), IDEmployee, IDEducDocument, IDAwardType, idEvent, IDAwardLevel FROM dbo.Award WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Award OFF
GO
DROP TABLE dbo.Award
GO
EXECUTE sp_rename N'dbo.Tmp_Award', N'Award', 'OBJECT' 
GO
ALTER TABLE dbo.Award ADD CONSTRAINT
	PK_Award PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Award ADD CONSTRAINT
	FK_Award_EducDocument FOREIGN KEY
	(
	IDEducDocument
	) REFERENCES dbo.EducDocument
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Award ADD CONSTRAINT
	FK_Award_Employee FOREIGN KEY
	(
	IDEmployee
	) REFERENCES dbo.Employee
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Award ADD CONSTRAINT
	FK_Award_AwardType FOREIGN KEY
	(
	IDAwardType
	) REFERENCES dbo.AwardType
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Award ADD CONSTRAINT
	FK_Award_AwardLevel FOREIGN KEY
	(
	IDAwardLevel
	) REFERENCES dbo.AwardLevel
	(
	ID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Award ADD CONSTRAINT
	FK_Award_Event FOREIGN KEY
	(
	idEvent
	) REFERENCES dbo.Event
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT

=======================================
Добавляем новый справочник "Ведомство"
=======================================
CREATE TABLE [dbo].[GovDepartment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_GovDepartment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [U_Name] UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

=========================================
Привязываем "Ведомство" к награде
=========================================
BEGIN TRANSACTION
GO
ALTER TABLE dbo.GovDepartment SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Award ADD
	IDGovDepartment int NULL
GO
ALTER TABLE dbo.Award ADD CONSTRAINT
	FK_Award_GovDepartment FOREIGN KEY
	(
	IDGovDepartment
	) REFERENCES dbo.GovDepartment
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Award SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

=========================================
Слабая сущность "Событие командировки"
=========================================
CREATE TABLE [dbo].[Event_BusinessTrip](
	[idEvent] [int] NOT NULL,
	[idBusinessTrip] [int] NOT NULL,
 CONSTRAINT [PK_Event_BusinessTrip] PRIMARY KEY CLUSTERED 
(
	[idEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

========================================
Изменяем "Командировку" для связи со слабой сущностью, также добавляем "Дни в дороге"
========================================

BEGIN TRANSACTION
GO
ALTER TABLE dbo.BusinessTrip
	DROP CONSTRAINT FK_BusinessTrip_FactStaffPrikaz
GO
ALTER TABLE dbo.Event SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.BusinessTrip ADD
	DaysInRoad int NULL
GO
ALTER TABLE dbo.BusinessTrip
	DROP CONSTRAINT IX_BusinessTrip_idFactStaffPrikaz
GO
ALTER TABLE dbo.BusinessTrip
	DROP COLUMN idEvent
GO
ALTER TABLE dbo.BusinessTrip SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

=======================================
Связи для слабой сущности "Событие командировки"
=======================================

BEGIN TRANSACTION
GO
ALTER TABLE dbo.Event_BusinessTrip ADD CONSTRAINT
	FK_Event_BusinessTrip_Event FOREIGN KEY
	(
	idEvent
	) REFERENCES dbo.Event
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Event_BusinessTrip ADD CONSTRAINT
	FK_Event_BusinessTrip_BusinessTrip FOREIGN KEY
	(
	idBusinessTrip
	) REFERENCES dbo.BusinessTrip
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Event_BusinessTrip SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
set identity_insert [dbo].AwardType ON

DROP INDEX  SocialFareTransit.IX_SocialFareTransitidFactStaffPrikaz
alter table [dbo].[SocialFareTransit] drop FK_SocialFareTransit_Event
alter table [dbo].[SocialFareTransit] drop column [idEvent]

alter table [dbo].[SocialFareTransit] add idPrikaz int null

/****** Object:  Index [IX_SocialFareTransit_prikaz]    Script Date: 30.09.2015 10:43:12 ******/
CREATE NONCLUSTERED INDEX [IX_SocialFareTransit_prikaz] ON [dbo].[SocialFareTransit]
(
	[idPrikaz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SocialFareTransit]  WITH CHECK ADD  CONSTRAINT [FK_SocialFareTransit_Prikaz] FOREIGN KEY([idPrikaz])
REFERENCES [dbo].[Prikaz] ([id])
GO
ALTER TABLE [dbo].[SocialFareTransit] CHECK CONSTRAINT [FK_SocialFareTransit_Prikaz]
GO

set identity_insert [dbo].[PrikazType] ON
insert into [dbo].[PrikazType]([id],[PrikazTypeName],idPrikazSuperType)
values(43,'Льготный проезд',1)
set identity_insert [dbo].[PrikazType] OFF







go
set identity_insert [dbo].[EventKind] ON

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [ForFactStaff], [DecoratorName],[WithContract])
values(7,'Продление договора',2,'Срок действия',1,'Kadr.Data.FactStaffHistoryMinDecorator',1)

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [ForFactStaff], [DecoratorName],[WithContract])
values(8,'Изменение размера ставки',2,'Размер ставки',1,'Kadr.Data.FactStaffHistoryStaffCountDecorator',1)

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [ForFactStaff], [DecoratorName],[WithContract])
values(9,'Присвоение квалификационной категории ПП',2,'Квалификационная категория ПП',1,'Kadr.Data.FactStaffHistoryPPCategoryDecorator',1)

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [ForFactStaff], [DecoratorName],[WithContract])
values(10,'Назначение замещения',null,'Назначение замещения',1,null,1)


insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [ForFactStaff], [DecoratorName],[WithContract])
values(11,'Прием почасовика',null,'Прием почасовика',1,null,0)
set identity_insert [dbo].[EventKind] OFF



/*go
alter table [dbo].[FactStaffHistory]
add [idFinancingSource] */


go
alter table [dbo].[Employee]
add email varchar(100) 
go
update [dbo].[Employee]
set email=[EmployeeLogin]


go
alter table [dbo].[SalaryKoeff]
add CategoryPPName varchar(150) null
go
alter table dbo.FactStaffHistory
add idFinancingSource int null

GO

ALTER TABLE [dbo].[FactStaffHistory]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffHistory_FinancingSource] FOREIGN KEY([idFinancingSource])
REFERENCES [dbo].[FinancingSource] ([id])
GO

ALTER TABLE [dbo].[FactStaffHistory] CHECK CONSTRAINT [FK_FactStaffHistory_FinancingSource]
GO

GO

/****** Object:  Index [IX_FactStaffHistory_idFinancingSource]    Script Date: 02.10.2015 18:35:04 ******/
CREATE NONCLUSTERED INDEX [IX_FactStaffHistory_idFinancingSource] ON [dbo].[FactStaffHistory]
(
	[idFinancingSource] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


GO


/*select * from [FactStaffCurrent] where id = 172 order by DateBegin
Представление со всеми текущими параметрами FactStaff (DateBegin...) */
alter VIEW [dbo].[FactStaffCurrent]
AS
SELECT        dbo.FactStaff.id, dbo.FactStaffHistory.StaffCount, dbo.FactStaffHistory.HourCount, dbo.FactStaffHistory.HourSalary, dbo.FactStaff.idPlanStaff, 
				dbo.FactStaff.idEmployee, dbo.FactStaffHistory.idBeginPrikaz, dbo.FactStaff.idEndPrikaz, 
                         dbo.FactStaffHistory.idTypeWork, CONVERT(date, dbo.FactStaffHistory.DateBegin) AS DateBegin, CONVERT(date, dbo.FactStaff.DateEnd) AS DateEnd, 
                         dbo.FactStaff.IsReplacement, dbo.FactStaffHistory.id AS idFactStaffHistory, dbo.FactStaff.DateEnd AS DateEndR, dbo.FactStaffHistory.DateBegin AS DateBeginR, 
                         dbo.FactStaff.idlaborcontrakt AS idLaborContaraktMain, dbo.FactStaffHistory.idlaborcontrakt AS idLaborContraktHistory,
                         FactStaff.idFundingDepartment, FactStaff.idFundingCenter,FactStaff.idMainFactStaff,FactStaff.idDepartment,FactStaffHistory.[idFinancingSource],
	FactStaffHistory.idSalaryKoeff, FactStaffHistory.[HourStaffCount],[CalcStaffCount], PhoneNumber, FactStaff.idOKVED
FROM            dbo.FactStaff INNER JOIN
                         dbo.FactStaffHistory ON dbo.FactStaff.id = dbo.FactStaffHistory.idFactStaff 
                             INNER JOIN
					  (SELECT   FactStaffHistory.idFactStaff,  MAX(DateBegin) AS LastDateBegin
                            FROM          dbo.FactStaffHistory
                            WHERE      (DateBegin <= GETDATE())
							GROUP BY FactStaffHistory.idFactStaff)LastFactStaffHistory
							ON (LastFactStaffHistory.idFactStaff = dbo.FactStaff.id) 
								AND  dbo.FactStaffHistory.DateBegin =LastFactStaffHistory.LastDateBegin

go











update [FactStaffHistory]
set [FactStaffHistory].[idFinancingSource]=FactStaff.idFinancingSource
from [dbo].[FactStaffHistory] 
inner join 
dbo.FactStaff
ON [FactStaffHistory].idFactStaff=FactStaff.id
where FactStaff.idFinancingSource is not null






