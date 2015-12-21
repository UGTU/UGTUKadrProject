CREATE TABLE [dbo].[DepartmentType] (
    [id]                 INT          IDENTITY (1, 1) NOT NULL,
    [DepartmentTypeName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_DepartmentType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_DepartmentType] UNIQUE NONCLUSTERED ([DepartmentTypeName] ASC)
);

