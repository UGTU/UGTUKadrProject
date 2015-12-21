CREATE TABLE [dbo].[OK_Otpuskvid] (
    [idotpuskvid]      INT           IDENTITY (1, 1) NOT NULL,
    [otpuskvidname]    VARCHAR (255) NOT NULL,
    [idDayStatus]      INT           NULL,
    [isMaternity]      BIT           CONSTRAINT [DF_OK_Otpuskvid_isMaternity] DEFAULT ((0)) NOT NULL,
    [otpTypeShortName] VARCHAR (10)  NULL,
    [isBase]           BIT           CONSTRAINT [DF_OK_Otpuskvid_isBase] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_OK_Otpuskvid] PRIMARY KEY CLUSTERED ([idotpuskvid] ASC),
    CONSTRAINT [FK_OK_Otpuskvid_DayStatus] FOREIGN KEY ([idDayStatus]) REFERENCES [ShemaTabel].[DayStatus] ([id])
);

