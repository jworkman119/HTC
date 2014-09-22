Select Person.ID 
	,  Person.Firstname + ' ' + Person.LastName as FullName
	, Person.Firstname
	, Person.LastName
	, Role.Description as Role
	
from person
	join Role on person.Role_ID = Role.ID
where (under18 = 'false' or under18 is NULL)
	and picpath is null
order by firstname

/*
Select Person.ID 
	, Person.Firstname
	, Person.LastName
	, Role.Description as Role
from person
	join Role on person.Role_ID = Role.ID
where (under18 = 'true')
	and picpath is not null
order by firstname
*/




