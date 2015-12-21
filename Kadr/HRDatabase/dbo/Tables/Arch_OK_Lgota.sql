CREATE TABLE [dbo].[Arch_OK_Lgota] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [tabn]      INT           NULL,
    [lgota]     VARCHAR (255) NULL,
    [docnom]    VARCHAR (255) NULL,
    [docdate]   DATETIME      NULL,
    [osnovanie] VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Lgota] PRIMARY KEY CLUSTERED ([id] ASC)
);

