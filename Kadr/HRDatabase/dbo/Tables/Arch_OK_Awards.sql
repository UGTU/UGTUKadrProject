CREATE TABLE [dbo].[Arch_OK_Awards] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [tabn]      INT           NULL,
    [awardname] VARCHAR (255) NULL,
    [dok]       VARCHAR (255) NULL,
    [doknom]    VARCHAR (255) NULL,
    [dokdate]   DATETIME      NULL,
    CONSTRAINT [PK_Arch_OK_Awards] PRIMARY KEY CLUSTERED ([id] ASC)
);

