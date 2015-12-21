CREATE TABLE [dbo].[FactStaffMonthHour] (
    [id]          INT             IDENTITY (1, 1) NOT NULL,
    [idFactStaff] INT             NOT NULL,
    [MonthNumber] INT             NOT NULL,
    [HourCount]   NUMERIC (10, 2) NOT NULL,
    [YearNumber]  INT             NOT NULL,
    CONSTRAINT [PK_FactStaffMonthHours] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CK_FactStaffMonthHourHourCount] CHECK ([HourCount]>=(0) AND [HourCount]<=(1000)),
    CONSTRAINT [CK_FactStaffMonthHourMonth] CHECK ([MonthNumber]>=(1) AND [MonthNumber]<=(12)),
    CONSTRAINT [CK_FactStaffMonthHourYear] CHECK ([YearNumber]>(2000) AND [YearNumber]<(2100)),
    CONSTRAINT [FK_FactStaffMonthHours_FactStaff] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id]),
    CONSTRAINT [IX_FactStaffMonthHoursUnique] UNIQUE NONCLUSTERED ([idFactStaff] ASC, [MonthNumber] ASC, [YearNumber] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffMonthHours_MonthNumber]
    ON [dbo].[FactStaffMonthHour]([MonthNumber] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FactStaffMonthHourYearNumber]
    ON [dbo].[FactStaffMonthHour]([YearNumber] ASC);

