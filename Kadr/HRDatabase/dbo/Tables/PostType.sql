CREATE TABLE [dbo].[PostType] (
    [id]           INT          IDENTITY (1, 1) NOT NULL,
    [PostTypeName] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_PostType] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_PostType] UNIQUE NONCLUSTERED ([PostTypeName] ASC)
);

