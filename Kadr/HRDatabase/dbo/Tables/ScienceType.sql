CREATE TABLE [dbo].[ScienceType] (
    [id]                   INT           IDENTITY (1, 1) NOT NULL,
    [ScienceTypeName]      VARCHAR (200) COLLATE SQL_Latin1_General_CP1251_CI_AS NOT NULL,
    [ScienceTypeAbbrev]    VARCHAR (50)  NOT NULL,
    [ScienceTypeShortName] VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_VidNauk] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_ScienceType] UNIQUE NONCLUSTERED ([ScienceTypeAbbrev] ASC),
    CONSTRAINT [IX_ScienceType_1] UNIQUE NONCLUSTERED ([ScienceTypeShortName] ASC),
    CONSTRAINT [IX_VidNauk] UNIQUE NONCLUSTERED ([ScienceTypeName] ASC)
);

