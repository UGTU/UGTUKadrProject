CREATE TABLE [dbo].[BusinessTripRegionType] (
    [ID]             INT      IDENTITY (1, 1) NOT NULL,
    [idRegionType]   INT      NOT NULL,
    [idBusinessTrip] INT      NOT NULL,
    [DateBegin]      DATETIME NOT NULL,
    [DateEnd]        DATETIME NOT NULL,
    CONSTRAINT [PK_BusinessTripRegionType] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_BusinessTripRegionType_BusinessTrip] FOREIGN KEY ([idBusinessTrip]) REFERENCES [dbo].[BusinessTrip] ([id]),
    CONSTRAINT [FK_BusinessTripRegionType_RegionType] FOREIGN KEY ([idRegionType]) REFERENCES [dbo].[RegionType] ([id])
);

