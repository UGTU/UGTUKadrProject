/****** Script for SelectTopNRows command from SSMS  ******/

SELECT *
  FROM [Kadr].[dbo].[Event]
  inner join
  dbo.[Contract] on [Event].idContract=[Contract].id
  inner join [dbo].[FactStaffHistory] on [FactStaffHistory].id=[Event].idFactStaffHistory
  inner join [dbo].[FactStaff] on [FactStaffHistory].idFactStaff=[FactStaff].id and [FactStaff].idlaborcontrakt is null
  inner join (SELECT  [Prikaz].PrikazName,[DatePrikaz],[DateBegin],[DateEnd],  MIN([id]) id
	from  [dbo].[Prikaz]
	WHERE [Prikaz].idPrikazType=27
	GROUP BY [Prikaz].PrikazName,[DatePrikaz],[DateBegin],[DateEnd]
	)[Prikaz]
	 on [Contract].ContractName=[Prikaz].PrikazName and [Contract].DateContract=[Prikaz].DatePrikaz
	 and [Contract].DateBegin=[Prikaz].DateBegin  and ([Contract].DateEnd=[Prikaz].DateEnd or ([Contract].DateEnd is null and  [Prikaz].DateEnd is null))
  where [idEventKind] =1 
  
  SELECT *
  FROM [Kadr].[dbo].[Event]
  inner join
  dbo.[Contract] on [Event].idContract=[Contract].id
  inner join [dbo].[FactStaffHistory] on [FactStaffHistory].id=[Event].idFactStaffHistory
  inner join [dbo].[FactStaff] on [FactStaffHistory].idFactStaff=[FactStaff].id 
  inner join [dbo].[Prikaz] on  [FactStaff].idlaborcontrakt=[Prikaz].id
  where [idEventKind] =1 
  
  INSERT INTO [dbo].[Prikaz]
           ([PrikazName]
           ,[DatePrikaz]
           ,[idPrikazType]
           ,[DateBegin]
           ,[DateEnd]
           ) 
SELECT DISTINCT [Contract].ContractName, [Contract].[DateContract], 27,[Contract].[DateBegin], [Contract].DateEnd
  FROM [Kadr].[dbo].[Event]
  inner join
  dbo.[Contract] on [Event].idContract=[Contract].id
  inner join [dbo].[FactStaffHistory] on [FactStaffHistory].id=[Event].idFactStaffHistory
  inner join [dbo].[FactStaff] on [FactStaffHistory].idFactStaff=[FactStaff].id and [FactStaff].idlaborcontrakt is null
  where [idEventKind] =1 and [Contract].[idMainContract] is null


  update [dbo].[FactStaff]
  set [idlaborcontrakt]=[Prikaz].id
  --SELECT *
  FROM [Kadr].[dbo].[Event]
  inner join
  dbo.[Contract] on [Event].idContract=[Contract].id
  inner join [dbo].[FactStaffHistory] on [FactStaffHistory].id=[Event].idFactStaffHistory
  inner join [dbo].[FactStaff] on [FactStaffHistory].idFactStaff=[FactStaff].id and [FactStaff].idlaborcontrakt is null
  inner join (SELECT  [Prikaz].PrikazName,[DatePrikaz],[DateBegin],[DateEnd],  MIN([id]) id
	from  [dbo].[Prikaz]
	WHERE [Prikaz].idPrikazType=27
	GROUP BY [Prikaz].PrikazName,[DatePrikaz],[DateBegin],[DateEnd]
	)[Prikaz]
	 on [Contract].ContractName=[Prikaz].PrikazName and [Contract].DateContract=[Prikaz].DatePrikaz
	 and [Contract].DateBegin=[Prikaz].DateBegin  and ([Contract].DateEnd=[Prikaz].DateEnd or ([Contract].DateEnd is null and  [Prikaz].DateEnd is null))
  where [idEventKind] =1 
 