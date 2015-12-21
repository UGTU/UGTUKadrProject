
--select * from [dbo].[GetAuditByPeriod](GETDATE()-1, GETDATE()+1)
CREATE FUNCTION [dbo].[GetAuditByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS @Result TABLE
   (
	  [ObjectName] VARCHAR(50)
      ,[ObjectTable]  VARCHAR(50)
      ,[OperationName]  VARCHAR(50)
      ,[AuditDateTime] DATETIME
      ,[UserName]  VARCHAR(50)
      ,[Description]  VARCHAR(500)
   ) 
AS
BEGIN
	
	--если период задан некорректно, выходим
	IF (@PeriodBegin>@PeriodEnd)
		RETURN

		
	SET @PeriodBegin=CONVERT(date,@PeriodBegin,103)
	SET @PeriodEnd=CONVERT(date,@PeriodEnd,103)
	
INSERT INTO @Result
SELECT [ObjectName]
      ,[ObjectTable]
      ,[OperationName]
      ,[AuditDateTime]
      ,[UserName]
      ,[Description]
  FROM [dbo].[AuditView]
  WHERE [AuditDateTime] BETWEEN @PeriodBegin AND @PeriodEnd  
  order by [AuditDateTime] desc 
		
RETURN
END

