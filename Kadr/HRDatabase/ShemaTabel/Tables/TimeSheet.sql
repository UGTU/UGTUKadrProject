CREATE TABLE [ShemaTabel].[TimeSheet] (
    [id]              INT              IDENTITY (1, 1) NOT NULL,
    [idDepartment]    INT              NOT NULL,
    [idCreater]       INT              NOT NULL,
    [DateBeginPeriod] DATE             NOT NULL,
    [DateEndPeriod]   DATE             NOT NULL,
    [DateComposition] DATETIME         NOT NULL,
    [idWF]            UNIQUEIDENTIFIER NULL,
    [ApproveStep]     INT              NULL,
    [IsFake]          BIT              DEFAULT ((0)) NOT NULL,
    CONSTRAINT [TablePrimary] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CheckTabelDateBegin] CHECK ([DateBeginPeriod]<=[DateEndPeriod]),
    CONSTRAINT [TabelApproverForeign] FOREIGN KEY ([idCreater]) REFERENCES [ShemaTabel].[Approver] ([id])
);

