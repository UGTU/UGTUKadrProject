


--select * from [dbo].[GetBonusByBonusTypeForProlong](75, GETDATE(),GETDATE()) order by idBonus where EmployeeName like '%Амосова%'
--select * from [dbo].[GetBonusByBonusTypeForProlong](3, '01.01.2015','30.01.2015') where EmployeeName like '%Амосова%'
--возвращает данные для отчета по надбавкам, отобранным по виду надбавки
CREATE FUNCTION [dbo].[GetBonusByBonusTypeForProlong] 
(
@idBonusType INT,
@PeriodBegin	DATE,
@PeriodEnd	DATE
)
RETURNS @Result TABLE
   (
    idDepartment			INT,
    DepartmentName			VARCHAR(500),
    TypeWorkName			VARCHAR(50) NULL,
    PostName				VARCHAR(150) NULL,
    EmployeeName			VARCHAR(150) NULL,
    BonusLevel				VARCHAR(50)  NULL,
    BonusCount				numeric(8,2) NULL,
    StaffCount				DECIMAL(14,4),
    idFactStaff				INT,
    idPlanStaff				INT,
    PrikazBegin				VARCHAR(50),
    DateBegin				DATETIME,
    DateEnd					DATETIME,
	CategoryName			VARCHAR(50),
	FinancingSourceName     VARCHAR(50),
	BonusFinancingSourceName VARCHAR(50),
	Prolong					BIT,
	idBonus					INT
   ) 
AS
BEGIN


	
--объявляем временную таблицу, в которую внесем все надбавки за период
DECLARE @BonusTable Table
(
	id INT,
	BonusCount numeric(8,2),
    DateBegin DATETIME,
    DateEnd DATETIME,
    idPrikaz	INT,
	idFinancingSource INT 
)

	INSERT INTO @BonusTable(id, BonusCount, idPrikaz, DateBegin, DateEnd, idFinancingSource)
	SELECT idBonus, PeriodBonus.BonusCount, PeriodBonus.[idBeginPrikaz], PeriodBonus.DateBegin, PeriodBonus.DateEnd,idFinancingSource  
	FROM [dbo]./*[GetBonusByPeriodWithHistory]*/[GetBonusByPeriod](@PeriodBegin, @PeriodEnd) as PeriodBonus
		INNER JOIN dbo.Bonus ON  PeriodBonus.idBonus=Bonus.id
	WHERE PeriodBonus.DateBegin<@PeriodEnd
		AND 
		Bonus.idBonusType=@idBonusType

