/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.ScheduleVsPunches;

*/

CREATE PROCEDURE `ScheduleVsPunches`(IN dtDay DATE)
Begin

	SELECT concat(vwWorkerSchedule.LastName,', ' , vwWorkerSchedule.FirstName) as Worker
	, concat(Time_Format(vwWorkerSchedule.TimeIn,'%h:%i %p'), ' - ',Time_Format(vwWorkerSchedule.TimeOut,'%h:%i %p')) as Scheduled
	, Date_Format(Time.TimeIn, '%c-%d-%y %h:%i %p') as TimeIn
	, Date_Format(Time.TimeOut, '%c-%d-%y %h:%i %p') as TimeOut
	,  Round(time_to_sec(TimeDiff(Time.TimeOut,Time.TimeIn))/3600,2) as TotalHours
	from vwWorkerSchedule
		left join Time on vwWorkerSchedule.Worker_ID = Time.Person_ID
			and date(Time.TimeIn) = dtDay
	where vwWorkerSchedule.day = dtDay
	
	
	Union
	
	Select vwSupSchedule.Supervisor as Worker

	, concat(Time_Format(vwSupSchedule.TimeIn,'%h:%i %p'), ' - ',Time_Format(vwSupSchedule.TimeOut,'%h:%i %p')) as Scheduled
	, Date_Format(Time.TimeIn, '%c/%d/%y %h:%i %p') as TimeIn
	, Date_Format(Time.TimeOut, '%c/%d/%y %h:%i %p') as TimeOut
	,  Round(time_to_sec(TimeDiff(Time.TimeOut,Time.TimeIn))/3600,2) as TotalHours
	from vwSupSchedule
		left join Time on vwSupSchedule.Worker_ID = Time.Person_ID
			and date(Time.TimeIn) = dtDay
	where vwSupSchedule.Day = dtDay


	Union
	
	select concat(Person.LastName, ', ', Person.FirstName) as Person

	, '' as Scheduled
	, Date_Format(Time.TimeIn, '%c/%d/%y %h:%i %p') as TimeIn
	, Date_Format(Time.TimeOut, '%c/%d/%y %h:%i %p') as TimeOut
	,  Round(time_to_sec(TimeDiff(Time.TimeOut,Time.TimeIn))/3600,2) as TotalHours
	from Time
		Join Person on Time.Person_ID = Person.ID
	Where Date(Time.TimeIn)= dtDay
	and Person.ID Not In (
							Select Person_ID
							From Schedule
							where Day = dtDay
							)
	Order by  Worker;

End

