/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.ReturnWorkerSchedule;

*/

CREATE PROCEDURE `ReturnWorkerSchedule`()
select WorkerSchedule.ID
		 , concat(Person.LastName, ', ' , Person.FirstName) as Worker
		, Person.FirstName
		, Person.LastName
		, Person.ID as Worker_ID
		, Date_Format(WorkerSchedule.Day,'%m-%d-%Y') as Day
		, Time_Format(WorkerSchedule.TimeIn,'%h:%i %p') as TimeIn
		, Time_Format(WorkerSchedule.TimeOut,'%h:%i %p') as TimeOut
		, WorkerSchedule.Hours as Hours
		, SupSchedule.Person_ID as Supervisor_ID
	From Person
	Join(Select Schedule.*
	         From Schedule
	             Join Person on Schedule.Person_ID = Person.ID
	         Where Role_ID = 'jan'
	         ) as WorkerSchedule on WorkerSchedule.Person_ID = Person.ID
	Left Join(
	     Select Schedule.*
	     From Schedule
	         Join Person on Schedule.Person_ID = Person.ID
	     Where Role_ID = 'sup'
	     ) as SupSchedule on SupSchedule.Zone_ID = WorkerSchedule.Zone_ID
	         and SupSchedule.Day = WorkerSchedule.Day
	Where
		WorkerSchedule.TimeIn < SupSchedule.TimeOut
		and TimeDiff(WorkerSchedule.TimeIn, SupSchedule.TimeIn) <= '2:00:00'
	Order by Person.LastName, Day

