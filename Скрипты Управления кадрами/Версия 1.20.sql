update [dbo].[EventKind]
set [idMainEventKind]=null
where id=4

go

insert into [dbo].[EventKind]([id],[EventKindName], [idMainEventKind], EventKindApplName, [DecoratorName])
values(12,'���������� ���������',2,'����������� �����', 'Kadr.Data.FactStaffHistoryMinDecorator')