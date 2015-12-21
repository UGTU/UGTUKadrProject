CREATE TABLE [dbo].[PlanStaffHistory] (
    [id]                INT            IDENTITY (1, 1) NOT NULL,
    [idPlanStaff]       INT            NOT NULL,
    [idBeginPrikaz]     INT            NOT NULL,
    [DateBegin]         DATETIME       NOT NULL,
    [StaffCount]        NUMERIC (8, 2) NOT NULL,
    [idFinancingSource] INT            NOT NULL,
    CONSTRAINT [PK_PlanStaffHistory] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [CK_PlanStaffHistoryStaffCount] CHECK ([StaffCount]>(0)),
    CONSTRAINT [FK_PlanStaffHistory_FinancingSource] FOREIGN KEY ([idFinancingSource]) REFERENCES [dbo].[FinancingSource] ([id]),
    CONSTRAINT [FK_PlanStaffHistory_PlanStaff] FOREIGN KEY ([idPlanStaff]) REFERENCES [dbo].[PlanStaff] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_PlanStaffHistory_Prikaz] FOREIGN KEY ([idBeginPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [IX_PlanStaffHistoryUnique] UNIQUE CLUSTERED ([idPlanStaff] ASC, [DateBegin] ASC, [idBeginPrikaz] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffHistoryDateBegin]
    ON [dbo].[PlanStaffHistory]([DateBegin] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffHistoryidBeginPrikaz]
    ON [dbo].[PlanStaffHistory]([idBeginPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffHistoryidFinancingSource]
    ON [dbo].[PlanStaffHistory]([idFinancingSource] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffHistoryUpdateRegister]
   ON  [dbo].[PlanStaffHistory]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(StaffCount)+' '+RTRIM(idFinancingSource)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,19,@name
END




GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffHistoryInsertRegister]
   ON  [dbo].[PlanStaffHistory]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(StaffCount)+' '+RTRIM(idFinancingSource)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,19,@name
END


GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffHistoryDeleteRegister]
   ON  [dbo].[PlanStaffHistory]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(StaffCount)+' '+RTRIM(idFinancingSource)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,19,@name
END
