--tanvok

--���������� ������ � �����������

--�������� ��� � �����������
ALTER TABLE [dbo].[Grazd]
add IsRussian BIT 

go
update [dbo].[Grazd]
set [IsRussian] = 1
where [id]=2

update [dbo].[Grazd]
set [IsRussian] = 0
where [id]>2

--�������� ������ � �����������
ALTER TABLE [dbo].[Grazd]
add CountryName VARCHAR(50) 

go
update [dbo].[Grazd]
set CountryName=[Grazd].grazdName
go
update [dbo].[Grazd]
set CountryName='������'
where [id]=2

update [dbo].[Grazd]
set CountryName='<�� ������>'
where [id]=3






---�������� ������� ��������� ���
GO
DROP TABLE [dbo].[EmployeeHistory]
GO

CREATE TABLE [dbo].[EmployeeHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idEmployee] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Otch] [varchar](50) NULL,
	[paspser] [varchar](255) NULL,
	[paspnomer] [varchar](255) NULL,
	[paspdate] [datetime] NULL,
	[paspkem] [varchar](255) NULL,
	[paspCodeKem] [varchar](20) NULL,
	[idPrikaz] [int] NULL,
	[EmployeeName]  AS (((([LastName]+' ')+[FirstName])+' ')+[Otch]) PERSISTED,
	[EmployeeSmallName]  AS ((((([LastName]+' ')+left([FirstName],(1)))+'. ')+left([Otch],(1)))+'.') PERSISTED,
 CONSTRAINT [PK_EmployeeHistory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EmployeeHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeHistory_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([id])
GO

ALTER TABLE [dbo].[EmployeeHistory] CHECK CONSTRAINT [FK_EmployeeHistory_Employee]
GO

ALTER TABLE [dbo].[EmployeeHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeHistory_Prikaz] FOREIGN KEY([idPrikaz])
REFERENCES [dbo].[Prikaz] ([id])
GO

ALTER TABLE [dbo].[EmployeeHistory] CHECK CONSTRAINT [FK_EmployeeHistory_Prikaz]
GO

ALTER TABLE [dbo].[EmployeeHistory]
ADD DateUse Date NULL

go
--���������� ������� � ����-��� ��� � ����������
ALTER TABLE [dbo].[Employee]
ADD idPrikazFIO INT NULL
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Prikaz] FOREIGN KEY(idPrikazFIO)
REFERENCES [dbo].[Prikaz] ([id])
GO

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Prikaz]


go
ALTER TABLE [dbo].[Employee]
ADD DateFIOUse Date NULL


go
set identity_insert [dbo].[PrikazType] ON
insert into [dbo].[PrikazType](id,[PrikazTypeName],[idPrikazSuperType])
values (23, '����� ��� ����������', 1)
set identity_insert [dbo].[PrikazType] OFF





go
--select * from [EmployeeWithHistory] 
--������������� �� ����� ��� ����������, ������� �������� (���� FactStaff)
CREATE VIEW [dbo].EmployeeWithHistory
AS
SELECT * FROM
(
SELECT  
		[id]
      ,[idEmployee]
      ,[FirstName]
      ,[LastName]
      ,[Otch]
      ,[paspser]
      ,[paspnomer]
      ,[paspdate]
      ,[paspkem]
      ,[paspCodeKem]
      ,[idPrikaz]
      ,[EmployeeName]
      ,[EmployeeSmallName]
      ,[DateUse]
FROM         
	[dbo].[EmployeeHistory]
	UNION
SELECT  
		null as id
      ,[id] as [idEmployee]
      ,[FirstName]
      ,[LastName]
      ,[Otch]
      ,[paspser]
      ,[paspnomer]
      ,[paspdate]
      ,[paspkem]
      ,[paspCodeKem]
      ,[idPrikazFIO]
      ,[EmployeeName]
      ,[EmployeeSmallName]
      ,[DateFIOUse]
FROM         
	[dbo].[Employee])EmplWithHistory
WHERE [idEmployee] IN (SELECT idEmployee FROM dbo.FactStaff)





















--�������� � ����������
go
delete from [dbo].[EventKind]
where id>19
go
set identity_insert [dbo].[EventKind] ON

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [ForFactStaff], [DecoratorName],[WithContract])
values(20,'������� �� ����� ���������',3,'�� ����� ���������',1,null,1)

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [ForFactStaff], [DecoratorName],[WithContract])
values(21,'������� � ����������� ���������',3,'� ����������',1,null,1)


insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [ForFactStaff], [DecoratorName],[WithContract])
values(22,'������� � ����������� ��������� (��������� ��������)',3,'� ���������� (���� ��������)',1,null,1)
set identity_insert [dbo].[EventKind] OFF

