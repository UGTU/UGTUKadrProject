CREATE TABLE [dbo].[FactStaffReplacementReason] (
    [id]                         INT          IDENTITY (1, 1) NOT NULL,
    [ReplacementReasonName]      VARCHAR (50) NOT NULL,
    [ReplacementReasonShortName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ReplacementType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_ReplacementType] UNIQUE NONCLUSTERED ([ReplacementReasonName] ASC)
);

