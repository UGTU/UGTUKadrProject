CREATE TABLE [dbo].[MilitaryType] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [MilitaryTypeName] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_MilitaryType] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryType]
    ON [dbo].[MilitaryType]([MilitaryTypeName] ASC);

