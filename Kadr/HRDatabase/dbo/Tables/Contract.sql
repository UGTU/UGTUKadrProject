CREATE TABLE [dbo].[Contract] (
    [id]                 INT          IDENTITY (1, 1) NOT NULL,
    [ContractName]       VARCHAR (50) NOT NULL,
    [DateContract]       DATE         NULL,
    [DateBegin]          DATE         NULL,
    [DateEnd]            DATE         NULL,
    [idMainContract]     INT          NULL,
    [idPrikazType]       INT          NULL,
    [idFactStaffHistory] INT          NULL,
    CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Contract_Contract] FOREIGN KEY ([idMainContract]) REFERENCES [dbo].[Contract] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Contract]
    ON [dbo].[Contract]([DateContract] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Contract_1]
    ON [dbo].[Contract]([ContractName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Contract_idMainContract]
    ON [dbo].[Contract]([idMainContract] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Contract_2]
    ON [dbo].[Contract]([idPrikazType] ASC);

