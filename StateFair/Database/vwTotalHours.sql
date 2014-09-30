/*
DROP VIEW htcStateFair.vwTotalHours;
*/
CREATE VIEW vwTotalHours 

AS 

SELECT  Time.Person_ID AS Person_Id
	, Person.Role_ID
	, Person.Disabled
	,sum(Round(time_to_sec(TimeDiff(TimeOut,TimeIn))/3600,2)) AS TotalHours 
from Time
	Join Person on Time.Person_ID = Person.ID 
group by Person_ID 
order by Person_ID;
