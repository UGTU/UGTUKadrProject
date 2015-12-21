CREATE TABLE [dbo].[DopEducType] (
    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    [DopEducName]        VARCHAR (500) NOT NULL,
    [Duration]           VARCHAR (50)  NULL,
    [idEducDocumentType] INT           NULL,
    CONSTRAINT [PK_OK_DopEduc] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_OK_DopEduc_EducDocumentType] FOREIGN KEY ([idEducDocumentType]) REFERENCES [dbo].[EducDocumentType] ([id])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_OK_DopEduc]
    ON [dbo].[DopEducType]([DopEducName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_DopEduc_1]
    ON [dbo].[DopEducType]([idEducDocumentType] ASC);

