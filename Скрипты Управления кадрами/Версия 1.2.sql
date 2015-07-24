

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




---Œ“œ”— ¿ ----------------
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