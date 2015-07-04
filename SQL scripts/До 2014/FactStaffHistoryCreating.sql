USE [kadrTest]
GO

/****** Object:  Table [dbo].[FactStaffHistory]    Script Date: 04/06/2012 13:02:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FactStaffHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idFactStaff] [int] NOT NULL,
	[idBeginPrikaz] [int] NOT NULL,
	[DateBegin] [datetime] NOT NULL,
	[StaffCount] [numeric](4, 2) NOT NULL,
	[idTypeWork] [int] NOT NULL,
 CONSTRAINT [PK_FactStaffHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FactStaffHistory]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffHistory_FactStaff] FOREIGN KEY([idFactStaff])
REFERENCES [dbo].[FactStaff] ([id])
GO

ALTER TABLE [dbo].[FactStaffHistory] CHECK CONSTRAINT [FK_FactStaffHistory_FactStaff]
GO

ALTER TABLE [dbo].[FactStaffHistory]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffHistory_Prikaz] FOREIGN KEY([idBeginPrikaz])
REFERENCES [dbo].[Prikaz] ([id])
GO

ALTER TABLE [dbo].[FactStaffHistory] CHECK CONSTRAINT [FK_FactStaffHistory_Prikaz]
GO

ALTER TABLE [dbo].[FactStaffHistory]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffHistory_WorkType] FOREIGN KEY([idTypeWork])
REFERENCES [dbo].[WorkType] ([id])
GO

ALTER TABLE [dbo].[FactStaffHistory] CHECK CONSTRAINT [FK_FactStaffHistory_WorkType]
GO




go
---заполнение таблицы
insert into dbo.FactStaffHistory(idFactStaff,idBeginPrikaz,DateBegin,StaffCount,idTypeWork)
select id,idBeginPrikaz,DateBegin,StaffCount,idTypeWork
from dbo.FactStaffWithHistory
where idTypeWork is not null
order by DateBegin




go
GO
--select * from [FactStaffMain] where id = 172 order by DateBegin
--Представление со всеми параметрами FactStaff (первоначальными DateBegin...) 
alter VIEW [dbo].[FactStaffMain]
AS
--выбираем последние изменения - которые берем из PlanStaff
SELECT  FactStaff.id, FactStaffHistory.StaffCount, FactStaff.idPlanStaff, 
	FactStaff.idEmployee, FactStaffHistory.idBeginPrikaz, 
	FactStaff.idEndPrikaz, FactStaffHistory.idTypeWork, 
	CONVERT(date,FactStaffHistory.DateBegin) DateBegin, CONVERT(date,FactStaff.DateEnd) DateEnd,
	IsReplacement, idTimeSheetSheduleType
FROM         
	dbo.FactStaff INNER JOIN
	 dbo.FactStaffHistory ON FactStaff.id=FactStaffHistory.idFactStaff
		AND FactStaffHistory.DateBegin = 
			(SELECT MIN(FactStaffHistory.DateBegin) FROM dbo.FactStaffHistory 
				WHERE FactStaffHistory.idFactStaff=FactStaff.id)
	


GO
--select * from [FactStaffCurrent] where id = 172 order by DateBegin
--Представление со всеми текущими параметрами FactStaff (DateBegin...) 
alter VIEW [dbo].[FactStaffCurrent]
AS
SELECT  FactStaff.id, FactStaffHistory.StaffCount, FactStaff.idPlanStaff, 
	FactStaff.idEmployee, FactStaffHistory.idBeginPrikaz, 
	FactStaff.idEndPrikaz, FactStaffHistory.idTypeWork, 
	CONVERT(date,FactStaffHistory.DateBegin) DateBegin, CONVERT(date,FactStaff.DateEnd) DateEnd,
	IsReplacement, idTimeSheetSheduleType
FROM         
	dbo.FactStaff INNER JOIN
	 dbo.FactStaffHistory ON FactStaff.id=FactStaffHistory.idFactStaff
		AND FactStaffHistory.DateBegin = 
			(SELECT MAX(FactStaffHistory.DateBegin) FROM dbo.FactStaffHistory 
				WHERE FactStaffHistory.idFactStaff=FactStaff.id AND
					FactStaffHistory.DateBegin<GETDATE())






go

--select * from [FactStaffWithHistory] where id = 172 order by DateBegin
--Представление со всей историей распределения штатов
ALTER VIEW [dbo].[FactStaffWithHistory]
AS

--выбираем последние изменения - которые берем из PlanStaff
SELECT  FactStaff.id, DistinctFactStaffHistory.StaffCount, FactStaff.idPlanStaff, 
	FactStaff.idEmployee, DistinctFactStaffHistory.idBeginPrikaz, 
	ISNULL(NextDistinctFactStaffHistory.idBeginPrikaz, FactStaff.idEndPrikaz) idEndPrikaz, 
	DistinctFactStaffHistory.idTypeWork, 
	DistinctFactStaffHistory.DateBegin, 
	ISNULL(NextDistinctFactStaffHistory.DateBegin-1, FactStaff.DateEnd) DateEnd,
	IsReplacement, idTimeSheetSheduleType 
FROM 
	dbo.FactStaff
	INNER JOIN 
	/*(SELECT idPlanStaff, DateBegin, MAX(id) id
		FROM dbo.PlanStaffHistory
		GROUP BY idPlanStaff, DateBegin) DistPlanStaffHistory
	ON PlanStaff.id=DistPlanStaffHistory.idPlanStaff
	INNER JOIN*/
	 dbo.FactStaffHistory DistinctFactStaffHistory
		ON DistinctFactStaffHistory.idFactStaff=FactStaff.id
	 LEFT JOIN	--выбираем ближайшее следующее изменение
	 dbo.FactStaffHistory NextDistinctFactStaffHistory ON FactStaff.id=NextDistinctFactStaffHistory.idFactStaff
			AND CONVERT(date, NextDistinctFactStaffHistory.DateBegin) =
				(SELECT CONVERT(date, MIN(history.DateBegin)) FROM dbo.FactStaffHistory history 
					WHERE DistinctFactStaffHistory.idFactStaff=history.idFactStaff
						AND history.DateBegin>DistinctFactStaffHistory.DateBegin)


