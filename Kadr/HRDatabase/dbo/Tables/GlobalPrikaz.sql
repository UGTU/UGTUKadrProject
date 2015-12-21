CREATE TABLE [dbo].[GlobalPrikaz] (
    [id]           INT          IDENTITY (1, 1) NOT NULL,
    [PrikazName]   VARCHAR (50) NULL,
    [DateBegin]    DATETIME     NULL,
    [PrikazNumber] VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_GP] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_GlobalPrikaz] UNIQUE NONCLUSTERED ([PrikazName] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Orientation', @value = 0, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'GlobalPrikaz';

