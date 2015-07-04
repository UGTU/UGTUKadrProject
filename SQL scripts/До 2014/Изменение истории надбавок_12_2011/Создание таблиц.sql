USE [Kadr]
GO

/****** Object:  Table [dbo].[BonusHistory]    Script Date: 12/08/2011 11:40:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BonusHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBonus] [int] NOT NULL,
	[idBeginPrikaz] [int] NOT NULL,
	[BonusCount] [numeric](8, 2) NOT NULL,
	[DateBegin] [datetime] NOT NULL,
 CONSTRAINT [PK_BonusHistory] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_BonusHistory] UNIQUE CLUSTERED 
(
	[idBonus] ASC,
	[DateBegin] ASC,
	[idBeginPrikaz] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BonusHistory]  WITH CHECK ADD  CONSTRAINT [FK_BonusHistory_Bonus] FOREIGN KEY([idBonus])
REFERENCES [dbo].[Bonus] ([id])
GO

ALTER TABLE [dbo].[BonusHistory] CHECK CONSTRAINT [FK_BonusHistory_Bonus]
GO

ALTER TABLE [dbo].[BonusHistory]  WITH CHECK ADD  CONSTRAINT [FK_BonusHistory_Prikaz] FOREIGN KEY([idBeginPrikaz])
REFERENCES [dbo].[Prikaz] ([id])
GO

ALTER TABLE [dbo].[BonusHistory] CHECK CONSTRAINT [FK_BonusHistory_Prikaz]
GO

GO

/****** Object:  Index [IX_BonusHistoryidBeginPrikaz]    Script Date: 12/09/2011 17:19:08 ******/
CREATE NONCLUSTERED INDEX [IX_BonusHistoryidBeginPrikaz] ON [dbo].[BonusHistory] 
(
	[idBeginPrikaz] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]


GO

/****** Object:  Index [IX_BonusHistoryDateBegin]    Script Date: 12/09/2011 17:19:31 ******/
CREATE NONCLUSTERED INDEX [IX_BonusHistoryDateBegin] ON [dbo].[BonusHistory] 
(
	[DateBegin] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


--заполнение из истории изменений
insert into dbo.BonusHistory(idBonus,idBeginPrikaz,BonusCount,DateBegin)
SELECT id, idPrikaz, BonusCount, DateBegin
FROM dbo.BonusWithHistory


go
alter table dbo.Bonus
drop constraint CheckBonusDateBegin 

go
alter table dbo.Bonus
drop constraint FK_Bonus_Prikaz 

go
 
drop index IX_BonusDateBegin 
on dbo.Bonus
go


alter table dbo.Bonus
drop column idPrikaz, BonusCount, DateBegin