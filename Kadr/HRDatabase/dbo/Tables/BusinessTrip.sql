CREATE TABLE [dbo].[BusinessTrip] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [TripTargetPlace] VARCHAR (MAX) NULL,
    [idFinanceSource] INT           NULL,
    [DaysInRoad]      INT           NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_BusinessTrip_FinancingSource] FOREIGN KEY ([idFinanceSource]) REFERENCES [dbo].[FinancingSource] ([id])
);

