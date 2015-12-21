CREATE TABLE [dbo].[OK_Inkapacity] (
    [idInkapacity]     INT          IDENTITY (1, 1) NOT NULL,
    [NInkapacity]      VARCHAR (50) NULL,
    [DateBegin]        DATETIME     NOT NULL,
    [DateEnd]          DATETIME     NULL,
    [idEmployee]       INT          NULL,
    [idEducDocument]   INT          NULL,
    [IsFinished]       BIT          CONSTRAINT [DF_OK_Inkapacity_IsFinished] DEFAULT ((1)) NULL,
    [idInkapacityType] INT          NULL,
    CONSTRAINT [PK_OK_Inkapacity] PRIMARY KEY CLUSTERED ([idInkapacity] ASC),
    CONSTRAINT [FK_OK_Inkapacity_EducDocument] FOREIGN KEY ([idEducDocument]) REFERENCES [dbo].[EducDocument] ([id]),
    CONSTRAINT [FK_OK_Inkapacity_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_OK_Inkapacity_InkapacityType] FOREIGN KEY ([idInkapacityType]) REFERENCES [dbo].[InkapacityType] ([id]),
    CONSTRAINT [U_OK_Inkapacity] UNIQUE NONCLUSTERED ([idInkapacity] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_OK_Inkapacity_Type]
    ON [dbo].[OK_Inkapacity]([idInkapacityType] ASC);

