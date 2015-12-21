CREATE TABLE [dbo].[OK_OtpuskPlanDay] (
    [idotpuskplanday]    INT           IDENTITY (1, 1) NOT NULL,
    [otpuskplandaykateg] VARCHAR (255) NOT NULL,
    [planday]            INT           NOT NULL,
    CONSTRAINT [PK_OK_OtpuskPlanDay] PRIMARY KEY CLUSTERED ([idotpuskplanday] ASC)
);

