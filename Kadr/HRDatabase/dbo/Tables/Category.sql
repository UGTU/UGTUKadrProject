CREATE TABLE [dbo].[Category] (
    [id]                INT          IDENTITY (1, 1) NOT NULL,
    [CategoryName]      VARCHAR (50) NOT NULL,
    [CategorySmallName] VARCHAR (50) NOT NULL,
    [OrderBy]           INT          NULL,
    [IsPPS]             BIT          NULL,
    [IsNP]              BIT          DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_Category] UNIQUE NONCLUSTERED ([CategoryName] ASC),
    CONSTRAINT [IX_Category_1] UNIQUE NONCLUSTERED ([CategorySmallName] ASC)
);

