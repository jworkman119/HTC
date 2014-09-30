
CREATE PROCEDURE ReturnSchedule()
Begin
	Set @rank=0;
	SELECT @rank:=@rank+1 AS rank 
		, Person.ID as Worker_ID
		, concat(Person.LastName, ', ' , Person.FirstName) as Worker
		, Person.LastName
		, Person.FirstName
		, Schedule.ID as Schedule_ID
		, Date_Format(Day,'%m/%d/%Y') as Day
		, Shift.Name as Shift, concat(Supervisor.LastName,', ') as Supervisor
	FROM Schedule 
		Join Person on Schedule.Person_ID = Person.ID 
		Join Shift on Schedule.Shift_ID = Shift.ID 
		Join Person as Supervisor on Supervisor.ID = Schedule.Supervisor_ID;
End



