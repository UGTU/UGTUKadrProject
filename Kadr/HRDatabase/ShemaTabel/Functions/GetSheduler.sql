create function [ShemaTabel].[GetSheduler](@IdWorkShedule int,@isPPS bit,
	@FirstDate date,@LastDate date)
	returns @ResultTab table
		(IdDayStatus int,
		 Date date,
		 KolHourMPS float,
		 KolHourMNS float,
		 KolHourGPS float,
		 KolHourGNS float,
		 IdWorkShedule int
		)
as
begin
--Объявляем переменные для инициализации их в курсоре
		 declare @IdDayStatus int,
		 @Date date,
		 @KolHourMPS float,
		 @KolHourMNS float,
		 @KolHourGPS float,
		 @KolHourGNS float,
		 @cursor cursor,
		 @temp int
--Инициализируем курсор
set @cursor=CURSOR SCROLL for 
	select IdDayStatus ,FirstEventDate ,KolHourMPS ,KolHourMNS ,
		KolHourGPS , KolHourGNS 
		from ShemaTabel.EventSuperType est 
		inner join ShemaTabel.WorkSheduleEvent wse on est.id=wse.idEventSuperType
		where wse.idShedule=@IdWorkShedule and wse.IsPPS=@isPPS --Выбираем дни недели для указаной во входном параметре рабочей недели
		set @Date=@FirstDate
		set @temp=DATEDIFF(week,'1.1.2011',@FirstDate)-1;--считаем количество недель между началом года (задаными днями недели)
while @Date<@LastDate --пока дата меньше даты конца периода	
begin
open @Cursor
--инициализация переменных	
FETCH NEXT FROM @CURSOR into @IdDayStatus ,
								@Date ,@KolHourMPS ,@KolHourMNS ,@KolHourGPS , @KolHourGNS
WHILE @@FETCH_STATUS = 0 
begin
--перебор дней недели
	set @Date=DATEADD(week,@temp,@Date)--считаем дату как дата первого в году дня недели + кол-во
			--недель до периода 
	--переопределяем данные если текущаяя дата имеется в исключениях
	select @IdDayStatus = IdDayStatus,@KolHourMPS=KolHourMPS ,@KolHourMNS=KolHourMNS,
		 @KolHourGPS=KolHourGPS, @KolHourGNS=KolHourGNS  
		from ShemaTabel.Exception where DateException=@Date and idWorkShedule=@IdWorkShedule
	if @Date between @FirstDate and @LastDate--если дата лежит в периоде то заносим в результирующую таблицу
	begin
		insert into @ResultTab
		values(@IdDayStatus ,
				@Date ,@KolHourMPS ,@KolHourMNS ,@KolHourGPS , @KolHourGNS, @IdWorkShedule)
	end
	FETCH NEXT FROM @CURSOR into @IdDayStatus ,
								@Date ,@KolHourMPS ,@KolHourMNS ,@KolHourGPS , @KolHourGNS 
end
close @Cursor
set @temp=@temp+1--наращивание счётчика недель
end
return 
end

