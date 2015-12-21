CREATE TABLE [ShemaTabel].[Approver] (
    [id]             INT      IDENTITY (1, 1) NOT NULL,
    [DateBegin]      DATETIME NOT NULL,
    [DateEnd]        DATETIME NULL,
    [idApproverType] INT      NOT NULL,
    [idDepartment]   INT      NOT NULL,
    [idEmployee]     INT      NOT NULL,
    CONSTRAINT [ApproverPrimary] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CheckApproverDateBegin] CHECK ([DateBegin]<=[DateEnd] OR [DateEnd] IS NULL),
    CONSTRAINT [ApproverTypeApproverForeign] FOREIGN KEY ([idApproverType]) REFERENCES [ShemaTabel].[ApproverType] ([id]),
    CONSTRAINT [fk_ApproverDep] FOREIGN KEY ([idDepartment]) REFERENCES [dbo].[Dep] ([id]),
    CONSTRAINT [FK_ApproverEmployee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id])
);

