-- drop procedure DownloadSchedule
Create Procedure htcStateFair.DownloadSchedule(In dtStart Date, In dtEnd Date)

	Select Case 
	When (Schedule.TimeIn>='23:00:00' or Schedule.TimeIn<'05:30:00') then
		'Overnight'
	When (Schedule.TimeIn>='05:30:00' and Schedule.TimeIn<'12:00:00') then
		'Morning'
	When (Schedule.TimeIn>='12:00:00' and Schedule.TimeIn<'23:00:00') then
		'Night'
	End as Shift
	, Schedule.Day
	, Schedule.Zone_ID
	, Schedule.TimeIn
	, Schedule.TimeOut
	, concat(Person.FirstName, ' ' ,Person.LastName) as Person
	, Role.Description as Role
	From Schedule
		Join Person on Person.ID = Schedule.Person_ID
		Join Zone on Zone.ID = Schedule.Zone_ID
		Join Role on Person.Role_ID= Role.ID
	Where Schedule.Day >= dtStart
		and Schedule.Day <= dtEnd
	order by Day,Shift,Zone_ID,TimeIn,TimeOut, Role desc;
