CREATE TABLE [dbo].[OK_phone] (
    [idphone]    INT           IDENTITY (1, 1) NOT NULL,
    [idEmployee] INT           NOT NULL,
    [phone]      VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_OK_phone] PRIMARY KEY CLUSTERED ([idphone] ASC),
    CONSTRAINT [FK_OK_phone_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

