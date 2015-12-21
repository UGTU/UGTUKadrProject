CREATE TABLE [dbo].[DepartmentTimeNorm] (
    [id]                INT             IDENTITY (1, 1) NOT NULL,
    [idDepartment]      INT             NOT NULL,
    [idFinancingSource] INT             NOT NULL,
    [NormHoursCount]    NUMERIC (18, 2) NOT NULL,
    [DateBegin]         DATETIME        NOT NULL,
    CONSTRAINT [PK_DepartmentTimeNorm] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [FK_DepartmentTimeNorm_Dep] FOREIGN KEY ([idDepartment]) REFERENCES [dbo].[Dep] ([id]),
    CONSTRAINT [FK_DepartmentTimeNorm_FinancingSource] FOREIGN KEY ([idFinancingSource]) REFERENCES [dbo].[FinancingSource] ([id]),
    CONSTRAINT [IX_DepartmentTimeNorm] UNIQUE CLUSTERED ([idDepartment] ASC, [idFinancingSource] ASC, [DateBegin] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentTimeNormFinS]
    ON [dbo].[DepartmentTimeNorm]([idFinancingSource] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentTimeNorm_DateBegin]
    ON [dbo].[DepartmentTimeNorm]([DateBegin] ASC);

