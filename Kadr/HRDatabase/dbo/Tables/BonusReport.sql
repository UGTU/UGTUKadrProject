CREATE TABLE [dbo].[BonusReport] (
    [id]                  INT          IDENTITY (1, 1) NOT NULL,
    [ReporName]           VARCHAR (50) NOT NULL,
    [WithManagers]        BIT          NOT NULL,
    [SalaryFirst]         BIT          NOT NULL,
    [DefaultBonusOrder]   BIT          NOT NULL,
    [WithReplacements]    BIT          NOT NULL,
    [SalaryFromCalcStaff] BIT          CONSTRAINT [DF_BonusReport_SalaryFromCalcStaff] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ReportType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_ReportType] UNIQUE NONCLUSTERED ([ReporName] ASC)
);

