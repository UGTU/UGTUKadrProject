CREATE TABLE [dbo].[TimeSheetDayState] (
    [id]                INT          IDENTITY (1, 1) NOT NULL,
    [DayStateName]      VARCHAR (50) NOT NULL,
    [IsRequired]        BIT          NOT NULL,
    [DayStateShortName] VARCHAR (50) NOT NULL,
    [IsWorking]         BIT          NULL,
    CONSTRAINT [PK_DayState] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_DayState] UNIQUE NONCLUSTERED ([DayStateName] ASC)
);

