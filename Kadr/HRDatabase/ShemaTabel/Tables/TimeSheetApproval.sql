CREATE TABLE [ShemaTabel].[TimeSheetApproval] (
    [id]           INT            IDENTITY (1, 1) NOT NULL,
    [idApprover]   INT            NOT NULL,
    [idTimeSheet]  INT            NOT NULL,
    [ApprovalDate] DATETIME       NOT NULL,
    [Result]       BIT            NOT NULL,
    [Comment]      VARCHAR (1000) NULL,
    CONSTRAINT [PK_TimeSheetApproval] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_TimeSheetApproval_Approver] FOREIGN KEY ([idApprover]) REFERENCES [ShemaTabel].[Approver] ([id]),
    CONSTRAINT [FK_TimeSheetApproval_TimeSheet] FOREIGN KEY ([idTimeSheet]) REFERENCES [ShemaTabel].[TimeSheet] ([id])
);

