GO

CREATE TABLE [dbo].[DepartmentHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idDepartment] [int] NOT NULL,
	[idManagerDepartment] [int] NOT NULL,
	[idBeginPrikaz] [int] NOT NULL,
	[DateBegin] [datetime] NOT NULL,
	[DepartmentName] [varchar](200) NOT NULL,
	[DepartmentSmallName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_DepartmentHistory] PRIMARY KEY NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_DepartmentHistoryUnique] UNIQUE CLUSTERED 
(
	[idDepartment] ASC,
	[DateBegin] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[DepartmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentHistory_Department] FOREIGN KEY([idDepartment])
REFERENCES [dbo].[Department] ([id])
GO

ALTER TABLE [dbo].[DepartmentHistory] CHECK CONSTRAINT [FK_DepartmentHistory_Department]
GO

ALTER TABLE [dbo].[DepartmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentHistory_Department1] FOREIGN KEY([idManagerDepartment])
REFERENCES [dbo].[Department] ([id])
GO

ALTER TABLE [dbo].[DepartmentHistory] CHECK CONSTRAINT [FK_DepartmentHistory_Department1]
GO

ALTER TABLE [dbo].[DepartmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentHistory_Prikaz] FOREIGN KEY([idBeginPrikaz])
REFERENCES [dbo].[Prikaz] ([id])
GO

ALTER TABLE [dbo].[DepartmentHistory] CHECK CONSTRAINT [FK_DepartmentHistory_Prikaz]
GO



--заполнение
INSERT INTO [Kadr].[dbo].[DepartmentHistory]
           ([idDepartment]
           ,[idManagerDepartment]
           ,[idBeginPrikaz]
           ,[DateBegin]
           ,[DepartmentName]
           ,[DepartmentSmallName])
select [id]
           ,[idManagerDepartment]
           ,[idBeginPrikaz]
           ,ISNULL(dateCreate,'01.01.2010')
           ,[DepartmentName]
           ,[DepartmentSmallName]
           from dbo.Dep
GO




GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[DepartmentUpdateRegister]
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
ALTER TRIGGER [dbo].[DepartmentInsertRegister]
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
ALTER TRIGGER [dbo].[DepartmentDeleteRegister]
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


go

update dbo.DepartmentHistory
set DateBegin='01.01.2010'
where DateBegin is null
GO

ALTER TABLE  dbo.DepartmentHistory ADD CONSTRAINT [DF_DepartmentHistory_DateBegin]  DEFAULT ((GETDATE())) FOR DateBegin



GO


--select * from [Department] 
--Представление со всеми текущими параметрами Department (DateBegin...) 
CREATE VIEW [dbo].Department
AS
SELECT  Dep.[id]
      ,DepartmentHistory.[DepartmentName]
      ,DepartmentHistory.[DepartmentSmallName]
      ,Dep.[idDepartmentType]
      ,DepartmentHistory.[idManagerDepartment]
      ,Dep.[KadrID]
      ,DepartmentHistory.DateBegin [dateCreate]
      ,Dep.[dateExit]
      ,Dep.[idManagerPlanStaff]
      ,DepartmentHistory.[idBeginPrikaz]
      ,Dep.[idEndPrikaz]
      ,Dep.[SeverKoeff]
      ,Dep.[RayonKoeff]
      ,Dep.[DepartmentGUID]
FROM         
	dbo.Dep INNER JOIN
	 dbo.DepartmentHistory ON Dep.id=DepartmentHistory.idDepartment
		AND DepartmentHistory.DateBegin = 
			(SELECT MAX(DepartmentHistory.DateBegin) FROM dbo.DepartmentHistory 
				WHERE DepartmentHistory.idDepartment=Dep.id AND
					DepartmentHistory.DateBegin<GETDATE())