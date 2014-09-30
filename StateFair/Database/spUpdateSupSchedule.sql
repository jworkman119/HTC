/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.updateSupSchedule;

*/

CREATE PROCEDURE updateSupSchedule (IN ScheduleID INT(10), IN Day VARCHAR(10), IN tmTimeIn TIME, IN tmTimeOut TIME, IN Zone varchar(35))
Begin
	Declare intWorker int;
	Declare fltHours float;
	
	Set fltHours = Round(time_to_sec(TimeDiff(tmTimeOut,tmTimeIn))/3600,2);
	
	if (fltHours<0) then
		Set fltHours = 24 + fltHours;
	End If;
		
	-- Inserting into db
		Update Schedule
		Set Day = Date_Format(Day,'%Y-%m-%d') 
			, TimeIn = tmTimeIn
			, TimeOut = tmTimeOut
			, Hours = fltHours
			, Zone_ID = Zone
		Where Schedule.ID = ScheduleID;	
End

