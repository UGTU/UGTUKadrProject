CREATE TABLE [dbo].[OK_Educ] (
    [idEducDocument]  INT           NOT NULL,
    [idEmployee]      INT           NOT NULL,
    [EducWhere]       VARCHAR (255) NULL,
    [EducWhen]        INT           NULL,
    [Spec]            VARCHAR (255) NULL,
    [Kvalif]          VARCHAR (255) NULL,
    [idEducationType] INT           NULL,
    CONSTRAINT [PK_OK_Educ] PRIMARY KEY CLUSTERED ([idEducDocument] ASC),
    CONSTRAINT [FK_OK_Educ_EducDocument] FOREIGN KEY ([idEducDocument]) REFERENCES [dbo].[EducDocument] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OK_Educ_EducDocumentType] FOREIGN KEY ([idEducationType]) REFERENCES [dbo].[EducationType] ([id]),
    CONSTRAINT [FK_OK_Educ_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OK_Educ]
    ON [dbo].[OK_Educ]([idEducationType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_Educ_1]
    ON [dbo].[OK_Educ]([idEmployee] ASC);

