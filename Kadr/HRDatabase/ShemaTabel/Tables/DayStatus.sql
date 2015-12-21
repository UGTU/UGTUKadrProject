CREATE TABLE [ShemaTabel].[DayStatus] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [DayStatusName]     VARCHAR (5)   NOT NULL,
    [DayStatusFullName] VARCHAR (400) NULL,
    [IsVisible]         BIT           DEFAULT ((1)) NOT NULL,
    CONSTRAINT [DayStatusPrimary] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [DayStatusFullNameDayStatusUnique] UNIQUE NONCLUSTERED ([DayStatusFullName] ASC),
    CONSTRAINT [DayStatusNameDayStatusUnique] UNIQUE NONCLUSTERED ([DayStatusName] ASC)
);

