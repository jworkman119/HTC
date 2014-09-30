/*
	drop procedure checkPunchIns
*/
create procedure htcStateFair.checkPunchIns (IN dtDay DATE)


	select concat(Person.FirstName, ' ',Person.LastName) as Person
		, TimeStamp(Schedule.Day,Schedule.TimeIn) TimeIn
		, Schedule.TimeOut
		, Time.TimeIn
		, Time.TimeOut
		, TimeDiff(Time.TimeIn, TimeStamp(Schedule.Day, Schedule.TimeIn)) as TimeIn_Difference
	from Time
		Join Schedule on Time.Person_ID = Schedule.Person_ID
		Join Person on Time.Person_ID = Person.ID
	where Date(Time.TimeOut) = dtDay
		and Schedule.Day = dtDay
		and TimeDiff(Time.TimeIn, TimeStamp(Schedule.Day, Schedule.TimeIn)) > '01:00:00';
