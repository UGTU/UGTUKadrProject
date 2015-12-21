CREATE TABLE [dbo].[Degree] (
    [id]              INT           NOT NULL,
    [DegreeName]      VARCHAR (100) COLLATE SQL_Latin1_General_CP1251_CI_AS NOT NULL,
    [DegreeShortName] VARCHAR (50)  NOT NULL,
    [DegreeAbbrev]    VARCHAR (50)  NOT NULL,
    [DegreeOrder]     INT           NOT NULL,
    CONSTRAINT [PK_Degree] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_Degree] UNIQUE NONCLUSTERED ([DegreeName] ASC),
    CONSTRAINT [IX_Degree_1] UNIQUE NONCLUSTERED ([DegreeAbbrev] ASC),
    CONSTRAINT [IX_Degree_2] UNIQUE NONCLUSTERED ([DegreeAbbrev] ASC)
);

