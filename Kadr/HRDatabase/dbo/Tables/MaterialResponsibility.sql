CREATE TABLE [dbo].[MaterialResponsibility] (
    [id]   INT            IDENTITY (1, 1) NOT NULL,
    [Sum]  NUMERIC (8, 2) NULL,
    [Perc] NUMERIC (4, 2) NULL,
    CONSTRAINT [PK_MaterialResponsibility] PRIMARY KEY CLUSTERED ([id] ASC)
);

