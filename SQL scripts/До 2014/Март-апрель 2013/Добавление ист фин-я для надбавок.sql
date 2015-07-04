select *
from [dbo].[BonusHistory]
inner join [dbo].[BonusFactStaff] ON [BonusHistory].idBonus=[BonusFactStaff].idBonus
inner join [dbo].[FactStaff] On [BonusFactStaff].idFactStaff=[FactStaff].id
inner join [dbo].PlanStaffCurrent [PlanStaff] ON [FactStaff].idPlanStaff=PlanStaff.id



update [dbo].[BonusHistory]
set [idFinancingSource]=[PlanStaff].idFinancingSource
from 

[dbo].[BonusHistory]
inner join [dbo].[BonusPlanStaff] ON [BonusHistory].idBonus=[BonusPlanStaff].idBonus
inner join [dbo].PlanStaffCurrent [PlanStaff] ON [BonusPlanStaff].idPlanStaff=PlanStaff.id


update [dbo].[BonusHistory]
set [idFinancingSource]=[PlanStaff].idFinancingSource
from 

[dbo].[BonusHistory]
inner join [dbo].[BonusFactStaff] ON [BonusHistory].idBonus=[BonusFactStaff].idBonus
inner join [dbo].[FactStaff] On [BonusFactStaff].idFactStaff=[FactStaff].id
inner join [dbo].PlanStaffCurrent [PlanStaff] ON [FactStaff].idPlanStaff=PlanStaff.id