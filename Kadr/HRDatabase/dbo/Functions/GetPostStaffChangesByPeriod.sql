--select * from [dbo].[GetPostStaffChangesByPeriod](1,'20.08.2013','20.09.2015',1) order by DepartmentName OperationDate where idPlanStaff=1066
--Процедура возвращает все изменения в штатном расписании, произошедшие за период
CREATE FUNCTION [dbo].[GetPostStaffChangesByPeriod] 
(
@idDepartment INT,
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL,
@WithSubDeps BIT
)
RETURNS @Result TABLE
   (
	DepartmentName			VARCHAR(500),
	OperationName			VARCHAR(50),
 	OperationDate			date,
    StaffCount				DECIMAL(14,2),
    FinancingSourceName		VARCHAR(50),
    PostName				VARCHAR(150) NULL,
	CategoryName			VARCHAR(50),
    PKCategoryName			VARCHAR(50),
	SalarySize				DECIMAL(14,2),
	OperationPrikazName		VARCHAR(100),
	PeriodBegin				DATETIME,
	PeriodEnd				DATETIME,
	--idReplacementReason	INT,						--причина замещения	 			
	idPlanStaff				INT,
	PredStaffCount			DECIMAL(14,2),
	IsIndividual			BIT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN;

	--объявляем временную таблицу, в которую внесем все ОТДЕЛЫ, по которым нужно вывести данные
	DECLARE @DepTable Table
	(
    idDepartment	INT NULL,
    IsMain			BIT,
	[DepartmentName] VARCHAR(500),
	[DepartmentSmallName] VARCHAR(50)
	)
	
		
	IF (@WithSubDeps = 1)	--если с подотделами

		INSERT INTO @DepTable
		SELECT idDepartment, IsMain, DepartmentName,DepartmentSmallName
		FROM [dbo].GetSubDepartmentsWithPeriod(@idDepartment, @PeriodBegin, @PeriodEnd)
	ELSE
		INSERT INTO @DepTable	--текущий отдел
			SELECT @idDepartment, 1, DepartmentName,DepartmentSmallName
				FROM [dbo].[Department]
				WHERE [id]=@idDepartment


	INSERT INTO @Result
	select deps.DepartmentName, OperationName, CONVERT(date, OperationDate),
		StaffCount, FinancingSourceName, PostName,
		CategorySmallName, PKCategory.PKCategoryFullName+' '+PKCategory.PKSubSubCategoryNumber PKCategoryName, SalarySize, 
		PrikazName+' от '+CONVERT(VARCHAR(10),CONVERT(Date,DatePrikaz)) OperationPrikazName, 
		@PeriodBegin, @PeriodEnd, PlanStaffHistory.id, PredStaffCount, IsIndividual
		from 
		@DepTable deps 
		INNER JOIN (SELECT PlanStaffWithHistory.id, PlanStaffWithHistory.idDepartment,  
					(PlanStaffWithHistory.StaffCount-ISNULL(PredPlanStaffHistoryChanges.StaffCount,0)) as StaffCount,
					PlanStaffWithHistory.idPost, PlanStaffWithHistory.idBeginPrikaz idOperationPrikaz,
					PlanStaffWithHistory.idFinancingSource, PlanStaffWithHistory.DateBegin OperationDate,
					PredPlanStaffHistoryChanges.StaffCount PredStaffCount, 
					'Добавление' OperationName --добавление ставок
				FROM dbo.PlanStaffWithHistory  
					LEFT JOIN
					dbo.PlanStaffWithHistory AS PredPlanStaffHistoryChanges ON PlanStaffWithHistory.id=PredPlanStaffHistoryChanges.id--PlanStaff 
						AND PlanStaffWithHistory.DateBegin >=
							PredPlanStaffHistoryChanges.DateBegin
						AND PredPlanStaffHistoryChanges.idPlanStaffHistory =
							(SELECT MAX(PrevPlanStaffHistoryChanges.idPlanStaffHistory) FROM dbo.PlanStaffWithHistory PrevPlanStaffHistoryChanges 
								WHERE PrevPlanStaffHistoryChanges.id=PlanStaffWithHistory.id
									AND PrevPlanStaffHistoryChanges.DateBegin<=PlanStaffWithHistory.DateBegin
									AND PlanStaffWithHistory.idPlanStaffHistory>PrevPlanStaffHistoryChanges.idPlanStaffHistory)
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
						AND PredPlanStaffHistoryChanges.idPlanStaffHistory = 
							(SELECT MAX(PlanStaffWithHistory.idPlanStaffHistory) 
								FROM dbo.PlanStaffWithHistory WHERE PlanStaffWithHistory.id=PredPlanStaffHistoryChanges.id) 
				WHERE 
					PlanStaffWithHistory.DateEnd >= @PeriodBegin AND PlanStaffWithHistory.DateEnd <= @PeriodEnd)PlanStaffHistory
			ON deps.idDepartment=PlanStaffHistory.idDepartment	
		INNER JOIN dbo.Post ON PlanStaffHistory.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.[GetFullPKCategory](@PeriodBegin,@PeriodEnd) PKCategory ON Post.idPKCategory=PKCategory.id
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

		UPDATE @Result
		SET PKCategoryName=PKCategoryName+'*'
		WHERE IsIndividual=1

	RETURN
	

		  
		  
RETURN
END
