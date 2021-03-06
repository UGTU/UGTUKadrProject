USE [Kadr]
GO
/****** Object:  Trigger [dbo].[FactStaffChangesHistoryDeleteRegister]    Script Date: 12/07/2011 12:05:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[FactStaffChangesHistoryDeleteRegister]
   ON  [dbo].[FactStaffChangesHistory]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idFactStaff)+' '+RTRIM(idPrikazChange)+' '+RTRIM(DateChange)+ ' '+RTRIM(NewStaffCount)+' '+RTRIM(idNewTypeWork) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,20,@name
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[FactStaffChangesHistoryInsertRegister]
   ON  [dbo].[FactStaffChangesHistory]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idFactStaff)+' '+RTRIM(idPrikazChange)+' '+RTRIM(DateChange)+ ' '+RTRIM(NewStaffCount)+' '+RTRIM(idNewTypeWork) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,20,@name
END


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[FactStaffChangesHistoryUpdateRegister]
   ON  [dbo].[FactStaffChangesHistory]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idFactStaff)+' '+RTRIM(idPrikazChange)+' '+RTRIM(DateChange)+ ' '+RTRIM(NewStaffCount)+' '+RTRIM(idNewTypeWork) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,20,@name
END




GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[PlanStaffHistoryChangesDeleteRegister]
   ON  [dbo].[PlanStaffHistoryChanges]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idPlanStaff)+' '+RTRIM(idPrikazChange)+' '+RTRIM(DateChange)+ ' '+RTRIM(NewStaffCount)+' '+RTRIM(idNewFinancingSource) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,19,@name
END



GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[PlanStaffHistoryChangesInsertRegister]
   ON  [dbo].[PlanStaffHistoryChanges]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idPlanStaff)+' '+RTRIM(idPrikazChange)+' '+RTRIM(DateChange)+ ' '+RTRIM(NewStaffCount)+' '+RTRIM(idNewFinancingSource) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,19,@name
END



GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[PlanStaffHistoryChangesUpdateRegister]
   ON  [dbo].[PlanStaffHistoryChanges]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idPlanStaff)+' '+RTRIM(idPrikazChange)+' '+RTRIM(DateChange)+ ' '+RTRIM(NewStaffCount)+' '+RTRIM(idNewFinancingSource) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,19,@name
END

