USE [Kadr]
GO

/****** Object:  Table [dbo].[PlanStaffHistory]    Script Date: 04/03/2012 09:37:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--создание таблицы
CREATE TABLE [dbo].[PlanStaffHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPlanStaff] [int] NOT NULL,
	[idBeginPrikaz] [int] NOT NULL,
	[DateBegin] [datetime] NOT NULL,
	[StaffCount] [numeric](4, 2) NOT NULL,
	[idFinancingSource] [int] NOT NULL,
 CONSTRAINT [PK_PlanStaffHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PlanStaffHistory]  WITH CHECK ADD  CONSTRAINT [FK_PlanStaffHistory_FinancingSource] FOREIGN KEY([idFinancingSource])
REFERENCES [dbo].[FinancingSource] ([id])
GO

ALTER TABLE [dbo].[PlanStaffHistory] CHECK CONSTRAINT [FK_PlanStaffHistory_FinancingSource]
GO

ALTER TABLE [dbo].[PlanStaffHistory]  WITH CHECK ADD  CONSTRAINT [FK_PlanStaffHistory_PlanStaff] FOREIGN KEY([idPlanStaff])
REFERENCES [dbo].[PlanStaff] ([id])
GO

ALTER TABLE [dbo].[PlanStaffHistory] CHECK CONSTRAINT [FK_PlanStaffHistory_PlanStaff]
GO

ALTER TABLE [dbo].[PlanStaffHistory]  WITH CHECK ADD  CONSTRAINT [FK_PlanStaffHistory_Prikaz] FOREIGN KEY([idBeginPrikaz])
REFERENCES [dbo].[Prikaz] ([id])
GO

ALTER TABLE [dbo].[PlanStaffHistory] CHECK CONSTRAINT [FK_PlanStaffHistory_Prikaz]
GO


--delete from dbo.PlanStaffHistory

---заполнение таблицы
insert into dbo.PlanStaffHistory(idPlanStaff,idBeginPrikaz,DateBegin,StaffCount,idFinancingSource)
select id,idBeginPrikaz,DateBegin,StaffCount,idFinancingSource
from dbo.PlanStaffWithHistory
where idFinancingSource is not null
order by DateBegin


GO
--select * from [PlanStaffMain] where id = 172 order by DateBegin
--Представление со всеми параметрами PlanStaff (первоначальными DateBegin...) 
alter VIEW [dbo].[PlanStaffMain]
AS
--выбираем первоначальные изменения из истории
SELECT  PlanStaff.id, PlanStaffHistory.StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, PlanStaffHistory.idBeginPrikaz, 
	PlanStaff.idEndPrikaz, PlanStaffHistory.idFinancingSource, 
	CONVERT(date,PlanStaffHistory.DateBegin) DateBegin, CONVERT(date,PlanStaff.DateEnd) DateEnd 
FROM         
	dbo.PlanStaff INNER JOIN
	 dbo.PlanStaffHistory ON PlanStaff.id=PlanStaffHistory.idPlanStaff
		AND PlanStaffHistory.DateBegin = 
			(SELECT MIN(PlanStaffHistory.DateBegin) FROM dbo.PlanStaffHistory 
				WHERE PlanStaffHistory.idPlanStaff=PlanStaff.id)
	


GO
--select * from [PlanStaffCurrent] where id = 172 order by DateBegin
--Представление со всеми текущими параметрами PlanStaff (DateBegin...) 
CREATE VIEW [dbo].[PlanStaffCurrent]
AS
--выбираем текущие изменения 
SELECT  PlanStaff.id, PlanStaffHistory.StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, PlanStaffHistory.idBeginPrikaz, 
	PlanStaff.idEndPrikaz, PlanStaffHistory.idFinancingSource, 
	CONVERT(date,PlanStaffHistory.DateBegin) DateBegin, CONVERT(date,PlanStaff.DateEnd) DateEnd 
FROM         
	dbo.PlanStaff INNER JOIN
	 dbo.PlanStaffHistory ON PlanStaff.id=PlanStaffHistory.idPlanStaff
		AND PlanStaffHistory.DateBegin = 
			(SELECT MAX(PlanStaffHistory.DateBegin) FROM dbo.PlanStaffHistory 
				WHERE PlanStaffHistory.idPlanStaff=PlanStaff.id AND
					PlanStaffHistory.DateBegin<GETDATE())






go

--select * from [PlanStaffWithHistory] where id = 172 order by DateBegin
--Представление со всей историей штатного расписания
ALTER VIEW [dbo].[PlanStaffWithHistory]
AS

SELECT  PlanStaff.id, DistinctPlanStaffHistory.StaffCount, PlanStaff.idDepartment, 
	PlanStaff.idPost, DistinctPlanStaffHistory.idBeginPrikaz, 
	ISNULL(NextDistinctPlanStaffHistory.idBeginPrikaz, PlanStaff.idEndPrikaz) idEndPrikaz, 
	DistinctPlanStaffHistory.idFinancingSource, 
	DistinctPlanStaffHistory.DateBegin, 
	ISNULL(NextDistinctPlanStaffHistory.DateBegin-1, PlanStaff.DateEnd) DateEnd 
FROM 
	dbo.PlanStaff
	INNER JOIN 
	/*(SELECT idPlanStaff, DateBegin, MAX(id) id
		FROM dbo.PlanStaffHistory
		GROUP BY idPlanStaff, DateBegin) DistPlanStaffHistory
	ON PlanStaff.id=DistPlanStaffHistory.idPlanStaff
	INNER JOIN*/
	 dbo.PlanStaffHistory DistinctPlanStaffHistory
		ON DistinctPlanStaffHistory.idPlanStaff=PlanStaff.id
	 LEFT JOIN	--выбираем ближайшее следующее изменение
	 dbo.PlanStaffHistory NextDistinctPlanStaffHistory ON PlanStaff.id=NextDistinctPlanStaffHistory.idPlanStaff
			AND CONVERT(date, NextDistinctPlanStaffHistory.DateBegin) =
				(SELECT CONVERT(date, MIN(history.DateBegin)) FROM dbo.PlanStaffHistory history 
					WHERE DistinctPlanStaffHistory.idPlanStaff=history.idPlanStaff 
						AND history.DateBegin>DistinctPlanStaffHistory.DateBegin)




