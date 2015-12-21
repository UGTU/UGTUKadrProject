CREATE TABLE [dbo].[EmployeeDegree] (
    [idEducDocument] INT           NOT NULL,
    [degreeDate]     DATETIME      NULL,
    [DissertCouncil] VARCHAR (200) NULL,
    [diplWhere]      VARCHAR (200) NULL,
    [idDegree]       INT           NOT NULL,
    [idScienceType]  INT           NOT NULL,
    [idEmployee]     INT           NOT NULL,
    CONSTRAINT [PK_EmployeeDegree_1] PRIMARY KEY NONCLUSTERED ([idEducDocument] ASC),
    CONSTRAINT [FK_EmployeeDegree_Degree] FOREIGN KEY ([idDegree]) REFERENCES [dbo].[Degree] ([id]),
    CONSTRAINT [FK_EmployeeDegree_EducDocument] FOREIGN KEY ([idEducDocument]) REFERENCES [dbo].[EducDocument] ([id]),
    CONSTRAINT [FK_EmployeeDegree_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EmployeeDegree_ScienceType] FOREIGN KEY ([idScienceType]) REFERENCES [dbo].[ScienceType] ([id]),
    CONSTRAINT [IX_EmployeeDegree_1] UNIQUE CLUSTERED ([idEmployee] ASC, [idDegree] ASC, [idScienceType] ASC)
);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeDegreeUpdateRegister]
   ON  dbo.EmployeeDegree
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idDegree)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEducDocument)+' '+RTRIM(idScienceType)+ ' '+RTRIM(DissertCouncil)+ ' '+RTRIM(diplWhere) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,4,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeDegreeInsertRegister]
   ON  dbo.EmployeeDegree
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idDegree)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEducDocument)+' '+RTRIM(idScienceType)+ ' '+RTRIM(DissertCouncil)+ ' '+RTRIM(diplWhere) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,4,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeDegreeDeleteRegister]
   ON  dbo.EmployeeDegree
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idDegree)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEducDocument)+' '+RTRIM(idScienceType)+ ' '+RTRIM(DissertCouncil)+ ' '+RTRIM(diplWhere) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,4,@name
END
