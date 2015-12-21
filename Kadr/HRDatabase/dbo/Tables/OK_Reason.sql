CREATE TABLE [dbo].[OK_Reason] (
    [idreason]   INT           IDENTITY (1, 1) NOT NULL,
    [reasonname] VARCHAR (255) NOT NULL,
    [isUvoln]    BIT           CONSTRAINT [DF_OK_Reason_isUvoln] DEFAULT ((1)) NOT NULL,
    [is_old]     BIT           NULL,
    CONSTRAINT [PK_OK_Reason] PRIMARY KEY CLUSTERED ([idreason] ASC)
);

