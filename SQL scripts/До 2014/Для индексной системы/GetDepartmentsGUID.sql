USE [Kadr]
GO
/****** Object:  UserDefinedFunction [dbo].[GetDepartmentsManager]    Script Date: 06/27/2012 14:13:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--select kadr.ShemaIndex.GetDepartmentsGUID('УГТУ') 

--Вычисляем GUID отдела по его названию
CREATE FUNCTION ShemaIndex.[GetDepartmentsGUID] 
(
@DepartmentName VARCHAR(200)
)
RETURNS uniqueidentifier
AS
BEGIN
	DECLARE @depsGUID uniqueidentifier
	SELECT @depsGUID=DepartmentGUID FROM dbo.Department WHERE DepartmentName LIKE @DepartmentName
	
				

RETURN @depsGUID
END





