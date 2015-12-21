CREATE TABLE [dbo].[Validation] (
    [ID]              INT           IDENTITY (1, 1) NOT NULL,
    [IDEducDocument]  INT           NULL,
    [idEvent]         INT           NOT NULL,
    [IDValidDecision] INT           NULL,
    [Commentary]      VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Attestation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Validation_Educ] FOREIGN KEY ([IDEducDocument]) REFERENCES [dbo].[EducDocument] ([id]),
    CONSTRAINT [FK_Validation_FactStaffPrikaz] FOREIGN KEY ([idEvent]) REFERENCES [dbo].[Event] ([id]),
    CONSTRAINT [FK_Validation_ValidationDecision] FOREIGN KEY ([IDValidDecision]) REFERENCES [dbo].[ValidationDecision] ([ID])
);

