CREATE TABLE [dbo].[OK_SocialStatus] (
    [idSocialStatus]   INT           IDENTITY (1, 1) NOT NULL,
    [SocialStatusName] VARCHAR (255) NOT NULL,
    [is_old]           BIT           NULL,
    CONSTRAINT [PK_OK_SocialStatus] PRIMARY KEY CLUSTERED ([idSocialStatus] ASC)
);

