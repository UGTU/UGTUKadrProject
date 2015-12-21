CREATE TABLE [dbo].[FinancingSource] (
    [id]                  INT          IDENTITY (1, 1) NOT NULL,
    [FinancingSourceName] VARCHAR (50) NOT NULL,
    [OrderBy]             INT          NULL,
    CONSTRAINT [PK_FinancingSource] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_FinancingSource] UNIQUE NONCLUSTERED ([FinancingSourceName] ASC)
);

