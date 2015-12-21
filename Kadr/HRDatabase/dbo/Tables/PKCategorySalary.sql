CREATE TABLE [dbo].[PKCategorySalary] (
    [id]           INT      IDENTITY (1, 1) NOT NULL,
    [SalarySize]   MONEY    NOT NULL,
    [DateBegin]    DATETIME NOT NULL,
    [DateEnd]      DATETIME NULL,
    [idPKCategory] INT      NOT NULL,
    [idPrikaz]     INT      NULL,
    CONSTRAINT [PK_Salary] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [CheckDateBegin] CHECK ([DateBegin]<=[dateEnd]),
    CONSTRAINT [CheckSalarySize] CHECK ([SalarySize]>(0)),
    CONSTRAINT [FK_PKCategorySalary_PKCategory] FOREIGN KEY ([idPKCategory]) REFERENCES [dbo].[PKCategory] ([id]),
    CONSTRAINT [FK_PKCategorySalary_Prikaz] FOREIGN KEY ([idPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [IX_PKCategorySalary] UNIQUE CLUSTERED ([idPKCategory] ASC, [DateBegin] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_PKCategorySalary_DateBegin]
    ON [dbo].[PKCategorySalary]([DateBegin] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PKCategorySalary_DateEnd]
    ON [dbo].[PKCategorySalary]([DateEnd] ASC);


GO
--при добавлении незакрытого оклада проверяется, чтобы в этот же день уже не было назначено оклада (или позже)
CREATE      TRIGGER [dbo].[PKCategorySalaryOnlyOneToday]
 ON dbo.PKCategorySalary
  FOR INSERT, UPDATE
AS 


  IF EXISTS(SELECT 'TRUE' FROM INSERTED, dbo.PKCategorySalary 
 	WHERE INSERTED.id<>PKCategorySalary.id
		AND INSERTED.idPKCategory=PKCategorySalary.idPKCategory
		AND INSERTED.DateBegin<=PKCategorySalary.DateBegin
		--AND PKCategorySalary.DateEnd IS NOT NULL
		AND INSERTED.DateEnd IS NOT NULL)
  BEGIN   
      RAISERROR('Невозможно добавить оклад, так как на указанную дату (или позже) в категории уже создан оклад.', 16,1)
      ROLLBACK TRAN 
  END

GO
DISABLE TRIGGER [dbo].[PKCategorySalaryOnlyOneToday]
    ON [dbo].[PKCategorySalary];


GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PKCategorySalaryUpdateRegister]
   ON  dbo.PKCategorySalary
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(SalarySize)+' '+RTRIM(idPKCategory)+ ' '+RTRIM(DateBegin)+ ' '+RTRIM(DateEnd) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,10,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PKCategorySalaryInsertRegister]
   ON  [dbo].[PKCategorySalary]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(SalarySize)+' '+RTRIM(idPKCategory)+ ' '+RTRIM(DateBegin)+ ' '+RTRIM(DateEnd) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,10,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PKCategorySalaryDeleteRegister]
   ON  [dbo].[PKCategorySalary]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(SalarySize)+' '+RTRIM(idPKCategory)+ ' '+RTRIM(DateBegin)+ ' '+RTRIM(DateEnd) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,10,@name
END

GO
--при назначении нового оклада нужно отменить прежний
create      TRIGGER [dbo].[PKCategorySalaryExitLast]
 ON dbo.PKCategorySalary
  FOR INSERT
AS 

UPDATE dbo.PKCategorySalary
SET DateEnd=INSERTED.DateBegin-1
FROM
dbo.PKCategorySalary, INSERTED
WHERE
PKCategorySalary.idPKCategory=INSERTED.idPKCategory
AND INSERTED.DateEnd IS NULL 
AND PKCategorySalary.DateEnd IS NULL 
AND INSERTED.DateBegin > PKCategorySalary.DateBegin
