CREATE TABLE [dbo].[GovDepartment] (
    [id]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_GovDepartment] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [U_Name] UNIQUE NONCLUSTERED ([Name] ASC)
);

