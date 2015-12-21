CREATE TABLE [dbo].[FactStaff] (
    [id]                     INT           IDENTITY (1, 1) NOT NULL,
    [idPlanStaff]            INT           NULL,
    [idEmployee]             INT           NULL,
    [idEndPrikaz]            INT           NULL,
    [DateEnd]                DATETIME      NULL,
    [IsReplacement]          BIT           CONSTRAINT [DF_FactStaff_IsReplacement] DEFAULT ((0)) NOT NULL,
    [PhoneNumber]            VARCHAR (50)  NULL,
    [IDShedule]              INT           NULL,
    [idlaborcontrakt]        INT           NULL,
    [idreason]               INT           NULL,
    [idFundingDepartment]    INT           NULL,
    [idTimeSheetSheduleType] INT           NULL,
    [idFundingCenter]        INT           NULL,
    [idDepartment]           INT           NULL,
    [idFinancingSource]      INT           NULL,
    [Comment]                VARCHAR (200) NULL,
    [idMainFactStaff]        INT           NULL,
    [idOKVED]                INT           NULL,
    CONSTRAINT [PK_FactStaff] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_FactStaff_Dep] FOREIGN KEY ([idDepartment]) REFERENCES [dbo].[Dep] ([id]),
    CONSTRAINT [FK_FactStaff_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]),
    CONSTRAINT [FK_FactStaff_FactStaff] FOREIGN KEY ([idMainFactStaff]) REFERENCES [dbo].[FactStaff] ([id]),
    CONSTRAINT [FK_FactStaff_FinancingSource] FOREIGN KEY ([idFinancingSource]) REFERENCES [dbo].[FinancingSource] ([id]),
    CONSTRAINT [FK_FactStaff_FundingCenter] FOREIGN KEY ([idFundingCenter]) REFERENCES [dbo].[FundingCenter] ([id]),
    CONSTRAINT [FK_FactStaff_OK_Reason] FOREIGN KEY ([idreason]) REFERENCES [dbo].[OK_Reason] ([idreason]),
    CONSTRAINT [FK_FactStaff_OKVED] FOREIGN KEY ([idOKVED]) REFERENCES [dbo].[OKVED] ([id]),
    CONSTRAINT [FK_FactStaff_PlanStaff] FOREIGN KEY ([idPlanStaff]) REFERENCES [dbo].[PlanStaff] ([id]),
    CONSTRAINT [FK_FactStaff_Prikaz1] FOREIGN KEY ([idEndPrikaz]) REFERENCES [dbo].[Prikaz] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffidPlanStaff]
    ON [dbo].[FactStaff]([idPlanStaff] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffEmpl]
    ON [dbo].[FactStaff]([idEmployee] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaff_idEndPrikaz]
    ON [dbo].[FactStaff]([idEndPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaff_DateEnd]
    ON [dbo].[FactStaff]([DateEnd] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffidFundingCenter]
    ON [dbo].[FactStaff]([idFundingCenter] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffidDepartment]
    ON [dbo].[FactStaff]([idDepartment] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaff_idFundingDepartment]
    ON [dbo].[FactStaff]([idFundingDepartment] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaff_idMainFactStaff]
    ON [dbo].[FactStaff]([idMainFactStaff] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaff_idOKVED]
    ON [dbo].[FactStaff]([idOKVED] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffUpdateRegister]
   ON  [dbo].[FactStaff]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEndPrikaz)+' '+RTRIM(DateEnd) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,8,@name
END



GO
--Триггеры
CREATE TRIGGER [dbo].[FactStaffInsertRegister]
   ON  [dbo].[FactStaff]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEndPrikaz)+' '+RTRIM(DateEnd) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,8,@name
END



GO

--при добавлении отдела, заполняет центр финансирования, если он не задан
CREATE TRIGGER [dbo].[FactStaffInsertFundingDepartment]
 ON [dbo].[FactStaff]
  FOR INSERT
AS



UPDATE dbo.FactStaff
SET idFundingDepartment=PlanStaff.idDepartment
FROM INSERTED INNER JOIN dbo.FactStaff
	ON INSERTED.id=FactStaff.id
	INNER JOIN dbo.PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id
	WHERE INSERTED.idFundingDepartment IS NULL




GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffDeleteRegister]
   ON  [dbo].[FactStaff]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+' '+RTRIM(idEmployee)+ ' '+RTRIM(idEndPrikaz)+' '+RTRIM(DateEnd) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,8,@name
END

GO
--если увольняется сотрудник, то нужно отменить все его надбавки (с даты увольнения)
CREATE TRIGGER [dbo].[FactStaffCancelBonus]
 ON [dbo].[FactStaff]
  FOR UPDATE, INSERT
AS



UPDATE dbo.Bonus
SET DateEnd=INSERTED.DateEnd, idEndPrikaz=INSERTED.idEndPrikaz
FROM INSERTED, Bonus, dbo.BonusFactStaff
WHERE INSERTED.DateEnd IS NOT NULL
	AND (Bonus.DateEnd IS NULL OR Bonus.DateEnd>INSERTED.DateEnd)	--либо даты отмены нет, либо она позже даты увольнения
	AND Bonus.id=BonusFactStaff.idBonus
	AND INSERTED.id=BonusFactStaff.idFactStaff



GO

--при увольнении сотрудника, если у него есть совместители, 
--отменяет им совмещение (указывает им дату окончания совмещения и признак совмещения сбрасывает)
CREATE TRIGGER [dbo].[FactStaffDismissal]
 ON [dbo].[FactStaff]
  FOR UPDATE
AS
UPDATE dbo.FactStaff
SET IsReplacement=0
FROM INSERTED INNER JOIN dbo.FactStaffReplacement
	ON INSERTED.id=FactStaffReplacement.idReplacedFactStaff INNER JOIN
	dbo.FactStaff ON FactStaffReplacement.idFactStaff=FactStaff.id
	WHERE INSERTED.DateEnd IS NOT NULL --AND FactStaffReplacement.DateEnd IS NULL

UPDATE dbo.FactStaffReplacement
SET DateEnd=Inserted.DateEnd
FROM INSERTED INNER JOIN dbo.FactStaffReplacement
	ON INSERTED.id=FactStaffReplacement.idReplacedFactStaff or 
		INSERTED.id=FactStaffReplacement.idFactStaff
	WHERE INSERTED.DateEnd IS NOT NULL AND FactStaffReplacement.DateEnd IS NULL

