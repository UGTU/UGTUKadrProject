

GO

CREATE TABLE [dbo].[FactStaffPrikaz](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPrikaz] [int] NOT NULL,
	[idFactStaff] [int] NOT NULL,
	[DateBegin] [date] NULL,
	[DateEnd] [date] NULL,
	[idMainFactStaffPrikaz] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_FactStaffPrikaz] UNIQUE NONCLUSTERED 
(
	[idFactStaff] ASC,
	[idPrikaz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[FactStaffPrikaz]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffPrikaz_FactStaff] FOREIGN KEY([idFactStaff])
REFERENCES [dbo].[FactStaff] ([id])
GO

ALTER TABLE [dbo].[FactStaffPrikaz] CHECK CONSTRAINT [FK_FactStaffPrikaz_FactStaff]
GO

ALTER TABLE [dbo].[FactStaffPrikaz]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffPrikaz_FactStaffPrikaz] FOREIGN KEY([idMainFactStaffPrikaz])
REFERENCES [dbo].[FactStaffPrikaz] ([id])
GO

ALTER TABLE [dbo].[FactStaffPrikaz] CHECK CONSTRAINT [FK_FactStaffPrikaz_FactStaffPrikaz]
GO

ALTER TABLE [dbo].[FactStaffPrikaz]  WITH CHECK ADD  CONSTRAINT [FK_FactStaffPrikaz_Prikaz] FOREIGN KEY([idPrikaz])
REFERENCES [dbo].[Prikaz] ([id])
GO

ALTER TABLE [dbo].[FactStaffPrikaz] CHECK CONSTRAINT [FK_FactStaffPrikaz_Prikaz]
GO




GO

GO

CREATE TABLE [dbo].[BusinessTrip](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idFactStaffPrikaz] [int] NOT NULL,
	[TripTargetPlace] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_BusinessTrip_idFactStaffPrikaz] UNIQUE NONCLUSTERED 
