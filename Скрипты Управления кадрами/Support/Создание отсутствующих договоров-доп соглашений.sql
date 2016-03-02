
--добавление договора и доп соглашения
alter table [dbo].[FactStaffHistory]
add idContract int null


go
--добавляем соответ столбец в Contract, чтобы знать к какому приказу он привязан
alter table [dbo].[Contract]
add idlaborContract_Prikaz int

go
update [dbo].[Contract]
set idlaborContract_Prikaz=ISNULL(FactStaffHistory.idlaborcontrakt,FactStaff.idlaborcontrakt)
--select *
from [dbo].[Contract]
inner join dbo.[Event] on [Event].idContract=[Contract].id
inner join dbo.FactStaffHistory on [Event].idFactStaffHistory=FactStaffHistory.id
inner join dbo.FactStaff on FactStaffHistory.idFactStaff=FactStaff.id
inner join dbo.EventKind on [Event].[idEventKind]=EventKind.id
where EventKind.ForFactStaff=1
and (FactStaffHistory.idlaborcontrakt is not null or FactStaff.idlaborcontrakt is not null)
--inner join dbo.Prikaz on [Contract].


go
--у кого нет события
SELECT  *      
FROM            dbo.FactStaffHistory 
WHERE
id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] --INNER JOIN
                         --dbo.Contract ON dbo.Event.idContract = dbo.Contract.id
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1
	)


go

--беру данные из типа приказа
SELECT  *      
FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE

FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)



--прием почасовиков
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
SELECT FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,11, 1, null 
FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and FactStaffHistory.HourCount>0


go
--заполняем договора, где они есть
insert into dbo.[Contract]([ContractName],[DateContract],[idPrikazType],[DateBegin],[DateEnd], [idlaborContract_Prikaz])
select [PrikazName], [DatePrikaz],[idPrikazType],FactStaffHistory.[DateBegin],FactStaff.[DateEnd],Prikaz.id 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ON ISNULL(FactStaff.idlaborcontrakt,FactStaffHistory.idlaborcontrakt)=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)



--прием 
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
select FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,1, 1, null 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ContrPrikaz ON ISNULL(FactStaff.idlaborcontrakt,FactStaffHistory.idlaborcontrakt)=ContrPrikaz.id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Contract on Contract.[idlaborContract_Prikaz]=ContrPrikaz.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and PrikazType.id=10


--перевод 
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
select  FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,3, 1, null 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ContrPrikaz ON ISNULL(FactStaff.idlaborcontrakt,FactStaffHistory.idlaborcontrakt)=ContrPrikaz.id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Contract on Contract.[idlaborContract_Prikaz]=ContrPrikaz.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and PrikazType.id=6



--перевод 
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
select  FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,4, 1, null 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ContrPrikaz ON ISNULL(FactStaff.idlaborcontrakt,FactStaffHistory.idlaborcontrakt)=ContrPrikaz.id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Contract on Contract.[idlaborContract_Prikaz]=ContrPrikaz.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and PrikazType.id=13
  

  
--перевод 
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
select  FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,7, 1, null 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ContrPrikaz ON ISNULL(FactStaff.idlaborcontrakt,FactStaffHistory.idlaborcontrakt)=ContrPrikaz.id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Contract on Contract.[idlaborContract_Prikaz]=ContrPrikaz.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and PrikazType.id=25



SELECT *--FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,11, 1, null 
FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)


























--там, где договоров нет...
go
--заполняем приказы
INSERT INTO [dbo].[Prikaz]
           ([PrikazName]
           ,[DatePrikaz]
           ,[idPrikazType]
           ,[DateBegin],
			[resume])
select  '<Номер не задан>', [DatePrikaz],[idPrikazType],FactStaffHistory.[DateBegin], CONVERT(VARCHAR(20), FactStaffHistory.id)


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)


--заполняем договора
insert into dbo.[Contract]([ContractName],[DateContract],[idPrikazType],[DateBegin],[DateEnd], [idlaborContract_Prikaz])
select  '<Номер не задан>', Prikaz.[DatePrikaz],Prikaz.[idPrikazType],FactStaffHistory.[DateBegin],FactStaff.[DateEnd],Contr_Prikaz.id


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Prikaz Contr_Prikaz ON  CONVERT(VARCHAR(20),Contr_Prikaz.resume)=CONVERT(VARCHAR(20),FactStaffHistory.id)
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)





--cоотв события
--прием 
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
select FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,1, 1, null 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ContrPrikaz ON CONVERT(VARCHAR(20),ContrPrikaz.resume)=CONVERT(VARCHAR(20),FactStaffHistory.id)
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Contract on Contract.[idlaborContract_Prikaz]=ContrPrikaz.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and PrikazType.id=10


--перевод 
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
select  FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,3, 1, null 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ContrPrikaz ON CONVERT(VARCHAR(20),ContrPrikaz.resume)=CONVERT(VARCHAR(20),FactStaffHistory.id)
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Contract on Contract.[idlaborContract_Prikaz]=ContrPrikaz.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and PrikazType.id=6



--перевод 
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
select  FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,4, 1, null 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ContrPrikaz ON CONVERT(VARCHAR(20),ContrPrikaz.resume)=CONVERT(VARCHAR(20),FactStaffHistory.id)
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Contract on Contract.[idlaborContract_Prikaz]=ContrPrikaz.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and PrikazType.id=13
  

  
--перевод 
go
INSERT INTO [dbo].[Event]
           ([idPrikaz]
           ,[DateBegin]
           ,[DateEnd]
           ,[idPrikazEnd]
           ,[idFactStaffHistory]
           ,[idEventKind]
           ,[idEventType]
           ,[idContract])
select  FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,7, 1, null 


FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ContrPrikaz ON CONVERT(VARCHAR(20),ContrPrikaz.resume)=CONVERT(VARCHAR(20),FactStaffHistory.id)
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
inner join dbo.Contract on Contract.[idlaborContract_Prikaz]=ContrPrikaz.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)
	and PrikazType.id=25



SELECT *--FactStaffHistory.idBeginPrikaz, FactStaffHistory.DateBegin, FactStaff.DateEnd, FactStaff.idEndPrikaz, FactStaffHistory.id,11, 1, null 
FROM            dbo.FactStaffHistory 
inner join dbo.FactStaff ON FactStaffHistory.[idFactStaff]=[dbo].[FactStaff].id
inner join dbo.Prikaz ON FactStaffHistory.idBeginPrikaz=Prikaz.id
inner join dbo.PrikazType ON Prikaz.idPrikazType=PrikazType.id
/*inner join dbo.FactStaffHistory EarlierFactStaffHistory 
	ON FactStaffHistory.idFactStaff=EarlierFactStaffHistory.idFactStaff and 
		FactStaffHistory.DateBegin>EarlierFactStaffHistory.DateBegin*/
WHERE
FactStaffHistory.id not in 
(SELECT Event.idFactStaffHistory
FROM
                         dbo.[Event] 
						 INNER JOIN [dbo].[EventKind] ON [Event].idEventKind=[EventKind].id
	WHERE [EventKind].ForFactStaff=1 
	)













