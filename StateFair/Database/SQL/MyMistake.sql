select *
from Time
where Person_Id >=7000
and Person_ID < 10000
and Person_ID not in
(select ID
from Person
where
 ID >=7000
 and ID <=10000
)
Order by Person_ID, TimeIn

select *
from Schedule
where Person_ID = 7799

select *
from Job 
where id = 233142




Select Schedule.Person_ID 
	, concat(Person.LastName, ', ' , Person.FirstName) as Person
	, Schedule.Day
from Schedule
	left Join Person on Person.ID = Schedule.Person_ID
Where shift_id = 23
and Day >='2011-08-25' 
and Day<='2011-08-29'
and Schedule.Supervisor_ID = 10334
and Job_ID = 233142
order by Person, Day


select *
from Time
where Person_ID in (3635,3856,3934)



select *
from Person
where concat(Person.FirstName, ' ' , Person.Lastname)
in
( 'Lonnie Bradford'
 , 'Edward Oliver'
 , 'Elaine Stallworth'
 )



select Person.ID
	, concat(Person.FirstName, ' ' , Person.LastName) as Person
from Person
where ID
Not in (Select Person_ID
		From Time)
order by Person.ID		