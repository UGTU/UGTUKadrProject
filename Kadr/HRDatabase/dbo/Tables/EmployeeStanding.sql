CREATE TABLE [dbo].[EmployeeStanding] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [DateBegin]      DATE          NOT NULL,
    [DateEnd]        DATE          NOT NULL,
    [WorkPlace]      VARCHAR (MAX) NULL,
    [Post]           VARCHAR (250) NULL,
    [idRegionType]   INT           NOT NULL,
    [idStandingType] INT           NOT NULL,
    [idEmployee]     INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_EmployeeStanding_Employee] FOREIGN KEY ([idEmployee]) REFERENCES [dbo].[Employee] ([id]),
    CONSTRAINT [FK_EmployeeStanding_RegionType] FOREIGN KEY ([idRegionType]) REFERENCES [dbo].[RegionType] ([id]),
    CONSTRAINT [FK_EmployeeStanding_StandingType] FOREIGN KEY ([idStandingType]) REFERENCES [dbo].[StandingType] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeStanding_idRegionType]
    ON [dbo].[EmployeeStanding]([idRegionType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeStanding_idStandingType]
    ON [dbo].[EmployeeStanding]([idStandingType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeStanding_idEmployee]
    ON [dbo].[EmployeeStanding]([idEmployee] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EmployeeStanding_DateBegin]
    ON [dbo].[EmployeeStanding]([DateBegin] ASC);

