CREATE TABLE [dbo].[Arch_OK_ProfPodg] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [tabn]      INT           NULL,
    [begindate] DATETIME      NULL,
    [enddate]   DATETIME      NULL,
    [doknom]    VARCHAR (255) NULL,
    [dokdate]   DATETIME      NULL,
    [prof]      VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_ProfPodg] PRIMARY KEY CLUSTERED ([id] ASC)
);

