CREATE TABLE [dbo].[MilitaryRank] (
    [id]               INT           IDENTITY (1, 1) NOT NULL,
    [MilitaryRankName] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_MilitaryRank] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryRank]
    ON [dbo].[MilitaryRank]([MilitaryRankName] ASC);

