CREATE TABLE [dbo].[Grazd] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [grazdName] VARCHAR (100) COLLATE SQL_Latin1_General_CP1251_CI_AS NULL,
    [KadrID]    INT           NULL,
    CONSTRAINT [PK_Grazd] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_Grazd] UNIQUE NONCLUSTERED ([grazdName] ASC)
);

