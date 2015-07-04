use Kadr
GO

ALTER TABLE dbo.Employee  WITH CHECK ADD  CONSTRAINT CK_EmployeeSeverKoeff CHECK  ((SeverKoeff BETWEEN 1 AND 150))
GO

ALTER TABLE [dbo].Employee CHECK CONSTRAINT CK_EmployeeSeverKoeff
go

ALTER TABLE dbo.Employee  WITH CHECK ADD  CONSTRAINT CK_EmployeeRayonKoeff CHECK  ((RayonKoeff BETWEEN 1 AND 150))
GO

ALTER TABLE [dbo].Employee CHECK CONSTRAINT CK_EmployeeRayonKoeff
go




alter table dbo.Department
add SeverKoeff INT 
go
alter table dbo.Department
add RayonKoeff INT 




go
--заполнение
update dbo.Department
set SeverKoeff = 50, RayonKoeff = 30



--создание таблицы параметров
GO

CREATE TABLE [dbo].[BonusKoeffs](
	[id] [int] NOT NULL identity,
	[SeverKoeff] [int] NOT NULL,
	[RayonKoeff] [int] NOT NULL,
	[NDFLKoeff] [int] NOT NULL,
	[dateBegin] [datetime] NOT NULL,
 CONSTRAINT [PK_BonusKoeffs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_BonusKoeffs] UNIQUE NONCLUSTERED 
(
	[NDFLKoeff] ASC,
	[RayonKoeff] ASC,
	[SeverKoeff] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


ALTER TABLE dbo.[BonusKoeffs]  WITH CHECK ADD  CONSTRAINT CK_BonusKoeffsSeverKoeff CHECK  ((SeverKoeff BETWEEN 1 AND 150))

go
ALTER TABLE dbo.[BonusKoeffs]  WITH CHECK ADD  CONSTRAINT CK_BonusKoeffsRayonKoeff CHECK  ((RayonKoeff BETWEEN 1 AND 150))

go
ALTER TABLE dbo.[BonusKoeffs]  WITH CHECK ADD  CONSTRAINT CK_BonusKoeffsNDFLKoeff CHECK  ((NDFLKoeff BETWEEN 1 AND 100))

go

insert into dbo.BonusKoeffs(SeverKoeff,RayonKoeff,NDFLKoeff, dateBegin)
values(50,30,13,'1.1.2010')









GO

--select * from [dbo].[GetBonusKoeffs]( '01.01.2010') 143
create FUNCTION [dbo].GetBonusKoeffs 
(
@Date	DATETIME=NULL
)
RETURNS @Result TABLE
   (
    SeverKoeff				INT,
    RayonKoeff				INT,
    NDFLKoeff				INT
   ) 
AS
BEGIN
	INSERT INTO @Result
	SELECT SeverKoeff, RayonKoeff, NDFLKoeff
	FROM dbo.BonusKoeffs
	WHERE dateBegin = (SELECT MAX(dateBegin) FROM dbo.BonusKoeffs WHERE dateBegin<= @Date)
	
	RETURN
END