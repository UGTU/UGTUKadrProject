create FUNCTION [dbo].[GetBonusKoeffs] 
(
@Date	DATETIME
)
RETURNS  TABLE

AS
RETURN
	(SELECT SeverKoeff, RayonKoeff, NDFLKoeff
	FROM dbo.BonusKoeffs
	WHERE dateBegin = (SELECT MAX(dateBegin) FROM dbo.BonusKoeffs WHERE dateBegin<= @Date))