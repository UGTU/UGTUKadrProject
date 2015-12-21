CREATE TABLE [dbo].[WorkSuperType] (
    [id]                     INT          IDENTITY (1, 1) NOT NULL,
    [WorkSuperTypeName]      VARCHAR (50) NOT NULL,
    [WorkSuperTypeShortName] VARCHAR (20) NULL,
    CONSTRAINT [PK_WorkSuperType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_WorkSuperType] UNIQUE NONCLUSTERED ([WorkSuperTypeName] ASC)
);

