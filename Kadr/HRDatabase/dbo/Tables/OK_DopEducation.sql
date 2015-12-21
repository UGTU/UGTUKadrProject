CREATE TABLE [dbo].[OK_DopEducation] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [idDopEducType]  INT           NOT NULL,
    [DateBegin]      DATE          NULL,
    [DateEnd]        DATE          NULL,
    [idEducDocument] INT           NOT NULL,
    [idEvent]        INT           NULL,
    [idEmployee]     INT           NOT NULL,
    [Spec]           VARCHAR (900) NULL,
    [Kvalif]         VARCHAR (900) NULL,
    [AuditHour]      INT           NULL,
    CONSTRAINT [PK_OK_DopEducEmployee] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_OK_DopEducation_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]),
    CONSTRAINT [FK_OK_DopEducEmployee_EducDocument] FOREIGN KEY ([idEducDocument]) REFERENCES [dbo].[EducDocument] ([id]),
    CONSTRAINT [FK_OK_DopEducEmployee_Event] FOREIGN KEY ([idEvent]) REFERENCES [dbo].[Event] ([id]),
    CONSTRAINT [FK_OK_DopEducEmployee_OK_DopEduc] FOREIGN KEY ([idDopEducType]) REFERENCES [dbo].[DopEducType] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_OK_DopEducEmployee]
    ON [dbo].[OK_DopEducation]([idDopEducType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_DopEducEmployee_1]
    ON [dbo].[OK_DopEducation]([idEducDocument] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_DopEducEmployee_2]
    ON [dbo].[OK_DopEducation]([idEvent] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_OK_DopEducation]
    ON [dbo].[OK_DopEducation]([idEmployee] ASC);

