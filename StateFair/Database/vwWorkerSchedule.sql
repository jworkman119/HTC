/*
	drop view vwWorkerSchedule
*/
CREATE  VIEW vwWorkerSchedule 

AS 
	select 	Schedule.ID AS Id 
		, concat(Person.FirstName,' ',Person.LastName) AS Worker
		, Person.FirstName
		, Person.LastName
		,Person.ID AS Worker_ID
		, Person.PicPath
		,Schedule.Day AS Day
		,Schedule.TimeIn AS TimeIn
		,Schedule.TimeOut AS TimeOut
		,Schedule.Zone_ID AS Zone_ID
		,Schedule.Hours AS Hours 
	from (Schedule 
		join Person on((Schedule.Person_ID = Person.ID))) 
	where (Person.Role_ID = 'jan')




			  
