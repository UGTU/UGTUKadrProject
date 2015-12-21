CREATE TABLE [dbo].[OK_HolyDate] (
    [idholydate] INT           IDENTITY (1, 1) NOT NULL,
    [idholyday]  INT           NOT NULL,
    [holydate]   DATETIME      NOT NULL,
    [lawname]    VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_OK_HolyDate] PRIMARY KEY CLUSTERED ([idholydate] ASC),
    CONSTRAINT [FK_OK_HolyDate_OK_Holyday] FOREIGN KEY ([idholyday]) REFERENCES [dbo].[OK_Holyday] ([idholyday]) ON DELETE CASCADE ON UPDATE CASCADE
);

