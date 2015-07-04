USE [Kadr]
GO

/****** Object:  Table [dbo].[BonusReport]    Script Date: 09/20/2011 12:16:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BonusReport](
	[id] [int] identity NOT NULL,
	[ReporName] [varchar](50) NOT NULL,
	[WithManagers] [bit] not NULL,
	SalaryFirst		bit not null,
	DefaultBonusOrder	bit not null,
	WithReplacements	bit not null
	
 CONSTRAINT [PK_ReportType] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_ReportType] UNIQUE NONCLUSTERED 
(
	[ReporName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



GO

CREATE TABLE [dbo].[BonusReportColumns](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idBonusReport] [int] NOT NULL,
	[idBonusType] [int] NOT NULL,
	[BonusOrderNumber] [int] NOT NULL,
 CONSTRAINT [PK_BonusReportColumns] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_BonusReportColumns] UNIQUE NONCLUSTERED 
(
	[idBonusReport] ASC,
	[idBonusType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BonusReportColumns]  WITH CHECK ADD  CONSTRAINT [FK_BonusReportColumns_BonusReport] FOREIGN KEY([idBonusReport])
REFERENCES [dbo].[BonusReport] ([id])
GO

ALTER TABLE [dbo].[BonusReportColumns] CHECK CONSTRAINT [FK_BonusReportColumns_BonusReport]
GO

ALTER TABLE [dbo].[BonusReportColumns]  WITH CHECK ADD  CONSTRAINT [FK_BonusReportColumns_BonusType] FOREIGN KEY([idBonusType])
REFERENCES [dbo].[BonusType] ([id])
GO

ALTER TABLE [dbo].[BonusReportColumns] CHECK CONSTRAINT [FK_BonusReportColumns_BonusType]
GO


