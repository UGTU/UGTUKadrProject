create PROCEDURE [dbo].[AuditLogEvent]
@OperationTypeID int, @ObjectID int, @Description varchar(500)=''
AS
BEGIN
  INSERT INTO Audit_Event(OperationTypeID, ObjectID, Description) VALUES (@OperationTypeID, @ObjectID, @Description)
END
