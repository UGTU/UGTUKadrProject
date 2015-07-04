update dbo.ok_step
set dipl_nom=null
where dipl_nom=''


insert into kadr.dbo.EducDocument(idEducDocType, DocSeries, DocNumber, DocDate)
select  1,dipl_ser,dipl_nom,dipl_d 
from ok.dbo.ok_step as okz, 
kadr.dbo.EmployeeDegree kadrzv,  
kadr.dbo.Employee as empl,
kadr.dbo.EducDocument as doc
where okz.itab_n=empl.itab_n
and kadrzv.idEmployee=empl.id
and kadrzv.idEducDocument=doc.id
and idEducDocument=1187 
and okz.id<>292


update Kadr.dbo.EmployeeDegree
set idEducDocument = EducDocument.id

 from
 kadr.dbo.EmployeeDegree,
(select kadrzv.id as rankid, dipl_ser,dipl_nom,dipl_d  from ok.dbo.ok_step as okz, 
kadr.dbo.EmployeeDegree kadrzv,  
kadr.dbo.Employee as empl,
kadr.dbo.EducDocument as doc
where okz.itab_n=empl.itab_n
and kadrzv.idEmployee=empl.id
and kadrzv.idEducDocument=doc.id
and idEducDocument=1187 
and okz.id<>292)num, kadr.dbo.EducDocument
where num.dipl_ser=EducDocument.DocSeries
and num.dipl_nom=EducDocument.DocNumber
and num.dipl_d=EducDocument.DocDate
and EmployeeDegree.id=rankid








update kadr.dbo.EmployeeDegree 
set idEducDocument=8902
where id in (select kadrzv.id
from ok.dbo.ok_step as okz, 
kadr.dbo.EmployeeDegree kadrzv,  
kadr.dbo.Employee as empl,
kadr.dbo.EducDocument as doc
where okz.itab_n=empl.itab_n
and dipl_ser is null
and dipl_nom is null
and kadrzv.idEmployee=empl.id
and kadrzv.idEducDocument=doc.id
and idEducDocument=1187)







select okz.*, doc.*, kadrzv.*, empl.* from ok.dbo.ok_step as okz, 
kadr.dbo.EmployeeDegree kadrzv,  
kadr.dbo.Employee as empl,
kadr.dbo.EducDocument as doc
where okz.itab_n=empl.itab_n
and kadrzv.idEmployee=empl.id
and kadrzv.idEducDocument=doc.id
and idEducDocument=1187
order by dipl_ser, dipl_nom






