CREATE TABLE [dbo].[PlanStaffSalary] (
    [id]          INT      IDENTITY (1, 1) NOT NULL,
    [SalarySize]  MONEY    NOT NULL,
    [DateBegin]   DATETIME NOT NULL,
    [DateEnd]     DATETIME NULL,
    [idPlanStaff] INT      NOT NULL,
    [idPrikaz]    INT      NULL,
    CONSTRAINT [PK_PlanStaffSalary] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [CheckPlanStaffSalaryDateBegin] CHECK ([DateBegin]<=[dateEnd]),
    CONSTRAINT [CheckPlanStaffSalarySalarySize] CHECK ([SalarySize]>(0)),
    CONSTRAINT [FK_PlanStaffSalary_PlanStaff] FOREIGN KEY ([idPlanStaff]) REFERENCES [dbo].[PlanStaff] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PlanStaffSalary_Prikaz] FOREIGN KEY ([idPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [IX_PlanStaffSalary] UNIQUE CLUSTERED ([idPlanStaff] ASC, [DateBegin] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffSalary_DateBegin]
    ON [dbo].[PlanStaffSalary]([DateBegin] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffSalary_DateEnd]
    ON [dbo].[PlanStaffSalary]([DateEnd] ASC);


GO

--при назначении нового оклада нужно отменить прежний
CREATE      TRIGGER [dbo].[PlanStaffSalaryExitLast]
 ON [dbo].[PlanStaffSalary]
  FOR INSERT
AS 

BEGIN
	UPDATE dbo.PlanStaffSalary
	SET DateEnd=INSERTED.DateBegin-1
	FROM
	dbo.PlanStaffSalary, INSERTED
	WHERE
	PlanStaffSalary.idPlanStaff=INSERTED.idPlanStaff
	AND INSERTED.DateEnd IS NULL 
	AND PlanStaffSalary.DateEnd IS NULL 
	AND INSERTED.DateBegin > PlanStaffSalary.DateBegin
END


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffSalaryUpdateRegister]
   ON  dbo.PlanStaffSalary
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(SalarySize)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(DateBegin)+ ' '+RTRIM(DateEnd) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,11,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffSalaryInsertRegister]
   ON  [dbo].[PlanStaffSalary]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(SalarySize)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(DateBegin)+ ' '+RTRIM(DateEnd) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,11,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffSalaryDeleteRegister]
   ON  [dbo].[PlanStaffSalary]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(SalarySize)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(DateBegin)+ ' '+RTRIM(DateEnd) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,11,@name
END
