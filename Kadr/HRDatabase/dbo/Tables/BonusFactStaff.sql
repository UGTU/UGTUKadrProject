CREATE TABLE [dbo].[BonusFactStaff] (
    [idBonus]     INT NOT NULL,
    [idFactStaff] INT NOT NULL,
    CONSTRAINT [PK_BonusFactStaff_1] PRIMARY KEY CLUSTERED ([idBonus] ASC),
    CONSTRAINT [FK_BonusFactStaff_Bonus] FOREIGN KEY ([idBonus]) REFERENCES [dbo].[Bonus] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BonusFactStaff_FactStaff] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_BonusFactStaff]
    ON [dbo].[BonusFactStaff]([idFactStaff] ASC);


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusFactStaffUpdateRegister]
   ON  dbo.BonusFactStaff
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idBonus)+' '+RTRIM(idFactStaff) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,16,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusFactStaffInsertRegister]
   ON  [dbo].[BonusFactStaff]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idBonus)+' '+RTRIM(idFactStaff) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,16,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusFactStaffDeleteRegister]
   ON  [dbo].[BonusFactStaff]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idBonus)+' '+RTRIM(idFactStaff) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,16,@name
END
