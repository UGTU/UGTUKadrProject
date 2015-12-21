CREATE proc [ShemaTabel].[CreateTimeSheet]
	@idDepartment int,
	@idCrater int,
	@DateBeginPeriod date,
	@DateEndPeriod date,
	@DateComposition date,
	@IdTimeSheet int output
as
	--declare @IdTimeSheet int
	begin tran 
	BEGIN TRY
		insert into ShemaTabel.TimeSheet
		values(	@idDepartment,@idCrater,@DateBeginPeriod,@DateEndPeriod,@DateComposition,NEWID(),1)
		set @IdTimeSheet=@@IDENTITY
		insert into ShemaTabel.TimeSheetRecord
		select Date,PlanKolHout,@IdTimeSheet,IdDayStatus,IdFactStaff,0 
			from ShemaTabel.GetTimeShedulerForDepartnment(@idDepartment,@DateBeginPeriod,@DateEndPeriod)
		commit tran
	end try
	begin catch
		raiserror('Процедура завершилась неудачей, табель не составлен!',10,15)
		rollback tran
	end catch	