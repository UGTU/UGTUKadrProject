CREATE TABLE [dbo].[Arch_OK_Nadbavka] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [tabn]           INT           NULL,
    [nadbavka]       VARCHAR (255) NULL,
    [begindate]      DATETIME      NULL,
    [enddate]        DATETIME      NULL,
    [nadbavkasize]   VARCHAR (255) NULL,
    [nadbavkametric] VARCHAR (255) NULL,
    [osnovanie]      VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Nadbavka] PRIMARY KEY CLUSTERED ([id] ASC)
);

