/*

  drop view vwSupSchedule
*/

CREATE VIEW vwSupSchedule 

AS 

Select concat(Person.FirstName,' ',Person.LastName) AS Supervisor
  ,Person.ID AS Worker_ID
  ,Schedule.ID AS Schedule_Id
  ,Schedule.Day AS Day
  ,Schedule.TimeIn AS TimeIn
  ,case
  	When Schedule.TimeOut ='00:00:10' Then
  		'23:59'
  	Else
  		Schedule.TimeOut
   End AS TimeOut
  ,Schedule.Zone_ID AS Zone_ID
  ,Schedule.Hours AS Hours 
From Schedule 
  Join Person on Schedule.Person_ID = Person.ID
Where Person.Role_ID = 'sup'

