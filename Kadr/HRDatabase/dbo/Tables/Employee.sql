CREATE TABLE [dbo].[Employee] (
    [id]                      INT              IDENTITY (1, 1) NOT NULL,
    [itab_n]                  VARCHAR (50)     NULL,
    [FirstName]               VARCHAR (50)     NULL,
    [LastName]                VARCHAR (50)     NULL,
    [Otch]                    VARCHAR (50)     NULL,
    [BirthDate]               DATETIME         NULL,
    [BirthPlace]              VARCHAR (200)    NULL,
    [SexBit]                  BIT              NOT NULL,
    [idGrazd]                 INT              NULL,
    [idSemPol]                INT              NULL,
    [SeverKoeff]              INT              CONSTRAINT [DF_Employee_SeverKoeff] DEFAULT ((50)) NOT NULL,
    [RayonKoeff]              INT              CONSTRAINT [DF_Employee_RayonKoeff] DEFAULT ((30)) NOT NULL,
    [GUID]                    UNIQUEIDENTIFIER CONSTRAINT [DF_Employee_GUID] DEFAULT (newsequentialid()) ROWGUIDCOL NOT NULL,
    [EmployeeSid]             VARBINARY (85)   NULL,
    [EmployeeLogin]           NVARCHAR (128)   NULL,
    [AllowBirthdate]          BIT              DEFAULT ((1)) NOT NULL,
    [paspser]                 VARCHAR (255)    NULL,
    [paspnomer]               VARCHAR (255)    NULL,
    [paspdate]                DATETIME         NULL,
    [paspkem]                 VARCHAR (255)    NULL,
    [inn]                     VARCHAR (255)    NULL,
    [ssgps]                   VARCHAR (255)    NULL,
    [medpolis]                VARCHAR (50)     NULL,
    [EmployeeName]            AS               (((([LastName]+' ')+[FirstName])+' ')+[Otch]) PERSISTED,
    [OtpReducedFareDateBegin] DATETIME         NULL,
    [EmployeeSmallName]       AS               ((((([LastName]+' ')+left([FirstName],(1)))+'. ')+left([Otch],(1)))+'.') PERSISTED,
    [EmplHistSer]             VARCHAR (10)     NULL,
    [EmplHistNumber]          VARCHAR (20)     NULL,
    [EmplHistDate]            DATE             NULL,
    [idMilitaryCategory]      INT              NULL,
    [idMilitaryRank]          INT              NULL,
    [VUSCode]                 VARCHAR (50)     NULL,
    [idMilitaryFitness]       INT              NULL,
    [MilitaryCommissariat]    VARCHAR (900)    NULL,
    [idMilitaryType]          INT              NULL,
    [RemovalMilitaryMark]     VARCHAR (900)    NULL,
    [idMilitaryStructure]     INT              NULL,
    [NumberMilitaryType]      VARCHAR (500)    NULL,
    [email]                   VARCHAR (100)    NULL,
    [paspCodeKem]             VARCHAR (20)     NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [CK_EmployeeRayonKoeff] CHECK ([RayonKoeff]>=(1) AND [RayonKoeff]<=(150)),
    CONSTRAINT [CK_EmployeeSeverKoeff] CHECK ([SeverKoeff]>=(1) AND [SeverKoeff]<=(150)),
    CONSTRAINT [FK_Employee_Grazd] FOREIGN KEY ([idGrazd]) REFERENCES [dbo].[Grazd] ([id]),
    CONSTRAINT [FK_Employee_MilitaryCategory] FOREIGN KEY ([idMilitaryCategory]) REFERENCES [dbo].[MilitaryCategory] ([id]),
    CONSTRAINT [FK_Employee_MilitaryFitness] FOREIGN KEY ([idMilitaryFitness]) REFERENCES [dbo].[MilitaryFitness] ([id]),
    CONSTRAINT [FK_Employee_MilitaryRank] FOREIGN KEY ([idMilitaryRank]) REFERENCES [dbo].[MilitaryRank] ([id]),
    CONSTRAINT [FK_Employee_MilitaryStructure] FOREIGN KEY ([idMilitaryStructure]) REFERENCES [dbo].[MilitaryStructure] ([id]),
    CONSTRAINT [FK_Employee_MilitaryType] FOREIGN KEY ([idMilitaryType]) REFERENCES [dbo].[MilitaryType] ([id]),
    CONSTRAINT [FK_Employee_SemPol] FOREIGN KEY ([idSemPol]) REFERENCES [dbo].[SemPol] ([id]),
    CONSTRAINT [IX_Employee] UNIQUE NONCLUSTERED ([FirstName] ASC, [LastName] ASC, [Otch] ASC, [BirthDate] ASC),
    CONSTRAINT [IX_Employee_1] UNIQUE NONCLUSTERED ([GUID] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_idGrazd]
    ON [dbo].[Employee]([idGrazd] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_idSemPol]
    ON [dbo].[Employee]([idSemPol] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_2]
    ON [dbo].[Employee]([EmployeeLogin] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryCategory]
    ON [dbo].[Employee]([idMilitaryCategory] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryFitness]
    ON [dbo].[Employee]([idMilitaryFitness] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryRank]
    ON [dbo].[Employee]([idMilitaryRank] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryStructure]
    ON [dbo].[Employee]([idMilitaryStructure] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryType]
    ON [dbo].[Employee]([idMilitaryType] ASC);


GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeUpdateRegister]
   ON  dbo.Employee
   AFTER update
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

declare @name varchar(100)
select @name=RTRIM(id)+' '+RTRIM(itab_n)+' '+RTRIM(LastName)+ ' '+RTRIM(FirstName)+' '+RTRIM(Otch) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 3,2,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeInsertRegister]
   ON  dbo.Employee
   AFTER INSERT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)
select @name=RTRIM(id)+' '+RTRIM(itab_n)+' '+RTRIM(LastName)+ ' '+RTRIM(FirstName)+' '+RTRIM(Otch) from inserted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 1,2,@name
END

GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[EmployeeDeleteRegister]
   ON  dbo.Employee
   AFTER DELETE
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
declare @name varchar(102)

select @name=RTRIM(id)+' '+RTRIM(itab_n)+' '+RTRIM(LastName)+ ' '+RTRIM(FirstName)+' '+RTRIM(Otch) from deleted
    -- Insert statements for trigger here
exec dbo.AuditLogEvent 2,2,@name
END
