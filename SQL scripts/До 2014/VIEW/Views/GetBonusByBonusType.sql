USE [Kadr]
GO
--last change 



GO


GO


--select * from [dbo].[GetBonusByBonusType](3, '08.02.2011','08.02.2011') 
--select * from [dbo].[GetBonusByBonusType](53) order by BonusSum
ALTER FUNCTION [dbo].[GetBonusByBonusType] 
(
@idBonusType INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idDepartment			INT,
    DepartmentName			VARCHAR(50),
    TypeWorkName			VARCHAR(50) NULL,
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    BonusLevel				VARCHAR(50)  NULL,
    BonusCount				VARCHAR(50) NULL,
    BonusSum				DECIMAL(8,2),
    AllBonusSum				DECIMAL(8,2),
    StaffCount				DECIMAL(8,2),
    idFactStaff				INT,
    idPlanStaff				INT,
    SeverKoeff				INT,
    RayonKoeff				INT,
    PrikazBegin				VARCHAR(50),
    DateBegin				DATETIME,
    DateEnd					DATETIME,
	Comment					VARCHAR(100)
   ) 
AS
BEGIN

	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
--объявляем временную таблицу, в которую внесем все надбавки за период
DECLARE @BonusTable Table
(
	id INT,
	BonusCount numeric(8,2)
		--,idPrikaz  INT
)

	INSERT INTO @BonusTable(id, BonusCount/*, idPrikaz*/)
	SELECT idBonus, BonusCount--, idPrikaz 
	FROM [dbo].[GetBonusByPeriod](@PeriodBegin, @PeriodEnd) as PeriodBonus, dbo.Bonus
	WHERE PeriodBonus.idBonus=Bonus.id
		AND Bonus.idBonusType=@idBonusType

