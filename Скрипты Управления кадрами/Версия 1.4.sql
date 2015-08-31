



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
select '<не указан>', [DatePrikaz],ISNULL([FactStaffHistory].[DateBegin],Prikaz.DateBegin),null
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
	and [FactStaffHistory].[idContract] is null and [Contract].ContractName='<не указан>'
	and [Contract].id not in (select ISNULL(idContract,0) from [dbo].[FactStaffHistory])

	delete from dbo.[Contract]
where  [ContractName]='<не указан>'
and 
id not in (select isnull(idContract,0) from [dbo].[FactStaffHistory])

/*
	select [FactStaffHistory].id, [FactStaffHistory].idContract, COUNT(id) from
	[dbo].[FactStaffHistory]
where idContract is not null
GROUP BY [FactStaffHistory].id, [FactStaffHistory].idContract
having COUNT(id)>1*/




