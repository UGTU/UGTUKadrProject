CREATE TABLE [dbo].[OK_Adress] (
    [idAdress]   INT           IDENTITY (1, 1) NOT NULL,
    [idEmployee] INT           NOT NULL,
    [Adress]     VARCHAR (255) NOT NULL,
    [DateReg]    DATETIME      CONSTRAINT [DF_OK_Adress_DateReg] DEFAULT ((0)) NULL,
    [RegBit]     BIT           CONSTRAINT [DF_OK_Adress_RegBit] DEFAULT ((0)) NOT NULL,
    [DateEnd]    DATE          NULL,
    CONSTRAINT [PK_OK_Adress] PRIMARY KEY CLUSTERED ([idAdress] ASC),
    CONSTRAINT [FK_OK_Adress_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

