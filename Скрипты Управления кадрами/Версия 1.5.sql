

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

  /*--�������� ������������ - ������ �� ������ �������
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













---��� �������
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
values('����������')

GO
GO

ALTER TABLE [dbo].[Event] ADD  CONSTRAINT [DF_Event_idEventType]  DEFAULT ((1)) FOR [idEventType]
GO

set identity_insert [dbo].[EventKind] ON
insert into [dbo].[EventKind]([id],[EventKindName])
values(15,'������')
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
values(1,'����� ����������')

insert into [dbo].[EventKind]([id],[EventKindName])
values(2,'��������� ������� ��������� ��������')


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
--������ ������ �� ������
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],1,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where Prikaz.idPrikazType=10  



go
set identity_insert [dbo].[EventKind] ON
insert into [dbo].[EventKind]([id],[EventKindName])
values(3,'������� ����������')

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind])
values(4,'����� ��������� ���������������',2)

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind])
values(5,'������������ ������������ ������',2)

insert into [dbo].[EventKind]([id],[EventKindName])
values(6,'����/����� ������')

insert into [dbo].[EventKind]([id],[EventKindName])
values(14,'����� ���������� �� ��������')
set identity_insert [dbo].[EventKind] OFF

go
--������ ��������
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  *--[idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],3,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where Prikaz.idPrikazType=6

go
--������ ����/����� ������
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],6,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where Prikaz.idPrikazType=7

go
--����� ��� ���
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],4,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where Prikaz.idPrikazType =13

go
--������ ��������� ������
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],5,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where (Prikaz.idPrikazType between 33 and 37 ) 
go
--������ ��������� ������� �����
insert into dbo.Event([idPrikaz],[DateBegin], DateEnd, [idFactStaffHistory],[idEventKind],[idContract])
select  [idBeginPrikaz],FactStaffHistory.[DateBegin], [Contract].DateEnd,FactStaffHistory.[id],2,FactStaffHistory.idContract
from dbo.FactStaffHistory
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] ON FactStaffHistory.idContract=[Contract].id
where (Prikaz.idPrikazType not between 33 and 37 ) and Prikaz.idPrikazType not in (10,13,6,7)

go

--������ �����������-������������
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
set [RegionTypeName]='��� ������ �������', [RegionTypeSmallName]='���'
where id=1




go
alter table [dbo].[EventKind]
add DecoratorName VARCHAR(500) NULL



go
update [dbo].[RegionType]
set [RegionTypeName]='��� ������ �������', [RegionTypeSmallName]='���'
where id=1


================================================
�������������� ���� "�����������" ��� ������
=================================================
/*
   23 �������� 2015 �.16:47:58
   ������������: 
   ������: ugtudb
   ���� ������: KadrRealTest
   ����������: 
*/

/* ����� ������������� ����������� ������ ������, ���������� ����������� ����������� ���� ������, ������ ��� ��������� ��� ��� ��������� ������������ ��� ������.*/
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
��������� ����� ���������� "���������"
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
����������� "���������" � �������
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



--��������� �������� ������� �� ���. ���������������
ALTER TABLE [dbo].[Event_MaterialResponsibility] DROP CONSTRAINT [FK_Event_MaterialResponsibility_Event]
GO
ALTER TABLE [dbo].[Event_MaterialResponsibility] WITH CHECK
ADD CONSTRAINT [FK_Event_MaterialResponsibility_Event] FOREIGN KEY([IdEvent])
REFERENCES [dbo].[Event] ([id])
ON DELETE CASCADE
GO

--���. �����������
set identity_insert [dbo].[EventKind] ON
  insert into [dbo].[EventKind](id,[EventKindName],[ForFactStaff]) values(16,'������������ ���������������',0)
  insert into [dbo].[EventKind](id,[EventKindName],[ForFactStaff]) values(19,'��������� ������������',0)
set identity_insert [dbo].[EventKind] OFF

--������ ������������
alter table [dbo].[OK_Reason] add is_old bit null
alter table OK_SocialStatus add is_old bit null

--��� �����������
alter table OK_Inkapacity add idInkapacityType int null

CREATE TABLE [dbo].[InkapacityType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NameInkapacityType] [varchar](500) NOT NULL,
 CONSTRAINT [PK_InkapacityType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OK_Inkapacity]    Script Date: 26.09.2015 15:52:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_Table_Name] ON [dbo].[InkapacityType]
(
	[NameInkapacityType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OK_Inkapacity_Type]    Script Date: 26.09.2015 15:52:47 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Inkapacity_Type] ON [dbo].[OK_Inkapacity]
(
	[idInkapacityType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OK_Inkapacity]  WITH CHECK ADD  CONSTRAINT [FK_OK_Inkapacity_InkapacityType] FOREIGN KEY([idInkapacityType])
REFERENCES [dbo].[InkapacityType] ([id])
GO
ALTER TABLE [dbo].[OK_Inkapacity] CHECK CONSTRAINT [FK_OK_Inkapacity_InkapacityType]
GO