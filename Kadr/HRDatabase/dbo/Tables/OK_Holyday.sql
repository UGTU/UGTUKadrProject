CREATE TABLE [dbo].[OK_Holyday] (
    [idholyday]   INT           IDENTITY (1, 1) NOT NULL,
    [holydayname] VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_OK_Holyday] PRIMARY KEY CLUSTERED ([idholyday] ASC)
);

