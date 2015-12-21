create function [ShemaTabel].[GetTimeShedulerPerson] (@idFactStuff int, @DadePeriodBegin date, @DatePeriodEnd date)
	returns @ResultTab table
		(IdFactStaff int,
		 Date date,
		 IdDayStatus int,
		 PlanKolHout float,
		 IdWorkShedule int
		)
as
begin
declare @IdSheduler int;
declare @SexBit bit;
declare @IsPPS bit;
declare @IdCategry int;
declare @StaffCount float;
--определяем пол, ставку и рабочую неделю работника
select @IdSheduler=idSheduler,@SexBit=SexBit,@StaffCount=StaffCount,@IdCategry=idCategory from ShemaTabel.GetFactStaffForTimeSheet (@DadePeriodBegin,@DatePeriodEnd) 
	where idFactStaff=@idFactStuff
if(@IdCategry=2) set @IsPPS = 1 else set @IsPPS = 0
if (@IsPPS=1 and @StaffCount=1)
--Если Профессорско преподавательский состав полная ставка
begin
	insert into @ResultTab 
	select idFactStaff,Date,IdDayStatus,KolHourGPS*StaffCount,IdWorkShedule
		from ShemaTabel.GetFactStaffForTimeSheet (@DadePeriodBegin,@DatePeriodEnd)  gfst
		inner join ShemaTabel.GetSheduler(@IdSheduler,@IsPPS,@DadePeriodBegin,@DatePeriodEnd) gs
		on gs.IdWorkShedule=gfst.idSheduler
		where idFactStaff=@idFactStuff and date>=DateBegin and date<=DateEnd or DateEnd=null
		order by Date
		return
END
if (@IsPPS=1 and @StaffCount!=1)
--Если Профессорско преподавательский состав не полная ставка
begin
	insert into @ResultTab 
	select idFactStaff,Date,IdDayStatus,KolHourGNS*StaffCount,IdWorkShedule
		from ShemaTabel.GetFactStaffForTimeSheet (@DadePeriodBegin,@DatePeriodEnd)  gfst
		inner join ShemaTabel.GetSheduler(@IdSheduler,@IsPPS,@DadePeriodBegin,@DatePeriodEnd) gs
		on gs.IdWorkShedule=gfst.idSheduler
		where idFactStaff=@idFactStuff and date>=DateBegin and date<=DateEnd or DateEnd=null
		order by Date
		return
END
--Если не полная ставка и пол мужской
if (@StaffCount!=1 and @SexBit=1)
begin
	insert into @ResultTab 
	select idFactStaff,Date,IdDayStatus,KolHourMNS*StaffCount,IdWorkShedule
		from ShemaTabel.GetFactStaffForTimeSheet (@DadePeriodBegin,@DatePeriodEnd)  gfst
		inner join ShemaTabel.GetSheduler(@IdSheduler,@IsPPS,@DadePeriodBegin,@DatePeriodEnd) gs
		on gs.IdWorkShedule=gfst.idSheduler
		where idFactStaff=@idFactStuff and date>=DateBegin and date<=DateEnd or DateEnd=null
		order by Date
		return
end
if (@StaffCount=1 and @SexBit=1)
--Если полная ставка и пол мужской
begin
	insert into @ResultTab 
	select idFactStaff,Date,IdDayStatus,KolHourMPS*StaffCount,IdWorkShedule
		from ShemaTabel.GetFactStaffForTimeSheet (@DadePeriodBegin,@DatePeriodEnd)  gfst
		inner join ShemaTabel.GetSheduler(@IdSheduler,@IsPPS,@DadePeriodBegin,@DatePeriodEnd) gs
		on gs.IdWorkShedule=gfst.idSheduler
		where idFactStaff=@idFactStuff and date>=DateBegin and date<=DateEnd or DateEnd=null
		order by Date
		return
END
--Если не полная ставка и пол женский
if (@StaffCount!=1 and @SexBit=0)
begin
	insert into @ResultTab 
	select idFactStaff,Date,IdDayStatus,KolHourGNS*StaffCount,IdWorkShedule
		from ShemaTabel.GetFactStaffForTimeSheet (@DadePeriodBegin,@DatePeriodEnd)  gfst
		inner join ShemaTabel.GetSheduler(@IdSheduler,@IsPPS,@DadePeriodBegin,@DatePeriodEnd) gs
		on gs.IdWorkShedule=gfst.idSheduler
		where idFactStaff=@idFactStuff and date>=DateBegin and date<=DateEnd or DateEnd=null
		order by Date
		return
end
--Если полная ставки и пол женский
if (@StaffCount=1 and @SexBit=0)
begin
	insert into @ResultTab 
	select idFactStaff,Date,IdDayStatus,KolHourGPS*StaffCount,IdWorkShedule
		from ShemaTabel.GetFactStaffForTimeSheet (@DadePeriodBegin,@DatePeriodEnd)  gfst
		inner join ShemaTabel.GetSheduler(@IdSheduler,@IsPPS,@DadePeriodBegin,@DatePeriodEnd) gs
		on gs.IdWorkShedule=gfst.idSheduler
		where idFactStaff=@idFactStuff and date>=DateBegin and date<=DateEnd or DateEnd=null
		order by Date
		return
end
return
end