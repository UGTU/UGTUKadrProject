CREATE TABLE [ShemaTabel].[WorkShedule] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [NameShedule] VARCHAR (50) NOT NULL,
    CONSTRAINT [ShedulePrimary] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [SheduleNameSheduleUniqeu] UNIQUE NONCLUSTERED ([NameShedule] ASC)
);

