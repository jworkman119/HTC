/*
	Drop Procedure deleteSchedule_Auto
*/

Create Procedure deleteSchedule_Auto(dtDay Date,strSheet varchar(25))
Begin
	Declare ShiftStart Time;
	Declare ShiftEnd Time;

	if(strSheet = 'Morning') then
		set ShiftStart = '05:00';
		set ShiftEnd = '12:00';
	elseif(strSheet = 'Evening')then		
		set ShiftStart = '12:00';
		set ShiftEnd = '23:59';
	elseif(strSheet = 'Overnight')then
		set ShiftStart = '00:00';
		set ShiftEnd = '5:00';		
	end if;

	Delete from Schedule
	Where Schedule.Day= dtDay
		and Schedule.TimeIn >= ShiftStart
		and Schedule.TimeIn<= ShiftEnd;
		
End

