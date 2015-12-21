CREATE TABLE [Shared].[DepartmentData] (
    [idDepartment] INT           NOT NULL,
    [DateBegin]    DATE          NOT NULL,
    [MinistryName] VARCHAR (50)  NULL,
    [DepState]     VARCHAR (500) NULL,
    [DepFullName]  VARCHAR (500) NULL,
    [DepShortName] VARCHAR (50)  NULL,
    [MainAddress]  VARCHAR (300) NULL,
    [Address]      VARCHAR (300) NULL,
    [PhoneNumber]  VARCHAR (50)  NULL,
    CONSTRAINT [PK_DepartmentData] PRIMARY KEY CLUSTERED ([idDepartment] ASC, [DateBegin] ASC),
    CONSTRAINT [FK_DepartmentData_Dep] FOREIGN KEY ([idDepartment]) REFERENCES [dbo].[Dep] ([id])
);

