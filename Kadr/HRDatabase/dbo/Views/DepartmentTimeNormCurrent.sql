

/*select * from DepartmentTimeNormCurrent
Представление со всеми текущими параметрами dbo.DepartmentTimeNorm (DateBegin...) */
CREATE VIEW dbo.DepartmentTimeNormCurrent
AS
SELECT DepartmentTimeNorm.*       
FROM            dbo.DepartmentTimeNorm INNER JOIN
                     (SELECT idDepartment,idFinancingSource, MAX(DateBegin) AS DateBegin
                       FROM dbo.DepartmentTimeNorm
                       WHERE (DateBegin < GETDATE())
                       GROUP BY idDepartment,idFinancingSource)CurrentNorm
                      ON DepartmentTimeNorm.idDepartment=CurrentNorm.idDepartment
						AND DepartmentTimeNorm.idFinancingSource=CurrentNorm.idFinancingSource
						AND DepartmentTimeNorm.DateBegin=CurrentNorm.DateBegin


