CREATE TABLE [dbo].[PKCategory] (
    [id]                     INT           IDENTITY (1, 1) NOT NULL,
    [idPKGroup]              INT           NOT NULL,
    [PKCategoryNumber]       INT           NOT NULL,
    [PKSubCategoryNumber]    INT           NOT NULL,
    [PKComment]              VARCHAR (200) NULL,
    [PKSubSubCategoryNumber] INT           NULL,
    [idSalaryKoeff]          INT           NULL,
    CONSTRAINT [PK_PKCategory] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_PKCategory_PKCategory] FOREIGN KEY ([idPKGroup]) REFERENCES [dbo].[PKGroup] ([id]),
    CONSTRAINT [FK_PKCategory_SalaryKoeff] FOREIGN KEY ([idSalaryKoeff]) REFERENCES [dbo].[SalaryKoeff] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_PKCategory_1]
    ON [dbo].[PKCategory]([idPKGroup] ASC);

