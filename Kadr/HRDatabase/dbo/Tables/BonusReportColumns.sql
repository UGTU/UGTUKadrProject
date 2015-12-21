CREATE TABLE [dbo].[BonusReportColumns] (
    [id]                 INT IDENTITY (1, 1) NOT NULL,
    [idBonusReport]      INT NOT NULL,
    [idBonusType]        INT NOT NULL,
    [BonusOrderNumber]   INT NOT NULL,
    [OnlyExtrabudgetary] BIT CONSTRAINT [DF_BonusReportColumns_OnlyExtrabudgetary] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_BonusReportColumns] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_BonusReportColumns_BonusReport] FOREIGN KEY ([idBonusReport]) REFERENCES [dbo].[BonusReport] ([id]),
    CONSTRAINT [FK_BonusReportColumns_BonusType] FOREIGN KEY ([idBonusType]) REFERENCES [dbo].[BonusType] ([id]),
    CONSTRAINT [IX_BonusReportColumns] UNIQUE NONCLUSTERED ([idBonusReport] ASC, [idBonusType] ASC)
);

