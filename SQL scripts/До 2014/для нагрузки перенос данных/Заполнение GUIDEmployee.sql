/****** Script for SelectTopNRows command from SSMS  ******/
SELECT Person.PersonFullName collate Cyrillic_General_CI_AS,*
    FROM [UGTU].[dbo].[Prepod]
  inner JOIN
  dbo.Person ON [Prepod].nCode=Person.nCode
  INNER JOIN
kadr.dbo.Employee ON 

Person.PersonFullName collate Cyrillic_General_CI_AS =Employee.EmployeeName
  where [EmployeeGUID] is null
  order by Person.PersonFullName

  update [dbo].[Prepod]
  set [EmployeeGUID]=Employee.GUID
  FROM [UGTU].[dbo].[Prepod]
  inner JOIN
  dbo.Person ON [Prepod].nCode=Person.nCode
  INNER JOIN
kadr.dbo.Employee ON 

Person.PersonFullName collate Cyrillic_General_CI_AS =Employee.EmployeeName
  where [EmployeeGUID] is null






  SELECT
    col.name, col.collation_name
FROM 
    sys.columns col
WHERE
    object_id = OBJECT_ID('[dbo].[PPrepod]')
go
use kadr
	  SELECT
    col.name, col.collation_name
FROM 
    sys.columns col
WHERE
    object_id = OBJECT_ID('dbo.Employee')

	ALTER TABLE [dbo].[Person]
  ALTER COLUMN [PersName]
    VARCHAR(92) COLLATE Cyrillic_General_CI_AS NOT NULL