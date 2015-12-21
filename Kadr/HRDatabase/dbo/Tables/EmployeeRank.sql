CREATE TABLE [dbo].[EmployeeRank] (
    [idEducDocument] INT           NOT NULL,
    [idEmployee]     INT           NOT NULL,
    [idRank]         INT           NULL,
    [rankWhere]      VARCHAR (200) NULL,
    CONSTRAINT [PK_EmployeeRank] PRIMARY KEY NONCLUSTERED ([idEducDocument] ASC),
    CONSTRAINT [FK_EmployeeRank_EducDocument] FOREIGN KEY ([idEducDocument]) REFERENCES [dbo].[EducDocument] ([id]),
    CONSTRAINT [FK_EmployeeRank_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeRank_Rank] FOREIGN KEY ([idRank]) REFERENCES [dbo].[Rank] ([id]),
    CONSTRAINT [IX_EmployeeZvanye] UNIQUE CLUSTERED ([idEmployee] ASC, [idRank] ASC)
);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeRankUpdateRegister]
   ON  dbo.EmployeeRank
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idRank)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEducDocument)+' '+RTRIM(rankWhere) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,5,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeRankInsertRegister]
   ON  dbo.EmployeeRank
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idRank)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEducDocument)+' '+RTRIM(rankWhere) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,5,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeRankDeleteRegister]
   ON  dbo.EmployeeRank
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idRank)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEducDocument)+' '+RTRIM(rankWhere) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,5,@name
END