(
	[idFactStaffPrikaz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[BusinessTrip]  WITH CHECK ADD  CONSTRAINT [FK_BusinessTrip_FactStaffPrikaz] FOREIGN KEY([idFactStaffPrikaz])
REFERENCES [dbo].[FactStaffPrikaz] ([id])
GO

ALTER TABLE [dbo].[BusinessTrip] CHECK CONSTRAINT [FK_BusinessTrip_FactStaffPrikaz]
GO


GO

CREATE TABLE [dbo].[BusinessTripRegionType](
	[idRegionType] [int] NOT NULL IDENTITY(1,1) NOT NULL,
	[idBusinessTrip] [int] NOT NULL,
	[DayTrip] [int] NOT NULL,
	[DayTravel] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRegionType] ASC,
	[idBusinessTrip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BusinessTripRegionType]  WITH CHECK ADD  CONSTRAINT [FK_BusinessTripRegionType_BusinessTrip] FOREIGN KEY([idBusinessTrip])
REFERENCES [dbo].[BusinessTrip] ([id])
GO

ALTER TABLE [dbo].[BusinessTripRegionType] CHECK CONSTRAINT [FK_BusinessTripRegionType_BusinessTrip]
GO

ALTER TABLE [dbo].[BusinessTripRegionType]  WITH CHECK ADD  CONSTRAINT [FK_BusinessTripRegionType_RegionType] FOREIGN KEY([idRegionType])
REFERENCES [dbo].[RegionType] ([id])
GO

ALTER TABLE [dbo].[BusinessTripRegionType] CHECK CONSTRAINT [FK_BusinessTripRegionType_RegionType]
GO



GO

GO
GO

CREATE TABLE [dbo].[BusinessTripRegionType](
	[idRegionType] [int] NOT NULL,
	[idBusinessTrip] [int] NOT NULL,
	[DateBegin] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRegionType] ASC,
	[idBusinessTrip] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BusinessTripRegionType]  WITH CHECK ADD  CONSTRAINT [FK_BusinessTripRegionType_BusinessTrip] FOREIGN KEY([idBusinessTrip])
REFERENCES [dbo].[BusinessTrip] ([id])
GO

ALTER TABLE [dbo].[BusinessTripRegionType] CHECK CONSTRAINT [FK_BusinessTripRegionType_BusinessTrip]
GO

ALTER TABLE [dbo].[BusinessTripRegionType]  WITH CHECK ADD  CONSTRAINT [FK_BusinessTripRegionType_RegionType] FOREIGN KEY([idRegionType])
REFERENCES [dbo].[RegionType] ([id])
GO

ALTER TABLE [dbo].[BusinessTripRegionType] CHECK CONSTRAINT [FK_BusinessTripRegionType_RegionType]
GO




---ОТПУСКА ----------------
ALTER TABLE [dbo].[OK_Otpusk]
ADD [idFactStaffPrikaz] INT NULL

GO

ALTER TABLE [dbo].[OK_Otpusk]  WITH CHECK ADD  CONSTRAINT [FK_OK_Otpusk_FactStaffPrikaz] FOREIGN KEY([idFactStaffPrikaz])
REFERENCES [dbo].[FactStaffPrikaz] ([id])
GO

ALTER TABLE [dbo].[OK_Otpusk] CHECK CONSTRAINT [FK_OK_Otpusk_FactStaffPrikaz]

GO


ALTER TABLE [dbo].[OK_Otpusk]
ADD [idSocialFareTransit] INT NULL

GO

ALTER TABLE [dbo].[OK_Otpusk]  WITH CHECK ADD  CONSTRAINT [FK_OK_Otpusk_SocialFareTransit] FOREIGN KEY([idSocialFareTransit])
REFERENCES [dbo].[SocialFareTransit] ([id])
GO

ALTER TABLE [dbo].[SocialFareTransit] CHECK CONSTRAINT [FK_OK_Otpusk_SocialFareTransit]




GO

ALTER TABLE [dbo].[OK_Otpusk]
ALTER COLUMN [idFactStaff] INT NULL


GO

ALTER TABLE [dbo].[OK_Otpusk]
ALTER COLUMN [idOtpuskPrikaz] INT NULL

GO

ALTER TABLE [dbo].[OK_Otpusk]
ALTER COLUMN [DateBegin] DATETIME NULL

GO


INSERT INTO [dbo].[FactStaffPrikaz](idPrikaz,[idFactStaff],[DateBegin],[DateEnd])
SELECT DISTINCT idOtpuskPrikaz,[OK_Otpusk].[idFactStaff],[OK_Otpusk].[DateBegin],[OK_Otpusk].[DateEnd] 
FROM [dbo].[OK_Otpusk] 
LEFT JOIN [dbo].[FactStaffPrikaz] 
	ON [OK_Otpusk].[idFactStaff]=[FactStaffPrikaz].idFactStaff
		AND [OK_Otpusk].idOtpuskPrikaz=[FactStaffPrikaz].idPrikaz
		AND [OK_Otpusk].DateBegin=[FactStaffPrikaz].DateBegin
WHERE [FactStaffPrikaz].id IS nULL

UPDATE [dbo].[OK_Otpusk]
SET [idFactStaffPrikaz]=
[FactStaffPrikaz].id
FROM  
[dbo].[OK_Otpusk]
INNER JOIN [dbo].[FactStaffPrikaz]
ON [OK_Otpusk].[idFactStaff]=[FactStaffPrikaz].idFactStaff
		AND [OK_Otpusk].idOtpuskPrikaz=[FactStaffPrikaz].idPrikaz
		AND [OK_Otpusk].DateBegin=[FactStaffPrikaz].DateBegin
		AND [OK_Otpusk].DateEnd=[FactStaffPrikaz].DateEnd



--SELECT idFactStaff,idOtpuskPrikaz, DateBegin, DateEnd, [idOtpuskVid],[CountDay], COUNT(*) col
--FROM [dbo].[OK_Otpusk] 
--GROUP BY idFactStaff,idOtpuskPrikaz, DateBegin, DateEnd, [idOtpuskVid],[CountDay]
--HAVING COUNT(*)>1





go

CREATE TABLE [dbo].[SocialFareTransit](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateBegin] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
	[idEmployee] [int] NOT NULL,
	[idFactStaffPrikaz] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [IX_SocialFareTransit_idEmployee] UNIQUE NONCLUSTERED 
(
	[idEmployee] ASC,
	[DateBegin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


--Источник финансирования для командировок--
/*
   24 июля 2015 г.15:04:07
   Пользователь: 
   Сервер: ugtudb
   База данных: KadrRealTest
   Приложение: 
*/

/* Чтобы предотвратить возможность потери данных, необходимо внимательно просмотреть этот скрипт, прежде чем запускать его вне контекста конструктора баз данных.*/
ALTER TABLE dbo.FinancingSource SET (LOCK_ESCALATION = TABLE)
GO

BEGIN TRANSACTION
GO
ALTER TABLE dbo.BusinessTrip ADD
	idFinanceSource int NULL
GO
ALTER TABLE dbo.BusinessTrip ADD CONSTRAINT
	FK_BusinessTrip_FinancingSource FOREIGN KEY
	(
	idFinanceSource
	) REFERENCES dbo.FinancingSource
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.BusinessTrip SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

GO

ALTER TABLE [dbo].[SocialFareTransit]  WITH CHECK ADD  CONSTRAINT [FK_SocialFareTransit_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
GO

ALTER TABLE [dbo].[SocialFareTransit] CHECK CONSTRAINT [FK_SocialFareTransit_Employee]
GO

ALTER TABLE [dbo].[SocialFareTransit]  WITH CHECK ADD  CONSTRAINT [FK_SocialFareTransit_FactStaff] FOREIGN KEY([idFactStaffPrikaz])
REFERENCES [dbo].[FactStaff] ([id])
GO

ALTER TABLE [dbo].[SocialFareTransit] CHECK CONSTRAINT [FK_SocialFareTransit_FactStaff]

----Договора и материальная ответственность--------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[Contract](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ContractName] [varchar](50) NOT NULL,
	[DateContract] [date] NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MaterialResponsibility]    Script Date: 25.07.2015 13:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialResponsibility](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idFactStaffPrikaz] [int] NOT NULL,
	[idContract] [int] NOT NULL,
	[Sum] [numeric](8, 2) NOT NULL,
 CONSTRAINT [PK_MaterialResponsibility] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Index [IX_Contract]    Script Date: 25.07.2015 13:18:33 ******/
CREATE NONCLUSTERED INDEX [IX_Contract] ON [dbo].[Contract]
(
	[DateContract] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Contract_1]    Script Date: 25.07.2015 13:18:33 ******/
CREATE NONCLUSTERED INDEX [IX_Contract_1] ON [dbo].[Contract]
(
	[ContractName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MaterialResponsibility]    Script Date: 25.07.2015 13:18:33 ******/
CREATE NONCLUSTERED INDEX [IX_MaterialResponsibility] ON [dbo].[MaterialResponsibility]
(
	[idContract] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MaterialResponsibility_1]    Script Date: 25.07.2015 13:18:33 ******/
CREATE NONCLUSTERED INDEX [IX_MaterialResponsibility_1] ON [dbo].[MaterialResponsibility]
(
	[idFactStaffPrikaz] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MaterialResponsibility]  WITH CHECK ADD  CONSTRAINT [FK_MaterialResponsibility_Contract] FOREIGN KEY([idContract])
REFERENCES [dbo].[Contract] ([id])
GO
ALTER TABLE [dbo].[MaterialResponsibility] CHECK CONSTRAINT [FK_MaterialResponsibility_Contract]
GO
ALTER TABLE [dbo].[MaterialResponsibility]  WITH CHECK ADD  CONSTRAINT [FK_MaterialResponsibility_FactStaffPrikaz] FOREIGN KEY([idFactStaffPrikaz])
REFERENCES [dbo].[FactStaffPrikaz] ([id])
GO
ALTER TABLE [dbo].[MaterialResponsibility] CHECK CONSTRAINT [FK_MaterialResponsibility_FactStaffPrikaz]
GO
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

-----------------------------------------
-----Добавление суррогатного ключа в таблицу BusinessTripRegionType
-----------------------------------------
DROP TABLE [dbo].[BusinessTripRegionType]
GO

CREATE TABLE [dbo].[BusinessTripRegionType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[idRegionType] [int] NOT NULL,
	[idBusinessTrip] [int] NOT NULL,
	[DateBegin] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
 CONSTRAINT [PK_BusinessTripRegionType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BusinessTripRegionType]  WITH CHECK ADD  CONSTRAINT [FK_BusinessTripRegionType_BusinessTrip] FOREIGN KEY([idBusinessTrip])
REFERENCES [dbo].[BusinessTrip] ([id])
GO

ALTER TABLE [dbo].[BusinessTripRegionType] CHECK CONSTRAINT [FK_BusinessTripRegionType_BusinessTrip]
GO

ALTER TABLE [dbo].[BusinessTripRegionType]  WITH CHECK ADD  CONSTRAINT [FK_BusinessTripRegionType_RegionType] FOREIGN KEY([idRegionType])
REFERENCES [dbo].[RegionType] ([id])
GO

ALTER TABLE [dbo].[BusinessTripRegionType] CHECK CONSTRAINT [FK_BusinessTripRegionType_RegionType]
GO

---------------------------------------------
---Добавление даты выдачи документа в "Больничный"
---------------------------------------------
/*
   31 июля 2015 г.14:06:58
   Пользователь: 
   Сервер: ugtudb
   База данных: KadrRealTest
   Приложение: 
*/

/* Чтобы предотвратить возможность потери данных, необходимо внимательно просмотреть этот скрипт, прежде чем запускать его вне контекста конструктора баз данных.*/
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OK_Inkapacity
	DROP CONSTRAINT FK_OK_Inkapacity_Employee
GO
ALTER TABLE dbo.Employee SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_OK_Inkapacity
	(
	idInkapacity int NOT NULL IDENTITY (1, 1),
	idEmployee int NOT NULL,
	NInkapacity varchar(50) NOT NULL,
	DateBegin datetime NOT NULL,
	DateEnd datetime NULL,
	DateDocument datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_OK_Inkapacity SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_OK_Inkapacity ON
GO
IF EXISTS(SELECT * FROM dbo.OK_Inkapacity)
	 EXEC('INSERT INTO dbo.Tmp_OK_Inkapacity (idInkapacity, idEmployee, NInkapacity, DateBegin, DateEnd)
		SELECT idInkapacity, idEmployee, NInkapacity, DateBegin, DateEnd FROM dbo.OK_Inkapacity WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_OK_Inkapacity OFF
GO
DROP TABLE dbo.OK_Inkapacity
GO
EXECUTE sp_rename N'dbo.Tmp_OK_Inkapacity', N'OK_Inkapacity', 'OBJECT' 
GO
ALTER TABLE dbo.OK_Inkapacity ADD CONSTRAINT
	PK_OK_Inkapacity PRIMARY KEY CLUSTERED 
	(
	idInkapacity
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.OK_Inkapacity ADD CONSTRAINT
	FK_OK_Inkapacity_Employee FOREIGN KEY
	(
	idEmployee
	) REFERENCES dbo.Employee
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
COMMIT

-----------------------------------------------
---------Добавления таблиц для учета наград----
-----------------------------------------------

USE [Kadr]
GO

/****** Object:  Table [dbo].[AwardType]    Script Date: 04.08.2015 14:09:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AwardType](
	[ID] [int] NOT NULL IDENTITY (1, 1),
	[Name] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_AwardType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Award]    Script Date: 05.08.2015 13:52:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Award](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDEmployee] [int] NOT NULL,
	[IDEducDocument] [int] NOT NULL,
	[IDAwardType] [int] NOT NULL,
	[IDFactStaffPrikaz] [int] NULL,
 CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_AwardType] FOREIGN KEY([IDAwardType])
REFERENCES [dbo].[AwardType] ([ID])
GO

ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_AwardType]
GO

ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_EducDocument] FOREIGN KEY([IDEducDocument])
REFERENCES [dbo].[EducDocument] ([id])
GO

ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_EducDocument]
GO

ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_Employee] FOREIGN KEY([IDEmployee])
REFERENCES [dbo].[Employee] ([id])
GO

ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_Employee]
GO

ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_FactStaffPrikaz] FOREIGN KEY([IDFactStaffPrikaz])
REFERENCES [dbo].[FactStaffPrikaz] ([id])
GO

ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_FactStaffPrikaz]
GO


=============================================================
==========Делаем необязательным тип подтверждающего документа
=============================================================
/*
   6 августа 2015 г.15:58:41
   Пользователь: 
   Сервер: ugtudb
   База данных: KadrRealTest
   Приложение: 
*/

/* Чтобы предотвратить возможность потери данных, необходимо внимательно просмотреть этот скрипт, прежде чем запускать его вне контекста конструктора баз данных.*/
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EducDocument
	DROP CONSTRAINT FK_EducDocument_EducDocumentType
GO
ALTER TABLE dbo.EducDocumentType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EducDocument
	DROP CONSTRAINT FK_EducDocument_Organisation
GO
ALTER TABLE dbo.Organisation SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_EducDocument
	(
	id int NOT NULL IDENTITY (1, 1),
	idEducDocType int NULL,
	DocSeries varchar(15) NULL,
	DocNumber varchar(50) NULL,
	DocDate datetime NULL,
	IdOrganisation int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_EducDocument SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_EducDocument ON
GO
IF EXISTS(SELECT * FROM dbo.EducDocument)
	 EXEC('INSERT INTO dbo.Tmp_EducDocument (id, idEducDocType, DocSeries, DocNumber, DocDate, IdOrganisation)
		SELECT id, idEducDocType, DocSeries, DocNumber, DocDate, IdOrganisation FROM dbo.EducDocument WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_EducDocument OFF
GO
ALTER TABLE dbo.OK_Educ
	DROP CONSTRAINT FK_OK_Educ_EducDocument
GO
ALTER TABLE dbo.Award
	DROP CONSTRAINT FK_Award_EducDocument
GO
ALTER TABLE dbo.OK_Inkapacity
	DROP CONSTRAINT FK_OK_Inkapacity_EducDocument
GO
ALTER TABLE dbo.EmployeeDegree
	DROP CONSTRAINT FK_EmployeeDegree_EducDocument
GO
ALTER TABLE dbo.EmployeeRank
	DROP CONSTRAINT FK_EmployeeRank_EducDocument
GO
DROP TABLE dbo.EducDocument
GO
EXECUTE sp_rename N'dbo.Tmp_EducDocument', N'EducDocument', 'OBJECT' 
GO
ALTER TABLE dbo.EducDocument ADD CONSTRAINT
	PK_EdicDocument PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_EducDocument ON dbo.EducDocument
	(
	idEducDocType
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_EducDocument_1 ON dbo.EducDocument
	(
	IdOrganisation
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.EducDocument ADD CONSTRAINT
	FK_EducDocument_Organisation FOREIGN KEY
	(
	IdOrganisation
	) REFERENCES dbo.Organisation
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.EducDocument ADD CONSTRAINT
	FK_EducDocument_EducDocumentType FOREIGN KEY
	(
	idEducDocType
	) REFERENCES dbo.EducDocumentType
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EducDocumentUniq]
   ON dbo.EducDocument 
   FOR INSERT, UPDATE 
AS
BEGIN
	IF EXISTS(SELECT 'TRUE' 
			FROM INSERTED, dbo.EducDocument
					WHERE INSERTED.id<>EducDocument.id
						AND INSERTED.idEducDocType=EducDocument.idEducDocType
						AND INSERTED.DocSeries=EducDocument.DocSeries AND INSERTED.DocSeries IS NOT NULL
						AND INSERTED.DocNumber=EducDocument.DocNumber AND INSERTED.DocNumber IS NOT NULL
						--AND INSERTED.DocDate=EducDocument.DocDate AND INSERTED.DocDate IS NOT NULL
	)			
	BEGIN
		  RAISERROR('Ошибка! Такие данные диплома уже есть в базе данных.', 16,1)
		  ROLLBACK TRAN 
	END
END
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EmployeeRank ADD CONSTRAINT
	FK_EmployeeRank_EducDocument FOREIGN KEY
	(
	idEducDocument
	) REFERENCES dbo.EducDocument
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.EmployeeRank SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.EmployeeDegree ADD CONSTRAINT
	FK_EmployeeDegree_EducDocument FOREIGN KEY
	(
	idEducDocument
	) REFERENCES dbo.EducDocument
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.EmployeeDegree SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OK_Inkapacity ADD CONSTRAINT
	FK_OK_Inkapacity_EducDocument FOREIGN KEY
	(
	idEducDocument
	) REFERENCES dbo.EducDocument
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.OK_Inkapacity SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Award ADD CONSTRAINT
	FK_Award_EducDocument FOREIGN KEY
	(
	IDEducDocument
	) REFERENCES dbo.EducDocument
	(
	id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Award SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.OK_Educ ADD CONSTRAINT
	FK_OK_Educ_EducDocument FOREIGN KEY
	(
	idEducDocument
	) REFERENCES dbo.EducDocument
	(
	id
	) ON UPDATE  CASCADE 
	 ON DELETE  CASCADE 
	
GO
ALTER TABLE dbo.OK_Educ SET (LOCK_ESCALATION = TABLE)
GO
COMMIT











ALTER TABLE [dbo].[RegionType]
ADD [RegionTypeSmallName] VARCHAR(10) NULL

ALTER TABLE [dbo].[RegionType]
ALTER COLUMN [RegionTypeSmallName] VARCHAR(10) NOT NULL

-----------------------------------------------------------------------------------------------------------------------------
--ТИП ОБРАЗОВАНИЯ
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EducationType](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[EduTypeName] [varchar](500) NOT NULL,
 CONSTRAINT [PK_EducationType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[EducationType] ON 

GO
INSERT [dbo].[EducationType] ([id], [EduTypeName]) VALUES (4, N'Высшее профессиональное')
GO
INSERT [dbo].[EducationType] ([id], [EduTypeName]) VALUES (5, N'Начальное профессиональное')
GO
INSERT [dbo].[EducationType] ([id], [EduTypeName]) VALUES (7, N'Неполное высшее профессиональное')
GO
INSERT [dbo].[EducationType] ([id], [EduTypeName]) VALUES (8, N'Профессиональная переподготовка')
GO
INSERT [dbo].[EducationType] ([id], [EduTypeName]) VALUES (6, N'Среднее (полное) общее')
GO
INSERT [dbo].[EducationType] ([id], [EduTypeName]) VALUES (3, N'Среднее профессиональное')
GO
SET IDENTITY_INSERT [dbo].[EducationType] OFF
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_EducationType] ON [dbo].[EducationType]
(
	[EduTypeName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OK_Educ]    Script Date: 07.08.2015 15:36:42 ******/
CREATE NONCLUSTERED INDEX [IX_OK_Educ] ON [dbo].[OK_Educ]
(
	[idEducationType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OK_Educ]  WITH CHECK ADD  CONSTRAINT [FK_OK_Educ_EducDocumentType] FOREIGN KEY([idEducationType])
REFERENCES [dbo].[EducationType] ([id])
GO
ALTER TABLE [dbo].[OK_Educ] CHECK CONSTRAINT [FK_OK_Educ_EducDocumentType]
GO

------------------------------------------------------------------------------------------------------------------
====================================
Таблицы для аттестаций
====================================
CREATE TABLE [dbo].[ValidationDecision](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ValidationDecision] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Validation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDEducDocument] [int] NULL,
	[IDFactStaffPrikaz] [int] NOT NULL,
	[IDValidDecision] [int] NULL,
	[Commentary] [varchar](max) NULL,
 CONSTRAINT [PK_Attestation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Validation]  WITH CHECK ADD  CONSTRAINT [FK_Validation_Educ] FOREIGN KEY([IDEducDocument])
REFERENCES [dbo].[EducDocument] ([id])
GO

ALTER TABLE [dbo].[Validation] CHECK CONSTRAINT [FK_Validation_Educ]
GO

ALTER TABLE [dbo].[Validation]  WITH CHECK ADD  CONSTRAINT [FK_Validation_FactStaffPrikaz] FOREIGN KEY([IDFactStaffPrikaz])
REFERENCES [dbo].[FactStaffPrikaz] ([id])
GO

ALTER TABLE [dbo].[Validation] CHECK CONSTRAINT [FK_Validation_FactStaffPrikaz]
GO

ALTER TABLE [dbo].[Validation]  WITH CHECK ADD  CONSTRAINT [FK_Validation_ValidationDecision] FOREIGN KEY([IDValidDecision])
REFERENCES [dbo].[ValidationDecision] ([ID])
GO

ALTER TABLE [dbo].[Validation] CHECK CONSTRAINT [FK_Validation_ValidationDecision]
GO

