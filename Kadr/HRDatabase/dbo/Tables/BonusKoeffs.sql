CREATE TABLE [dbo].[BonusKoeffs] (
    [id]         INT      IDENTITY (1, 1) NOT NULL,
    [SeverKoeff] INT      NOT NULL,
    [RayonKoeff] INT      NOT NULL,
    [NDFLKoeff]  INT      NOT NULL,
    [dateBegin]  DATETIME NOT NULL,
    CONSTRAINT [PK_BonusKoeffs] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CK_BonusKoeffsNDFLKoeff] CHECK ([NDFLKoeff]>=(1) AND [NDFLKoeff]<=(100)),
    CONSTRAINT [CK_BonusKoeffsRayonKoeff] CHECK ([RayonKoeff]>=(1) AND [RayonKoeff]<=(150)),
    CONSTRAINT [CK_BonusKoeffsSeverKoeff] CHECK ([SeverKoeff]>=(1) AND [SeverKoeff]<=(150)),
    CONSTRAINT [IX_BonusKoeffs] UNIQUE NONCLUSTERED ([NDFLKoeff] ASC, [RayonKoeff] ASC, [SeverKoeff] ASC)
);