go
drop table dbo.FactStaffChangesHistory

GO

ALTER TABLE [dbo].[FactStaffHistory] ADD  CONSTRAINT [DF_FactStaffHistory_StaffCount]  DEFAULT ((1)) FOR [StaffCount]

GO

--select * from [dbo].[GetAverageNumEmpl](2011, 64, 1)
--select * from [dbo].[GetFactStaffForTimeSheet]('1.1.2011', '31.1.2011') where idDepartment=18 order by idEmployee


ALTER FUNCTION [dbo].[GetAverageNumEmpl] 
(
@Year	INT,
@idDepartment	INT,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
	DepartmentSmallName		VARCHAR(50),
	CategorySmallName		VARCHAR(50), 
	PostShortName		VARCHAR(50),
	IsSubDep		BIT NOT NULL,
	TypeWorkName	VARCHAR(50),
	TimeSheetYear	INT,
	TimeSheetMonth	INT,
	TimeSheetMonthName VARCHAR(50),
	StaffAverage	FLOAT,
	FreeStaffAverage FLOAT,
	CategoryOrderBy	INT,
	FinancingSourceName VARCHAR(50),
	FinancingSourceOrderBy INT  
   ) 
AS
BEGIN
	
	--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
    IsSubDep		BIT,
    DepartmentName  VARCHAR(50)
	)
	
	INSERT INTO @DepTable	--текущий отдел
		SELECT @idDepartment, 0, DepartmentSmallName
		FROM Department
		WHERE id=@idDepartment
		
	IF (@WithSubDeps = 1)	--если с подотделами
		INSERT INTO @DepTable
		SELECT idDepartment, 1, 'Подчиненные отделы'
		FROM [dbo].[GetSubDepartments](@idDepartment)
		WHERE IsMain=0
		
	
	DECLARE TimeSheetCursor CURSOR LOCAL FAST_FORWARD READ_ONLY FOR 
	SELECT TimeSheet.id,
	CONVERT(date, '01.'+CONVERT(VARCHAR(2),TimeSheet.TimeSheetMonth)+'.'+CONVERT(VARCHAR(4),TimeSheet.TimeSheetYear),103) DateBegin,
	DATEADD(dd, -1, DATEADD(mm, 1, CONVERT(date, '01.'+CONVERT(VARCHAR(2),TimeSheet.TimeSheetMonth)+'.'+CONVERT(VARCHAR(4),TimeSheet.TimeSheetYear),103))) DateEnd 
	FROM dbo.TimeSheet
	WHERE TimeSheet.TimeSheetYear=@Year
		AND TimeSheet.IsFilled=1 
	ORDER BY TimeSheetMonth

	OPEN TimeSheetCursor

	DECLARE @DateBegin DATETIME
	DECLARE @DateEnd DATETIME
	DECLARE @idTimeSheet INT
