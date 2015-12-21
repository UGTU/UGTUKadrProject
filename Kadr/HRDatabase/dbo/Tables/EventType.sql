CREATE TABLE [dbo].[EventType] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [EventTypeName] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_EventType_EventTypeName] UNIQUE NONCLUSTERED ([EventTypeName] ASC),
    CONSTRAINT [IX_EvenType_EventTypeName] UNIQUE NONCLUSTERED ([EventTypeName] ASC)
);

