CREATE TABLE [ShemaTabel].[Exception] (
    [id]            INT          IDENTITY (1, 1) NOT NULL,
    [ExceptionName] VARCHAR (50) NOT NULL,
    [DateException] DATE         NOT NULL,
    [idDayStatus]   INT          NOT NULL,
    [idPrikaz]      INT          NOT NULL,
    [KolHourMPS]    REAL         NOT NULL,
    [KolHourMNS]    REAL         NOT NULL,
    [KolHourGPS]    REAL         NOT NULL,
    [KolHourGNS]    REAL         NOT NULL,
    [idWorkShedule] INT          NOT NULL,
    CONSTRAINT [ExceptionPrimary] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [ExceptionDayStatusForeign] FOREIGN KEY ([idDayStatus]) REFERENCES [ShemaTabel].[DayStatus] ([id]),
    CONSTRAINT [ExceptionPrikazForeign] FOREIGN KEY ([idPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [ExceptionWorkSheduleForeign] FOREIGN KEY ([idWorkShedule]) REFERENCES [ShemaTabel].[WorkShedule] ([id])
);

