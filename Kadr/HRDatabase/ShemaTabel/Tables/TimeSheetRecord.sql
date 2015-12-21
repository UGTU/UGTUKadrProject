CREATE TABLE [ShemaTabel].[TimeSheetRecord] (
    [RecordDate]         DATETIME         NOT NULL,
    [JobTimeCount]       FLOAT (53)       NOT NULL,
    [idTimeSheet]        INT              NOT NULL,
    [idDayStatus]        INT              NOT NULL,
    [IsChecked]          BIT              NULL,
    [idFactStaffHistory] INT              NOT NULL,
    [IdTimeSheetRecord]  UNIQUEIDENTIFIER DEFAULT (newsequentialid()) NOT NULL,
    CONSTRAINT [TimeSheetRecordTablePrimary] PRIMARY KEY CLUSTERED ([IdTimeSheetRecord] ASC),
    CONSTRAINT [TimeSheetRecordFactStaffHistoryFK] FOREIGN KEY ([idFactStaffHistory]) REFERENCES [dbo].[FactStaffHistory] ([id]) ON DELETE CASCADE,
    CONSTRAINT [TimeSheetRecordTimeSheetForeign] FOREIGN KEY ([idTimeSheet]) REFERENCES [ShemaTabel].[TimeSheet] ([id]),
    CONSTRAINT [ZapisTabelDayStatusForeign] FOREIGN KEY ([idDayStatus]) REFERENCES [ShemaTabel].[DayStatus] ([id])
);

