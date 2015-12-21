CREATE TABLE [dbo].[SemPol] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [sempolName] VARCHAR (100) COLLATE SQL_Latin1_General_CP1251_CI_AS NOT NULL,
    [KadrID]     INT           NULL,
    CONSTRAINT [PK_SemPol] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_SemPol] UNIQUE NONCLUSTERED ([sempolName] ASC)
);

