CREATE TABLE [dbo].[DepartmentHistory] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [idDepartment]        INT           NOT NULL,
    [idManagerDepartment] INT           NULL,
    [idBeginPrikaz]       INT           NOT NULL,
    [DateBegin]           DATETIME      CONSTRAINT [DF_DepartmentHistory_DateBegin] DEFAULT (getdate()) NOT NULL,
    [DepartmentName]      VARCHAR (500) NOT NULL,
    [DepartmentSmallName] VARCHAR (50)  NOT NULL,
    [idRegionType]        INT           NULL,
    [Address]             VARCHAR (500) NULL,
    CONSTRAINT [PK_DepartmentHistory] PRIMARY KEY NONCLUSTERED ([id] ASC),
    CONSTRAINT [CK_DepartmentHistoryidManagerDepartment] CHECK ([idManagerDepartment]<>[idDepartment]),
    CONSTRAINT [FK_DepartmentHistory_Dep] FOREIGN KEY ([idDepartment]) REFERENCES [dbo].[Dep] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_DepartmentHistory_ManagerDep] FOREIGN KEY ([idManagerDepartment]) REFERENCES [dbo].[Dep] ([id]),
    CONSTRAINT [FK_DepartmentHistory_Prikaz] FOREIGN KEY ([idBeginPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [FK_DepartmentHistory_RegionType] FOREIGN KEY ([idRegionType]) REFERENCES [dbo].[RegionType] ([id]),
    CONSTRAINT [IX_DepartmentHistoryUnique] UNIQUE CLUSTERED ([idDepartment] ASC, [DateBegin] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentHistory_idManagerDepartment]
    ON [dbo].[DepartmentHistory]([idManagerDepartment] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_DepartmentHistoryDateBegin]
    ON [dbo].[DepartmentHistory]([DateBegin] ASC);

