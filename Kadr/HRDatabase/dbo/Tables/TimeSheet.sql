CREATE TABLE [dbo].[TimeSheet] (
    [id]                        INT        IDENTITY (1, 1) NOT NULL,
    [TimeSheetMonth]            INT        NOT NULL,
    [TimeSheetYear]             INT        NOT NULL,
    [TimeSheetWorkingDayCount]  INT        NOT NULL,
    [IsClosed]                  BIT        CONSTRAINT [DF_TimeSheetIsClosed] DEFAULT ((0)) NULL,
    [IsFilled]                  BIT        CONSTRAINT [DF_TimeSheetIsFilled] DEFAULT ((0)) NULL,
    [TimeSheetWorkingHourCount] FLOAT (53) NULL,
    CONSTRAINT [PK_TimeSheet] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CK_TimeSheetTimeSheetMonth] CHECK ([TimeSheetMonth]>(0) AND [TimeSheetMonth]<(13)),
    CONSTRAINT [CK_TimeSheetTimeSheetTimeSheetWorkingDayCount] CHECK ([TimeSheetWorkingDayCount]>(0) AND [TimeSheetWorkingDayCount]<(32)),
    CONSTRAINT [CK_TimeSheetTimeSheetYear] CHECK ([TimeSheetYear]>(2000) AND [TimeSheetMonth]<(2100)),
    CONSTRAINT [IX_TimeSheet] UNIQUE NONCLUSTERED ([TimeSheetMonth] ASC, [TimeSheetYear] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheet_TimeSheetYear]
    ON [dbo].[TimeSheet]([TimeSheetYear] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TimeSheet_IsFilled]
    ON [dbo].[TimeSheet]([IsFilled] ASC);


GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TimeSheetInsertRegister]
   ON [dbo].[TimeSheet] 
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(TimeSheetMonth)+' '+RTRIM(TimeSheetYear)+ ' '+RTRIM(TimeSheetWorkingDayCount)+' дней' from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,17,@name
END




GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TimeSheetUpdateRegister]
   ON  [dbo].[TimeSheet]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(TimeSheetMonth)+' '+RTRIM(TimeSheetYear)+ ' '+RTRIM(TimeSheetWorkingDayCount)+' дней' from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,17,@name
END




GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[TimeSheetDeleteRegister]
   ON  [dbo].[TimeSheet]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(TimeSheetMonth)+' '+RTRIM(TimeSheetYear)+ ' '+RTRIM(TimeSheetWorkingDayCount)+' дней' from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,17,@name
END

