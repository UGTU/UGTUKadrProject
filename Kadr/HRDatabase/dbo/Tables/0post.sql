CREATE TABLE [dbo].[0post] (
    [id]   FLOAT (53)     NULL,
    [DOL]  NVARCHAR (255) NULL,
    [PRIM] NVARCHAR (255) NULL,
    [F4]   FLOAT (53)     NULL
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Orientation', @value = 0, @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'0post';