FETCH NEXT FROM TimeSheetCursor INTO @idTimeSheet, @DateBegin, @DateEnd

WHILE @@FETCH_STATUS = 0
BEGIN
	
		
	
	INSERT INTO @Result
	SELECT DepartmentName, CategorySmallName, PostShortName, IsSubDep, WorkSuperTypeShortName, TimeSheetYear, TimeSheetMonth, MonthName,
		SUM(TimeSheetFSWorkingDays.StaffCount*WorkingDaysCount)/TimeSheetWorkingDayCount,
		SUM(TimeSheetFSWorkingDays.StaffCount*(TimeSheetWorkingDayCount-WorkingDaysCount))/TimeSheetWorkingDayCount,
		Category.OrderBy, FinancingSourceName, FinancingSource.OrderBy
	FROM TimeSheet, dbo.TimeSheetFSWorkingDays, dbo.WorkType,
		[dbo].[GetFactStaffForTimeSheet](@DateBegin, @DateEnd) PeriodStaff, Months, 
		@DepTable as DepList,dbo.FactStaffCurrent FactStaff,
		dbo.Category, dbo.Post, dbo.WorkSuperType, dbo.FinancingSource
	WHERE TimeSheet.id=@idTimeSheet
		AND Months.MonthNumber=TimeSheet.TimeSheetMonth
		AND TimeSheet.id=TimeSheetFSWorkingDays.idTimeSheet
		AND TimeSheetFSWorkingDays.idFactStaff=PeriodStaff.idFactStaff 
			AND TimeSheetFSWorkingDays.StaffCount=PeriodStaff.StaffCount
		AND PeriodStaff.idDepartment=DepList.idDepartment
		AND Post.idCategory=Category.id
		AND PeriodStaff.idPost=Post.id
		AND FactStaff.idTypeWork=WorkType.id
		AND PeriodStaff.idFactStaff=FactStaff.id
		AND WorkType.idWorkSuperType=WorkSuperType.id
		AND TimeSheetFSWorkingDays.IsClosed=1
		AND FinancingSource.id=PeriodStaff.idFinancingSource
		AND WorkType.idWorkSuperType<>4

	GROUP BY DepartmentName, CategorySmallName, PostShortName, IsSubDep, WorkSuperTypeShortName, 
		TimeSheetYear, TimeSheetMonth, TimeSheetWorkingDayCount, MonthName, 
		Category.OrderBy, FinancingSourceName, FinancingSource.OrderBy
	ORDER BY IsSubDep, TimeSheetMonth, WorkSuperTypeShortName, Category.OrderBy
 
	FETCH NEXT FROM TimeSheetCursor INTO @idTimeSheet, @DateBegin, @DateEnd

END
		
RETURN
END

