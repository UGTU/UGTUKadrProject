USE [kadr]
GO

/****** Object:  View [dbo].[DepEmplCount]    Script Date: 09/14/2010 11:01:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[DepEmplCount]
AS
SELECT     PlanStaff.idDepartment as idDepartment, dbo.PKGroup.GroupNumber, dbo.PKCategory.PKCategoryNumber, 
	RTRIM(PKGroup.GroupNumber)+' '+RTRIM(PKCategory.PKCategoryNumber) AS PKCatName,
	SUM(dbo.PlanStaff.StaffCount) as planCount, SUM(dbo.FactStaff.StaffCount) as factCount
FROM  --dbo.Department CROSS JOIN      
			dbo.PKGroup INNER JOIN
             dbo.PKCategory ON dbo.PKCategory.idPKGroup = dbo.PKGroup.id LEFT JOIN
             dbo.Post ON dbo.Post.idPKCategory = dbo.PKCategory.id LEFT JOIN
             dbo.PlanStaff ON dbo.PlanStaff.idPost = dbo.Post.id --AND PlanStaff.idDepartment=Department.id 
             LEFT JOIN
			 dbo.FactStaff ON dbo.PlanStaff.id = dbo.FactStaff.idPlanStaff 
WHERE PlanStaff.idEndPrikaz IS NULL
	AND FactStaff.idEndPrikaz IS NULL
	--»— Àﬁ◊¿≈Ã —Œ¬Ã≈—“»“≈À≈… - ŒÕ» Õ≈ «¿Õ»Ã¿ﬁ“ Œ“ƒ≈À‹ÕŒ… —“¿¬ »
	AND FactStaff.id NOT IN (SELECT idFactStaff FROM dbo.FactStaffReplacement)
	and PlanStaff.idDepartment is not null
GROUP BY PlanStaff.idDepartment, dbo.PKGroup.GroupNumber, dbo.PKCategory.PKCategoryNumber

GO


--select @@trancount


