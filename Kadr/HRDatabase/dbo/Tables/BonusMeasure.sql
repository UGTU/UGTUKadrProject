CREATE TABLE [dbo].[BonusMeasure] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [MeasureName] VARCHAR (50) NOT NULL,
    [Sign]        VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Measure] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_BonusMeasure] UNIQUE NONCLUSTERED ([MeasureName] ASC)
);

