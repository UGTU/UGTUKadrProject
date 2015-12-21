CREATE TABLE [dbo].[Prikaz] (
    [id]           INT          IDENTITY (1, 1) NOT NULL,
    [PrikazName]   VARCHAR (50) NOT NULL,
    [DatePrikaz]   DATETIME     NULL,
    [idPrikazType] INT          NULL,
    [DateBegin]    DATETIME     NULL,
    [DateEnd]      DATETIME     NULL,
    [resume]       TEXT         NULL,
    CONSTRAINT [PK_Prikaz] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Prikaz_PrikazType] FOREIGN KEY ([idPrikazType]) REFERENCES [dbo].[PrikazType] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PrikazDatePrikaz]
    ON [dbo].[Prikaz]([DatePrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PrikazidPrikazType]
    ON [dbo].[Prikaz]([idPrikazType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Prikaz]
    ON [dbo].[Prikaz]([PrikazName] ASC, [DateBegin] ASC);


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PrikazUpdateRegister]
   ON  [dbo].[Prikaz]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(PrikazName)+' '+RTRIM(idPrikazType)+ ' '+RTRIM(DatePrikaz) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,6,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PrikazInsertRegister]
   ON  [dbo].[Prikaz]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(PrikazName)+' '+RTRIM(idPrikazType)+ ' '+RTRIM(DatePrikaz) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,6,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PrikazDeleteRegister]
   ON  [dbo].[Prikaz]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(PrikazName)+' '+RTRIM(idPrikazType)+ ' '+RTRIM(DatePrikaz) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,6,@name
END

