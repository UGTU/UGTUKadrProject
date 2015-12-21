CREATE TABLE [dbo].[OK_DopInf] (
    [idDopInf]   INT           IDENTITY (1, 1) NOT NULL,
    [idEmployee] INT           NOT NULL,
    [DopInf]     VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_OK_DopInf] PRIMARY KEY CLUSTERED ([idDopInf] ASC),
    CONSTRAINT [FK_OK_DopInf_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE
);

