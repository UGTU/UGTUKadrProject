CREATE TABLE [dbo].[Rank] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [RankName]  VARCHAR (100) COLLATE SQL_Latin1_General_CP1251_CI_AS NOT NULL,
    [KadrID]    INT           NULL,
    [RankOrder] INT           NOT NULL,
    CONSTRAINT [PK_Rank] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_ZRank] UNIQUE NONCLUSTERED ([RankName] ASC)
);

