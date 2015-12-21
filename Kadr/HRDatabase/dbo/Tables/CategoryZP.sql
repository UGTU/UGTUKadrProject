CREATE TABLE [dbo].[CategoryZP] (
    [id]                  INT          IDENTITY (1, 1) NOT NULL,
    [CategoryZPName]      VARCHAR (50) NOT NULL,
    [CategoryZPSmallName] VARCHAR (50) NOT NULL,
    [OrderBy]             INT          NULL,
    CONSTRAINT [PK_CategoryZP] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_Category_1ZP] UNIQUE NONCLUSTERED ([CategoryZPSmallName] ASC),
    CONSTRAINT [IX_CategoryZP] UNIQUE NONCLUSTERED ([CategoryZPName] ASC)
);

