CREATE TABLE [dbo].[TimeSheetFSWorkingDays] (
    [idTimeSheet]      INT            NOT NULL,
    [idFactStaff]      INT            NOT NULL,
    [WorkingDaysCount] INT            NOT NULL,
    [IsClosed]         BIT            NOT NULL,
    [StaffCount]       NUMERIC (3, 2) CONSTRAINT [DF_TimeSheetFSWorkingDays_Staff] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TimeSheetFSWorkingDays] PRIMARY KEY CLUSTERED ([idTimeSheet] ASC, [idFactStaff] ASC, [StaffCount] ASC),
    CONSTRAINT [FK_TimeSheetFSWorkingDays_FactStaff] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TimeSheetFSWorkingDays_TimeSheet] FOREIGN KEY ([idTimeSheet]) REFERENCES [dbo].[TimeSheet] ([id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheetFSWorkingDaysFactStaff]
    ON [dbo].[TimeSheetFSWorkingDays]([idFactStaff] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheetFSWorkingDaysIsClosed]
    ON [dbo].[TimeSheetFSWorkingDays]([IsClosed] ASC);


GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create TRIGGER [dbo].[TimeSheetFSWorkingDaysDeleteRegister]
   ON  [dbo].TimeSheetFSWorkingDays
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idTimeSheet)+' '+RTRIM(idFactStaff)+' '+RTRIM(WorkingDaysCount)+ ' '+RTRIM(IsClosed) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,17,@name
END


GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create TRIGGER [dbo].[TimeSheetFSWorkingDaysInsertRegister]
   ON dbo.TimeSheetFSWorkingDays
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idTimeSheet)+' '+RTRIM(idFactStaff)+' '+RTRIM(WorkingDaysCount)+ ' '+RTRIM(IsClosed) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,18,@name
END




GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create TRIGGER [dbo].[TimeSheetFSWorkingDaysUpdateRegister]
   ON  [dbo].TimeSheetFSWorkingDays
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idTimeSheet)+' '+RTRIM(idFactStaff)+' '+RTRIM(WorkingDaysCount)+ ' '+RTRIM(IsClosed) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,17,@name
END



