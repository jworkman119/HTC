/*
	drop procedure returnDaysWorked
*/

Create Procedure returnDaysWorked(Worker int)

Select Time.ID 
	, Date_Format(Time.TimeIn,'%m-%d-%Y') as Day
	, Time_Format(Time.TimeIn,'%h:%i %p') as TimeIn
	, Time_Format(Time.TimeOut,'%h:%i %p') as TimeOut
from Person
	Join Time on Person.ID = Time.Person_ID
Where Person.ID = Worker

