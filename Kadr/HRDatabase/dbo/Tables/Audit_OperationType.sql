CREATE TABLE [dbo].[Audit_OperationType] (
    [OperationTypeID] INT          NOT NULL,
    [OperationName]   VARCHAR (50) NOT NULL,
    [OperationSQL]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Audit_OperationType] PRIMARY KEY CLUSTERED ([OperationTypeID] ASC)
);

