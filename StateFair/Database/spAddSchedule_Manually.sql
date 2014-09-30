/*
Highlight and execute the following statement to drop the procedure
before executing the create statement.

DROP PROCEDURE htcStateFair.addSchedule_Manually;

*/

CREATE PROCEDURE addSchedule_Manually(PersonID int, Day VARCHAR(10), TimeIn TIME, TimeOut TIME, Zone varchar(25))
Begin
Declare LastID int;

	-- Inserting into db
		Insert Into Schedule(Person_ID, Day,TimeIn, TimeOut, Zone_ID)
		Values (PersonID ,Date_Format(Day,'%Y-%m-%d') ,TimeIn, TimeOut, Zone);

		Set LastId = Last_Insert_ID();
		
		Select Schedule.ID
			, Time_Format(Schedule.TimeIn,'%h:%i %p') as TimeIn
			, Time_Format(Schedule.TimeOut,'%h:%i %p') as TimeOut
			, Schedule.Hours
			, concat(Zone.ID, ' - ', Zone.Description) as Zone
		from Schedule
			Join Zone on Schedule.Zone_ID = Zone.ID
		Where Schedule.ID = LastID
			and Schedule.Person_ID = PersonID;
		
End

