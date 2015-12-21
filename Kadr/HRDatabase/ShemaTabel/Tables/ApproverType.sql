CREATE TABLE [ShemaTabel].[ApproverType] (
    [id]               INT          IDENTITY (1, 1) NOT NULL,
    [ApproverTypeName] VARCHAR (50) NOT NULL,
    [ApproveNumber]    INT          NULL,
    CONSTRAINT [ApproverTypePrimary] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_ApproverType] UNIQUE NONCLUSTERED ([ApproveNumber] ASC),
    CONSTRAINT [SostavitelTypeNameSostavitelTypeUnique] UNIQUE NONCLUSTERED ([ApproverTypeName] ASC)
);

