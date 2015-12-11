
-- поправить типы приказов для повышения квалификации
update [dbo].[Prikaz] set idPrikazType = 44
where idPrikazType = 27
and id in (select [idPrikaz]
		   from [dbo].[OK_DopEducation], [dbo].[Event]
		   where [dbo].[OK_DopEducation].idEvent = [dbo].[Event].id)

---------------------------------------------------------------------------
-- установить тип приказа "по личному составу" для приказов вида Н.Н.
update [dbo].[Prikaz] set idPrikazType = 25
where id in (1846,1845)

-- установить тип приказа "по личному составу" для всех приказов приема, увольнения, перевода, изменения трудового договора
update [dbo].[Prikaz] set idPrikazType = 25
where idPrikazType in (5, 6, 10, 14)

select distinct idPrikazType from [dbo].[Prikaz]
where (id in (select [idEndPrikaz] from [dbo].[FactStaff]))
or (id in (select [idBeginPrikaz] from [dbo].[FactStaffHistory]))
order by idPrikazType


select * from [Prikaz] where [PrikazName] like '%696-л%'