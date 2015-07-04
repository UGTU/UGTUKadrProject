select idEducDocument, COUNT(*)
from dbo.EmployeeDegree
group by idEducDocument
having(COUNT(*))>1


select * from dbo.EducDocument
where id=31631187


select *
from dbo.EmployeeDegree
where idEducDocument=990 1187

update dbo.EmployeeDegree
set idEducDocument=8802
where id=1178





select * from dbo.EducDocument
where DocSeries is null and DocNumber is null




declare @idDoc int
declare @newIdDoc int
select @idDoc=MIN(id) from EmployeeDegree
where idEducDocument=8902

while (@idDoc <5140)
begin

select @newIdDoc=MIN(EducDocument.id)
from 
dbo.EducDocument
where 
 EducDocument.DocNumber is null 
and EducDocument.DocSeries is null  
and EducDocument.DocDate is null 
and EducDocument.idEducDocType=1  
and EducDocument.id not in (select idEducDocument from EmployeeDegree)

update EmployeeDegree
set 
idEducDocument=  @newIdDoc
where id=@idDoc



select @idDoc=MIN(id) from EmployeeDegree
where idEducDocument=8902

end


select * from EmployeeRank, EducDocument
where EmployeeRank.idEducDocument=EducDocument.id
and  EducDocument.DocNumber is null 
and EducDocument.DocSeries is null  
and EducDocument.DocDate is null 
and EducDocument.idEducDocType=2  


select MIN(EducDocument.id)
from 
dbo.EducDocument
where 
 EducDocument.DocNumber is null 
and EducDocument.DocSeries is null  
and EducDocument.DocDate is null 
and EducDocument.idEducDocType=2  
and EducDocument.id not in (select idEducDocument from EmployeeRank)




select * from EmployeeDegree
where idEducDocument=8902




delete
select * 
from dbo.EducDocument
where id not in (select idEducDocument from dbo.EmployeeRank)
and id not in (select idEducDocument from dbo.EmployeeDegree)


