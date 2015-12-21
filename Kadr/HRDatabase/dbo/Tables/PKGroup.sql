CREATE TABLE [dbo].[PKGroup] (
    [id]          INT          IDENTITY (1, 1) NOT NULL,
    [GroupNumber] INT          NOT NULL,
    [GroupName]   VARCHAR (50) NULL,
    CONSTRAINT [PK_PKGroup] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_PKGroup] UNIQUE NONCLUSTERED ([GroupNumber] ASC, [GroupName] ASC)
);

