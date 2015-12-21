CREATE TABLE [dbo].[Arch_OK_Live] (
    [id]      INT           IDENTITY (1, 1) NOT NULL,
    [tabn]    INT           NULL,
    [adres]   VARCHAR (255) NULL,
    [regdate] DATETIME      NULL,
    CONSTRAINT [PK_Arch_OK_Live] PRIMARY KEY CLUSTERED ([id] ASC)
);

