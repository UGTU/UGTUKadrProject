CREATE TABLE [ShemaTabel].[EmployeeEvent] (
    [idEventSuperType] INT NOT NULL,
    [idFactStaff]      INT NOT NULL,
    CONSTRAINT [ShemaTabelEmployeeEventPrimary] PRIMARY KEY CLUSTERED ([idEventSuperType] ASC),
    CONSTRAINT [EmployeeEventFactStaffForeign] FOREIGN KEY ([idFactStaff]) REFERENCES [dbo].[FactStaff] ([id]) ON DELETE CASCADE,
    CONSTRAINT [EmployeeEventSuperTypeEventForeign] FOREIGN KEY ([idEventSuperType]) REFERENCES [ShemaTabel].[EventSuperType] ([id])
);

