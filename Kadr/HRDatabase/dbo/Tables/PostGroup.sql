CREATE TABLE [dbo].[PostGroup] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [GroupName]      VARCHAR (500) NOT NULL,
    [GroupSmallName] VARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_PostGroup] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_Table_GroupName] UNIQUE NONCLUSTERED ([GroupName] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Table_GroupSmallName]
    ON [dbo].[PostGroup]([GroupSmallName] ASC);

