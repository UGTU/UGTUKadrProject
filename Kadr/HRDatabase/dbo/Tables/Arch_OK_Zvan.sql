CREATE TABLE [dbo].[Arch_OK_Zvan] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [tabn]      INT           NULL,
    [zvan]      VARCHAR (255) NULL,
    [zvandate]  DATETIME      NULL,
    [zvanwhere] VARCHAR (255) NULL,
    [zvanspec]  VARCHAR (255) NULL,
    [zvanshifr] VARCHAR (255) NULL,
    [attestser] VARCHAR (255) NULL,
    [attestnom] VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Zvan] PRIMARY KEY CLUSTERED ([id] ASC)
);

