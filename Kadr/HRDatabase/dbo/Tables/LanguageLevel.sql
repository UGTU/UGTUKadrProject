CREATE TABLE [dbo].[LanguageLevel] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [LevelName] VARCHAR (255) NOT NULL,
    [GoodBit]   BIT           NOT NULL,
    CONSTRAINT [PK_LanguageLevel] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_LanguageLevel]
    ON [dbo].[LanguageLevel]([LevelName] ASC);

