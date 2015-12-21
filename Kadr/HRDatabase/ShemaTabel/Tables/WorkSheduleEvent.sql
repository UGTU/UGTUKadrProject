CREATE TABLE [ShemaTabel].[WorkSheduleEvent] (
    [idEventSuperType] INT        NOT NULL,
    [KolHourMPS]       FLOAT (53) NOT NULL,
    [KolHourMNS]       FLOAT (53) NOT NULL,
    [KolHourGPS]       FLOAT (53) NOT NULL,
    [KolHourGNS]       FLOAT (53) NOT NULL,
    [idShedule]        INT        NOT NULL,
    [idRepeatRate]     INT        NOT NULL,
    [Data_Agr]         DATE       NULL,
    [IsPPS]            BIT        NULL,
    CONSTRAINT [WorkSheduleEventRepeatRateForeign] FOREIGN KEY ([idRepeatRate]) REFERENCES [ShemaTabel].[RepeatRate] ([id]),
    CONSTRAINT [WorkSheduleEventSheduleForeign] FOREIGN KEY ([idShedule]) REFERENCES [ShemaTabel].[WorkShedule] ([id]),
    CONSTRAINT [WorkSheduleEventSuperTypeEventForeign] FOREIGN KEY ([idEventSuperType]) REFERENCES [ShemaTabel].[EventSuperType] ([id])
);

