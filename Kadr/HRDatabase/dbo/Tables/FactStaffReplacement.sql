CREATE TABLE [dbo].[FactStaffReplacement] (
    [idFactStaff]         INT      NOT NULL,
    [idReplacedFactStaff] INT      NOT NULL,
    [idReplacementReason] INT      NOT NULL,
    [DateEnd]             DATETIME NULL,
    CONSTRAINT [PK_FactStaffReplacement] PRIMARY KEY CLUSTERED ([idFactStaff] ASC),
    CONSTRAINT [FK_FactStaffReplacement_FactStaff1] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FactStaffReplacement_ReplacedFactStaff] FOREIGN KEY ([idReplacedFactStaff]) REFERENCES [dbo].[FactStaff] ([id]),
    CONSTRAINT [FK_FactStaffReplacement_ReplacementReason] FOREIGN KEY ([idReplacementReason]) REFERENCES [dbo].[FactStaffReplacementReason] ([id]),
    CONSTRAINT [IX_FactStaffReplacement] UNIQUE NONCLUSTERED ([idReplacedFactStaff] ASC, [idFactStaff] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffReplacement_1]
    ON [dbo].[FactStaffReplacement]([idReplacementReason] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffReplacementUpdateRegister]
   ON  dbo.FactStaffReplacement
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idFactStaff)+' '+RTRIM(idReplacedFactStaff)+ ' '+RTRIM(idReplacementReason) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,9,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffReplacementInsertRegister]
   ON  [dbo].[FactStaffReplacement]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idFactStaff)+' '+RTRIM(idReplacedFactStaff)+ ' '+RTRIM(idReplacementReason) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,9,@name

update dbo.FactStaff
set IsReplacement=1
where id in (select idFactStaff from INSERTED)
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffReplacementDeleteRegister]
   ON  [dbo].[FactStaffReplacement]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idFactStaff)+' '+RTRIM(idReplacedFactStaff)+ ' '+RTRIM(idReplacementReason) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,9,@name

update dbo.FactStaff
set IsReplacement=0
where id in (select idFactStaff from DELETED)
END

GO
--при указании Даты окончания замещения, сбрасывает флаг замещения для сотрудника
CREATE TRIGGER [dbo].[FactStaffReplacementCancel]
 ON [dbo].[FactStaffReplacement]
  FOR UPDATE
AS
UPDATE dbo.FactStaff
SET IsReplacement=0
FROM INSERTED FactStaffReplacement INNER JOIN
	dbo.FactStaff ON FactStaffReplacement.idFactStaff=FactStaff.id
	WHERE FactStaffReplacement.DateEnd IS NOT NULL AND (FactStaffReplacement.DateEnd<>FactStaff.DateEnd) 
		AND IsReplacement=1






GO
DISABLE TRIGGER [dbo].[FactStaffReplacementCancel]
    ON [dbo].[FactStaffReplacement];

