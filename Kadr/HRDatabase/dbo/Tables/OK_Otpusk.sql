CREATE TABLE [dbo].[OK_Otpusk] (
    [idOtpusk]            INT           IDENTITY (1, 1) NOT NULL,
    [idFactStaff]         INT           NULL,
    [idOtpuskVid]         INT           NOT NULL,
    [idOtpuskPrikaz]      INT           NULL,
    [DateBegin]           DATETIME      NULL,
    [DateEnd]             DATETIME      NULL,
    [CountDay]            INT           NULL,
    [CountDayFND]         INT           CONSTRAINT [DF_OK_Otpusk_CountDayFND] DEFAULT ((0)) NOT NULL,
    [OtpPeriodWork]       VARCHAR (255) NULL,
    [idFactStaffPrikaz]   INT           NULL,
    [idSocialFareTransit] INT           NULL,
    CONSTRAINT [PK_OK_Otpusk] PRIMARY KEY CLUSTERED ([idOtpusk] ASC),
    CONSTRAINT [FK_OK_Otpusk_FactStaff] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id]) ON DELETE CASCADE,
    CONSTRAINT [FK_OK_Otpusk_FactStaffPrikaz] FOREIGN KEY ([idFactStaffPrikaz]) REFERENCES [dbo].[Event] ([id]),
    CONSTRAINT [FK_OK_Otpusk_OK_Otpuskvid] FOREIGN KEY ([idOtpuskVid]) REFERENCES [dbo].[OK_Otpuskvid] ([idotpuskvid]),
    CONSTRAINT [FK_OK_Otpusk_Prikaz] FOREIGN KEY ([idOtpuskPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [FK_OK_Otpusk_SocialFareTransit] FOREIGN KEY ([idSocialFareTransit]) REFERENCES [dbo].[SocialFareTransit] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_OK_OtpuskidFactStaff]
    ON [dbo].[OK_Otpusk]([idFactStaff] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_OtpuskidOtpuskVid]
    ON [dbo].[OK_Otpusk]([idOtpuskVid] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_OtpuskidOtpuskPrikaz]
    ON [dbo].[OK_Otpusk]([idOtpuskPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_OtpuskidFactStaffPrikaz]
    ON [dbo].[OK_Otpusk]([idFactStaffPrikaz] ASC);

