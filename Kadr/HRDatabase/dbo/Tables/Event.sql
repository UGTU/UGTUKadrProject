CREATE TABLE [dbo].[Event] (
    [id]                 INT  IDENTITY (1, 1) NOT NULL,
    [idPrikaz]           INT  NULL,
    [DateBegin]          DATE NULL,
    [DateEnd]            DATE NULL,
    [idMainEvent]        INT  NULL,
    [idPrikazEnd]        INT  NULL,
    [idFactStaffHistory] INT  NOT NULL,
    [idEventKind]        INT  NULL,
    [idEventType]        INT  CONSTRAINT [DF_Event_idEventType] DEFAULT ((1)) NULL,
    [idContract]         INT  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Event_Contract] FOREIGN KEY ([idContract]) REFERENCES [dbo].[Contract] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Event_EventKind] FOREIGN KEY ([idEventKind]) REFERENCES [dbo].[EventKind] ([id]),
    CONSTRAINT [FK_Event_EventType] FOREIGN KEY ([idEventType]) REFERENCES [dbo].[EventType] ([id]),
    CONSTRAINT [FK_FactStaffHistoryEvent_FactStaffHistory] FOREIGN KEY ([idFactStaffHistory]) REFERENCES [dbo].[FactStaffHistory] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_FactStaffPrikaz_FactStaffPrikaz] FOREIGN KEY ([idMainEvent]) REFERENCES [dbo].[Event] ([id]),
    CONSTRAINT [FK_FactStaffPrikaz_Prikaz] FOREIGN KEY ([idPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [FK_FactStaffPrikaz_Prikaz1] FOREIGN KEY ([idPrikazEnd]) REFERENCES [dbo].[Prikaz] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Event_idFactStaffHistory]
    ON [dbo].[Event]([idFactStaffHistory] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffPrikaz_idPrikaz]
    ON [dbo].[Event]([idPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffPrikaz_idMainFactStaffPrikaz]
    ON [dbo].[Event]([idMainEvent] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffPrikaz_PrikazEnd]
    ON [dbo].[Event]([idPrikazEnd] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Event_idEventKind]
    ON [dbo].[Event]([idEventKind] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Event_idEventType]
    ON [dbo].[Event]([idEventType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Event_idContract]
    ON [dbo].[Event]([idContract] ASC);

