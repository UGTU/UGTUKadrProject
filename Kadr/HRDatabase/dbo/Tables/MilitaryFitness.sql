CREATE TABLE [dbo].[MilitaryFitness] (
    [id]          INT           IDENTITY (1, 1) NOT NULL,
    [Letter]      VARCHAR (10)  NOT NULL,
    [Description] VARCHAR (500) NOT NULL,
    CONSTRAINT [PK_MilitaryFitness] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryFitness]
    ON [dbo].[MilitaryFitness]([Letter] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_MilitaryFitness_1]
    ON [dbo].[MilitaryFitness]([Description] ASC);

