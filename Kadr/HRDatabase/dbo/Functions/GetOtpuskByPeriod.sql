--выбирает отпуски за заданный период
--select * from [dbo].[GetOtpuskByPeriod]('20.01.2011','20.02.2011')
CREATE FUNCTION [dbo].[GetOtpuskByPeriod] 
(
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL
)
RETURNS  TABLE

AS
RETURN (SELECT OK_Otpusk.idOtpusk, OK_Otpusk.idFactStaff, OK_Otpusk.idOtpuskVid,
		isMaternity, otpTypeShortName, [DateBegin], [DateEnd]
	FROM dbo.OK_Otpusk INNER JOIN dbo.OK_Otpuskvid ON OK_Otpusk.idOtpuskVid=OK_Otpuskvid.idOtpuskVid
	WHERE 
		((OK_Otpusk.DateBegin<=@PeriodBegin AND (OK_Otpusk.DateEnd>=@PeriodBegin OR OK_Otpusk.DateEnd IS NULL))
								OR (OK_Otpusk.DateBegin>=@PeriodBegin AND OK_Otpusk.DateBegin<=@PeriodEnd))
	)
	--group by FactStaff.id, idPlanStaff, idEmployee, idTypeWork, IsReplacement, LastFactStaff.DateBegin		  
		  
