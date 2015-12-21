CREATE TABLE [dbo].[BonusEmployee] (
    [idBonus]    INT NOT NULL,
    [idEmployee] INT NOT NULL,
    CONSTRAINT [PK_BonusEmployee_1] PRIMARY KEY CLUSTERED ([idBonus] ASC),
    CONSTRAINT [FK_BonusEmployee_Bonus] FOREIGN KEY ([idBonus]) REFERENCES [dbo].[Bonus] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BonusEmployee_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BonusEmployee]
    ON [dbo].[BonusEmployee]([idEmployee] ASC);


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusEmployeeUpdateRegister]
   ON  dbo.BonusEmployee
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idBonus)+' '+RTRIM(idEmployee) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,13,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusEmployeeInsertRegister]
   ON  [dbo].[BonusEmployee]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idBonus)+' '+RTRIM(idEmployee) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,13,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusEmployeeDeleteRegister]
   ON  [dbo].[BonusEmployee]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idBonus)+' '+RTRIM(idEmployee) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,13,@name
END
