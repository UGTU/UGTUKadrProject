CREATE TABLE [ShemaTabel].[ApperoveDepartment] (
    [idApprover]   INT NOT NULL,
    [idDepartment] INT NOT NULL,
    CONSTRAINT [PK_ApperoveDepartment] PRIMARY KEY CLUSTERED ([idApprover] ASC, [idDepartment] ASC),
    CONSTRAINT [thisApproverFK] FOREIGN KEY ([idApprover]) REFERENCES [ShemaTabel].[Approver] ([id])
);

