CREATE TABLE [dbo].[OK_DataChange] (
    [idDataChange] INT           IDENTITY (1, 1) NOT NULL,
    [DataName]     VARCHAR (255) NOT NULL,
    [OldValue]     VARCHAR (255) NOT NULL,
    [DateChange]   DATETIME      NOT NULL,
    [idEmployee]   INT           NOT NULL,
    CONSTRAINT [PK_DataChange] PRIMARY KEY CLUSTERED ([idDataChange] ASC),
    CONSTRAINT [FK_OK_DataChange_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

