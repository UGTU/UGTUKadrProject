--SET STATISTICS TIME ON
--select * from [dbo].[GetSubDepartmentsWithPeriod](1,'08.01.2015','09.02.2015')  order by DepTreeIndex
--select * from [dbo].[GetSubDepartmentsWithPeriod_optimized](1,'08.01.2015','09.02.2015')  order by DepTreeIndex
--возвращает подотделы переданного отдела (вместе с переданным отделом)
CREATE FUNCTION [dbo].[GetSubDepartmentsWithPeriod] 
(
@idManagerDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    idDepartment	INT NULL,
	idManagerDepartment		INT,
    IsMain			BIT,
	[DepartmentName] VARCHAR(500),
	[DepartmentSmallName] VARCHAR(50),
	DepNumber				INT,
	DepTreeIndex			VARCHAR(30),
	idOKVED INT,
	[idFundingCenter] INT
   ) 
AS
BEGIN
	WITH DepRecursiveInfo(idDepartment,IsMain,[DepartmentName],[DepartmentSmallName],idManagerDepartment,
		SubLevel, DepTreeIndex, idOKVED, [idFundingCenter])
	AS
	(
	SELECT id,@idManagerDepartment,[DepartmentName],[DepartmentSmallName],idManagerDepartment,0, CONVERT(VARCHAR(40),'1'), idOKVED, [idFundingCenter]
		FROM dbo.Department
		WHERE [id]=@idManagerDepartment
	UNION ALL
	SELECT deps.idDepartment,deps.idManagerDepartment,deps.[DepartmentName],deps.[DepartmentSmallName],deps.idManagerDepartment,SubLevel+1, 
		IIF(row_number() over(order by deps.DepartmentName)>9, 
		CONVERT(VARCHAR(32),DepTreeIndex)+CONVERT(VARCHAR(4),'.')+CONVERT(VARCHAR(4),80+row_number() over(order by deps.DepartmentName)),
		CONVERT(VARCHAR(32),DepTreeIndex)+CONVERT(VARCHAR(4),'.')+CONVERT(VARCHAR(4),row_number() over(order by deps.DepartmentName)))
		, deps.idOKVED, deps.[idFundingCenter]
		FROM [dbo].[GetDepartmentByPeriod](@PeriodBegin, @PeriodEnd) deps
			INNER JOIN DepRecursiveInfo ON deps.idManagerDepartment=DepRecursiveInfo.idDepartment
	)
	
	INSERT INTO @Result(idDepartment,IsMain,[DepartmentName],[DepartmentSmallName],idManagerDepartment,
		 DepTreeIndex, idOKVED, [idFundingCenter])
	SELECT idDepartment,IsMain,[DepartmentName],[DepartmentSmallName],idManagerDepartment,
		 DepTreeIndex, idOKVED, [idFundingCenter] FROM DepRecursiveInfo
	ORDER BY DepRecursiveInfo.DepTreeIndex
	
	
RETURN
END




