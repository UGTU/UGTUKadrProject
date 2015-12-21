CREATE TABLE [dbo].[BonusPost] (
    [idPost]  INT NOT NULL,
    [idBonus] INT NOT NULL,
    CONSTRAINT [PK_BonusPost_1] PRIMARY KEY CLUSTERED ([idBonus] ASC),
    CONSTRAINT [FK_BonusPost_Bonus] FOREIGN KEY ([idBonus]) REFERENCES [dbo].[Bonus] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BonusPost_Post] FOREIGN KEY ([idPost]) REFERENCES [dbo].[Post] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BonusPostidPost]
    ON [dbo].[BonusPost]([idPost] ASC);


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusPostUpdateRegister]
   ON  dbo.BonusPost
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idBonus)+' '+RTRIM(idPost) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,14,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusPostInsertRegister]
   ON  [dbo].[BonusPost]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idBonus)+' '+RTRIM(idPost) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,14,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusPostDeleteRegister]
   ON  [dbo].[BonusPost]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idBonus)+' '+RTRIM(idPost) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,14,@name
END
