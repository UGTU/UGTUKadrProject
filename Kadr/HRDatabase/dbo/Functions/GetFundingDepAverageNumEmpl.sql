
--select * from [dbo].[GetFundingDepAverageNumEmpl](2015, 1, 1,1,3)

--Возвращает среднесп численность для центров финансирования
CREATE FUNCTION [dbo].[GetFundingDepAverageNumEmpl] 
(
@Year	INT,
@idDepartment	INT,
@WithSubDeps BIT,
@MonthBegin  INT=1,
@MonthEnd	 INT=12
)
RETURNS @Result TABLE
   (
	DepartmentSmallName		VARCHAR(50),
	TypeWorkName	VARCHAR(50),
	TimeSheetYear	INT,
	TimeSheetMonth	INT,
	TimeSheetMonthName VARCHAR(50),
	StaffAverage	FLOAT,
	TimeSheetHourCount NUMERIC(12,2) ,
	PersonCount   FLOAT,
	idSuperTypeWork  INT,
	idEmployee	INT
   ) 
AS
BEGIN

	--записываем всех
	INSERT INTO @Result(DepartmentSmallName,TypeWorkName,TimeSheetYear,TimeSheetMonth,TimeSheetMonthName,StaffAverage,
		TimeSheetHourCount,PersonCount,idSuperTypeWork)
	SELECT 
		FundingCenterName, TypeWorkName,
	TimeSheetYear, TimeSheetMonth, TimeSheetMonthName,StaffAverage,
		TimeSheetHourCount,PersonCount,idTypeWork
	FROM 
		[dbo].[GetAverageNumEmpl](@Year,@idDepartment,@WithSubDeps, @MonthBegin, @MonthEnd) AverageNum 
		--INNER JOIN dbo.WorkType ON AverageNum.idTypeWork=WorkType.id
		--INNER JOIN dbo.WorkSuperType ON WorkType.idWorkSuperType=WorkSuperType.id
		--INNER JOIN dbo.Months ON Months.MonthNumber=AverageNum.TimeSheetMonth
		INNER JOIN dbo.FundingCenter ON FundingCenter.id=AverageNum.idFundingCenter
 
	
	INSERT INTO @Result(DepartmentSmallName,TypeWorkName,TimeSheetYear,TimeSheetMonth,TimeSheetMonthName,StaffAverage,
		TimeSheetHourCount,PersonCount,idSuperTypeWork)
	SELECT DepartmentSmallName,TypeWorkName + '  (ф.л.)',TimeSheetYear,TimeSheetMonth,TimeSheetMonthName,PersonCount,
		TimeSheetHourCount,PersonCount,idSuperTypeWork
	FROM @Result
	WHERE idSuperTypeWork BETWEEN 1 AND 3	
	
RETURN
END

