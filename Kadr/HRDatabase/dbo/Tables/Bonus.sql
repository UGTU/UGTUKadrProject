CREATE TABLE [dbo].[Bonus] (
    [id]                      INT           IDENTITY (1, 1) NOT NULL,
    [DateEnd]                 DATE          NULL,
    [idBonusType]             INT           NOT NULL,
    [idEndPrikaz]             INT           NULL,
    [Comment]                 VARCHAR (100) NULL,
    [idIntermediateEndPrikaz] INT           NULL,
    CONSTRAINT [PK_Bonus] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Bonus_BonusType] FOREIGN KEY ([idBonusType]) REFERENCES [dbo].[BonusType] ([id]),
    CONSTRAINT [FK_Bonus_Prikaz1] FOREIGN KEY ([idEndPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [FK_Bonus_Prikaz2] FOREIGN KEY ([idIntermediateEndPrikaz]) REFERENCES [dbo].[Prikaz] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_BonusDateEnd]
    ON [dbo].[Bonus]([DateEnd] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BonusidBonusType]
    ON [dbo].[Bonus]([idBonusType] ASC);


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusUpdateRegister]
   ON  [dbo].[Bonus]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idBonusType)+' '+RTRIM(ISNULL(DateEnd,''))+' '+RTRIM(ISNULL(idEndPrikaz,0))
	+' '+RTRIM(ISNULL(idIntermediateEndPrikaz,0))+' '+RTRIM(ISNULL(Comment,'')) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,12,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusInsertRegister]
   ON  [dbo].[Bonus]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idBonusType)+' '+RTRIM(ISNULL(DateEnd,''))+' '+RTRIM(ISNULL(idEndPrikaz,0))
	+' '+RTRIM(ISNULL(idIntermediateEndPrikaz,0))+' '+RTRIM(ISNULL(Comment,'')) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,12,@name
END


GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusDeleteRegister]
   ON  [dbo].[Bonus]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idBonusType)+' '+RTRIM(ISNULL(DateEnd,''))+' '+RTRIM(ISNULL(idEndPrikaz,0))
	+' '+RTRIM(ISNULL(idIntermediateEndPrikaz,0))+' '+RTRIM(ISNULL(Comment,'')) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,12,@name
END



