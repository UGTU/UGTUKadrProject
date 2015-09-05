



alter table [dbo].[OK_Fam]
add BirthDate DATE NULL

alter table [dbo].[OK_Fam]
add BirthYear INT NULL


go

select *
from [dbo].[OK_Fam]
where Len([godbirth])=4


update [dbo].[OK_Fam]
set [BirthYear]=CONVERT(INT, [godbirth])
WHERE Len([godbirth])=4


/*select *--, cast([godbirth] as DATE)-- CONVERT(DATE, CONVERT(VARCHAR(10), [godbirth]))--, CONVERT(DATE, [godbirth])
from [dbo].[OK_Fam]
where
Len([godbirth])=10 and 
 ISDATE([godbirth])=1
(substring([godbirth],3,1)='.'
and substring([godbirth],6,1)='.')
and
not
(((CONVERT(INT,substring([godbirth],1,2)) BETWEEN 1 AND 30
and CONVERT(INT,substring([godbirth],4,2)) in (4,6,9,11))
or 
(CONVERT(INT,substring([godbirth],1,2)) BETWEEN 1 AND 31
and CONVERT(INT,substring([godbirth],4,2)) in (1,3,5,7,8,10,12))
or
(CONVERT(INT,substring([godbirth],1,2)) BETWEEN 1 AND 29
and CONVERT(INT,substring([godbirth],4,2)) =2))
and (CONVERT(INT,substring([godbirth],7,4)) BETWEEN 1900 AND 2050))

*/

update  [dbo].[OK_Fam]
set 
--select
[godbirth]=substring([godbirth],1,2)+'.'+substring([godbirth],4,2)+'.'+substring([godbirth],7,4)
--from [dbo].[OK_Fam]
where
Len([godbirth])=10 and 
 NOT-- ISDATE([godbirth])=1
(substring([godbirth],3,1)='.'
and substring([godbirth],6,1)='.')



/*update [dbo].[OK_Fam]--, CONVERT(DATE, [godbirth])
set [godbirth]=''
where Len([godbirth])=10 
and not 
(CONVERT(INT,substring([godbirth],1,2)) BETWEEN 1 AND 31
and CONVERT(INT,substring([godbirth],4,2)) BETWEEN 1 AND 12
and CONVERT(INT,substring([godbirth],7,7)) BETWEEN 1900 AND 2050)*/

update [dbo].[OK_Fam]
set [BirthDate]=CONVERT(DATE, CONVERT(VARCHAR(10), [godbirth]))
WHERE Len([godbirth])=10 and /*CONVERT(INT,substring([godbirth],1,2)) BETWEEN 1 AND 31
and CONVERT(INT,substring([godbirth],4,2)) BETWEEN 1 AND 12
and CONVERT(INT,substring([godbirth],7,7)) BETWEEN 1900 AND 2050*/
 ISDATE([godbirth])=1


select *--, cast([godbirth] as DATE)-- CONVERT(DATE, CONVERT(VARCHAR(10), [godbirth]))--, CONVERT(DATE, [godbirth])
from [dbo].[OK_Fam]
where BirthDate is null and BirthYear is null

go
EXEC sp_rename 'dbo.Contract.DataBegin', 'DateBegin', 'COLUMN'
go
EXEC sp_rename 'dbo.Contract.DataEnd', 'DateEnd', 'COLUMN'

go

alter table [dbo].[OK_Adress]
add DateEnd DATE NULL



go
select *
from dbo.FactStaffHistory
where idContract is null


go 




insert into dbo.[Contract]([ContractName],[DateContract],[DateBegin],[DateEnd])
select '<не внесен номер>', [DatePrikaz],ISNULL([FactStaffHistory].[DateBegin],Prikaz.DateBegin),null
from [dbo].[FactStaffHistory]
inner join dbo.Prikaz
ON [FactStaffHistory].idBeginPrikaz=Prikaz.id
and [FactStaffHistory].idContract is null

update [dbo].[FactStaffHistory]
set [idContract]=[Contract].id
--select *
from  [dbo].[FactStaffHistory]
inner join dbo.Prikaz
ON [FactStaffHistory].idBeginPrikaz=Prikaz.id
inner join dbo.[Contract] 
	ON (ISNULL([FactStaffHistory].[DateBegin],Prikaz.DateBegin)=[Contract].DateBegin or (Prikaz.DateBegin is null and [Contract].DateBegin is null))
	AND (Prikaz.DatePrikaz=[Contract].DateContract or (Prikaz.DatePrikaz is null and [Contract].DateContract is null))
	and [FactStaffHistory].[idContract] is null and [Contract].ContractName='<не внесен номер>'
	and [Contract].id not in (select ISNULL(idContract,0) from [dbo].[FactStaffHistory])

	delete from dbo.[Contract]
where  [ContractName]='<не внесен номер>'
and 
id not in (select isnull(idContract,0) from [dbo].[FactStaffHistory])

/*

update dbo.[Contract]
set [ContractName]='<не внесен номер>'
where [ContractName]='<не указан>'
	select [FactStaffHistory].id, [FactStaffHistory].idContract, COUNT(id) from
	[dbo].[FactStaffHistory]
where idContract is not null
GROUP BY [FactStaffHistory].id, [FactStaffHistory].idContract
having COUNT(id)>1*/





