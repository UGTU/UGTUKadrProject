




--select dbo.[FIOToDat]('Сергей',1)  
--1 - имя, 2 - фамилия, 3 - отчество
CREATE   FUNCTION [dbo].[FIOToDat](@FIO varchar(100), @kind int)
RETURNS varchar(100) 

AS
BEGIN
DECLARE @res varchar(100) 

declare @fl bit
set @fl=0

if (@FIO='Гусейн' ) or (@FIO='Айгуль') or (@FIO='Гапон') or (@FIO='Гуртик') or (@FIO='Айсель') 
	 or (@FIO='Шоман')   
	return @FIO


--Фамилия
if (((SELECT RIGHT(@FIO,2))='ва')and(@fl=0)and(@kind=2))
begin
  set @fl=1
  select @res=LEFT(@FIO, LEN(@FIO)-2)+'вой'
end
if (((SELECT RIGHT(@FIO,1))='в')and(@fl=0)and(@kind=2))
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-1)+'ву'
end

if (((@FIO='Антон') or (@FIO='Колесник') or (@FIO='Гребеник'))and(@fl=0)and(@kind=2))
begin
set @fl=1
select @res=@FIO
end

if (((SELECT RIGHT(@FIO,2))='ик')and(@fl=0)and(@kind=2))
begin
set @fl=1
select @res=@FIO+'у'
end

if (((SELECT RIGHT(@FIO,2))='ха')and(@fl=0)and(@kind=2))
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-2)+'хе'
end

if (((SELECT RIGHT(@FIO,2))='на')and(@fl=0)and(@kind=2))
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-2)+'ной'
end
if (((SELECT RIGHT(@FIO,1))='н')and(@fl=0)and(@kind=2))
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-1)+'ну'
end

if (((SELECT RIGHT(@FIO,3)) in ('кая','ная','вая'))and(@fl=0)and(@kind=2))
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-2)+'ой'
end
if (((SELECT RIGHT(@FIO,3))in ('кий','ный','рый'))and(@fl=0)and(@kind=2))
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-2)+'ому'
end


--ИМЯ
if (((SELECT RIGHT(@FIO,1)) in ('й','ь'))and(@fl=0)and(@kind=1))  --имя муж. на "-й"
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-1)+'ю'
end

if (((SELECT RIGHT(@FIO,2)) in ('на','да','са','ла','та','ва','ра',
                                'за','ба','ма','па','фа','ца'))and(@fl=0)and(@kind=1))  --имя жен
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-1)+'е'
end

if (((SELECT RIGHT(@FIO,2)) in ('га','жа','ка','ха','ча','ша','ща'))and(@fl=0)and(@kind=1)) --имя жен.
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-1)+'е'
end

if (((SELECT RIGHT(@FIO,1)) in ('л','б','в','г','д','ж','з','к','м','н','п','р','с','т',
                                'ф','х','ц','ч','ш','щ'))and(@fl=0)and(@kind=1))   --имя муж. на согласную
begin
set @fl=1
select @res=@FIO+'у'
end

if (((SELECT RIGHT(@FIO,1)) in ('я'))and(@fl=0)and(@kind=1))  --имя жен. "Юлия"
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-1)+'е'
end

--ОТЧЕСТВО
if (((SELECT RIGHT(@FIO,2)) in ('ич'))and(@fl=0)and(@kind=3)) --отчество муж
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-2)+'ичу'
end

if (((SELECT RIGHT(@FIO,2)) in ('на'))and(@fl=0)and(@kind=3)) --отчество жен
begin
set @fl=1
select @res=LEFT(@FIO, LEN(@FIO)-2)+'не'
end

if (@FIO='Лев')
 select @res='Льву'

if (@FIO='Павел')
 select @res='Павлу'

if (@FIO='Любовь')
 select @res='Любови'

if (@FIO='Гузель')
 select @res='Гузели'

if (@fl=0)             --специф.
  select @res=@FIO
return @res
END
