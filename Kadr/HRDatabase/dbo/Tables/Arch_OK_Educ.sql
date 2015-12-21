CREATE TABLE [dbo].[Arch_OK_Educ] (
    [id]           INT           IDENTITY (1, 1) NOT NULL,
    [tabn]         INT           NULL,
    [educ]         VARCHAR (255) NULL,
    [educwhere]    VARCHAR (255) NULL,
    [educwhen]     VARCHAR (255) NULL,
    [diplomser]    VARCHAR (255) NULL,
    [diplomn]      VARCHAR (255) NULL,
    [diplomkvalif] VARCHAR (255) NULL,
    [diplomspec]   VARCHAR (255) NULL,
    CONSTRAINT [PK_Arch_OK_Educ] PRIMARY KEY CLUSTERED ([id] ASC)
);

