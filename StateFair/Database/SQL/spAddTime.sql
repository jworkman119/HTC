Drop Procedure AddTime

CREATE PROCEDURE AddTime (IN PersonID INT(10))
Begin	

	Declare TimeID int;
	Declare TimeDiff_In Time;
	Declare TimeDiff_Out Time;

			
	Select Time.ID
		, TimeDiff(Now(),Time.TimeIn)
		, TimeDiff(Now(),Time.TimeOut)
	into TimeID, TimeDiff_In,TimeDiff_Out	
	From Time
		join Person on Time.Person_ID = Person.ID
	where Time.Person_ID = PersonID
		and (
					date(Now()) = date(Time.TimeIn)
					or 
					(date(Now()) = date(Time.TimeIn)+ 1 
						and Time.TimeOut is NULL)
			)
	order by Time.id desc
	Limit 1;

		
	if ((TimeDiff_In >= '00:05:00' and TimeDiff_Out is NULL) OR TimeDiff_Out >= '00:05:00' OR TimeID is NULL) Then
		
		If (TimeID is Not Null and TimeDiff_In <='17:00:00') Then
			Update Time
				Join Person on Time.Person_ID = Person.ID
			Set Time.TimeOut = Now()
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
				Select Person.ID, Now()
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