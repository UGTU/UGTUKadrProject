CREATE TABLE [dbo].[Audit_Event] (
    [OperationTypeID] INT           NOT NULL,
    [ObjectID]        INT           NOT NULL,
    [AuditDateTime]   DATETIME      CONSTRAINT [DF_Audit_Event_AuditDateTime] DEFAULT (getdate()) NOT NULL,
    [UserName]        VARCHAR (50)  CONSTRAINT [DF_Audit_Event_UserName] DEFAULT (suser_sname()) NOT NULL,
    [Description]     VARCHAR (500) NULL,
    CONSTRAINT [FK_Audit_Event_Audit_Object] FOREIGN KEY ([ObjectID]) REFERENCES [dbo].[Audit_Object] ([ObjectID]),
    CONSTRAINT [FK_Audit_Event_Audit_OperationType] FOREIGN KEY ([OperationTypeID]) REFERENCES [dbo].[Audit_OperationType] ([OperationTypeID])
);

