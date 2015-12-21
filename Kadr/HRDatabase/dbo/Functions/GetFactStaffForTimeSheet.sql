--select * from [dbo].[GetFactStaffForTimeSheet]('1.01.2015','31.01.2015') order by idFactStaff where  idDepartment=604    21 
CREATE FUNCTION [dbo].[GetFactStaffForTimeSheet] 
(
@PeriodBegin	DATE=NULL,
@PeriodEnd	DATE=NULL
)
RETURNS @Result TABLE
   (
    idFactStaff		INT NOT NULL,
    StaffCount	numeric(4,2) NOT NULL,
    idDepartment	INT NOT NULL,
    IsReplacement	BIT NOT NULL,
	idTypeWork		INT,
	idPost		 INT,
	idPlanStaff  INT,
	idEmployee   INT,
	idFinancingSource	INT,
	idOKVED     INT,
	isMain		BIT,
	daysCount	INT,
	DateBegin	DATE,
	DateEnd		DATE,
	OtpDateBegin DATE,
	OtpDateEnd  DATE,
	idOtpusk	INT
   ) 
AS
BEGIN
	IF (@PeriodBegin>@PeriodEnd)
	RETURN
	
	INSERT INTO @Result
	SELECT DISTINCT FactStaff.id, FactStaff.StaffCount, idDepartment,WorkType.IsReplacement, FactStaff.idTypeWork, idPost,
	idPlanStaff, idEmployee, idFinancingSource, FactStaff.idOKVED, 0 ISMain, 
	DATEDIFF(dd, IIF(FactStaff.DateBegin BETWEEN @PeriodBegin AND @PeriodEnd,FactStaff.DateBegin,@PeriodBegin),  
				IIF(FactStaff.DateEnd BETWEEN @PeriodBegin AND @PeriodEnd, FactStaff.DateEnd,@PeriodEnd)) + 1 daysCount,
	 FactStaff.DateBegin, FactStaff.DateEnd, null, null, null
	FROM  (SELECT FactStaff.id, FactStaff.StaffCount, MIN(FactStaff.idTypeWork) idTypeWork, 
			idPlanStaff, idEmployee, FactStaff.idOKVED, 0 isMain, DATEDIFF(dd, @PeriodBegin, @PeriodEnd) + 1 daysCount,
			MIN(FactStaff.DateBegin) DateBegin, ISNULL(MAX(FactStaff.DateEnd),'01.12.2200') DateEnd
			FROM dbo.FactStaffWithHistory FactStaff
			WHERE ((FactStaff.DateBegin<=@PeriodBegin AND (FactStaff.DateEnd>=@PeriodBegin OR FactStaff.DateEnd IS NULL))
								OR (FactStaff.DateBegin>=@PeriodBegin AND FactStaff.DateBegin<=@PeriodEnd))
					AND FactStaff.idTypeWork<>16
			GROUP BY id, FactStaff.StaffCount, FactStaff.idOKVED, idPlanStaff, idEmployee
		) as FactStaff 
		INNER JOIN dbo.PlanStaffCurrent PlanStaff ON FactStaff.idPlanStaff=PlanStaff.id
		INNER JOIN dbo.WorkType ON FactStaff.idTypeWork=WorkType.id 

	/*UPDATE @Result
	SET daysCount=DATEDIFF(dd, DateBegin, @PeriodEnd) + 1
	WHERE DateBegin BETWEEN @PeriodBegin AND @PeriodEnd

	UPDATE @Result
	SET daysCount=DATEDIFF(dd, @PeriodBegin, DateEnd) + 1
	WHERE DateEnd BETWEEN @PeriodBegin AND @PeriodEnd*/

	DECLARE @IntCount INT
	SET @IntCount=1
	WHILE @IntCount<3
	BEGIN

		--учитываем отпуска по беременности и родам
		UPDATE @Result
		SET OtpDateBegin=[OK_Otpusk].[DateBegin],OtpDateEnd=[OK_Otpusk].[DateEnd], idOtpusk=[OK_Otpusk].idOtpusk
		FROM [dbo].[GetOtpuskByPeriod](@PeriodBegin,@PeriodEnd) [OK_Otpusk]
		INNER JOIN @Result res
		ON [OK_Otpusk].idFactStaff=res.idFactStaff
		WHERE  [isMaternity]=1
		AND (res.idOtpusk<>[OK_Otpusk].idOtpusk OR res.idOtpusk IS NULL)

		UPDATE @Result
		SET daysCount=0, OtpDateBegin=NULL, OtpDateEnd=NULL
		WHERE OtpDateBegin <= @PeriodBegin AND @PeriodEnd <= OtpDateEnd

		UPDATE @Result
		SET daysCount=daysCount-DATEDIFF(dd, OtpDateBegin, @PeriodEnd) -1, OtpDateBegin=NULL
		WHERE OtpDateBegin BETWEEN @PeriodBegin AND @PeriodEnd AND NOT OtpDateEnd BETWEEN @PeriodBegin AND @PeriodEnd

		UPDATE @Result
		SET daysCount=daysCount-DATEDIFF(dd, @PeriodBegin, OtpDateEnd) -1, OtpDateEnd=NULL
		WHERE OtpDateEnd BETWEEN @PeriodBegin AND @PeriodEnd AND NOT OtpDateBegin BETWEEN @PeriodBegin AND @PeriodEnd

		UPDATE @Result
		SET daysCount=daysCount-DATEDIFF(dd, OtpDateEnd, OtpDateEnd) -1, OtpDateBegin=NULL, OtpDateEnd=NULL
		WHERE OtpDateEnd BETWEEN @PeriodBegin AND @PeriodEnd AND OtpDateBegin BETWEEN @PeriodBegin AND @PeriodEnd

		SET @IntCount = @IntCount+1

	END

	
RETURN
END


