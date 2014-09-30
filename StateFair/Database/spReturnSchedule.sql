/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.returnSchedule;

*/

CREATE  PROCEDURE `returnSchedule`(IN Worker INT(10))
Select Distinct concat(Person.FirstName, ' ' , Person.LastName) as Person
	, Date_Format(Schedule.Day,'%m-%d-%Y') as Day
		, Time_Format(Schedule.TimeIn,'%h:%i %p') as TimeIn
		, Time_Format(Schedule.TimeOut,'%h:%i %p') as TimeOut
	, concat(Zone.ID , ' - ' , Zone.Description) as Zone
from Person
	Join Schedule on Person.ID = Schedule.Person_ID
	Left Join Zone on Schedule.Zone_ID = Zone.ID
Where Person.ID = Worker
Order By Day

