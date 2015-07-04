select *--[Bonus].idBonusHistory
from [dbo].[BonusWithHistory] [Bonus]
inner join [dbo].[BonusFactStaff]  ON [Bonus].id=[BonusFactStaff].idBonus
inner join [dbo].[FactStaff] on [BonusFactStaff].idFactStaff=FactStaff.id
inner join [dbo].[PlanStaffCurrent] [PlanStaff] on FactStaff.idPlanStaff=PlanStaff.id
inner join [dbo].Post on PlanStaff.idPost=Post.id

where [idPrikaz]=22191 and Post.idCategory between 2 and 4
--and [Bonus].idBonusType=3
and [PlanStaff].idFinancingSource=1
and [Bonus].idFinancingSource<>1


update [dbo].[BonusHistory]
set [idFinancingSource]=1
where  id IN 
(select [Bonus].idBonusHistory
from [dbo].[BonusWithHistory] [Bonus]
inner join [dbo].[BonusFactStaff]  ON [Bonus].id=[BonusFactStaff].idBonus
inner join [dbo].[FactStaff] on [BonusFactStaff].idFactStaff=FactStaff.id
inner join [dbo].[PlanStaffCurrent] [PlanStaff] on FactStaff.idPlanStaff=PlanStaff.id
inner join [dbo].Post on PlanStaff.idPost=Post.id

where [idPrikaz]=22191 and Post.idCategory between 2 and 4
--and [Bonus].idBonusType=3
and [PlanStaff].idFinancingSource=1
and [Bonus].idFinancingSource<>1)

update [dbo].[BonusHistory]
set [idFinancingSource]=2
where  id IN 
(select [Bonus].idBonusHistory
from [dbo].[BonusWithHistory] [Bonus]
inner join [dbo].[BonusFactStaff]  ON [Bonus].id=[BonusFactStaff].idBonus
inner join [dbo].[FactStaff] on [BonusFactStaff].idFactStaff=FactStaff.id
inner join [dbo].[PlanStaff] on FactStaff.idPlanStaff=PlanStaff.id
inner join [dbo].Post on PlanStaff.idPost=Post.id

where [idPrikaz]=17887 and Post.idCategory=4
and [Bonus].idBonusType=3)
