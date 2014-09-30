/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.updateSchedule_Manually;

*/

CREATE PROCEDURE updateSchedule_Manually(ScheduleID int, dtTimeIn varchar(50), dtTimeOut varchar(50), ZoneID varchar(50))
Begin

		Update Schedule
		Set TimeIn = dtTimeIn
			, TimeOut = dtTimeOut
			, Zone_ID = ZoneID
		Where ID = ScheduleID;
		
		Select Schedule.ID 
			, Time_Format(Schedule.TimeIn,'%h:%i %p') as TimeIn
			, Time_Format(Schedule.TimeOut,'%h:%i %p') as TimeOut
			, Hours
			, concat(Zone.ID, ' - ', Zone.Description) as Zone
		From Schedule
			Join Zone on Zone.ID = Schedule.Zone_ID			
		Where Schedule.ID = ScheduleID;

	
End

