CREATE TABLE [dbo].[FactStaffHistory] (
    [id]                INT             IDENTITY (1, 1) NOT NULL,
    [idFactStaff]       INT             NOT NULL,
    [idBeginPrikaz]     INT             NULL,
    [DateBegin]         DATETIME        NOT NULL,
    [StaffCount]        NUMERIC (6, 4)  CONSTRAINT [DF_FactStaffHistory_StaffCount] DEFAULT ((1)) NOT NULL,
    [idTypeWork]        INT             NOT NULL,
    [idlaborcontrakt]   INT             NULL,
    [HourCount]         NUMERIC (10, 2) NULL,
    [HourSalary]        NUMERIC (10, 2) NULL,
    [idSalaryKoeff]     INT             NULL,
    [HourStaffCount]    NUMERIC (6, 4)  NULL,
    [CalcStaffCount]    AS              (isnull([HourStaffCount],[StaffCount])),
    [HourFullSalary]    NUMERIC (10, 2) NULL,
    [idRegionType]      INT             NULL,
    [Address]           VARCHAR (500)   NULL,
    [idFinancingSource] INT             NULL,
    CONSTRAINT [PK_FactStaffHistory] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [CK_FactStaffHistoryStaffCount] CHECK ([StaffCount]>=(0)),
    CONSTRAINT [FK_FactStaffHistory_FactStaff] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FactStaffHistory_FinancingSource] FOREIGN KEY ([idFinancingSource]) REFERENCES [dbo].[FinancingSource] ([id]),
    CONSTRAINT [FK_FactStaffHistory_Prikaz] FOREIGN KEY ([idBeginPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [FK_FactStaffHistory_RegionType] FOREIGN KEY ([idRegionType]) REFERENCES [dbo].[RegionType] ([id]),
    CONSTRAINT [FK_FactStaffHistory_SalaryKoeff] FOREIGN KEY ([idSalaryKoeff]) REFERENCES [dbo].[SalaryKoeff] ([id]),
    CONSTRAINT [FK_FactStaffHistory_WorkType] FOREIGN KEY ([idTypeWork]) REFERENCES [dbo].[WorkType] ([id]),
    CONSTRAINT [IX_FactStaffHistoryUnique] UNIQUE CLUSTERED ([idFactStaff] ASC, [DateBegin] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffHistoryDateBegin]
    ON [dbo].[FactStaffHistory]([DateBegin] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffHistoryidBeginPrikaz]
    ON [dbo].[FactStaffHistory]([idBeginPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffHistoryTypeWork]
    ON [dbo].[FactStaffHistory]([idTypeWork] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffHistory_idFinancingSource]
    ON [dbo].[FactStaffHistory]([idFinancingSource] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffHistoryDeleteRegister]
   ON  dbo.FactStaffHistory
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idFactStaff)+' '+RTRIM(idTypeWork)+' '+RTRIM(StaffCount)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,20,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffHistoryInsertRegister]
   ON  dbo.FactStaffHistory
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idFactStaff)+' '+RTRIM(idTypeWork)+' '+RTRIM(StaffCount)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,20,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffHistoryUpdateRegister]
   ON  dbo.FactStaffHistory
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idFactStaff)+' '+RTRIM(idTypeWork)+' '+RTRIM(StaffCount)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,20,@name
END

GO
--проверяем, чтобы основная должность была 1
CREATE TRIGGER [dbo].[FactStaffHistoryOneMainStaff]
 ON [dbo].[FactStaffHistory]
  FOR UPDATE, INSERT
AS

DECLARE @idFactStaffHistory INT
SELECT @idFactStaffHistory=
 INSERTED.id
		FROM INSERTED
			INNER JOIN
				dbo.FactStaff FactStaffCurrent ON INSERTED.idFactStaff=FactStaffCurrent.id
			INNER JOIN
				dbo.FactStaffCurrent OtherFactStaff ON FactStaffCurrent.idEmployee=OtherFactStaff.idEmployee
					AND OtherFactStaff.id<>INSERTED.idFactStaff
			inner join 
				(SELECT Event.idFactStaffHistory, Event.idEventKind from 
					dbo.Event 
					INNER JOIN dbo.EventKind ON Event.idEventKind=EventKind.id
						AND EventKind.ForFactStaff=1)Event ON INSERTED.id=Event.idFactStaffHistory	 
		WHERE FactStaffCurrent.idEndPrikaz IS NULL		--СТАВКИ ОТКРЫТЫ
			AND OtherFactStaff.idEndPrikaz IS NULL		--остальные ставки ОТКРЫТы
			AND OtherFactStaff.idTypeWork IN (SELECT WorkType.id	--осн вид работы
				FROM WorkType WHERE WorkType.IsMain=1)
			AND INSERTED.idTypeWork IN (SELECT WorkType.id	--осн вид работы
				FROM WorkType WHERE WorkType.IsMain=1)
			and Event.idEventKind<>3

IF (@idFactStaffHistory IS NOT NULL )			
BEGIN
	DECLARE @error VARCHAR(MAX)
	SET @error='Ошибка! Вы пытаетесь добавить сотруднику еще одну основную должность. id='+CONVERT(VARCHAR(MAX),@idFactStaffHistory)
      RAISERROR(@error, 16,1)
      ROLLBACK TRAN 
END
GO
CREATE TRIGGER [dbo].[FactStaffHistoryNotMoreStaffs]
 ON [dbo].[FactStaffHistory]
  FOR UPDATE, INSERT
AS


IF EXISTS(SELECT PlanStaff.id, PlanStaff.StaffCount,INSERTED.StaffCount, SUM(AllFactStaff.StaffCount) AS FactStaffCount 
		FROM INSERTED
			INNER JOIN
				dbo.FactStaff FactStaffCurrent ON INSERTED.idFactStaff=FactStaffCurrent.id
			INNER JOIN 
				dbo.PlanStaffCurrent PlanStaff ON FactStaffCurrent.idPlanStaff=PlanStaff.id
			INNER JOIN
				dbo.FactStaffCurrent AllFactStaff ON FactStaffCurrent.idPlanStaff=AllFactStaff.idPlanStaff
					AND AllFactStaff.id<>INSERTED.idFactStaff
		WHERE FactStaffCurrent.idEndPrikaz IS NULL		--СТАВКИ ОТКРЫТЫ
			AND AllFactStaff.idEndPrikaz IS NULL		--ШТАТНОЕ ОТКРЫТО
			AND FactStaffCurrent.IsReplacement=0	--не совмещение
			AND AllFactStaff.IsReplacement=0	--не совмещение
		GROUP BY PlanStaff.id,PlanStaff.StaffCount,INSERTED.StaffCount
		HAVING (SUM(AllFactStaff.StaffCount)+INSERTED.StaffCount)>PlanStaff.StaffCount
)			
BEGIN
      RAISERROR('Ошибка! Вы пытаетесь добавить ставку в запись штатного расписания, в которой уже заняты все ставки.', 16,1)
      ROLLBACK TRAN 
END

GO
DISABLE TRIGGER [dbo].[FactStaffHistoryNotMoreStaffs]
    ON [dbo].[FactStaffHistory];

