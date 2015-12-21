CREATE TABLE [dbo].[EducDocument] (
    [id]             INT          IDENTITY (1, 1) NOT NULL,
    [idEducDocType]  INT          NULL,
    [DocSeries]      VARCHAR (15) NULL,
    [DocNumber]      VARCHAR (50) NULL,
    [DocDate]        DATETIME     NULL,
    [IdOrganisation] INT          NULL,
    CONSTRAINT [PK_EdicDocument] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_EducDocument_EducDocumentType] FOREIGN KEY ([idEducDocType]) REFERENCES [dbo].[EducDocumentType] ([id]),
    CONSTRAINT [FK_EducDocument_Organisation] FOREIGN KEY ([IdOrganisation]) REFERENCES [dbo].[Organisation] ([id])
);


GO
CREATE NONCLUSTERED INDEX [IX_EducDocument]
    ON [dbo].[EducDocument]([idEducDocType] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_EducDocument_1]
    ON [dbo].[EducDocument]([IdOrganisation] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EducDocumentUniq]
   ON dbo.EducDocument 
   FOR INSERT, UPDATE 
AS
BEGIN
	IF EXISTS(SELECT 'TRUE' 
			FROM INSERTED, dbo.EducDocument
					WHERE INSERTED.id<>EducDocument.id
						AND INSERTED.idEducDocType=EducDocument.idEducDocType
						AND INSERTED.DocSeries=EducDocument.DocSeries AND INSERTED.DocSeries IS NOT NULL
						AND INSERTED.DocNumber=EducDocument.DocNumber AND INSERTED.DocNumber IS NOT NULL
						--AND INSERTED.DocDate=EducDocument.DocDate AND INSERTED.DocDate IS NOT NULL
	)			
	BEGIN
		  RAISERROR('Ошибка! Такие данные диплома уже есть в базе данных.', 16,1)
		  ROLLBACK TRAN 
	END
END
