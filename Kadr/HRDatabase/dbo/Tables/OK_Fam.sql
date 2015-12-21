CREATE TABLE [dbo].[OK_Fam] (
    [idfam]      INT           IDENTITY (1, 1) NOT NULL,
    [idmembfam]  INT           NOT NULL,
    [idemployee] INT           NOT NULL,
    [fiomembfam] VARCHAR (255) NULL,
    [godbirth]   VARCHAR (10)  NULL,
    [BirthDate]  DATE          NULL,
    [BirthYear]  INT           NULL,
    CONSTRAINT [PK_OK_Fam] PRIMARY KEY CLUSTERED ([idfam] ASC),
    CONSTRAINT [FK_OK_Fam_Employee] FOREIGN KEY ([idemployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OK_Fam_OK_MembFam] FOREIGN KEY ([idmembfam]) REFERENCES [dbo].[OK_MembFam] ([idmembfam]) ON DELETE CASCADE ON UPDATE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_OK_Fam]
    ON [dbo].[OK_Fam]([idemployee] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_Fam_1]
    ON [dbo].[OK_Fam]([idmembfam] ASC);

