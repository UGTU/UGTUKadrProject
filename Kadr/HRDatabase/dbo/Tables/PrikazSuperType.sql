CREATE TABLE [dbo].[PrikazSuperType] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [PrikazSuperTypeName] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_PrikazSuperType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_PrikazSuperType] UNIQUE NONCLUSTERED ([PrikazSuperTypeName] ASC)
);

