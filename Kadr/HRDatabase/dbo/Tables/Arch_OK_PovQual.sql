CREATE TABLE [dbo].[Arch_OK_PovQual] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [tabn]      INT           NULL,
    [vidpovq]   VARCHAR (255) NULL,
    [povqwhere] VARCHAR (255) NULL,
    [povqplace] VARCHAR (255) NULL,
    [begindate] DATETIME      NULL,
    [enddate]   DATETIME      NULL,
    [dokser]    VARCHAR (255) NULL,
    [doknom]    VARCHAR (255) NULL,
    [dokdate]   DATETIME      NULL,
    [osnovanie] VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_PovQual] PRIMARY KEY CLUSTERED ([id] ASC)
);

