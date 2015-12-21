CREATE TABLE [dbo].[OK_EmployeeLang] (
    [idEmployeeLang]  INT IDENTITY (1, 1) NOT NULL,
    [idEmployee]      INT NOT NULL,
    [idLanguage]      INT NOT NULL,
    [goodlevelbit]    BIT CONSTRAINT [DF_EmployeeLang_goodlevelbit] DEFAULT ((0)) NOT NULL,
    [idLanguageLevel] INT NULL,
    [idEducDocument]  INT NULL,
    CONSTRAINT [PK_EmployeeLang] PRIMARY KEY CLUSTERED ([idEmployeeLang] ASC),
    CONSTRAINT [FK_OK_EmployeeLang_EducDocument] FOREIGN KEY ([idEducDocument]) REFERENCES [dbo].[EducDocument] ([id]),
    CONSTRAINT [FK_OK_EmployeeLang_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OK_EmployeeLang_LanguageLevel] FOREIGN KEY ([idLanguageLevel]) REFERENCES [dbo].[LanguageLevel] ([id]),
    CONSTRAINT [FK_OK_EmployeeLang_OK_Language] FOREIGN KEY ([idLanguage]) REFERENCES [dbo].[OK_Language] ([idlanguage])
);


GO
CREATE NONCLUSTERED INDEX [IX_OK_EmployeeLang]
    ON [dbo].[OK_EmployeeLang]([idEducDocument] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_EmployeeLang_1]
    ON [dbo].[OK_EmployeeLang]([idEmployee] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_EmployeeLang_2]
    ON [dbo].[OK_EmployeeLang]([idLanguage] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_EmployeeLang_3]
    ON [dbo].[OK_EmployeeLang]([idLanguageLevel] ASC);

