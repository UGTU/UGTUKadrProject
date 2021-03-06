﻿CREATE TABLE [dbo].[Arch_OK_Employe] (
    [id]              INT           IDENTITY (1, 1) NOT NULL,
    [arc]             INT           NULL,
    [tabn]            INT           NULL,
    [fio]             VARCHAR (255) NULL,
    [sex]             VARCHAR (255) NULL,
    [sempol]          VARCHAR (255) NULL,
    [grazd]           VARCHAR (255) NULL,
    [birthdate]       DATETIME      NULL,
    [birthplace]      VARCHAR (255) NULL,
    [paspser]         VARCHAR (255) NULL,
    [paspnom]         VARCHAR (255) NULL,
    [paspdate]        DATETIME      NULL,
    [paspkem]         VARCHAR (255) NULL,
    [pensstr]         VARCHAR (255) NULL,
    [inn]             VARCHAR (255) NULL,
    [phone]           VARCHAR (255) NULL,
    [uvolndate]       DATETIME      NULL,
    [uvolnprikazn]    VARCHAR (255) NULL,
    [uvolnprikazdate] DATETIME      NULL,
    [uvolnprichina]   VARCHAR (255) NULL,
    [profosn]         VARCHAR (255) NULL,
    [harakterwork]    VARCHAR (255) NULL,
    [otpuskost]       INT           NULL,
    [periodworkdate]  DATETIME      NULL,
    CONSTRAINT [PK_Arch_OK_Employe] PRIMARY KEY CLUSTERED ([id] ASC)
);

