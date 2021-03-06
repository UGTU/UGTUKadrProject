/****** Script for SelectTopNRows command from SSMS  ******/
SELECT idEmployee, Count(id) ContractCount
  FROM [dbo].[FactStaff]
    where idlaborcontrakt in
  (select id from Prikaz where idPrikazType in (27))
  GROUP BY idEmployee
  HAVING Count(id)=1

  SELECT idEmployee, Count([FactStaffHistory].id) ContractCount
  FROM [dbo].[FactStaffHistory]
  inner join dbo.FactStaff ON FactStaff.id=[FactStaffHistory].idFactStaff
    where [FactStaffHistory].idlaborcontrakt in
  (select id from Prikaz where idPrikazType in (27))
  GROUP BY idEmployee
  HAVING Count([FactStaffHistory].id)=1

 SELECT *
	  FROM dbo.FactStaff
		  INNER JOIN
		  (SELECT idEmployee, Count(id) ContractCount
		  FROM [dbo].[FactStaff]
		  where idlaborcontrakt in
		  (select id from Prikaz where idPrikazType in (27))
		  GROUP BY idEmployee
		  HAVING Count(id)=1)UniqueContractEmpl
		  ON FactStaff.idEmployee=UniqueContractEmpl.idEmployee
		  AND idlaborcontrakt not in
		  (select id from Prikaz where idPrikazType in (27))


  SELECT *
  FROM dbo.FactStaffHistory
  WHERE idFactStaff IN
	  (SELECT id
	  FROM dbo.FactStaff
		  INNER JOIN
		  (SELECT idEmployee, Count(id) ContractCount
		  FROM [dbo].[FactStaff]
		  where idlaborcontrakt not in
		  (select id from Prikaz where idPrikazType in (27))
		  GROUP BY idEmployee
		  HAVING Count(id)=1)UniqueContractEmpl
		  ON FactStaff.idEmployee=UniqueContractEmpl.idEmployee)


  SELECT *
  FROM [dbo].[FactStaffHistory]
  where idlaborcontrakt not in
  (select id from Prikaz where idPrikazType in (27,28))


  --убираем неуникальные строки
  select *
  from [dbo].[Prikaz] inner join
  (select [PrikazName], [DatePrikaz], [DateBegin], [idPrikazType], [DateEnd], CONVERT(varchar(500), [resume]) resume, COUNT(id) col
  from dbo.Prikaz
  where
  Prikaz.id in (select idlaborcontrakt from dbo.FactStaff)
  or
   Prikaz.id in (select idlaborcontrakt from dbo.FactStaffHistory) 
   GROUP BY [PrikazName], [DatePrikaz], [DateBegin], [idPrikazType], [DateEnd], CONVERT(varchar(500), [resume])
   HAVING COUNT(id)>1)doublePrikaz
   ON [Prikaz].DateBegin=doublePrikaz.DateBegin and ([Prikaz].DateEnd=doublePrikaz.DateEnd OR ([Prikaz].DateEnd IS NULL AND doublePrikaz.DateEnd IS NULL))
	 and [Prikaz].PrikazName=doublePrikaz.PrikazName  and [Prikaz].DatePrikaz=doublePrikaz.DatePrikaz  
	 and [Prikaz].idPrikazType=doublePrikaz.idPrikazType



select [PrikazName], [DatePrikaz], [DateBegin], [idPrikazType], [DateEnd], CONVERT(varchar(500), [resume]) resume
  from dbo.Prikaz
  where
 ( Prikaz.id in (select idlaborcontrakt from dbo.FactStaff)
  or
   Prikaz.id in (select idlaborcontrakt from dbo.FactStaffHistory))
   and resume is not null
