CREATE TABLE [dbo].[SalaryKoeff] (
    [id]                     INT            IDENTITY (1, 1) NOT NULL,
    [PKSubSubCategoryNumber] INT            NOT NULL,
    [SalaryKoeffc]           NUMERIC (6, 2) NOT NULL,
    [CategoryPPName]         VARCHAR (150)  NULL,
    CONSTRAINT [PK_SalaryKoeff] PRIMARY KEY CLUSTERED ([id] ASC)
);

