CREATE TABLE [dbo].[MilitaryCategory] (
    [id]                   INT          IDENTITY (1, 1) NOT NULL,
    [MilitaryCategoryName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MilitaryCategory] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryCategory]
    ON [dbo].[MilitaryCategory]([MilitaryCategoryName] ASC);

