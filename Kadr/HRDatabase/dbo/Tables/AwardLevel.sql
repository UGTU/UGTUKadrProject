CREATE TABLE [dbo].[AwardLevel] (
    [ID]         INT          IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (50) NOT NULL,
    [AwardLevel] INT          NULL,
    CONSTRAINT [PK_AwardLevel] PRIMARY KEY CLUSTERED ([ID] ASC)
);