--объявляем временную таблицу, в которую внесем всех сотрудников в периоде
	DECLARE @StaffTable Table
	(
		idDepartment INT,
		idPost		 INT,
		idPlanStaff  INT,
		idFactStaff  INT,
		idEmployee   INT,
		StaffCount	 NUMERIC(8,2),
		idFinancingSource	INT,
		idTypeWork			INT,
		idSalaryKoeff INT,
		DepartmentName			VARCHAR(500)
	)

	--грузим сотрудников, которые будут работать в начале следующего месяца
	INSERT INTO @StaffTable(idDepartment, idPost, idPlanStaff, idFactStaff, idEmployee, StaffCount, 
		idFinancingSource, idTypeWork, idSalaryKoeff, DepartmentName)
	SELECT DISTINCT deps.idDepartment, idPost, PeriodStaff.idPlanStaff, idFactStaff, idEmployee, PeriodStaff.StaffCount, 
		idFinancingSource, idTypeWork, idSalaryKoeff, deps.DepartmentSmallName
	FROM [dbo].[GetFactStaffByPeriod](@PeriodEnd,@PeriodEnd) as PeriodStaff
		INNER JOIN [dbo].[GetPlanStaffByPeriod](@PeriodEnd,@PeriodEnd) PlanStaff ON PeriodStaff.idPlanStaff=PlanStaff.idPlanStaff
		INNER JOIN [dbo].[GetSubDepartmentsWithPeriod](1, @PeriodEnd, @PeriodEnd)deps
		--INNER JOIN (SELECT MIN [dbo].[FactStaffHistory]
		ON PlanStaff.idDepartment=deps.idDepartment

	
	
	
	
	INSERT INTO @Result(EmployeeName,BonusLevel,BonusCount,  idFactStaff, 
			TypeWorkName, StaffCount, DepartmentName, idDepartment, PostName, idPlanStaff,
			PrikazBegin, DateBegin, DateEnd, CategoryName, 
			FinancingSourceName, BonusFinancingSourceName, Prolong, idBonus)
	SELECT  EmployeeName, 
			AllBonus.BonusLevel, AllBonus.BonusCount, 
			AllBonus.idFactStaff, 
			WorkType.TypeWorkName, 
			Staff.StaffCount, 
			Staff.DepartmentName, Staff.idDepartment, Post.PostName, Staff.idPlanStaff,
			Prikaz.PrikazName PrikazBegin, AllBonus.DateBegin, AllBonus.DateEnd,
			CategorySmallName,  
			FinancingSource.FinancingSourceName, BonusFinancingSource.FinancingSourceName, 1 as Prolong, idBonus
	FROM
		(SELECT idBonus,
			Staff.idEmployee, 'Сотрудник' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL as ForEmployee, Bonus.idFinancingSource
		FROM @BonusTable as Bonus, dbo.BonusEmployee, @StaffTable as Staff
		WHERE  Bonus.id=BonusEmployee.idBonus
			AND BonusEmployee.idEmployee=Staff.idEmployee
			AND Staff.StaffCount=(SELECT MAX(StaffCount) FROM @StaffTable as Staff 
									WHERE Staff.idEmployee=BonusEmployee.idEmployee)
		--GROUP BY Employee.LastName+' '+Employee.FirstName+' '+Employee.Otch, BonusCount, SeverKoeff, RayonKoeff
	 
		UNION		
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Распределение штатов' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			NULL, Bonus.idFinancingSource
		FROM @BonusTable as Bonus, dbo.BonusFactStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusFactStaff.idBonus
			AND BonusFactStaff.idFactStaff=Staff.idFactStaff
		
		UNION
		SELECT idBonus,--idPrikaz as PrikazBegin, DateBegin, DateEnd,
			Staff.idEmployee, 'Штатное расписание' as BonusLevel, 
			BonusCount, Staff.idFactStaff, Bonus.idPrikaz, Bonus.DateBegin, Bonus.DateEnd, 
			ForEmployee, Bonus.idFinancingSource
		FROM @BonusTable as Bonus, dbo.BonusPlanStaff, @StaffTable as Staff
		WHERE Bonus.id=BonusPlanStaff.idBonus
			AND BonusPlanStaff.idPlanStaff=Staff.idPlanStaff) AllBonus INNER JOIN
		dbo.Employee ON AllBonus.idEmployee=Employee.id INNER JOIN
		dbo.Bonus ON AllBonus.idBonus=Bonus.id INNER JOIN
		dbo.Prikaz ON Prikaz.id=AllBonus.idPrikaz INNER JOIN
	
		@StaffTable as Staff ON AllBonus.idFactStaff=Staff.idfactStaff INNER JOIN 
		dbo.WorkType ON Staff.idTypeWork=WorkType.id  INNER JOIN
		--dbo.Department ON Staff.idDepartment=Department.id INNER JOIN 
		dbo.Post ON Staff.idPost=Post.id INNER JOIN 
		dbo.Category ON Post.idCategory=Category.id INNER JOIN 
		[dbo].[FinancingSource] ON Staff.idFinancingSource=[FinancingSource].id INNER JOIN
		[dbo].[FinancingSource] BonusFinancingSource ON AllBonus.idFinancingSource=BonusFinancingSource.id --LEFT JOIN		
	ORDER BY Staff.DepartmentName, Post.PostName, EmployeeName
	--удаляем надбавки для сотрудников, если они для них не предназначены
	/*DELETE FROM  @Result
	FROM  @Result res
	WHERE ForEmployee=0*/

	

RETURN
END


