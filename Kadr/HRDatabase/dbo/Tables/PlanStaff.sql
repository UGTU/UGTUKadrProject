CREATE TABLE [dbo].[PlanStaff] (
    [id]            INT      IDENTITY (1, 1) NOT NULL,
    [idDepartment]  INT      NOT NULL,
    [idPost]        INT      NOT NULL,
    [idEndPrikaz]   INT      NULL,
    [DateEnd]       DATETIME NULL,
    [IdWorkShedule] INT      CONSTRAINT [DF_PlanStaff_IdWorkShedule] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_PlanStaff] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_PlanStaff_Dep] FOREIGN KEY ([idDepartment]) REFERENCES [dbo].[Dep] ([id]),
    CONSTRAINT [FK_PlanStaff_Post] FOREIGN KEY ([idPost]) REFERENCES [dbo].[Post] ([id]),
    CONSTRAINT [FK_PlanStaff_Prikaz] FOREIGN KEY ([idEndPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [FK_PlanStaff_WorkShedule] FOREIGN KEY ([IdWorkShedule]) REFERENCES [ShemaTabel].[WorkShedule] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffDep]
    ON [dbo].[PlanStaff]([idDepartment] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffPost]
    ON [dbo].[PlanStaff]([idPost] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffidEndPrikaz]
    ON [dbo].[PlanStaff]([idEndPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PlanStaffDateEnd]
    ON [dbo].[PlanStaff]([DateEnd] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffUpdateRegister]
   ON  dbo.PlanStaff
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idDepartment)+' '+RTRIM(idPost)+ ' '+' '+RTRIM(idEndPrikaz)+' '+RTRIM(DateEnd)  from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,7,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffInsertRegister]
   ON  dbo.PlanStaff
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idDepartment)+' '+RTRIM(idPost)+ ' '+' '+RTRIM(idEndPrikaz)+' '+RTRIM(DateEnd) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,7,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffDeleteRegister]
   ON  dbo.PlanStaff
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idDepartment)+' '+RTRIM(idPost)+ ' '+' '+RTRIM(idEndPrikaz)+' '+RTRIM(DateEnd) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,7,@name
END

GO
--при удалении записи в штатном расписании каскадно удаляем индивидуальные оклады
CREATE TRIGGER [dbo].[PlanStaffDelete]
 ON dbo.PlanStaff
instead of
  DELETE
AS

delete from dbo.PlanStaffSalary
where idPlanStaff in
(select id from deleted)

delete from
dbo.PlanStaff
where id in
(select id from deleted)

GO
--если штат отменяется, то нужно отменить все его надбавки (с даты увольнения)
CREATE TRIGGER [dbo].[PlanStaffCancelBonus]
 ON [dbo].[PlanStaff]
  FOR UPDATE, INSERT
AS



UPDATE dbo.Bonus
SET DateEnd=CONVERT(DATE,Prikaz.DatePrikaz), idEndPrikaz=INSERTED.idEndPrikaz
FROM INSERTED, Bonus, dbo.BonusPlanStaff, Prikaz
WHERE INSERTED.idEndPrikaz IS NOT NULL
	AND (Bonus.DateEnd IS NULL OR Bonus.DateEnd>CONVERT(DATE,Prikaz.DatePrikaz))	--либо даты отмены нет, либо она позже даты увольнения
	AND Bonus.id=BonusPlanStaff.idBonus
	AND INSERTED.id=BonusPlanStaff.idPlanStaff
	AND INSERTED.idEndPrikaz=Prikaz.id

GO
--если закрывается запись штатного расписания
--проверяем, чтобы все ставки также были закрыты
CREATE TRIGGER [dbo].[PlanStaffBeforClose]
 ON dbo.PlanStaff
  FOR UPDATE, INSERT
AS

IF EXISTS(SELECT 'TRUE' FROM INSERTED, dbo.FactStaff 
		WHERE INSERTED.id=FactStaff.idPlanStaff  
			AND INSERTED.idEndPrikaz IS NOT NULL		--ШТАТНОЕ ЗАКРЫТО
			AND FactStaff.idEndPrikaz IS NULL)			--СТАВКА НЕ ЗАКРЫТА
BEGIN
      RAISERROR('Ошибка! Вы пытаетесь закрыть запись штатного расписания, в которой еще не закрыты все ставки.', 16,1)
      ROLLBACK TRAN 
END

GO
DISABLE TRIGGER [dbo].[PlanStaffBeforClose]
    ON [dbo].[PlanStaff];

