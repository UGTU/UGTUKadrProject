CREATE TABLE [dbo].[BonusHistory] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [idBonus]           INT            NOT NULL,
    [idBeginPrikaz]     INT            NOT NULL,
    [BonusCount]        NUMERIC (8, 2) NOT NULL,
    [DateBegin]         DATE           NOT NULL,
    [idFinancingSource] INT            NULL,
    CONSTRAINT [PK_BonusHistory] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [CK_BonusHistoryBonusCount] CHECK ([BonusCount]>=(0)),
    CONSTRAINT [FK_BonusHistory_Bonus] FOREIGN KEY ([idBonus]) REFERENCES [dbo].[Bonus] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BonusHistory_FinancingSource] FOREIGN KEY ([idFinancingSource]) REFERENCES [dbo].[FinancingSource] ([id]),
    CONSTRAINT [FK_BonusHistory_Prikaz] FOREIGN KEY ([idBeginPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [IX_BonusHistory] UNIQUE CLUSTERED ([idBonus] ASC, [DateBegin] ASC, [idBeginPrikaz] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_BonusHistoryidBeginPrikaz]
    ON [dbo].[BonusHistory]([idBeginPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BonusHistoryDateBegin]
    ON [dbo].[BonusHistory]([DateBegin] ASC);


GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusHistoryInsertRegister]
   ON  dbo.BonusHistory
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idBonus)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(BonusCount)
	+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,21,@name
END


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusHistoryUpdateRegister]
   ON  [dbo].BonusHistory
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idBonus)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(BonusCount)
	+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,21,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusHistoryDeleteRegister]
   ON  [dbo].BonusHistory
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idBonus)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(BonusCount)
	+' '+RTRIM(DateBegin) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,21,@name
END

