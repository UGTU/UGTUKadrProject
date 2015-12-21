

--select * from [dbo].[GetAverageNumEmplByCat](2015, 1, 1,10,12) where idTypeWork=17
CREATE FUNCTION [dbo].[GetAverageNumEmplByCat] 
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
	CategorySmallName		VARCHAR(50), 
	PostShortName		VARCHAR(150),
	IsSubDep		BIT NOT NULL,
	TypeWorkName	VARCHAR(60),
	TimeSheetYear	INT,
	TimeSheetMonth	INT,
	TimeSheetMonthName VARCHAR(50),
	StaffAverage	FLOAT,
	FreeStaffAverage FLOAT,
	CategoryOrderBy	INT,
	FinancingSourceName VARCHAR(50),
	FinancingSourceOrderBy INT,
	TimeSheetHourCount NUMERIC(14,2),
	PersonCount   FLOAT,
	idTypeWork INT,
	[CategoryVPOName] VARCHAR(50),
	[CategoryVPOOrderBy] INT,
	[CategoryZPName] VARCHAR(50),
	[CategoryZPOrderBy] INT
   ) 
AS
BEGIN
	
	--записываем всех
	INSERT INTO @Result(DepartmentSmallName,CategorySmallName,PostShortName,IsSubDep,TypeWorkName,
		TimeSheetYear,TimeSheetMonth,TimeSheetMonthName,StaffAverage,FreeStaffAverage,
		CategoryOrderBy,FinancingSourceName,FinancingSourceOrderBy,TimeSheetHourCount,
		PersonCount,idTypeWork,
		[CategoryVPOName],[CategoryVPOOrderBy],[CategoryZPName],[CategoryZPOrderBy])
	SELECT DepartmentSmallName,CategorySmallName,PostShortName,IsSubDep,TypeWorkName,
		TimeSheetYear,TimeSheetMonth,TimeSheetMonthName,StaffAverage,FreeStaffAverage,
		CategoryOrderBy,FinancingSourceName,FinancingSourceOrderBy,TimeSheetHourCount,
		PersonCount,idTypeWork,
		[CategoryVPOName],[CategoryVPOOrderBy],[CategoryZPName],[CategoryZPOrderBy]
	FROM 
		[dbo].[GetAverageNumEmpl](@Year,@idDepartment,@WithSubDeps, @MonthBegin, @MonthEnd)
 
	--редактируем всех в соответствии с тем, что надо выводить
	/*UPDATE @Result
	SET StaffAverage=PersonCount
	WHERE idTypeWork=1*/
	
	INSERT INTO @Result(DepartmentSmallName,CategorySmallName,PostShortName,IsSubDep,TypeWorkName,
		TimeSheetYear,TimeSheetMonth,TimeSheetMonthName,StaffAverage,FreeStaffAverage,
		CategoryOrderBy,FinancingSourceName,FinancingSourceOrderBy,TimeSheetHourCount,
		PersonCount,idTypeWork, [CategoryVPOName],[CategoryVPOOrderBy],[CategoryZPName],[CategoryZPOrderBy])
	SELECT DepartmentSmallName,CategorySmallName,PostShortName,IsSubDep,TypeWorkName + '  (ф.л.)',
		TimeSheetYear,TimeSheetMonth,TimeSheetMonthName,PersonCount,FreeStaffAverage,
		CategoryOrderBy,FinancingSourceName,FinancingSourceOrderBy,TimeSheetHourCount,
		PersonCount,idTypeWork, [CategoryVPOName],[CategoryVPOOrderBy],[CategoryZPName],[CategoryZPOrderBy]
	FROM @Result
	WHERE idTypeWork BETWEEN 1 AND 3	
RETURN
END


