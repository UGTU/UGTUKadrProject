CREATE TABLE [dbo].[AuditISStaffVersion] (
    [id]          INT  IDENTITY (1, 1) NOT NULL,
    [VersionDate] DATE CONSTRAINT [DF_AuditISStaffVersion_VersionDate] DEFAULT (getdate()) NOT NULL,
    [Comment]     TEXT NULL,
    CONSTRAINT [PK_AuditISStaffVersion] PRIMARY KEY CLUSTERED ([id] ASC)
);

