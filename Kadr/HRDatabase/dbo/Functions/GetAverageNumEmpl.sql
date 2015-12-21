

--select * from [dbo].[GetAverageNumEmpl](2015, 1, 1,1,3) where idTypeWork=17
CREATE FUNCTION [dbo].[GetAverageNumEmpl] 
(
@Year	INT,
@idDepartment	INT,
@WithSubDeps BIT,
@MonthBegin  INT=1,
@MonthEnd	 INT=12

)
RETURNS TABLE
   /*(
	DepartmentSmallName		VARCHAR(50),
	CategorySmallName		VARCHAR(50), 
	PostShortName		VARCHAR(150),
	IsSubDep		BIT NOT NULL,
	TypeWorkName	VARCHAR(50),
	TimeSheetYear	INT,
	TimeSheetMonth	INT,
	TimeSheetMonthName VARCHAR(50),
	StaffAverage	FLOAT,
	FreeStaffAverage FLOAT,
	CategoryOrderBy	INT,
	FinancingSourceName VARCHAR(50),
	FinancingSourceOrderBy INT,
	TimeSheetHourCount NUMERIC(12,2),
	PersonCount   FLOAT,
	idTypeWork INT,
	[CategoryVPOName] VARCHAR(50),
	[CategoryVPOOrderBy] INT,
	[CategoryZPName] VARCHAR(50),
	[CategoryZPOrderBy] INT,
	[OKVEDName]		VARCHAR(100)
   )*/ 
AS
RETURN
(
	SELECT DepartmentName DepartmentSmallName, CategorySmallName, PostName PostShortName, IsSubDep, WorkSuperTypeShortName TypeWorkName, TimeSheetYear, TimeSheetMonth, MonthName TimeSheetMonthName,
		(StaffAverage) StaffAverage,
		FreeStaffAverage,
		Category.OrderBy CategoryOrderBy, FinancingSourceName, FinancingSource.OrderBy FinancingSourceOrderBy,
		(TimeSheetHourCount),
		(PersonCount), WorkSuperType.id idTypeWork,
		[CategoryVPOSmallName] CategoryVPOName,[CategoryVPO].[OrderBy] CategoryVPOOrderBy,[CategoryZPName],CategoryZP.[OrderBy] CategoryZPOrderBy, [OKVED].OKVEDName, idFundingCenter
	FROM 
		[dbo].[GetAverageSums](@Year, @idDepartment,@WithSubDeps,@MonthBegin,@MonthEnd)averSums
		INNER JOIN  dbo.WorkType ON averSums.idTypeWork=WorkType.id
		INNER JOIN dbo.WorkSuperType ON WorkType.idWorkSuperType=WorkSuperType.id
		INNER JOIN dbo.Months ON Months.MonthNumber=averSums.TimeSheetMonth
		INNER JOIN dbo.Post ON averSums.idPost=Post.id
		INNER JOIN dbo.Category ON Post.idCategory=Category.id
		INNER JOIN dbo.FinancingSource ON FinancingSource.id=averSums.idFinancingSource
		LEFT JOIN [dbo].[CategoryVPO] ON [CategoryVPO].id=Post.idCategoryVPO
		LEFT JOIN [dbo].[CategoryZP] ON [CategoryZP].id=Post.idCategoryZP
		LEFT JOIN [dbo].[OKVED] ON averSums.idOKVED=[OKVED].id
	WHERE 
		WorkType.idWorkSuperType<>4
)

