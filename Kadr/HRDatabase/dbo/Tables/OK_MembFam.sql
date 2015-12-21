CREATE TABLE [dbo].[OK_MembFam] (
    [idmembfam]   INT           IDENTITY (1, 1) NOT NULL,
    [membfamname] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_OK_MembFam] PRIMARY KEY CLUSTERED ([idmembfam] ASC),
    CONSTRAINT [IX_OK_MembFam] UNIQUE NONCLUSTERED ([membfamname] ASC)
);

