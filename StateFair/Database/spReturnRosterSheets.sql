/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.ReturnRosterSheets;

*/

CREATE PROCEDURE `ReturnRosterSheets`(IN dtDay DATE, IN intSupervisor INT(10))
Begin

	select  Distinct
		vwSupSchedule.Supervisor
	, concat(Zone2.ID, ' - ' ,Zone2.Description ) as SupZone
	, concat(Time_Format(vwSupSchedule.TimeIn, '%h:%i'), ' - ',Time_Format(vwSupSchedule.TimeOut, '%h:%i %p')) as SupShift
	, vwWorkerSchedule.Worker
	 , Date_Format(vwWorkerSchedule.Day,'%m-%d-%Y') as Day 
	 , concat(Time_Format(vwWorkerSchedule.TimeIn, '%h:%i'), ' - ',Time_Format(vwWorkerSchedule.TimeOut, '%h:%i %p')) as Shift
	 , concat('../../images/jpg/',FirstName,'_',LastName,'.jpg') as PicPath
	 , concat(vwWorkerSchedule.Zone_ID, ' - ',Zone.Description) as Zone
	From vwWorkerSchedule 
		left Join vwSupSchedule on vwSupSchedule.Zone_ID = vwWorkerSchedule.Zone_ID 
			and vwSupSchedule.Day = vwWorkerSchedule.Day 
			and vwWorkerSchedule.TimeOut >= vwSupSchedule.TimeIn
			and vwWorkerSchedule.TimeIn <= vwSupSchedule.TimeOut 
		Left Join Zone on vwWorkerSchedule.Zone_ID = Zone.ID
		Left Join Zone as Zone2 on vwSupSchedule.Zone_ID = Zone2.ID	
	Where  
		vwSupSchedule.Day = dtDay
		and vwSupSchedule.Worker_ID = intSupervisor
		and timediff(vwSupSchedule.TimeOut,vwWorkerSchedule.TimeIn) > '02:00:00'
		and timediff(vwWorkerSchedule.TimeOut, vwSupSchedule.TimeIn) > '02:00:00'
	Order by  Zone,vwWorkerSchedule.TimeIn,Worker;
		
End

