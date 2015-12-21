CREATE TABLE [dbo].[Organisation] (
    [id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (900) NOT NULL,
    CONSTRAINT [PK_Organisation] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Organisation]
    ON [dbo].[Organisation]([Name] ASC);

