CREATE TABLE [dbo].[Arch_OK_DopSved] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [tabn]    INT           NULL,
    [dopsved] VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_DopSved] PRIMARY KEY CLUSTERED ([id] ASC)
);

