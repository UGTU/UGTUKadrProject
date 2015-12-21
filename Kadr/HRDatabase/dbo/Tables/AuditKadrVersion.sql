CREATE TABLE [dbo].[AuditKadrVersion] (
    [idVersion]   VARCHAR (10)  NOT NULL,
    [VersionDate] DATE          CONSTRAINT [DF_AuditKadrVersion_VersionDate] DEFAULT (getdate()) NOT NULL,
    [Comment]     VARCHAR (MAX) NULL,
    CONSTRAINT [PK_AuditKadrVersion] PRIMARY KEY CLUSTERED ([idVersion] ASC)
);

