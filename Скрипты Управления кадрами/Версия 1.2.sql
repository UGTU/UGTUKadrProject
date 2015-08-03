

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
	[idRegionType] [int] NOT NULL,
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
--Образование и подтверждающие документы
----------------------------------------
CREATE TABLE [dbo].[Organisation](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](900) NOT NULL,
 CONSTRAINT [PK_Organisation] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

 alter table EducDocument add idOrganisation int null

  insert into Organisation(Name)
  select distinct [EducWhere]
  from [dbo].[OK_Educ]

  update [dbo].[EducDocument]
  set idOrganisation = (select Organisation.id
						from Organisation, OK_Educ
						where OK_Educ.idEducDocument = EducDocument.id
						and OK_Educ.EducWhere = Organisation.Name)

  alter table OK_Educ add idEducationType int null

  update OK_Educ set idEducationType = (select [idEducDocType]
										from EducDocument
										where EducDocument.id = OK_Educ.idEducDocument)


CREATE NONCLUSTERED INDEX [IX_EducDocument_1] ON [dbo].[EducDocument]
(
	[IdOrganisation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OK_Educ] ON [dbo].[OK_Educ]
(
	[idEducationType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_OK_Educ_1] ON [dbo].[OK_Educ]
(
	[idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
CREATE NONCLUSTERED INDEX [IX_Organisation] ON [dbo].[Organisation]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EducDocument]  WITH CHECK ADD  CONSTRAINT [FK_EducDocument_Organisation] FOREIGN KEY([IdOrganisation])
REFERENCES [dbo].[Organisation] ([id])
GO
ALTER TABLE [dbo].[EducDocument] CHECK CONSTRAINT [FK_EducDocument_Organisation]
GO
ALTER TABLE [dbo].[OK_Educ]  WITH CHECK ADD  CONSTRAINT [FK_OK_Educ_EducDocumentType] FOREIGN KEY([idEducationType])
REFERENCES [dbo].[EducDocumentType] ([id])
GO
ALTER TABLE [dbo].[OK_Educ] CHECK CONSTRAINT [FK_OK_Educ_EducDocumentType]
GO

