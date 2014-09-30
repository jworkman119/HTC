drop Procedure ScheduleVsPunches

Create Procedure ScheduleVsPunches(dtDay Date)
Begin


	select concat(Person.FirstName, ' ', Person.LastName) as Person
		, Schedule.Day as ScheduleDay	
		, Shift.Name as Shift
		, Shift.TimeIn as ShiftStart
		, Date_Format(Time.TimeIn, '%c/%d/%y %h:%i %p') as TimeIn
		, Date_Format(Time.TimeOut, '%c/%d/%y %h:%i %p') as TimeOut
		, TimeDiff(Time.TimeOut, Time.TimeIn) as TimeWorked
	from Person
		Join Schedule on Schedule.Person_ID = Person.ID
		left Join Time on Time.Person_ID = Person.ID
		Join Shift on Schedule.Shift_ID = Shift.ID
	where Schedule.Day = dtDay
		and Date(Time.TimeIn) = dtDay

	
	Union	


	select concat(Person.FirstName, ' ', Person.LastName) as Person
			, Schedule.Day as ScheduleDay	
			, Shift.Name as Shift
			, Shift.TimeIn as ShiftStart
			, Date_Format(Time.TimeIn, '%c/%d/%y %h:%i %p') as TimeIn
			, Date_Format(Time.TimeOut, '%c/%d/%y %h:%i %p') as TimeOut
			, TimeDiff(Time.TimeOut, Time.TimeIn) as TimeWorked
		from Person
			Join Schedule on Schedule.Person_ID = Person.ID
			left Join Time on Time.Person_ID = Person.ID
			Join Shift on Schedule.Shift_ID = Shift.ID
		where Schedule.Day = dtDay
			and Time.TimeIn >= concat(dtDay -1,' ', '23:00:00')
			and Time.TimeIn <= concat(dtDay, ' ', '04:00:00')
			and Shift.TimeIn = '00:00:00'


	Union
	
	select concat(Person.FirstName, ' ', Person.LastName) as Person
			, Schedule.Day as ScheduleDay	
			, Shift.Name as Shift
			, Shift.TimeIn as ShiftStart
			, Date_Format(Time.TimeIn, '%c/%d/%y %h:%i %p') as TimeIn
			, Date_Format(Time.TimeOut, '%c/%d/%y %h:%i %p') as TimeOut
			, TimeDiff(Time.TimeOut, Time.TimeIn) as TimeWorked
		from Schedule
			Join Person on Schedule.Person_ID = Person.ID
			left Join Time on Time.Person_ID = Person.ID
			Join Shift on Schedule.Shift_ID = Shift.ID
		where Schedule.Day = dtDay
			and Time.TimeIn is NULL
	Order by ShiftStart, Person, TimeIn;
End;
	
call ScheduleVsPunches('2011-08-31')