--объявляем временную таблицу, в которую внесем всех сотрудников в периоде
	DECLARE @StaffTable Table
	(
		idDepartment INT,
		idPost		 INT,
		idPlanStaff  INT,
		idFactStaff  INT,
		idEmployee   INT,
		StaffCount	 NUMERIC(7,2),
		StaffCountWithoutReplacement NUMERIC(7,2),	--кол-во ставок без замещений
		idReplacementReason	INT,					--причина замещения
		IsMain			BIT,							--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		IsReplacement	BIT,
		idFinancingSource	INT,
		idTypeWork			INT
	)

	INSERT INTO @StaffTable(idDepartment, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason, IsMain, IsReplacement,
		idFinancingSource, idTypeWork)
	SELECT DISTINCT idDepartment, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		StaffCountWithoutReplacement, idReplacementReason, IsMain, IsReplacement,
		idFinancingSource, idTypeWork
	FROM dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff

	
	INSERT INTO @Result(EmployeeName,BonusLevel,BonusCount, idFactStaff, SeverKoeff, RayonKoeff,
			TypeWorkName, StaffCount, DepartmentName, idDepartment, PostName, idPlanStaff,
			PrikazBegin, DateBegin, DateEnd, Comment)
	SELECT  Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch as EmployeeName, 
			AllBonus.BonusLevel, AllBonus.BonusCount, 
			AllBonus.idFactStaff, Employee.SeverKoeff, Employee.RayonKoeff, 
			WorkType.TypeWorkShortName+ISNULL(' ('+FactStaffReplacementReason.ReplacementReasonShortName+')',''), 
			Staff.StaffCount, 
			Department.DepartmentSmallName, Department.id, Post.PostShortName, Staff.idPlanStaff,
			Prikaz.PrikazName PrikazBegin, Bonus.DateBegin, Bonus.DateEnd,
			Bonus.Comment
	FROM
		(SELECT idBonus,
			Staff.idEmployee, 'Сотрудник' as BonusLevel, 
			BonusCount, Staff.idFactStaff
		FROM @BonusTable as Bonus, dbo.BonusEmployee, @StaffTable as Staff
		WHERE  Bonus.id=BonusEmployee.idBonus
			AND BonusEmployee.idEmployee=Staff.idEmployee
			AND Staff.StaffCount=(SELECT MAX(StaffCount) FROM @StaffTable as Staff 
									WHERE Staff.idEmployee=BonusEmployee.idEmployee)
		--GROUP BY Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch, BonusCount, SeverKoeff, RayonKoeff
	 
		UNION		
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Распределение штатов' as BonusLevel, 
			BonusCount, Staff.idFactStaff
		FROM @BonusTable as Bonus, dbo.BonusFactStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusFactStaff.idBonus
			AND BonusFactStaff.idFactStaff=Staff.idFactStaff
		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Штатное расписание' as BonusLevel, 
			BonusCount, Staff.idFactStaff
		FROM @BonusTable as Bonus, dbo.BonusPlanStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusPlanStaff.idBonus
			AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff

		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Должность' as BonusLevel, 
			BonusCount, Staff.idFactStaff
		FROM @BonusTable as Bonus, dbo.BonusPost, @StaffTable as Staff
		WHERE Bonus.id=BonusPost.idBonus
			AND BonusPost.idPost=Staff.idPost) AllBonus INNER JOIN
		dbo.Employee ON AllBonus.idEmployee=Employee.id INNER JOIN
		dbo.Bonus ON AllBonus.idBonus=Bonus.id INNER JOIN
		dbo.Prikaz ON Prikaz.id=Bonus.idPrikaz INNER JOIN
	
		@StaffTable as Staff ON AllBonus.idFactStaff=Staff.idfactStaff INNER JOIN 
		dbo.WorkType ON Staff.idTypeWork=WorkType.id  INNER JOIN
		dbo.Department ON Staff.idDepartment=Department.id INNER JOIN 
		dbo.Post ON Staff.idPost=Post.id INNER JOIN 
		dbo.Category ON Post.idCategory=Category.id INNER JOIN 
		dbo.PKCategory ON Post.idPKCategory=PKCategory.id INNER JOIN 
		dbo.PKGroup ON PKCategory.idPKGroup=PKGroup.id LEFT JOIN 
		dbo.FactStaffReplacement ON FactStaffReplacement.idFactStaff=AllBonus.idFactStaff LEFT JOIN
		dbo.FactStaffReplacementReason ON FactStaffReplacement.idReplacementReason=FactStaffReplacementReason.id
	ORDER BY Department.DepartmentSmallName, Category.OrderBy, PKGroup.GroupNumber desc, 
		PKCategory.PKCategoryNumber desc, Post.PostShortName, EmployeeName
	
	--если проценты
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND idBonusMeasure=1)
	begin
		UPDATE @Result
		SET BonusSum = CONVERT(DECIMAL(8,2),BonusCount)*SalarySize*StaffCount/100
		FROM @Result as res, dbo.PlanStaffsWithSalaries
		WHERE  res.idPlanStaff=PlanStaffsWithSalaries.idPlanStaff
	end
	ELSE
	begin
		UPDATE @Result
		SET BonusSum = BonusCount
	end
	
	--если зависит от ставки
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND IsStaffRateable=1)
	begin
		UPDATE @Result
		SET BonusSum = CONVERT(DECIMAL(8,2), BonusSum*StaffCount)
	end

	--если cеверные накручиваются
	IF EXISTS(SELECT 'TRUE' from dbo.BonusType WHERE id=@idBonusType AND HasEnvironmentBonus=1)
	begin
		UPDATE @Result
		SET AllBonusSum = CONVERT(DECIMAL(8,2), BonusSum*(100+SeverKoeff+RayonKoeff)/100)
	end
	ELSE
	begin
		UPDATE @Result
		SET AllBonusSum = BonusSum
	end
	
	
	UPDATE @Result
	SET BonusCount=BonusCount+' '+BonusMeasure.Sign
	FROM  @Result res, dbo.BonusType, dbo.BonusMeasure
	WHERE BonusType.id=@idBonusType
		AND BonusType.idBonusMeasure=BonusMeasure.id
RETURN
END

