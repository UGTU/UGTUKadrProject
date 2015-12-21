CREATE TABLE [ShemaTabel].[EventSuperType] (
    [id]             INT      IDENTITY (1, 1) NOT NULL,
    [idDayStatus]    INT      NOT NULL,
    [BeginDate]      DATE     NOT NULL,
    [EndDate]        DATE     NULL,
    [FirstEventDate] DATETIME NOT NULL,
    CONSTRAINT [EventSuperTypePrimary] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CheckEventSuperTypeDateBegin] CHECK ([BeginDate]<=[EndDate] OR [EndDate] IS NULL),
    CONSTRAINT [EventSuperTypeDayStatusForeign] FOREIGN KEY ([idDayStatus]) REFERENCES [ShemaTabel].[DayStatus] ([id])
);

