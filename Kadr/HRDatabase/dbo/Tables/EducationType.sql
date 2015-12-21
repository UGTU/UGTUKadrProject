CREATE TABLE [dbo].[EducationType] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [EduTypeName] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_EducationType] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EducationType]
    ON [dbo].[EducationType]([EduTypeName] ASC);

