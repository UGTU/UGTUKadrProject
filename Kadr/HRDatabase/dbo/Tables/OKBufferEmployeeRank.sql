CREATE TABLE [dbo].[OKBufferEmployeeRank] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [idRank]    INT           NULL,
    [dokSer]    VARCHAR (100) NULL,
    [dokNum]    VARCHAR (100) NULL,
    [rankDate]  DATETIME      NULL,
    [rankWhere] VARCHAR (200) NULL,
    [itab_n]    INT           NOT NULL,
    CONSTRAINT [PK_OKBufferEmployeeRank] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_OKBufferEmployeeRank] UNIQUE NONCLUSTERED ([itab_n] ASC, [idRank] ASC)
);

