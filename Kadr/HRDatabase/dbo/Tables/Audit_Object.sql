CREATE TABLE [dbo].[Audit_Object] (
    [ObjectID]    INT          NOT NULL,
    [ObjectName]  VARCHAR (50) NOT NULL,
    [ObjectTable] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Audit_Object] PRIMARY KEY CLUSTERED ([ObjectID] ASC)
);

