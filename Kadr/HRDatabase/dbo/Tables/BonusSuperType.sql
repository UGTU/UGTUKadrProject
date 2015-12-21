CREATE TABLE [dbo].[BonusSuperType] (
    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    [BonusSuperTypeName] VARCHAR (100) NOT NULL,
    [OrderNumber]        INT           NULL,
    CONSTRAINT [PK_BonusSuperType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_BonusSuperType] UNIQUE NONCLUSTERED ([BonusSuperTypeName] ASC)
);

