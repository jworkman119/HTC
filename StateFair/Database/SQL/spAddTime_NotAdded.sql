drop procedure AddTime_NotAdded

CREATE PROCEDURE AddTime_NotAdded (IN PersonID INT(10), IN TimeGiven DATETIME)
Begin	

	Declare TimeID int;
	Declare TimeDiff_In double;
	Declare TimeDiff_Out double;


	Select Time.ID
		, Now() - Time.TimeIn
		, Now() - Time.TimeOut 
	into TimeID, TimeDiff_In,TimeDiff_Out	
	From Time
		join Person on Time.Person_ID = Person.ID
	where Time.Person_ID = PersonID
		and (date(Now()) = date(Time.TimeIn)
			or date(Now()) = date(Time.TimeIn)
		)
	order by Time.id desc
	Limit 1;

		
	if ((TimeDiff_In >= 500 and TimeDiff_Out is NULL) OR TimeDiff_Out >= 500 OR TimeID is NULL) Then
		
		If (TimeDiff_Out is NULL and TimeDiff_In is Not Null) Then
			Update Time
				Join Person on Time.Person_ID = Person.ID
			Set Time.TimeOut = TimeGiven
			where Time.ID = TimeID
				and Person.ID = Time.Person_ID;
									
			Select Time.ID
				, Time.Person_ID
				, concat(Person.FirstName, ' ', Person.LastName) as Person
				, TimeDiff_In
				, Time.TimeIn as TimeIn
				, Time.TimeOut as TimeOut
				, 'Out' as Status
			from Time
				join Person on Time.Person_ID = Person.ID
			where Time.ID = TimeID;
		else
			Insert into Time(Time.Person_ID, Time.TimeIn)
				Select Person.ID, TimeGiven
				From Person
				Where Person.ID = PersonID;
		
			Select Time.ID
				, Time.Person_ID
				, concat(Person.FirstName, ' ', Person.LastName) as Person
				, TimeDiff_In
				, Time.TimeIn as TimeIn
				, Time.TimeOut as TimeOut
				, 'In' as Status 
			From Time
				join Person on Time.Person_ID = Person.ID
			Where Time.TimeOut is NULL
				and Time.Person_ID = PersonID;
		End If;
	else 
		Select 'Double-Swipe' as Status;
	End if;
End