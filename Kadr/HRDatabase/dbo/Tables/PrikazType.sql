CREATE TABLE [dbo].[PrikazType] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [PrikazTypeName]    VARCHAR (100) NOT NULL,
    [idPrikazSuperType] INT           NOT NULL,
    CONSTRAINT [PK_PrikazType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_PrikazType_PrikazSuperType] FOREIGN KEY ([idPrikazSuperType]) REFERENCES [dbo].[PrikazSuperType] ([id]),
    CONSTRAINT [IX_PrikazType] UNIQUE NONCLUSTERED ([PrikazTypeName] ASC)
);

