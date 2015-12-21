CREATE TABLE [dbo].[EducDocumentType] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [DocTypeName] VARCHAR (50) NOT NULL,
    [isOld]       BIT          CONSTRAINT [col_isOld_def] DEFAULT ((0)) NULL,
    CONSTRAINT [PK_EducDocumentType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_EducDocumentType] UNIQUE NONCLUSTERED ([DocTypeName] ASC)
);

