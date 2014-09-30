/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.updateWorkerSchedule;

*/

CREATE PROCEDURE updateWorkerSchedule (IN ScheduleID INT, IN Day VARCHAR(10),  IN tmTimeIn Time, IN tmTimeOut Time, In strZone VarChar(25))
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
			, Zone_ID = strZone
		Where Schedule.ID = ScheduleID;	
End

