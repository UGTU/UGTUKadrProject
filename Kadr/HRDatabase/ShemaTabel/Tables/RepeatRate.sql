CREATE TABLE [ShemaTabel].[RepeatRate] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [DaysRepeat] INT NOT NULL,
    CONSTRAINT [RepeatRatePrimary] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [RepeatRateDaysRepeatUnique] UNIQUE NONCLUSTERED ([DaysRepeat] ASC)
);

