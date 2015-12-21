CREATE TABLE [dbo].[InkapacityType] (
    [id]                 INT           IDENTITY (1, 1) NOT NULL,
    [NameInkapacityType] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_InkapacityType] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Table_Name]
    ON [dbo].[InkapacityType]([NameInkapacityType] ASC);

