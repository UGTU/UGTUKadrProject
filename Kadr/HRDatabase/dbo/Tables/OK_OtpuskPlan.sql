CREATE TABLE [dbo].[OK_OtpuskPlan] (
    [idFactStaff] INT      NOT NULL,
    [OtpuskYear]  INT      NOT NULL,
    [DateBegin]   DATETIME NOT NULL,
    [DateEnd]     DATETIME NOT NULL,
    [CountDay]    INT      CONSTRAINT [DF_OK_OtpuskPlan_CountDay] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_OK_OtpuskPlan] PRIMARY KEY CLUSTERED ([idFactStaff] ASC, [OtpuskYear] ASC, [DateBegin] ASC),
    CONSTRAINT [FK_OK_OtpuskPlan_FactStaff] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

