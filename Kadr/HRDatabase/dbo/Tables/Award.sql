CREATE TABLE [dbo].[Award] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            VARCHAR (100)  NULL,
    [IDEmployee]      INT            NOT NULL,
    [IDEducDocument]  INT            NOT NULL,
    [IDAwardType]     INT            NULL,
    [idEvent]         INT            NULL,
    [IDAwardLevel]    INT            NULL,
    [Organization]    NVARCHAR (100) NULL,
    [IDGovDepartment] INT            NULL,
    CONSTRAINT [PK_Award] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Award_AwardLevel] FOREIGN KEY ([IDAwardLevel]) REFERENCES [dbo].[AwardLevel] ([ID]),
    CONSTRAINT [FK_Award_AwardType] FOREIGN KEY ([IDAwardType]) REFERENCES [dbo].[AwardType] ([ID]),
    CONSTRAINT [FK_Award_EducDocument] FOREIGN KEY ([IDEducDocument]) REFERENCES [dbo].[EducDocument] ([id]),
    CONSTRAINT [FK_Award_Employee] FOREIGN KEY ([IDEmployee]) REFERENCES [dbo].[Employee] ([id]),
    CONSTRAINT [FK_Award_Event] FOREIGN KEY ([idEvent]) REFERENCES [dbo].[Event] ([id]),
    CONSTRAINT [FK_Award_GovDepartment] FOREIGN KEY ([IDGovDepartment]) REFERENCES [dbo].[GovDepartment] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Award_Level]
    ON [dbo].[Award]([IDAwardLevel] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Award_Type]
    ON [dbo].[Award]([IDAwardType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Award_Document]
    ON [dbo].[Award]([IDEducDocument] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Award_Employee]
    ON [dbo].[Award]([IDEmployee] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Award_Event]
    ON [dbo].[Award]([idEvent] ASC);

