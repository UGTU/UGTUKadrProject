CREATE TABLE [dbo].[EventKind] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [EventKindName]     VARCHAR (500) NOT NULL,
    [idMainEventKind]   INT           NULL,
    [ForFactStaff]      BIT           NOT NULL,
    [EventKindApplName] VARCHAR (100) NULL,
    [DecoratorName]     VARCHAR (500) NULL,
    [WithContract]      BIT           NULL,
    CONSTRAINT [PK_EventKind] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_EventKind_EventKind] FOREIGN KEY ([idMainEventKind]) REFERENCES [dbo].[EventKind] ([id]),
    CONSTRAINT [IX_EventKind_EventKindName] UNIQUE NONCLUSTERED ([EventKindName] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_EventKind_idMainEventKind]
    ON [dbo].[EventKind]([idMainEventKind] ASC);

