CREATE TABLE [dbo].[WorkType] (
    [id]                INT          IDENTITY (1, 1) NOT NULL,
    [TypeWorkName]      VARCHAR (50) NOT NULL,
    [TypeWorkShortName] VARCHAR (50) NULL,
    [IsReplacement]     BIT          CONSTRAINT [DF_WorkType_IsReplacement] DEFAULT ((0)) NOT NULL,
    [IsMain]            BIT          CONSTRAINT [DF_WorkType_IsMain] DEFAULT ((0)) NOT NULL,
    [idWorkSuperType]   INT          NULL,
    CONSTRAINT [PK_TypeWork] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_WorkType_WorkSuperType] FOREIGN KEY ([idWorkSuperType]) REFERENCES [dbo].[WorkSuperType] ([id]),
    CONSTRAINT [IX_TypeWork] UNIQUE NONCLUSTERED ([TypeWorkName] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_WorkTypeidWorkSuperType]
    ON [dbo].[WorkType]([idWorkSuperType] ASC);

