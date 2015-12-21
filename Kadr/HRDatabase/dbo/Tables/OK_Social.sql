CREATE TABLE [dbo].[OK_Social] (
    [idSocial]       INT      IDENTITY (1, 1) NOT NULL,
    [idEmployee]     INT      NOT NULL,
    [idSocialStatus] INT      NOT NULL,
    [idEducDocument] INT      NULL,
    [DateBegin]      DATETIME NULL,
    [DateEnd]        DATETIME NULL,
    CONSTRAINT [PK_OK_Social] PRIMARY KEY CLUSTERED ([idSocial] ASC),
    CONSTRAINT [FK_OK_Social_EducDocument] FOREIGN KEY ([idEducDocument]) REFERENCES [dbo].[EducDocument] ([id]),
    CONSTRAINT [FK_OK_Social_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OK_Social_OK_SocialStatus] FOREIGN KEY ([idSocialStatus]) REFERENCES [dbo].[OK_SocialStatus] ([idSocialStatus])
);

