CREATE TABLE [dbo].[Event_BusinessTrip] (
    [idEvent]        INT NOT NULL,
    [idBusinessTrip] INT NOT NULL,
    CONSTRAINT [PK_Event_BusinessTrip] PRIMARY KEY CLUSTERED ([idEvent] ASC),
    CONSTRAINT [FK_Event_BusinessTrip_BusinessTrip] FOREIGN KEY ([idBusinessTrip]) REFERENCES [dbo].[BusinessTrip] ([id]),
    CONSTRAINT [FK_Event_BusinessTrip_Event] FOREIGN KEY ([idEvent]) REFERENCES [dbo].[Event] ([id])
);

