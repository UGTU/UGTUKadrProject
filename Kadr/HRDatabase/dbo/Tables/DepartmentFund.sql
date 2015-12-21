CREATE TABLE [dbo].[DepartmentFund] (
    [idDepartment] INT             NOT NULL,
    [DateBegin]    DATE            NOT NULL,
    [PlanFundSum]  DECIMAL (18, 2) NOT NULL,
    [FactFundSum]  DECIMAL (18, 2) NOT NULL,
    [ExtraordSum]  DECIMAL (18, 2) NOT NULL,
    CONSTRAINT [PK_DepartmentFund] PRIMARY KEY CLUSTERED ([idDepartment] ASC, [DateBegin] ASC),
    CONSTRAINT [FK_DepartmentFund_Dep] FOREIGN KEY ([idDepartment]) REFERENCES [dbo].[Dep] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentFund]
    ON [dbo].[DepartmentFund]([DateBegin] ASC);

