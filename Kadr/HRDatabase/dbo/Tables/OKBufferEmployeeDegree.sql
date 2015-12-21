CREATE TABLE [dbo].[OKBufferEmployeeDegree] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [itab_n]         INT           NULL,
    [degreeDate]     DATETIME      NULL,
    [DissertCouncil] VARCHAR (200) NULL,
    [dokSer]         VARCHAR (100) NULL,
    [dokNum]         VARCHAR (100) NULL,
    [diplDate]       DATETIME      NULL,
    [diplWhere]      VARCHAR (200) NULL,
    [idDegree]       INT           NOT NULL,
    [idScienceType]  INT           NOT NULL,
    CONSTRAINT [PK_OKBufferEmployeeDegree] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_OKBufferEmployeeDegree_Degree] FOREIGN KEY ([idDegree]) REFERENCES [dbo].[Degree] ([id]),
    CONSTRAINT [FK_OKBufferEmployeeDegree_ScienceType] FOREIGN KEY ([idScienceType]) REFERENCES [dbo].[ScienceType] ([id]),
    CONSTRAINT [IX_OKBufferEmployeeDegree_1] UNIQUE NONCLUSTERED ([itab_n] ASC, [idDegree] ASC, [idScienceType] ASC)
);

