/*
Highlight and execute the following statement to drop the trigger
before executing the create statement.

DROP TRIGGER htcStateFair.insertScheduleHours;

*/

CREATE TRIGGER insertScheduleHours BEFORE INSERT ON Schedule FOR EACH ROW Begin
	Declare fltHours float;

	Set fltHours = Round(time_to_sec(TimeDiff(New.TimeOut,New.TimeIn))/3600,2);
	
	if (fltHours<0) then
		Set fltHours = 24 + fltHours;
	End If;

	Set New.Hours = fltHours;
End

