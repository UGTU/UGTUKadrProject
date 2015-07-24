
GO

/****** Object:  Table [dbo].[AuditKadrVersion]    Script Date: 16.07.2015 14:02:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

--Таблица версий
CREATE TABLE [dbo].[AuditKadrVersion](
	[idVersion] [varchar](10) NOT NULL,
	[VersionDate] [date] NOT NULL CONSTRAINT [DF_AuditKadrVersion_VersionDate]  DEFAULT (getdate()),
	[Comment] [varchar](max) NULL,
 CONSTRAINT [PK_AuditKadrVersion] PRIMARY KEY CLUSTERED 
(
	[idVersion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO







--трудовая книжка
ALTER TABLE [dbo].[Employee]
ADD EmplHistSer VARCHAR(10) 

ALTER TABLE [dbo].[Employee]
ADD EmplHistNumber VARCHAR(20)

ALTER TABLE [dbo].[Employee]
ADD EmplHistDate DATE




CREATE TABLE StandingType (id int IDENTITY NOT NULL,StandingTypeName varchar(250) NOT NULL UNIQUE, PRIMARY KEY (ID));
CREATE TABLE RegionType (id int IDENTITY NOT NULL, RegionTypeName varchar(250) NOT NULL UNIQUE, PRIMARY KEY (ID));

GO

CREATE TABLE [dbo].[EmployeeStanding](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateBegin] [date] NOT NULL,
	[DateEnd] [date] NOT NULL,
	[WorkPlace] [varchar](max) NULL,
	[Post] [varchar](250) NULL,
	[idRegionType] [int] NOT NULL,
	[idStandingType] [int] NOT NULL,
	[idEmployee] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EmployeeStanding]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeStanding_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
GO

ALTER TABLE [dbo].[EmployeeStanding] CHECK CONSTRAINT [FK_EmployeeStanding_Employee]
GO

ALTER TABLE [dbo].[EmployeeStanding]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeStanding_RegionType] FOREIGN KEY([idRegionType])
REFERENCES [dbo].[RegionType] ([id])
GO

ALTER TABLE [dbo].[EmployeeStanding] CHECK CONSTRAINT [FK_EmployeeStanding_RegionType]
GO

ALTER TABLE [dbo].[EmployeeStanding]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeStanding_StandingType] FOREIGN KEY([idStandingType])
REFERENCES [dbo].[StandingType] ([id])
GO

ALTER TABLE [dbo].[EmployeeStanding] CHECK CONSTRAINT [FK_EmployeeStanding_StandingType]


GO

/****** Object:  Index [IX_EmployeeStanding_DateBegin]    Script Date: 16.07.2015 16:33:55 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeStanding_DateBegin] ON [dbo].[EmployeeStanding]
(
	[DateBegin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


GO

/****** Object:  Index [IX_EmployeeStanding_idEmployee]    Script Date: 16.07.2015 16:34:12 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeStanding_idEmployee] ON [dbo].[EmployeeStanding]
(
	[idEmployee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

GO

/****** Object:  Index [IX_EmployeeStanding_idRegionType]    Script Date: 16.07.2015 16:34:25 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeStanding_idRegionType] ON [dbo].[EmployeeStanding]
(
	[idRegionType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

GO

/****** Object:  Index [IX_EmployeeStanding_idStandingType]    Script Date: 16.07.2015 16:34:38 ******/
CREATE NONCLUSTERED INDEX [IX_EmployeeStanding_idStandingType] ON [dbo].[EmployeeStanding]
(
	[idStandingType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO