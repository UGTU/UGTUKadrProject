CREATE TABLE [dbo].[BonusPlanStaff] (
    [idBonus]     INT NOT NULL,
    [idPlanStaff] INT NOT NULL,
    [ForVacancy]  BIT CONSTRAINT [DF_BonusPlanStaff_ForVacancy] DEFAULT ((0)) NOT NULL,
    [ForEmployee] BIT CONSTRAINT [DF_BonusPlanStaff_ForEmployee] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_BonusPlanStaff_1] PRIMARY KEY CLUSTERED ([idBonus] ASC),
    CONSTRAINT [FK_BonusPlanStaff_Bonus] FOREIGN KEY ([idBonus]) REFERENCES [dbo].[Bonus] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_BonusPlanStaff_PlanStaff] FOREIGN KEY ([idPlanStaff]) REFERENCES [dbo].[PlanStaff] ([id]) ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_BonusPlanStaffidPlanStaff]
    ON [dbo].[BonusPlanStaff]([idPlanStaff] ASC);


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusPlanStaffUpdateRegister]
   ON  dbo.BonusPlanStaff
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idBonus)+' '+RTRIM(idPlanStaff) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,15,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusPlanStaffInsertRegister]
   ON  [dbo].[BonusPlanStaff]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idBonus)+' '+RTRIM(idPlanStaff) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,15,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusPlanStaffDeleteRegister]
   ON  [dbo].[BonusPlanStaff]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idBonus)+' '+RTRIM(idPlanStaff) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,15,@name
END
