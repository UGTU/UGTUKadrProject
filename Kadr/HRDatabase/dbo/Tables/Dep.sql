CREATE TABLE [dbo].[Dep] (
    [id]                 INT              IDENTITY (1, 1) NOT NULL,
    [idDepartmentType]   INT              NULL,
    [KadrID]             INT              NULL,
    [dateExit]           DATETIME         NULL,
    [idManagerPlanStaff] INT              NULL,
    [idEndPrikaz]        INT              NULL,
    [SeverKoeff]         INT              NULL,
    [RayonKoeff]         INT              NULL,
    [DepartmentGUID]     UNIQUEIDENTIFIER DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [idFundingCenter]    INT              NULL,
    [DepartmentIndex]    VARCHAR (10)     NULL,
    [DepPhoneNumber]     VARCHAR (20)     NULL,
    [HasTimeSheet]       BIT              CONSTRAINT [DF_Dep_HasTimeSheet] DEFAULT ((1)) NOT NULL,
    [idOKVED]            INT              NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Dep_DepartmentType] FOREIGN KEY ([idDepartmentType]) REFERENCES [dbo].[DepartmentType] ([id]),
    CONSTRAINT [FK_Dep_FundingCenter] FOREIGN KEY ([idFundingCenter]) REFERENCES [dbo].[FundingCenter] ([id]),
    CONSTRAINT [FK_Dep_OKVED] FOREIGN KEY ([idOKVED]) REFERENCES [dbo].[OKVED] ([id]),
    CONSTRAINT [FK_Department_PlanStaff] FOREIGN KEY ([idManagerPlanStaff]) REFERENCES [dbo].[PlanStaff] ([id]),
    CONSTRAINT [FK_Department_Prikaz1] FOREIGN KEY ([idEndPrikaz]) REFERENCES [dbo].[Prikaz] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Dep_idDepartmentType]
    ON [dbo].[Dep]([idDepartmentType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Dep_idEndPrikaz]
    ON [dbo].[Dep]([idEndPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Dep_idFundingCenter]
    ON [dbo].[Dep]([idFundingCenter] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Dep_idManagerPlanStaff]
    ON [dbo].[Dep]([idManagerPlanStaff] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Dep_idOKVED]
    ON [dbo].[Dep]([idOKVED] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[DepartmentUpdateRegister]
   ON  [dbo].[Dep]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idDepartmentType)+' '+RTRIM(KadrID)+' '+RTRIM(dateExit)+' '+RTRIM(idManagerPlanStaff)
	+' '+RTRIM(idEndPrikaz)+ ' ('+RTRIM(DepartmentGUID)+')' from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,1,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[DepartmentInsertRegister]
   ON  [dbo].[Dep]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idDepartmentType)+' '+RTRIM(KadrID)+' '+RTRIM(dateExit)+' '+RTRIM(idManagerPlanStaff)
	+' '+RTRIM(idEndPrikaz)+ ' ('+RTRIM(DepartmentGUID)+')' from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,1,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[DepartmentDeleteRegister]
   ON  [dbo].[Dep]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idDepartmentType)+' '+RTRIM(KadrID)+' '+RTRIM(dateExit)+' '+RTRIM(idManagerPlanStaff)
	+' '+RTRIM(idEndPrikaz)+ ' ('+RTRIM(DepartmentGUID)+')' from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,1,@name
END

