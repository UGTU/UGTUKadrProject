CREATE TABLE [dbo].[Arch_OK_Otpusk] (
    [id]                INT           IDENTITY (1, 1) NOT NULL,
    [tabn]              INT           NULL,
    [otpuskvid]         VARCHAR (255) NULL,
    [periodworkdateend] DATETIME      NULL,
    [dayplan]           INT           NULL,
    [dayfact]           INT           NULL,
    [dayost]            INT           NULL,
    [begindate]         DATETIME      NULL,
    [enddate]           DATETIME      NULL,
    [otpuskprikazn]     VARCHAR (255) NULL,
    [otpuskprikazdate]  VARCHAR (255) NULL,
    [fullnamedep]       VARCHAR (255) NULL,
    [prof]              VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Otpusk] PRIMARY KEY CLUSTERED ([id] ASC)
);

