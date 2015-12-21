CREATE TABLE [dbo].[SocialFareTransit] (
    [id]         INT  IDENTITY (1, 1) NOT NULL,
    [DateBegin]  DATE NOT NULL,
    [DateEnd]    DATE NOT NULL,
    [idEmployee] INT  NOT NULL,
    [idPrikaz]   INT  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_SocialFareTransit_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]),
    CONSTRAINT [FK_SocialFareTransit_Prikaz] FOREIGN KEY ([idPrikaz]) REFERENCES [dbo].[Prikaz] ([id]),
    CONSTRAINT [IX_SocialFareTransit_idEmployee] UNIQUE NONCLUSTERED ([idEmployee] ASC, [DateBegin] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_SocialFareTransit_prikaz]
    ON [dbo].[SocialFareTransit]([idPrikaz] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SocialFareTransitDateBegin]
    ON [dbo].[SocialFareTransit]([DateBegin] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SocialFareTransit_DateEnd]
    ON [dbo].[SocialFareTransit]([DateEnd] ASC);

