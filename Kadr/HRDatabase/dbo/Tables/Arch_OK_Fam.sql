CREATE TABLE [dbo].[Arch_OK_Fam] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [tabn]      INT           NULL,
    [fio]       VARCHAR (255) NULL,
    [birthdate] VARCHAR (255) NULL,
    [membfam]   VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Fam] PRIMARY KEY CLUSTERED ([id] ASC)
);

