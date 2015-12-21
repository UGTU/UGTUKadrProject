CREATE TABLE [dbo].[StandingType] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [StandingTypeName] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    UNIQUE NONCLUSTERED ([StandingTypeName] ASC)
);

