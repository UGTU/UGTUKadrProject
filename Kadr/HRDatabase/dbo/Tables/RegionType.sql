CREATE TABLE [dbo].[RegionType] (
    [id]                  INT           IDENTITY (1, 1) NOT NULL,
    [RegionTypeName]      VARCHAR (250) NOT NULL,
    [RegionTypeSmallName] VARCHAR (12)  NOT NULL,
    CONSTRAINT [PK__RegionTy__3213E83FC5281071] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [UQ__RegionTy__6D09DAB58D60ADA7] UNIQUE NONCLUSTERED ([RegionTypeName] ASC)
);

