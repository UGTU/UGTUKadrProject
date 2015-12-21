--SELECT * from [dbo].[GetDepartmentDataForReports](1, '9.01.2015','09.02.2015',1,3) 
--функция выбирает данные отдела для отчета по надбавкам или просто отчета 
--Настройки: @WithSubDeps - с зависимыми отделами, @idBonusReport - код отчета для получения остальных настроек отчета
CREATE FUNCTION [dbo].[GetDepartmentDataForReports] 
(
@idDepartment INT,
@PeriodBegin	DATETIME=NULL,
@PeriodEnd	DATETIME=NULL,
@WithSubDeps BIT,
@idBonusReport		 INT
)
RETURNS @DepTable TABLE
   (
	idDepartment	INT NULL,
	idManagerPlanStaff	INT,
	DirectionManagerName	VARCHAR(170),
    IsMain			BIT  ,
	[DepartmentName] VARCHAR(500),
	[DepartmentSmallName] VARCHAR(50),
	DepTreeIndex			VARCHAR(30),
	idOKVED	INT,
	[idFundingCenter] INT
   ) 
AS
BEGIN
	
	--заполняем отделы с менеджерами
	IF EXISTS(SELECT 'TRUE' FROM dbo.BonusReport WHERE id=@idBonusReport AND WithManagers = 1)	
	BEGIN
		IF (@WithSubDeps = 1)	--подотделы
			INSERT INTO @DepTable
				SELECT idDepartment, idManagerPlanStaff, null, IsMain, DepartmentName,DepartmentSmallName, DepTreeIndex, idOKVED, [idFundingCenter]
				FROM [dbo].GetSubDepartmentsWithManagersWithPeriod(@idDepartment, @PeriodBegin, @PeriodEnd)	--с менеджерами
		ELSE	--текущий отдел
			INSERT INTO @DepTable	
				SELECT @idDepartment, [dbo].[GetDepartmentsManager](@idDepartment), null, 1, DepartmentName,DepartmentSmallName, '1', idOKVED, [idFundingCenter]
				FROM [dbo].[Department]
				WHERE [id]=@idDepartment
			
		UPDATE 	@DepTable
		SET DirectionManagerName=EmployeeSmallName
		FROM @DepTable as Deps
			INNER JOIN dbo.GetStaffByPeriod(@PeriodBegin,@PeriodEnd) as PeriodStaff ON PeriodStaff.idPlanStaff=Deps.idManagerPlanStaff
			INNER JOIN dbo.FactStaff ON PeriodStaff.idFactStaff=FactStaff.id
			INNER JOIN dbo.Employee ON FactStaff.idEmployee=Employee.id
	END
	--без менеджеров
	ELSE	
	BEGIN
		IF (@WithSubDeps = 1)	--подотделы
			INSERT INTO @DepTable
			SELECT idDepartment, null, null, IsMain, DepartmentName,DepartmentSmallName, DepTreeIndex, idOKVED, [idFundingCenter]
			FROM [dbo].GetSubDepartmentsWithPeriod(@idDepartment, @PeriodBegin, @PeriodEnd)	--без менеджеров
		ELSE	--текущий отдел
		INSERT INTO @DepTable	--текущий отдел
			SELECT @idDepartment, null, null, 1, DepartmentName,DepartmentSmallName, '1', idOKVED, [idFundingCenter]
			FROM [dbo].[Department]
				WHERE [id]=@idDepartment
	END
	RETURN
END