GO

CREATE TABLE [dbo].[Audit_Object](
	[ObjectID] [int] NOT NULL,
	[ObjectName] [varchar](50) NOT NULL,
	[ObjectTable] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Audit_Object] PRIMARY KEY CLUSTERED 
(
	[ObjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


GO

CREATE TABLE [dbo].[Audit_OperationType](
	[OperationTypeID] [int] NOT NULL,
	[OperationName] [varchar](50) NOT NULL,
	[OperationSQL] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Audit_OperationType] PRIMARY KEY CLUSTERED 
(
	[OperationTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



GO

CREATE TABLE [dbo].[Audit_Event](
	[OperationTypeID] [int] NOT NULL,
	[ObjectID] [int] NOT NULL,
	[AuditDateTime] [datetime] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Description] [varchar](500) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Audit_Event]  WITH NOCHECK ADD  CONSTRAINT [FK_Audit_Event_Audit_Object] FOREIGN KEY([ObjectID])
REFERENCES [dbo].[Audit_Object] ([ObjectID])
GO

ALTER TABLE [dbo].[Audit_Event] CHECK CONSTRAINT [FK_Audit_Event_Audit_Object]
GO

ALTER TABLE [dbo].[Audit_Event]  WITH CHECK ADD  CONSTRAINT [FK_Audit_Event_Audit_OperationType] FOREIGN KEY([OperationTypeID])
REFERENCES [dbo].[Audit_OperationType] ([OperationTypeID])
GO

ALTER TABLE [dbo].[Audit_Event] CHECK CONSTRAINT [FK_Audit_Event_Audit_OperationType]
GO

ALTER TABLE [dbo].[Audit_Event] ADD  CONSTRAINT [DF_Audit_Event_AuditDateTime]  DEFAULT (getdate()) FOR [AuditDateTime]
GO

ALTER TABLE [dbo].[Audit_Event] ADD  CONSTRAINT [DF_Audit_Event_UserName]  DEFAULT (suser_sname()) FOR [UserName]
GO




GO
create PROCEDURE [dbo].[AuditLogEvent]
@OperationTypeID int, @ObjectID int, @Description varchar(500)=''
AS
BEGIN
  INSERT INTO Audit_Event(OperationTypeID, ObjectID, Description) VALUES (@OperationTypeID, @ObjectID, @Description)
END



GO

GO

go

insert into Audit_OperationType
select * from UGTU.dbo.Audit_OperationType

