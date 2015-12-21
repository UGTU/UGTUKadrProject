CREATE TABLE [dbo].[OK_OtpuskDopInfo] (
    [idFactStaff]            INT      NOT NULL,
    [idOtpuskPlanDay]        INT      NOT NULL,
    [OtpOstBaseDay]          INT      CONSTRAINT [DF_OK_OtpuskDopInfo_OtpOstBaseDay] DEFAULT ((0)) NOT NULL,
    [OtpOstFNDDay]           INT      CONSTRAINT [DF_OK_OtpuskDopInfo_OtpOstFNDDay] DEFAULT ((0)) NOT NULL,
    [OtpPeriodWorkDateBegin] DATETIME NOT NULL,
    CONSTRAINT [PK_OK_OtpuskDopInfo] PRIMARY KEY CLUSTERED ([idFactStaff] ASC),
    CONSTRAINT [FK_OK_OtpuskDopInfo_FactStaff] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OK_OtpuskDopInfo_OK_OtpuskPlanDay] FOREIGN KEY ([idOtpuskPlanDay]) REFERENCES [dbo].[OK_OtpuskPlanDay] ([idotpuskplanday]) ON DELETE CASCADE ON UPDATE CASCADE
);

