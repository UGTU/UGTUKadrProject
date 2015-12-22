CREATE FUNCTION [dbo].[FetchVacationPlansByDepartmentId](@DepartmenGuid uniqueidentifier, @Year int) RETURNS TABLE 
AS
RETURN 
(
	WITH tblChild AS
	(
		SELECT *
			FROM ViewVacationPlan WHERE DepartmentGUID = @DepartmenGuid and ((OtpuskYear = @Year)or(OtpuskYear is null))		
		UNION ALL SELECT ViewVacationPlan.* 
		    FROM ViewVacationPlan  INNER JOIN tblChild  
				ON ViewVacationPlan.DepManagerGUID = tblChild.DepartmentGUID and ((ViewVacationPlan.OtpuskYear = @Year)or(ViewVacationPlan.OtpuskYear is null))
	) select distinct * from tblChild where DateBegin is not null
)
