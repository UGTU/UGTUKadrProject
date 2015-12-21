CREATE TABLE [dbo].[Arch_OK_Step] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [tabn]       INT           NULL,
    [step]       VARCHAR (255) NULL,
    [vidnauk]    VARCHAR (255) NULL,
    [stepdate]   DATETIME      NULL,
    [dissovet]   VARCHAR (255) NULL,
    [diplomser]  VARCHAR (255) NULL,
    [diplomnom]  VARCHAR (255) NULL,
    [diplomdate] DATETIME      NULL,
    [diplomkem]  VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Step] PRIMARY KEY CLUSTERED ([id] ASC)
);

