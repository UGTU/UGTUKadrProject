CREATE TABLE [dbo].[Arch_OK_Work] (
    [id]               INT            IDENTITY (1, 1) NOT NULL,
    [tabn]             INT            NULL,
    [fullnamedep]      VARCHAR (255)  NULL,
    [prof]             VARCHAR (255)  NULL,
    [kateg]            VARCHAR (255)  NULL,
    [kvalif]           VARCHAR (255)  NULL,
    [vidwork]          VARCHAR (255)  NULL,
    [stavka]           NUMERIC (5, 2) NULL,
    [ets]              INT            NULL,
    [dogovornomer]     VARCHAR (255)  NULL,
    [dogovordate]      DATETIME       NULL,
    [dogovorbegindate] DATETIME       NULL,
    [dogovorenddate]   DATETIME       NULL,
    [perevodprichina]  VARCHAR (255)  NULL,
    [perevodvid]       VARCHAR (255)  NULL,
    [perevoddate]      DATETIME       NULL,
    [prikazn]          VARCHAR (255)  NULL,
    [prikazdate]       DATETIME       NULL,
    CONSTRAINT [PK_Arch_OK_Work] PRIMARY KEY CLUSTERED ([id] ASC)
);