go
alter table [dbo].[Category]
add IsNP bit default (0)

go
update [dbo].[Category]
set [IsNP]=1
where [id] in (0,2,6)

update [dbo].[Category]
set [IsNP]=0
where [id] not in (0,2,6)





go
alter table [dbo].[DepartmentHistory]
add idRegionType int null
go
alter table [dbo].[DepartmentHistory]
add Address varchar(500) null


GO

ALTER TABLE [dbo].[DepartmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentHistory_RegionType] FOREIGN KEY([idRegionType])
REFERENCES [dbo].[RegionType] ([id])
GO

ALTER TABLE [dbo].[DepartmentHistory] CHECK CONSTRAINT [FK_DepartmentHistory_RegionType]
GO

go
update [dbo].DepartmentHistory
set [idRegionType]=2


go
alter table [dbo].FactStaffHistory
add idRegionType int null
go
alter table [dbo].FactStaffHistory
add Address varchar(500) null
GO

ALTER TABLE [dbo].FactStaffHistory  WITH CHECK ADD  CONSTRAINT [FK_FactStaffHistory_RegionType] FOREIGN KEY([idRegionType])
REFERENCES [dbo].[RegionType] ([id])
GO

ALTER TABLE [dbo].FactStaffHistory CHECK CONSTRAINT [FK_FactStaffHistory_RegionType]



go
--select * from [Department] where  [dateExit]>GETDATE()
--Представление со всеми текущими параметрами Department (DateBegin...) 
ALTER VIEW [dbo].[Department]
AS
SELECT  Dep.[id]
      ,DepartmentHistory.[DepartmentName]
      ,DepartmentHistory.[DepartmentSmallName]
      ,Dep.[idDepartmentType]
      ,DepartmentHistory.[idManagerDepartment]
      ,Dep.[KadrID]
      ,DepartmentHistory.DateBegin [dateCreate]
      ,Dep.[dateExit]
      ,Dep.[idManagerPlanStaff]
      ,DepartmentHistory.[idBeginPrikaz]
      ,Dep.[idEndPrikaz]
      ,Dep.[SeverKoeff]
      ,Dep.[RayonKoeff]
      ,Dep.[DepartmentGUID]
      ,idFundingCenter
	  ,Dep.DepartmentIndex
	  ,Dep.[DepPhoneNumber]
	  ,Dep.HasTimeSheet
	  , Dep.idOKVED,
	  DepartmentHistory.[Address],
	  DepartmentHistory.idRegionType
FROM         
	dbo.Dep INNER JOIN
	 dbo.DepartmentHistory ON Dep.id=DepartmentHistory.idDepartment
		AND DepartmentHistory.DateBegin = 
			ISNULL((SELECT MAX(DepartmentHistory.DateBegin) FROM dbo.DepartmentHistory 
				WHERE DepartmentHistory.idDepartment=Dep.id AND
					DepartmentHistory.DateBegin<GETDATE()),DepartmentHistory.DateBegin)


drop table [dbo].[OK_Military]

alter table [dbo].[Employee] add [idCategory] int
alter table [dbo].[Employee] add [idRank] int
alter table [dbo].[Employee] add [VUSCode] varchar(50)
alter table [dbo].[Employee] add [idFitness] int
alter table [dbo].[Employee] add [MilitaryCommissariat] varchar(900)
alter table [dbo].[Employee] add [idType] int
alter table [dbo].[Employee] add [RemovalMark] varchar(900)
alter table [dbo].[Employee] add [idStructure] int
alter table [dbo].[Employee] add [NumberForType] varchar(500)

/****** Object:  Index [IX_Employee_MilitaryCategory]    Script Date: 05.09.2015 15:39:43 ******/
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryCategory] ON [dbo].[Employee]
(
	[idMilitaryCategory] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_MilitaryFitness]    Script Date: 05.09.2015 15:39:43 ******/
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryFitness] ON [dbo].[Employee]
(
	[idMilitaryFitness] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_MilitaryRank]    Script Date: 05.09.2015 15:39:43 ******/
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryRank] ON [dbo].[Employee]
(
	[idMilitaryRank] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_MilitaryStructure]    Script Date: 05.09.2015 15:39:43 ******/
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryStructure] ON [dbo].[Employee]
(
	[idMilitaryStructure] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Employee_MilitaryType]    Script Date: 05.09.2015 15:39:43 ******/
CREATE NONCLUSTERED INDEX [IX_Employee_MilitaryType] ON [dbo].[Employee]
(
	[idMilitaryType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_MilitaryCategory] FOREIGN KEY([idMilitaryCategory])
REFERENCES [dbo].[MilitaryCategory] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_MilitaryCategory]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_MilitaryFitness] FOREIGN KEY([idMilitaryFitness])
REFERENCES [dbo].[MilitaryFitness] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_MilitaryFitness]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_MilitaryRank] FOREIGN KEY([idMilitaryRank])
REFERENCES [dbo].[MilitaryRank] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_MilitaryRank]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_MilitaryStructure] FOREIGN KEY([idMilitaryStructure])
REFERENCES [dbo].[MilitaryStructure] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_MilitaryStructure]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_MilitaryType] FOREIGN KEY([idMilitaryType])
REFERENCES [dbo].[MilitaryType] ([id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_MilitaryType]
GO