go
drop table dbo.PlanStaffHistoryChanges

go
GO

ALTER TABLE dbo.PlanStaffHistory  WITH CHECK ADD  CONSTRAINT [CK_PlanStaffHistoryStaffCount] CHECK  (([StaffCount]>(0)))
GO

ALTER TABLE [dbo].PlanStaffHistory CHECK CONSTRAINT [CK_PlanStaffHistoryStaffCount]
GO

--select * from [dbo].[GetFactStaffForTimeSheet]('1.02.2011','28.02.2011')where  idDepartment=39 
ALTER FUNCTION [dbo].[GetFactStaffForTimeSheet] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idFactStaff		INT NOT NULL,
    StaffCount	numeric(4,2) NOT NULL,
    idDepartment	INT NOT NULL,
    IsReplacement	BIT NOT NULL,
	idTypeWork		INT,
	idPost		 INT,
	idPlanStaff  INT,
	idEmployee   INT,
	idFinancingSource	INT,
	isMain		BIT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
	INSERT INTO @Result
	SELECT DISTINCT FactStaff.id, FactStaff.StaffCount, idDepartment,WorkType.IsReplacement, 0, idPost,
	idPlanStaff, idEmployee, idFinancingSource, 0
	FROM  dbo.FactStaffWithHistory as FactStaff, dbo.PlanStaffCurrent PlanStaff, dbo.WorkType
	WHERE
		((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
								OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
		AND FactStaff.idPlanStaff=PlanStaff.id
		AND FactStaff.idTypeWork=WorkType.id
		  
RETURN
END


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
	SELECT 'Уволен' as Operation, FactStaff.id idFactStaff, idPlanStaff, idEmployee, 
			idTypeWork, StaffCount, IsReplacement, DateEnd OperationDate, idEndPrikaz idOperationPrikaz
	FROM dbo.FactStaff
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


GO
--select * from [dbo].[GetPostStaffChangesByPeriod](1,'20.01.2011','20.02.2012',1) order by DepartmentName OperationDate where idPlanStaff=1066
--Процедура возвращает все изменения в штатном расписании, произошедшие за период
ALTER FUNCTION [dbo].[GetPostStaffChangesByPeriod] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
	DepartmentName			VARCHAR(150),
	OperationName			VARCHAR(50),
 	OperationDate			date,
    StaffCount				DECIMAL(10,2),
    FinancingSourceName		VARCHAR(50),
    PostName				VARCHAR(150) NULL,
	CategoryName			VARCHAR(50),
    PKCategoryName			VARCHAR(50),
	SalarySize				DECIMAL(10,2),
	OperationPrikazName		VARCHAR(50),
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	--idReplacementReason	INT,						--причина замещения	 			
	idPlanStaff				INT,
	PredStaffCount			DECIMAL(10,2)
	
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
	select Department.DepartmentSmallName, OperationName, CONVERT(date, OperationDate),
		StaffCount, FinancingSourceName, PostName,
		CategorySmallName, CONVERT(VARCHAR(3),GroupNumber)+' '+CONVERT(VARCHAR(3),PKCategoryNumber) PKCategoryName, SalarySize, 
		PrikazName+' от '+CONVERT(VARCHAR(10),CONVERT(Date,DatePrikaz)) OperationPrikazName, 
		@PeriodBegin, @PeriodEnd, PlanStaffHistory.id, PredStaffCount
		from 
		@DepTable deps 
		INNER JOIN dbo.Department ON deps.idDepartment=Department.id
		INNER JOIN (SELECT PlanStaffWithHistory.id, PlanStaffWithHistory.idDepartment,  
					(PlanStaffWithHistory.StaffCount-ISNULL(PredPlanStaffHistoryChanges.StaffCount,0)) as StaffCount,
					PlanStaffWithHistory.idPost, PlanStaffWithHistory.idBeginPrikaz idOperationPrikaz,
					PlanStaffWithHistory.idFinancingSource, PlanStaffWithHistory.DateBegin OperationDate,
					PredPlanStaffHistoryChanges.StaffCount PredStaffCount, 
					'Добавление' OperationName --добавление ставок
				FROM dbo.PlanStaffWithHistory  
					LEFT JOIN
					dbo.PlanStaffWithHistory AS PredPlanStaffHistoryChanges ON PlanStaffWithHistory.id=PredPlanStaffHistoryChanges.id--PlanStaff 
						AND PlanStaffWithHistory.DateBegin >
							PredPlanStaffHistoryChanges.DateBegin
						AND PredPlanStaffHistoryChanges.DateBegin =
							(SELECT MAX(PrevPlanStaffHistoryChanges.DateBegin) FROM dbo.PlanStaffWithHistory PrevPlanStaffHistoryChanges 
								WHERE PrevPlanStaffHistoryChanges.id=PlanStaffWithHistory.id
									AND PrevPlanStaffHistoryChanges.DateBegin<PlanStaffWithHistory.DateBegin)
				WHERE 
					PlanStaffWithHistory.DateBegin >= @PeriodBegin AND PlanStaffWithHistory.DateBegin <= @PeriodEnd
			UNION
				--отмена ставок
				SELECT PlanStaffWithHistory.id, PlanStaffWithHistory.idDepartment,  
					(PredPlanStaffHistoryChanges.StaffCount) as StaffCount,
					PlanStaffWithHistory.idPost, PlanStaffWithHistory.idEndPrikaz idOperationPrikaz,
					PredPlanStaffHistoryChanges.idFinancingSource, PlanStaffWithHistory.DateEnd OperationDate,
					PredPlanStaffHistoryChanges.StaffCount PredStaffCount, 'Вывод штатов' OperationName --добавление ставок
				FROM dbo.PlanStaff PlanStaffWithHistory
				INNER JOIN
					dbo.PlanStaffWithHistory AS PredPlanStaffHistoryChanges 
						ON PlanStaffWithHistory.id=PredPlanStaffHistoryChanges.id 
						AND PredPlanStaffHistoryChanges.DateBegin = 
							(SELECT MAX(PlanStaffWithHistory.DateBegin) 
								FROM dbo.PlanStaffWithHistory WHERE PlanStaffWithHistory.id=PredPlanStaffHistoryChanges.id) 
				WHERE 
					PlanStaffWithHistory.DateEnd >= @PeriodBegin AND PlanStaffWithHistory.DateEnd <= @PeriodEnd)PlanStaffHistory
			ON deps.idDepartment=PlanStaffHistory.idDepartment	
		INNER JOIN dbo.Post ON PlanStaffHistory.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.PKCategory ON Post.idPKCategory=PKCategory.id
		INNER JOIN dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id
		INNER JOIN dbo.FinancingSource ON PlanStaffHistory.idFinancingSource=FinancingSource.id
		INNER JOIN dbo.Prikaz ON PlanStaffHistory.idOperationPrikaz=Prikaz.id
		LEFT JOIN
		[dbo].[GetSalaryByPeriod](@PeriodBegin,@PeriodEnd)Salary
		ON PlanStaffHistory.id=Salary.idPlanStaff		
		
		UPDATE @Result
		SET OperationName='Уменьшение', StaffCount=-StaffCount
		WHERE StaffCount<0
		
		UPDATE @Result
		SET OperationName='Ввод штатов'
		WHERE PredStaffCount IS NULL

	RETURN
	

		  
		  
RETURN
END












--триггеры
go
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[PlanStaffUpdateRegister]
   ON  [dbo].[PlanStaff]
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

go
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffHistoryUpdateRegister]
   ON  [dbo].[PlanStaffHistory]
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(StaffCount)+' '+RTRIM(idFinancingSource)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,19,@name
END



GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[PlanStaffInsertRegister]
   ON  [dbo].[PlanStaff]
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
CREATE TRIGGER [dbo].[PlanStaffHistoryInsertRegister]
   ON  [dbo].[PlanStaffHistory]
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(StaffCount)+' '+RTRIM(idFinancingSource)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,19,@name
END

GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER TRIGGER [dbo].[PlanStaffDeleteRegister]
   ON  [dbo].[PlanStaff]
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


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[PlanStaffHistoryDeleteRegister]
   ON  [dbo].[PlanStaffHistory]
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(idPlanStaff)+ ' '+RTRIM(StaffCount)+' '+RTRIM(idFinancingSource)+' '+RTRIM(idBeginPrikaz)+' '+RTRIM(DateBegin) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,19,@name
END
