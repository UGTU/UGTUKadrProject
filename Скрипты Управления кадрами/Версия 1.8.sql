alter table [dbo].[MaterialResponsibility] alter column [Sum] numeric(8,2) null


update [EducDocument] set [IdOrganisation] = (select top(1) id
												from [dbo].[Organisation], [dbo].[OK_Educ]
												where [dbo].[OK_Educ].idEducDocument = [EducDocument].id
												and [dbo].[Organisation].Name = [dbo].[OK_Educ].EducWhere)
where [IdOrganisation] is null

update [OK_Educ] set idEducationType = (select idEducDocType
										from [EducDocument],[dbo].[EducDocumentType]
										where [EducDocument].idEducDocType = [dbo].[EducDocumentType].id
										and [EducDocument].id = [OK_Educ].idEducDocument
										and isOld = 1
										and idEducDocType not in (1,2,8))
where idEducationType is null

update [dbo].[EducDocument] set [idEducDocType] = 11
where [idEducDocType] in (3,4,5,7)

update [dbo].[EducDocument] set [idEducDocType] = 12
where [idEducDocType] in (6)