CREATE FUNCTION [dbo].[FetchVacationPlansByDepartmentId](@DepartmenGuid uniqueidentifier, @Year int) RETURNS TABLE 
AS
RETURN 
(
	WITH tblChild AS
	(
		SELECT *
			FROM ViewVacationPlan WHERE DepartmentGUID = @DepartmenGuid and OtpuskYear = @Year
		UNION ALL SELECT *
			FROM ViewVacationPlan WHERE DepManagerGUID = @DepartmenGuid and OtpuskYear = @Year
		UNION ALL
			SELECT ViewVacationPlan.* FROM ViewVacationPlan  INNER JOIN tblChild  
				ON ViewVacationPlan.DepManagerGUID = tblChild.DepartmentGUID and ViewVacationPlan.OtpuskYear = @Year
	) select distinct * from tblChild
)
