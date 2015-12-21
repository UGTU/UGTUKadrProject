CREATE TABLE [dbo].[FundingCenter] (
    [id]                INT          IDENTITY (1, 1) NOT NULL,
    [FundingCenterName] VARCHAR (50) NOT NULL,
    [DateEnd]           DATE         NULL,
    CONSTRAINT [PK_FundingCenter] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [IX_FundingCenter] UNIQUE NONCLUSTERED ([FundingCenterName] ASC)
);

