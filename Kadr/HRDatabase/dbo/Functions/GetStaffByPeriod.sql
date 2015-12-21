
--select * from [dbo].[GetStaffByPeriod]('01.1.2015','30.01.2015') WHERE idTypeWork=17 idDepartment=143 idPlanStaff=172
CREATE FUNCTION [dbo].[GetStaffByPeriod] 
(
@PeriodBegin	DATE,
@PeriodEnd	DATE
)
RETURNS @Result TABLE
   (
		idDepartment INT,
		idPost		 INT,
		idPlanStaff  INT,
		idFactStaff  INT,
		idEmployee   INT,
		StaffCount	 NUMERIC(14,4),
		StaffCountWithoutReplacement NUMERIC(14,4),	--кол-во ставок без замещений (т.е. если замещение, то эта ставка будет равна 0)
		StaffCountReal	NUMERIC(14,4),				--реальная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
		CalcStaffCount NUMERIC(14,4),				--расчетное кол-во ставок 
		CalcStaffCountWithoutReplacement NUMERIC(14,4),		--расчетное кол-во ставок без замещений
		CalcStaffCountReal NUMERIC(14,4),			--реальная расчетная ставка (т.е. если человека замещают на х ставки, то для замещаемого реальная ставка будет у-х, где у - его ставка  
		idReplacementReason	INT,					--причина замещения
		IsMain			BIT,						--признак основной должности (та, у которой либо ставка выше, либо основной вид работы
		IsReplacement	BIT,
		idFinancingSource	INT,
		idTypeWork			INT,
		SeverKoeff		INT,
		RayonKoeff		INT,
		ReplacedEmployeeName	VARCHAR(150) NULL,	--ФИО замещаемого
		HourCount NUMERIC(10,2), 
		HourSalary NUMERIC(10,2),
		idSalaryKoeff INT,
		[idlaborcontrakt] INT,
		[idreason] INT,
		idOKVED		INT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

	--Указываем занятые ставки
	INSERT INTO @Result(idPost, idPlanStaff, idFactStaff, idEmployee, 
		idDepartment, StaffCount, StaffCountWithoutReplacement, StaffCountReal, IsMain, 
		CalcStaffCount,CalcStaffCountWithoutReplacement,CalcStaffCountReal,
		IsReplacement, idFinancingSource, idTypeWork, SeverKoeff, RayonKoeff, HourCount, 
		HourSalary, idSalaryKoeff, [idlaborcontrakt], [idreason], idOKVED)
	SELECT idPost, PlanStaff.idPlanStaff, FactStaff.idFactStaff, idEmployee, 
		idDepartment, FactStaff.StaffCount, FactStaff.StaffCount, FactStaff.StaffCount, WorkType.IsMain, 
		CalcStaffCount, CalcStaffCount, CalcStaffCount,
		WorkType.IsReplacement, PlanStaff.idFinancingSource, idTypeWork, PlanStaff.SeverKoeff, 
		PlanStaff.RayonKoeff, HourCount, HourSalary, idSalaryKoeff, FactStaff.[idlaborcontrakt], FactStaff.[idreason], ISNULL(FactStaff.idOKVED, PlanStaff.idOKVED) idOKVED
	FROM [dbo].[GetPlanStaffByPeriod](@PeriodBegin, @PeriodEnd)  PlanStaff
		INNER JOIN [dbo].[GetFactStaffByPeriod](@PeriodBegin, @PeriodEnd) FactStaff 
			ON PlanStaff.idPlanStaff=FactStaff.idPlanStaff
		INNER JOIN dbo.WorkType ON FactStaff.idTypeWork=WorkType.id

	--для замещаемых уменьшаем ставку на ставку замещения
	UPDATE @Result
	SET StaffCountReal = StaffCount-ReplacedStaffCount, CalcStaffCountReal=CalcStaffCount-ReplacedCalcStaffCount
	FROM @Result as res 
		INNER JOIN
		(SELECT idReplacedFactStaff, SUM(FactStaff.StaffCount) ReplacedStaffCount, SUM(FactStaff.CalcStaffCount) ReplacedCalcStaffCount FROM
			@Result as FactStaff INNER JOIN dbo.FactStaffReplacement
				ON FactStaff.idFactStaff=FactStaffReplacement.idFactStaff
			WHERE FactStaffReplacement.DateEnd IS NULL OR FactStaffReplacement.DateEnd>@PeriodBegin
			GROUP BY idReplacedFactStaff)replacedStaff
		ON res.idFactStaff=replacedStaff.idReplacedFactStaff

			
	--отмечаем замещающих (обнуляем ставку)
	UPDATE @Result
	SET StaffCountWithoutReplacement = 0, CalcStaffCountWithoutReplacement=0,
		idReplacementReason=FactStaffReplacement.idReplacementReason,
		ReplacedEmployeeName = Employee.LastName+' '+CONVERT(VARCHAR(1),Employee.FirstName)+'. '+CONVERT(VARCHAR(1),Employee.Otch)+'.'
	FROM @Result as res 
		INNER JOIN dbo.FactStaffReplacement ON res.idFactStaff= FactStaffReplacement.idFactStaff
		INNER JOIN dbo.FactStaff ON FactStaffReplacement.idReplacedFactStaff=FactStaff.id
		INNER JOIN dbo.Employee ON FactStaff.idEmployee=Employee.id
	WHERE FactStaffReplacement.DateEnd IS NULL OR FactStaffReplacement.DateEnd>@PeriodBegin
	
	
	
	UPDATE  @Result  
	SET IsMain=1
	FROM @Result as Result
	WHERE idEmployee NOT IN (SELECT idEmployee FROM @Result WHERE IsMain=1)
		AND idFactStaff=
		(SELECT MIN(idFactStaff) FROM @Result as res
			WHERE res.idEmployee=Result.idEmployee
				AND res.StaffCount=(SELECT MAX(StaffCount) FROM @Result as resl 
									WHERE resl.idEmployee=res.idEmployee))
	
	
				
	--заполняем вакансии	
	INSERT INTO @Result(idPost, idPlanStaff, idFactStaff, idEmployee, idDepartment, 
		StaffCount, StaffCountWithoutReplacement, StaffCountReal, 
		CalcStaffCount, CalcStaffCountWithoutReplacement,CalcStaffCountReal, 
		IsMain, idFinancingSource,
		PlanStaff.SeverKoeff, PlanStaff.RayonKoeff, idOKVED)
	SELECT PlanStaff.idPost, PlanStaff.idPlanStaff, null, null, PlanStaff.idDepartment, 
		PlanStaff.StaffCount-ISNULL(SUM(staff.StaffCountWithoutReplacement),0),
		PlanStaff.StaffCount-ISNULL(SUM(staff.StaffCountWithoutReplacement),0), 
		PlanStaff.StaffCount-ISNULL(SUM(staff.StaffCountWithoutReplacement),0), 
		PlanStaff.StaffCount-ISNULL(SUM(staff.CalcStaffCountWithoutReplacement),0), 
		PlanStaff.StaffCount-ISNULL(SUM(staff.CalcStaffCountWithoutReplacement),0), 
		PlanStaff.StaffCount-ISNULL(SUM(staff.CalcStaffCountWithoutReplacement),0), 
		0, 
		PlanStaff.idFinancingSource, PlanStaff.SeverKoeff, PlanStaff.RayonKoeff, PlanStaff.idOKVED
	FROM [dbo].[GetPlanStaffByPeriod](@PeriodBegin, @PeriodEnd) as PlanStaff
		 LEFT JOIN @Result staff ON PlanStaff.idPlanStaff=staff.idPlanStaff
		 
	GROUP BY PlanStaff.idPost, PlanStaff.idPlanStaff, PlanStaff.idDepartment, 
		PlanStaff.StaffCount, PlanStaff.idFinancingSource, PlanStaff.SeverKoeff, PlanStaff.RayonKoeff, PlanStaff.idOKVED
	HAVING PlanStaff.StaffCount-ISNULL(SUM(staff.StaffCountWithoutReplacement),0)>0 OR
		   PlanStaff.StaffCount-ISNULL(SUM(staff.CalcStaffCountWithoutReplacement),0)>0
	
	--UPDATE @Result
	
 
		
RETURN
END











