
--select * from [GetReportBonusOrder](12) ord inner join BonusType on BonusType.id=ord.idBonusType order by BonusOrderNumber
--Функция возращает список выводимых надбавок и их последовательность для переданного отчета
--включая оклад (обозначение оклада -1)
CREATE FUNCTION [dbo].[GetReportBonusOrder] 
(
@idBonusReport INT
)
RETURNS @Result TABLE
   (
	idBonusType			INT,	
	BonusOrderNumber	INT,
	[OnlyExtrabudgetary]  BIT
   ) 
AS
BEGIN
	--если последовательность столбцов используется по умолчанию (т.е. как идет в таблице)
	--сортируем по алфавиту по названию надбавки
	IF EXISTS(SELECT 'TRUE' FROM dbo.BonusReport WHERE id=@idBonusReport AND DefaultBonusOrder=1)
		INSERT INTO @Result
			SELECT id, (SELECT COUNT(*) FROM dbo.BonusType bonType 
							WHERE bonType.BonusTypeShortName<=BonusType.BonusTypeShortName)	,0
			FROM dbo.BonusType
	--если не по умолчанию, берем значения из dbo.BonusReportColumns	
	ELSE
	BEGIN
		IF (@idBonusReport=12) --если это фонд по надбавкам, то для него сортировка особенная - по типу надбавки и по единице измерения
			INSERT INTO @Result
			SELECT BonusType.id, [BonusSuperType].[OrderNumber]*10-[idBonusMeasure] BonusOrderNumber, 0 [OnlyExtrabudgetary]	
			FROM [dbo].[BonusType]
				INNER JOIN [dbo].[BonusSuperType] ON [BonusType].idBonusSuperType=[BonusSuperType].id
			--ORDER BY [BonusSuperType].[OrderNumber], [idBonusMeasure] DESC
		ELSE
			INSERT INTO @Result
				SELECT idBonusType, BonusOrderNumber, [OnlyExtrabudgetary]	
				FROM dbo.BonusReportColumns
				WHERE idBonusReport=@idBonusReport
	END
	
	--добавляем оклад (обозначение -1)
	--если установлено, что оклад вначале
	IF EXISTS(SELECT 'TRUE' FROM dbo.BonusReport WHERE id=@idBonusReport AND SalaryFirst=1)
		INSERT INTO @Result
			VALUES(-1, -1, 0)
	--иначе считаем, что в конце	
	ELSE
		INSERT INTO @Result
			SELECT -1, (SELECT MAX(BonusOrderNumber)+1 FROM @Result), 0
			
	/*--если это отчет с надбавками по должностям, добавляем еще секретность
	IF (@idBonusReport=2)
	BEGIN
		INSERT INTO @Result
			SELECT 63, (SELECT MAX(BonusOrderNumber)+1 FROM @Result)
	END*/

RETURN
END













