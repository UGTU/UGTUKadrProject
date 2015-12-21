create function [ShemaTabel].[GetTimeShedulerForDepartnment]
	(@idDepartment int, @DatePeriodStart date, @DatePeriodEnd date)
returns @ResultTab table
		(IdFactStaff int,
		 Date date,
		 IdDayStatus int,
		 PlanKolHout float,
		 IdWorkShedule int
		)
as
begin
declare @IdFactStaff int;
declare @cursor cursor
--Выбираем в курсор всех работников числящихся в заданом отделе
set @cursor=CURSOR SCROLL for
	select distinct idFactStaff from ShemaTabel.GetFactStaffForTimeSheet (@DatePeriodStart,@DatePeriodEnd)
		where idDepartment=@idDepartment
open @Cursor	
FETCH NEXT FROM @CURSOR into @IdFactStaff
WHILE @@FETCH_STATUS = 0 
begin
	--Вызываем процедуру получения граффика работы для работника для каждого работника отдела
	insert into @ResultTab select*from ShemaTabel.GetTimeShedulerPerson(@IdFactStaff,@DatePeriodStart,@DatePeriodEnd)
	FETCH NEXT FROM @CURSOR into @IdFactStaff
end
return
end
