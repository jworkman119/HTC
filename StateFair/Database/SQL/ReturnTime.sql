select Time.ID 
	, concat(Person.LastName,', ',Person.FirstName) as Worker
	, Person.FirstName
	, Person.LastName
	, Date_Format(TimeIn,'%m/%d/%Y %h:%i %p') as TimeIn
	, Date_Format(TimeOut,'%m/%d/%Y %h:%i %p') as TimeOut 
from Time
	join Person on Time.Person_ID = Person.ID
	Order by LastName, TimeOut
	
	
SELECT Time.ID
, Person.ID as WorkerID
, concat(Person.LastName, ', ' , Person.FirstName) as Worker
, Person.FirstName, Person.LastName
, Person.ID as Worker_ID
, Date_Format(TimeIn,'%m/%d/%Y %h:%i %p') as TimeIn 
FROM Time 
	Join Person on Time.Person_ID = Person.ID 
Order by LastName, TimeOut