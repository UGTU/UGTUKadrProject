USE [Kadr]
GO
/****** Object:  Trigger [dbo].[BonusInsertRegister]    Script Date: 12/09/2011 17:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[BonusInsertRegister]
   ON  [dbo].[Bonus]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idBonusType)+' '+RTRIM(ISNULL(DateEnd,0))+' '+RTRIM(ISNULL(idEndPrikaz,0))
	+' '+RTRIM(ISNULL(idIntermediateEndPrikaz,0))+' '+RTRIM(ISNULL(Comment,'')) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,12,@name
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[BonusUpdateRegister]
   ON  [dbo].[Bonus]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idBonusType)+' '+RTRIM(ISNULL(DateEnd,0))+' '+RTRIM(ISNULL(idEndPrikaz,0))
	+' '+RTRIM(ISNULL(idIntermediateEndPrikaz,0))+' '+RTRIM(ISNULL(Comment,'')) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,12,@name
END


GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[BonusDeleteRegister]
   ON  [dbo].[Bonus]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idBonusType)+' '+RTRIM(ISNULL(DateEnd,0))+' '+RTRIM(ISNULL(idEndPrikaz,0))
	+' '+RTRIM(ISNULL(idIntermediateEndPrikaz,0))+' '+RTRIM(ISNULL(Comment,'')) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,12,@name
END



go
insert into dbo.Audit_Object
values(21, 'История надбавок','BonusHistory')

GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusHistoryInsertRegister]
   ON  dbo.BonusHistory
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idBonus)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(BonusCount)
	+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,21,@name
END

GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusHistoryUpdateRegister]
   ON  [dbo].BonusHistory
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idBonus)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(BonusCount)
	+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,21,@name
END


GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[BonusHistoryDeleteRegister]
   ON  [dbo].BonusHistory
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idBonus)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(BonusCount)
	+' '+RTRIM(DateBegin) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,21,@name
END

