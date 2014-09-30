select concat(Person.LastName, ', ',Person.FirstName) as Person
	, Role.Description as Role
	, TotalHours
from vwTotalHours
	Join Person on vwTotalHours.Person_Id = Person.ID
	Join Role on Role.ID = Person.Role_ID
Where TotalHours>0
Order by Role, Person

Select sum(TotalHours) as TotalHours
	, Count(Person_ID) as TotalWorkers
	, Role.Description as Role
from vwTotalHours	
	Join Person on vwTotalHours.Person_ID = Person.ID
	Join Role on Person.Role_ID = Role.ID
Where TotalHours>0
group by Role.Description

