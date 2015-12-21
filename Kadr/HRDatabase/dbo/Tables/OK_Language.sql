CREATE TABLE [dbo].[OK_Language] (
    [idlanguage]   INT           IDENTITY (1, 1) NOT NULL,
    [languagename] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_OK_Language] PRIMARY KEY CLUSTERED ([idlanguage] ASC)
);

