CREATE TABLE [dbo].[Arch_OK_Attest] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [tabn]          INT           NULL,
    [attestdate]    DATETIME      NULL,
    [attestresh]    VARCHAR (255) NULL,
    [protokoln]     VARCHAR (255) NULL,
    [protokoldate]  DATETIME      NULL,
    [protokolosnov] VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Attest] PRIMARY KEY CLUSTERED ([id] ASC)
);

