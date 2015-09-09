

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

		











