CREATE TABLE [dbo].[MilitaryStructure] (
    [id]                    INT           IDENTITY (1, 1) NOT NULL,
    [MilitaryStructureName] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_MilitaryStructure] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryStructure]
    ON [dbo].[MilitaryStructure]([MilitaryStructureName] ASC);

