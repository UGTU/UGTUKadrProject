CREATE TABLE [dbo].[AwardType] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_AwardType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

