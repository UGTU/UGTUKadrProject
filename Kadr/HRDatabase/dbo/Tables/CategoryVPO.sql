CREATE TABLE [dbo].[CategoryVPO] (
    [id]                   INT          IDENTITY (1, 1) NOT NULL,
    [CategoryVPOName]      VARCHAR (50) NOT NULL,
    [CategoryVPOSmallName] VARCHAR (50) NOT NULL,
    [OrderBy]              INT          NULL,
    CONSTRAINT [PK_CategoryVPO] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_Category_1VPO] UNIQUE NONCLUSTERED ([CategoryVPOSmallName] ASC),
    CONSTRAINT [IX_CategoryVPO] UNIQUE NONCLUSTERED ([CategoryVPOName] ASC)
);

