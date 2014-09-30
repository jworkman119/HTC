CREATE TRIGGER insertStagingTime AFTER INSERT ON stagingTime FOR EACH ROW Begin
	
	Declare TimeID int;
	Declare NewTimeID int;
	
	Set TimeID = (Select Time.ID
				 From Time
				 Where Time.TimeOut is null
					and Time.Person_ID = new.Person_ID
					and time_to_sec(TimeDiff(New.Time,Time.TimeIn))/3600 <= 18
				order by Time.TimeIn
				Limit 1);
				
		
				
	If (TimeID is not null) then
		Update Time
		Set Time.TimeOut = New.Time
			, Time.stagingTimeOut_ID = New.Id
		Where Time.ID = TimeID;
	Else
		Insert into Time(Person_ID,TimeIn,stagingTimeIn_ID)
		Values(New.Person_ID, New.Time, New.ID);
				
	End If;
	

End