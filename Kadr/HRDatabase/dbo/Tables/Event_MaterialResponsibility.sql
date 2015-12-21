CREATE TABLE [dbo].[Event_MaterialResponsibility] (
    [idEvent]                  INT NOT NULL,
    [idMaterialResponsibility] INT NOT NULL,
    CONSTRAINT [PK_Event_MaterialResponsibility] PRIMARY KEY CLUSTERED ([idEvent] ASC),
    CONSTRAINT [FK_Event_MaterialResponsibility_Event] FOREIGN KEY ([idEvent]) REFERENCES [dbo].[Event] ([id]),
    CONSTRAINT [FK_Event_MaterialResponsibility_MaterialResponsibility] FOREIGN KEY ([idMaterialResponsibility]) REFERENCES [dbo].[MaterialResponsibility] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Table_Event]
    ON [dbo].[Event_MaterialResponsibility]([idEvent] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Table_Material]
    ON [dbo].[Event_MaterialResponsibility]([idMaterialResponsibility] ASC);

