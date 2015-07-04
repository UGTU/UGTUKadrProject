use Kadr

alter table dbo.EducDocument
add idEmployee INT

GO

ALTER TABLE  dbo.EducDocument WITH CHECK ADD  CONSTRAINT [FK_EducDocument_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
GO

ALTER TABLE [dbo].EducDocument CHECK CONSTRAINT [FK_EducDocument_Employee]

go
update dbo.EducDocument
set idEmployee=EmployeeDegree.idEmployee
from dbo.EducDocument inner join dbo.EmployeeDegree
on EducDocument.id=EmployeeDegree.idEducDocument

update dbo.EducDocument
set idEmployee=dbo.EmployeeRank.idEmployee
from dbo.EducDocument inner join dbo.EmployeeRank
on EducDocument.id=dbo.EmployeeRank.idEducDocument

--select * 
--from dbo.EducDocument inner join dbo.EmployeeDegree
--on EducDocument.id=EmployeeDegree.idEducDocument


--триггеры
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[EmployeeDegreeDeleteRegister]
   ON  [dbo].[EmployeeDegree]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idDegree)+ ' '+RTRIM(idEducDocument)+' '+RTRIM(idScienceType)+ ' '+RTRIM(DissertCouncil)+ ' '+RTRIM(diplWhere) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,4,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[EmployeeDegreeInsertRegister]
   ON  [dbo].[EmployeeDegree]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idDegree)+ ' '+RTRIM(idEducDocument)+' '+RTRIM(idScienceType)+ ' '+RTRIM(DissertCouncil)+ ' '+RTRIM(diplWhere) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,4,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[EmployeeDegreeUpdateRegister]
   ON  [dbo].[EmployeeDegree]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idDegree)+' ' +RTRIM(idEducDocument)+' '+RTRIM(idScienceType)+ ' '+RTRIM(DissertCouncil)+ ' '+RTRIM(diplWhere) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,4,@name
END


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[EmployeeRankDeleteRegister]
   ON  [dbo].[EmployeeRank]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(idRank)+' '+RTRIM(idEducDocument)+' '+RTRIM(rankWhere) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,5,@name
END


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[EmployeeRankUpdateRegister]
   ON  [dbo].[EmployeeRank]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(idRank)+' '+RTRIM(idEducDocument)+' '+RTRIM(rankWhere) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,5,@name
END


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[EmployeeRankInsertRegister]
   ON  [dbo].[EmployeeRank]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(idRank)+' '+RTRIM(idEducDocument)+' '+RTRIM(rankWhere) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,5,@name
END


---удаление столбцов
GO

/****** Object:  Index [IX_EmployeeZvanye]    Script Date: 06/28/2011 10:16:53 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeRank]') AND name = N'IX_EmployeeZvanye')
ALTER TABLE [dbo].[EmployeeRank] DROP CONSTRAINT [IX_EmployeeZvanye]
go
ALTER TABLE [dbo].[EmployeeRank] DROP CONSTRAINT FK_EmployeeZvanye_Employee

go
alter table dbo.EmployeeRank
drop column idEmployee

GO

/****** Object:  Index [IX_EmployeeZvanye]    Script Date: 06/28/2011 10:16:53 ******/
ALTER TABLE dbo.EmployeeDegree DROP CONSTRAINT IX_EmployeeDegree
go
ALTER TABLE dbo.EmployeeDegree DROP CONSTRAINT IX_EmployeeDegree_1
go
ALTER TABLE dbo.EmployeeDegree DROP CONSTRAINT FK_EmployeeDegree_Employee

go
alter table dbo.EmployeeDegree
drop column idEmployee