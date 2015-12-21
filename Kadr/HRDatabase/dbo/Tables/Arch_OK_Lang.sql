CREATE TABLE [dbo].[Arch_OK_Lang] (
    [id]       INT           IDENTITY (1, 1) NOT NULL,
    [tabn]     INT           NULL,
    [stepvlad] VARCHAR (255) NULL,
    [lang]     VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Lang] PRIMARY KEY CLUSTERED ([id] ASC)
);

