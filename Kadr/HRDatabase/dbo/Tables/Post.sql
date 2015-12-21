CREATE TABLE [dbo].[Post] (
    [id]             INT              IDENTITY (1, 1) NOT NULL,
    [PostName]       VARCHAR (150)    NOT NULL,
    [ManagerBit]     BIT              CONSTRAINT [DF_Post_ManagerBit] DEFAULT ((0)) NOT NULL,
    [idGlobalPrikaz] INT              NOT NULL,
    [idPKCategory]   INT              NOT NULL,
    [idCategory]     INT              NULL,
    [PostGUID]       UNIQUEIDENTIFIER CONSTRAINT [DF_Post_PostGUID] DEFAULT (newsequentialid()) NOT NULL,
    [DateEnd]        DATE             NULL,
    [Comment]        VARCHAR (150)    NULL,
    [PostCode]       VARCHAR (20)     NULL,
    [idPostType]     INT              NULL,
    [PostShortName]  AS               ([PostName]),
    [idCategoryVPO]  INT              NULL,
    [idCategoryZP]   INT              NULL,
    [idNewCategory]  INT              NULL,
    [idPostGroup]    INT              NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Post_Category] FOREIGN KEY ([idCategory]) REFERENCES [dbo].[Category] ([id]),
    CONSTRAINT [FK_Post_CategoryNew] FOREIGN KEY ([idNewCategory]) REFERENCES [dbo].[Category] ([id]),
    CONSTRAINT [FK_Post_CategoryVPO] FOREIGN KEY ([idCategoryVPO]) REFERENCES [dbo].[CategoryVPO] ([id]),
    CONSTRAINT [FK_Post_CategoryZP] FOREIGN KEY ([idCategoryZP]) REFERENCES [dbo].[CategoryZP] ([id]),
    CONSTRAINT [FK_Post_GlobalPrikaz] FOREIGN KEY ([idGlobalPrikaz]) REFERENCES [dbo].[GlobalPrikaz] ([id]),
    CONSTRAINT [FK_Post_PKCategory] FOREIGN KEY ([idPKCategory]) REFERENCES [dbo].[PKCategory] ([id]),
    CONSTRAINT [FK_Post_PostGroup] FOREIGN KEY ([idPostGroup]) REFERENCES [dbo].[PostGroup] ([id]),
    CONSTRAINT [FK_Post_PostType] FOREIGN KEY ([idPostType]) REFERENCES [dbo].[PostType] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PostCat]
    ON [dbo].[Post]([idCategory] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PostPKCat]
    ON [dbo].[Post]([idPKCategory] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PostGlobalPrik]
    ON [dbo].[Post]([idGlobalPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Post_idCategoryVPO]
    ON [dbo].[Post]([idCategoryVPO] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Post_idCategoryZP]
    ON [dbo].[Post]([idCategoryZP] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Post_idPostType]
    ON [dbo].[Post]([idPostType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Post_ManagerBit]
    ON [dbo].[Post]([ManagerBit] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PostUpdateRegister]
   ON  [dbo].[Post]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(PostName)+' '+RTRIM(PostShortName)++' '+RTRIM(idPKCategory)+ ' '+RTRIM(ManagerBit)+' '+RTRIM(idGlobalPrikaz) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,3,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PostInsertRegister]
   ON  [dbo].[Post]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(PostName)+' '++RTRIM(PostShortName)+' '+RTRIM(idPKCategory)+ ' '+RTRIM(ManagerBit)+' '+RTRIM(idGlobalPrikaz) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,3,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PostDeleteRegister]
   ON  [dbo].[Post]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(PostName)+' '++RTRIM(PostShortName)+' '+RTRIM(idPKCategory)+ ' '+RTRIM(ManagerBit)+' '+RTRIM(idGlobalPrikaz) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,3,@name
END
