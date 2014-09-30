Drop Procedure addWorkerSchedule
Create Procedure addWorkerSchedule(strFirstName varchar(35), strLastName varchar(50), Day Date,intSupervisor varchar(50), intJob varchar(25), intShift varchar(50))
Begin
	Declare intWorker int;
	
	Select ID
	Into intWorker
	From Person 
	Where  concat(Person.FirstName, ' ', Person.LastName) = concat(strFirstName, ' ' , strLastName)
		and Person.Role_ID = 'jan';	
		
	-- Updating db
	If(intWorker > 0) Then
		Update Schedule
		Set Schedule.Person_ID = intWorker
			, Schedule.Day = Date
			, Schedule.Shift_ID = intShift
			, Schedule.Supervisor_ID = intSupervisor
			, Schedule.Job_ID = Job.ID
	End If;
End;



 