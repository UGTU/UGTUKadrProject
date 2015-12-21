CREATE TABLE [dbo].[BonusType] (
    [id]                       INT          IDENTITY (1, 1) NOT NULL,
    [BonusTypeName]            VARCHAR (50) NOT NULL,
    [BonusTypeShortName]       VARCHAR (50) NOT NULL,
    [idBonusSuperType]         INT          NOT NULL,
    [idBonusMeasure]           INT          NULL,
    [HasEnvironmentBonus]      BIT          CONSTRAINT [DF_BonusType_HasEnvironmentBonus] DEFAULT ((1)) NOT NULL,
    [IsStaffRateable]          BIT          CONSTRAINT [DF_BonusTypeIsStaffRateable] DEFAULT ((0)) NOT NULL,
    [idDefaultFinancingSource] INT          NULL,
    [IsCalcStaffRateable]      BIT          CONSTRAINT [DF_BonusType_IsCalcStaffRateable] DEFAULT ((0)) NOT NULL,
    [DateEnd]                  DATE         NULL,
    CONSTRAINT [PK_TypeBonus] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_BonusType_BonusMeasure] FOREIGN KEY ([idBonusMeasure]) REFERENCES [dbo].[BonusMeasure] ([id]),
    CONSTRAINT [FK_BonusType_BonusSuperType] FOREIGN KEY ([idBonusSuperType]) REFERENCES [dbo].[BonusSuperType] ([id]),
    CONSTRAINT [FK_BonusType_FinancingSource] FOREIGN KEY ([idDefaultFinancingSource]) REFERENCES [dbo].[FinancingSource] ([id]),
    CONSTRAINT [IX_TypeBonus] UNIQUE NONCLUSTERED ([BonusTypeName] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_BonusTypeidBonusSuperType]
    ON [dbo].[BonusType]([idBonusSuperType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_BonusTypeidBonusMeasure]
    ON [dbo].[BonusType]([idBonusMeasure] ASC);