GO
--select * from [dbo].[GetFactStaffChangesByPeriod](141,'20.01.2011','20.02.2011',1)where idPlanStaff=1066
ALTER FUNCTION [dbo].[GetFactStaffChangesByPeriod] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
    TypeWorkName			VARCHAR(50) NULL,
    PKCategoryName			VARCHAR(50),
    FinancingSourceName		VARCHAR(50),
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    StaffCount				DECIMAL(10,2),
	DepartmentName			VARCHAR(150),
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	--idReplacementReason	INT,						--причина замещения	 			
	CategoryName			VARCHAR(50),
	OperationName			VARCHAR(50),
	OperationDate			DATETIME,
	OperationPrikazName		VARCHAR(50),
	idPlanStaff				INT
	
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)

--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
    IsMain			BIT
	)
	
		
	IF (@WithSubDeps = 1)	--если с подотделами
		INSERT INTO @DepTable
		SELECT idDepartment, IsMain
		FROM [dbo].[GetSubDepartments](@idDepartment)
	ELSE
		INSERT INTO @DepTable	--текущий отдел
			SELECT @idDepartment, 1
	

	
	INSERT INTO @Result
	SELECT
	WorkSuperTypeShortName, CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber) PKCategoryName, 
	FinancingSourceName, PostShortName, 
	Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'. '+CONVERT(VARCHAR(1),Employee.Otch)+'.' EmployeeName,
    FactStaff.StaffCount, DepartmentSmallName, @PeriodBegin, @PeriodEnd,
	CategorySmallName, OperationName, 
	OperationDate, PrikazName+' от '+CONVERT(VARCHAR(10),CONVERT(Date,DatePrikaz)) OperationPrikazName,
	PlanStaff.id
	FROM
	
	(SELECT 'Принят' as OperationName, idFactStaff, idPlanStaff, idEmployee, 
			idTypeWork, StaffCount, IsReplacement, DateBegin OperationDate, idBeginPrikaz idOperationPrikaz
	FROM  [dbo].GetRecruitedFactStaffByPeriod(@PeriodBegin, @PeriodEnd) as FactStaff 
	WHERE 
		((FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
		
	UNION
	SELECT 'Уволен' as OperationName, FactStaff.id idFactStaff, idPlanStaff, idEmployee, 
			idTypeWork, StaffCount, IsReplacement, DateEnd OperationDate, idEndPrikaz idOperationPrikaz
	FROM dbo.FactStaffCurrent FactStaff
	WHERE FactStaff.DateEnd>=@PeriodBegin AND FactStaff.DateEnd<=@PeriodEnd) FactStaff
	INNER JOIN dbo.PlanStaffCurrent PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id  
		INNER JOIN dbo.Department ON PlanStaff.idDepartment=Department.id
		INNER JOIN dbo.Post ON PlanStaff.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.PKCategory ON Post.idPKCategory=PKCategory.id
		INNER JOIN dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id
		INNER JOIN dbo.FinancingSource ON PlanStaff.idFinancingSource=FinancingSource.id
		INNER JOIN dbo.WorkType ON FactStaff.idTypeWork=WorkType.id
		INNER JOIN dbo.WorkSuperType ON WorkType.idWorkSuperType=WorkSuperType.id
		INNER JOIN dbo.Employee ON FactStaff.idEmployee=Employee.id
		INNER JOIN dbo.Prikaz ON FactStaff.idOperationPrikaz=Prikaz.id
		INNER JOIN @DepTable deps ON Department.id=deps.idDepartment
		


		  
		  
RETURN
END



go
--Триггеры
ALTER TRIGGER [dbo].[FactStaffInsertRegister]
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
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[FactStaffUpdateRegister]
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
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[FactStaffDeleteRegister]
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
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[FactStaffHistoryDeleteRegister]
   ON  [dbo].[FactStaffHistory]
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
   ON  [dbo].[FactStaffHistory]
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
   ON  [dbo].[FactStaffHistory]
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
