/*
drop table tempTotalHours
*/
 

Create Table tempTotalHours

as

SELECT  Person.ID AS Person_Id
	, Person.Role_ID
	, Person.Disabled
	, Case Person.Disabled
		When 1 then
			0
		Else
			1
		end as NonDisabled
	, TotalTime.TotalHours
	, Case 
			When LaborDay.TotalHours is NULL then
				TotalTime.TotalHours
			Else
				TotalTime.TotalHours - LaborDay.TotalHours
			End as NonLaborDay
	, LaborDay.TotalHours as LaborDay
from Person
	Join (
		Select Person_ID
		, sum(Round(time_to_sec(TimeDiff(Time.TimeOut,Time.TimeIn))/3600,2)) AS TotalHours
		From Time
		Group By Person_ID
	)
	as  TotalTime on Person.ID = TotalTime.Person_ID
	Left Join
	(
		Select Person_ID
		, sum(Round(time_to_sec(TimeDiff(Time.TimeOut,Time.TimeIn))/3600,2)) AS TotalHours
		From Time
		Where 
			Date(Time.TimeOut) = '2012-09-03'
		Group By Person_ID
	) as LaborDay on Person.ID = LaborDay.Person_ID
group by Person.ID
	, Person.Role_ID
	, Person.Disabled 
order by Person.ID;
