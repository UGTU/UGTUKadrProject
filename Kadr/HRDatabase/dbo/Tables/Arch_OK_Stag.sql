CREATE TABLE [dbo].[Arch_OK_Stag] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [tabn]      INT           NULL,
    [stag]      VARCHAR (255) NULL,
    [countdate] DATETIME      NULL,
    CONSTRAINT [PK_Arch_OK_Stag] PRIMARY KEY CLUSTERED ([id] ASC)
);

