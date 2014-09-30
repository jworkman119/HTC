CREATE PROCEDURE addWorkerSchedule (IN strFirstName VARCHAR(35), IN strLastName VARCHAR(50), IN Day VARCHAR(10), IN intSupervisor VARCHAR(50), IN intJob VARCHAR(25), IN intShift VARCHAR(50), intHours int)
Begin
	Declare intWorker int;
	
	Select ID
	Into intWorker
	From Person 
	Where  concat(Person.FirstName, ' ', Person.LastName) = concat(strFirstName, ' ' , strLastName)
		and Person.Role_ID = 'jan';	
		
	-- Inserting into db
	If(intWorker > 0) Then
		Insert Into Schedule(Person_ID, Day,Shift_ID,Supervisor_ID,Job_ID,Hours)
		Values (intWorker,Date_Format(Day,'%Y-%m-%d'),intShift,intSupervisor,intJob,intHours);
	End If;
End